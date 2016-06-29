using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Emotiv
{    
    class EmotivServer
    {
        private bool isComposer;
        private TcpListener listener;
        private Thread listenerThread;
        private Socket mySocket;
        private bool listen;

        public float excitement;
        public float engagement;
        public float meditation;
        public float frustration;
        public float ltexcit;

        public EmotivServer()
        {
            
        }

        public EmotivServer(string IP, int port)
        {
            configure(IP, port);
        }

        public void configure(string IP, int port)
        {
            listener = new TcpListener(IPAddress.Parse(IP), port);            
        }

        public Thread getThread()
        {
            return listenerThread;
        }
        public void start()
        {
            listen = true;
            listener.Start();
            listenerThread = new Thread(new ThreadStart(serverListen));
            listenerThread.Start();
        }

        public void stop()
        {
            listen = false;        
            //setting listen to false, ends the loop in serverListen() and stops the listener
        }

        private void serverListen()
        {
            while (listen)
            {
                //Accept a new connection
                if (listener.Pending())
                {
                    mySocket = listener.AcceptSocket();
                    //Console.WriteLine ("Socket Type " + mySocket.SocketType ); 
                    if (mySocket.Connected)
                    {
                        //Console.WriteLine("\nClient Connected!!\n==================\nCLient IP {0}\n", mySocket.RemoteEndPoint) ;


                        //make a byte array and receive data from the client 
                        Byte[] bReceive = new Byte[1024];
                        int i = mySocket.Receive(bReceive, bReceive.Length, 0);


                        //Convert Byte to String
                        string sBuffer = Encoding.ASCII.GetString(bReceive);

                        //At present we will only deal with GET type
                        if (sBuffer.Substring(0, 3) != "GET")
                        {
                            //Console.WriteLine("Only Get Method is supported..");
                            mySocket.Close();
                            return;
                        }
                        int startAddress = 4;
                        int endAddress = sBuffer.IndexOf("HTTP");
                        string address = sBuffer.Substring(4, endAddress - startAddress);
                        //Console.WriteLine("Address: " + address);
                        int callbackindex = sBuffer.IndexOf("?jsoncallback=");                        
                        if (callbackindex != -1)
                        {
                            int endindex=sBuffer.IndexOf("&",callbackindex);
                            endindex = endindex == -1 ? sBuffer.IndexOf("HTTP",callbackindex) : endindex;                            
                            string callback = sBuffer.Substring(callbackindex+14,endindex - (callbackindex+15));
                            //string sErrorMessage = callback + "({\"symbol\" : \"IBM\", \"price\" : \"91.42\"});";
                            //string sErrorMessage = callback + "({\"excitement\" : \"" + excitement + "\", \"engagement\" : \"" + engagement + "\", \"meditation\" : \"" + meditation + "\", \"frustration\" : \"" + frustration+ "\"});";
                            string sErrorMessage = callback + "({\"excitement\" : \"" + excitement + "\", \"engagement\" : \"" + engagement + "\", \"meditation\" : \"" + meditation + "\", \"frustration\" : \"" + frustration + "\", \"ltexcitement\" : \"" + ltexcit + "\"});";
                            //Console.WriteLine("message: " + sErrorMessage);
                            SendHeader("HTTP/1.1", "", sErrorMessage.Length, " 200 OK", ref mySocket);
                            SendToBrowser(sErrorMessage, ref mySocket);
                        }
                        Console.WriteLine("socket closing");
                        mySocket.Close();
                        Console.WriteLine("socket closed");
                    }
                }
            }
            Console.WriteLine("stoppping");
            listener.Stop();       
        }
        private void SendToBrowser(String sData, ref Socket mySocket)
        {
            SendToBrowser(Encoding.ASCII.GetBytes(sData), ref mySocket);
        }
        private void SendToBrowser(Byte[] bSendData, ref Socket mySocket)
        {
            int numBytes = 0;
            try
            {
                if (mySocket.Connected)
                {
                    if ((numBytes = mySocket.Send(bSendData,
                          bSendData.Length, 0)) == -1)
                        Console.WriteLine("Socket Error cannot Send Packet");
                    else
                    {
                        Console.WriteLine("No. of bytes send {0}", numBytes);
                    }
                }
                else
                    Console.WriteLine("Connection Dropped....");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred : {0} ", e);
            }
        }
        private void SendHeader(string sHttpVersion, string sMIMEHeader, int iTotBytes, string sStatusCode, ref Socket mySocket)
        {

            String sBuffer = "";

            // if Mime type is not provided set default to text/html

            if (sMIMEHeader.Length == 0)
            {
                sMIMEHeader = "text/javascript";  // Default Mime Type is text/html

            }

            sBuffer = sBuffer + sHttpVersion + sStatusCode + "\r\n";
            sBuffer = sBuffer + "Server: cx1193719-b\r\n";
            sBuffer = sBuffer + "Content-Type: " + sMIMEHeader + "\r\n";
            sBuffer = sBuffer + "Accept-Ranges: bytes\r\n";
            sBuffer = sBuffer + "Content-Length: " + iTotBytes + "\r\n\r\n";

            Byte[] bSendData = Encoding.ASCII.GetBytes(sBuffer);

            SendToBrowser(bSendData, ref mySocket);

            Console.WriteLine("Total Bytes : " + iTotBytes.ToString());

        }
    }
}
