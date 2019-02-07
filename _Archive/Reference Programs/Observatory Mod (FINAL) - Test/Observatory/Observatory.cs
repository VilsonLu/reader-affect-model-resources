using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Emotiv;
//using GoogleChartSharp;
using WebChart;
using System.Threading;
using WMEncoderLib;
using DirectX.Capture;
using System.Diagnostics;

using Gma.UserActivityMonitor;


namespace Observatory
{
    public partial class Observatory : Form
    {
        private bool isDisposed;
        private ArrayList excitement;
        private ArrayList engagement;
        private ArrayList frustration;
        private ArrayList meditation;
        private ArrayList ltexcit;
        private int MAX_GRAPH_WIDTH = 100;
        private EmotivServer server;
        private bool showGraph = false;
        private Single longTermExcitementScore, shortTermExcitementScore, meditationScore, frustrationScore, boredomScore;
        private EmoEngine engine;
        Object emoLock = new Object();
        private Thread emotivThread;
        private volatile bool isRetrieving=false;
        private int userID = -1;
        private bool isemoComposer=true;
        private WMEncoderClass encoder;
        private Capture webcam;
        StreamWriter frequencyWriter;
        StreamWriter clicksWriter;

        //mouse behavior declarations
        int nTime = 0;
        int nTime2 = 0;
        int x, y, prevX = 0, prevY = 0;
        int moveFreq = 0;
        string clicksDestination = "Clicks.txt";
        string frequencyDestination = "Frequency.txt";
        string psrPath = @"%USERPROFILE%\Desktop\psr.zip";
        Process psr;

        //self-reportt declarations
        Main selfreport;
        
        public Observatory()
        {
            this.FormClosing+=new FormClosingEventHandler(EmotivDataManager_FormClosing);
            InitializeComponent();
            cbxSource.SelectedIndex=0;
            engine = EmoEngine.Instance;
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded_Event);
            engine.AffectivEmoStateUpdated += new EmoEngine.AffectivEmoStateUpdatedEventHandler(engine_AffectivEmoStateUpdated);
            cbEmotiv.Checked = true;
            server = new EmotivServer();
            initGraph();
            initScreenCap();
            initWebcamCap();
        }

        public void initGraph()
        {
            excitement = new ArrayList();
            engagement = new ArrayList();
            meditation = new ArrayList();
            frustration = new ArrayList();
            ltexcit = new ArrayList();
            for (int i = 0; i < MAX_GRAPH_WIDTH; i++)
            {
                excitement.Add((float)(0));
                engagement.Add((float)(0));
                meditation.Add((float)(0));
                frustration.Add((float)(0));
                ltexcit.Add((float)(0));
            }
        }
        private void initScreenCap()
        {
            encoder = new WMEncoderClass();
            IWMEncSourceGroup SrcGrp;
            IWMEncSourceGroupCollection SrcGrpColl;
            SrcGrpColl = encoder.SourceGroupCollection;
            SrcGrp = SrcGrpColl.Add("SourceGroup");
            IWMEncSource SrcVid = null;
            IWMEncSource SrcAud = null;
            SrcVid = SrcGrp.AddSource(WMENC_SOURCE_TYPE.WMENC_VIDEO);
            SrcVid.SetInput("ScreenCap://ScreenCapture1", "", "");
            SrcAud = SrcGrp.AddSource(WMENC_SOURCE_TYPE.WMENC_AUDIO);
            SrcAud.SetInput("Device://Default_Audio_Device", "", "");
            IWMEncDisplayInfo Descr;
            Descr = encoder.DisplayInfo;
            Descr.Author = "ActivityRecorder";
            Descr.Description = "Screen capture";
            IWMEncFile saveFile = encoder.File;
            saveFile.LocalFileName = "out-screen.wmv";
            IWMEncProfile m_profile = null;
            IWMEncProfileCollection ProColl = encoder.ProfileCollection;
            for (int i = 0; i < ProColl.Count; i++)
            {
                Console.WriteLine(ProColl.Item(i).Name+"\n");
                if (ProColl.Item(i).Name.Equals("Screen Video/Audio High (CBR)"))
                {
                    m_profile = ProColl.Item(i);
                }
            }
            if (m_profile != null)
            {
                SrcGrp.set_Profile(m_profile);
            }
        }
        private void initWebcamCap()
        {
            /*Filter videoDevice = new Filters().VideoInputDevices[0];
            Filter audioDevice = new Filters().AudioInputDevices[0];*/
            Filter videoDevice = new Filters().VideoInputDevices[Properties.Settings.Default.webCamIndex];
            Filter audioDevice = new Filters().AudioInputDevices[Properties.Settings.Default.audioIndex];
            webcam = new Capture(videoDevice, audioDevice, false);
            webcam.Filename = "out-webcam.wmv";
        }
        private void EmotivDataManager_Load(object sender, EventArgs e)
        {

            cbxSource.SelectedIndex = 1;
            //a.NewHeadsetRawDataEvent += new the0nex.EmotivPower.BaseData.d_HeadsetRawDataEvent(testing);            
        }

        private void initFile()
        {
            TextWriter csv = new StreamWriter("out.csv");
            csv.Write("Timestamp,Excel Timestamp, COUNTER,INTERPOLATED,RAW_CQ,AF3,F7,F3, FC5, T7, P7, O1, O2,P8" +
                            ", T8, FC6, F4,F8, AF4,GYROX, GYROY, TIMESTAMP, ES_TIMESTAMP" +
                            "FUNC_ID, FUNC_VALUE, MARKER, SYNC_SIGNAL, ?,longTermExcitementScore, shortTermExcitementScore, meditationScore, frustrationScore, boredomScore\n");
            //csv.Write("Timestamp, Excitement, Engagement, Frustration, Meditation, Long Term Excitement\n");
            csv.Close();         
        }
        void EmotivDataManager_FormClosing(object sender, EventArgs e)
        {            
            isDisposed = true;              
            if(isRetrieving)
                stop();
        }

        private Image getGraphiImage()
        {
            if (excitement.Count > MAX_GRAPH_WIDTH)
                excitement.RemoveAt(0);
            if (engagement.Count > MAX_GRAPH_WIDTH)
                engagement.RemoveAt(0);
            if (frustration.Count > MAX_GRAPH_WIDTH)
                frustration.RemoveAt(0);
            if (meditation.Count > MAX_GRAPH_WIDTH)
                meditation.RemoveAt(0);
            if (ltexcit.Count > MAX_GRAPH_WIDTH)
                ltexcit.RemoveAt(0);


            ChartEngine engine = new ChartEngine();
            Size s = new Size(pictGraph.Width, pictGraph.Height);
            engine.Size = s;
            ChartCollection charts = new ChartCollection(engine);
            engine.Charts = charts;

            ChartPointCollection data = new ChartPointCollection();
            Chart line = new LineChart(data, Color.Red);
            line.ShowLineMarkers = false;
            foreach (float pt in excitement)
            {
                data.Add(new ChartPoint("0", pt));
            }
            charts.Add(line);
            data = new ChartPointCollection();
            line = new LineChart(data, Color.Green);
            line.ShowLineMarkers = false;
            foreach (float pt in engagement)
                data.Add(new ChartPoint("0", pt));
            charts.Add(line);
            data = new ChartPointCollection();
            line = new LineChart(data, Color.Blue);
            line.ShowLineMarkers = false;
            foreach (float pt in meditation)
                data.Add(new ChartPoint("0", pt));
            charts.Add(line);
            data = new ChartPointCollection();
            line = new LineChart(data, Color.Black);
            line.ShowLineMarkers = false;
            foreach (float pt in frustration)
                data.Add(new ChartPoint("0", pt));
            charts.Add(line);
            data = new ChartPointCollection();
            line = new LineChart(data, Color.Yellow);
            line.ShowLineMarkers = false;
            foreach (float pt in ltexcit)
                data.Add(new ChartPoint("0", pt));
            charts.Add(line);
            engine.ChartPadding = 0;
            engine.Border.Color = Color.White;
            engine.GridLines = GridLines.None;
            return engine.GetBitmap();
        }
        void engine_UserAdded_Event(object sender, EmoEngineEventArgs e)
        {
            // record the user 
            userID = (int)e.userId;            
            // enable data aquisition for this user.
            engine.DataAcquisitionEnable((uint)userID, true);

            // ask for up to 1 second of buffered data
            engine.EE_DataSetBufferSizeInSec(1);
        }

        void engine_AffectivEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            lock(emoLock)
            {
                
                EmoState es = e.emoState;
                longTermExcitementScore = es.AffectivGetExcitementLongTermScore();
                shortTermExcitementScore = es.AffectivGetExcitementShortTermScore();
                meditationScore = es.AffectivGetMeditationScore();
                frustrationScore = es.AffectivGetFrustrationScore();
                boredomScore = es.AffectivGetEngagementBoredomScore();
            }
        }
        delegate void SetTextCallback(TextBox container, string text);
        void setText(TextBox container, string text)
        {
            container.Text = text;
        }
        void threadSafeEmotivValueSet(TextBox container,float value)
        {
            if (container.InvokeRequired)
            {                
                // It's on a different thread, so use Invoke.
                SetTextCallback d = new SetTextCallback(setText);
                container.BeginInvoke
                    (d, new object[] { container, value + "" });
            }
            else
            {
                // It's on the same thread, no need for Invoke
                container.Text = value + "";
            }
        }
        void updateEmotivData()
        {
            int delay = int.Parse(txtDelay.Text);
            while (isRetrieving)
            {
                engine.ProcessEvents();
                TextWriter csv = File.AppendText("out.csv");

                threadSafeEmotivValueSet(txtExcitement, shortTermExcitementScore);
                threadSafeEmotivValueSet(txtEngagement, boredomScore);
                threadSafeEmotivValueSet(txtFrustration, frustrationScore);
                threadSafeEmotivValueSet(txtMeditation, meditationScore);
                threadSafeEmotivValueSet(txtLTExcit, longTermExcitementScore);
                
                double stamp = (DateTime.Now.ToLocalTime() - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds;
                
                if (!isemoComposer)
                {
                    Dictionary<EdkDll.EE_DataChannel_t, double[]> data = engine.GetData((uint)userID);
                    if (data == null)
                    {
                        csv.Close();
                        continue;
                    }
                    
                    lock (emoLock)
                    {
                        int _bufferSize = data[EdkDll.EE_DataChannel_t.TIMESTAMP].Length;

                        // Write the data to a file
                        for (int i = 0; i < _bufferSize; i++)
                        {
                            //csv.Write(stamp + "," + (stamp / 1000 / 86400 + 25569) + ","); - ORIGINAL VERSION
                            csv.Write(stamp + "," + DateTime.Now.ToLongTimeString() + ",");
                            // now write the data
                            foreach (EdkDll.EE_DataChannel_t channel in data.Keys)
                            {   
                                csv.Write(data[channel][i] + ",");
                            }
                            csv.Write(longTermExcitementScore + "," + shortTermExcitementScore + "," + meditationScore + "," + frustrationScore + "," + boredomScore);
                            csv.WriteLine("");
                        }
                        //file.WriteLine("");
                    }
                }
                
                if(isemoComposer)
                {
                    csv.Write(stamp + "," + (stamp / 1000 / 86400 + 25569) + ",");
                    for (int i = 0; i < 25; i++)
                        csv.Write("?,");
                    csv.Write(longTermExcitementScore + "," + shortTermExcitementScore + "," + meditationScore + "," + frustrationScore + "," + boredomScore);
                    csv.WriteLine("");
                }
                csv.Close();

                server.excitement = shortTermExcitementScore * 100;
                server.engagement = boredomScore * 100;
                server.meditation = meditationScore * 100;
                server.frustration = frustrationScore * 100;
                server.ltexcit = longTermExcitementScore * 100;

                if (showGraph)
                {
                    excitement.Add(shortTermExcitementScore * 100);
                    engagement.Add(boredomScore * 100);
                    frustration.Add(frustrationScore * 100);
                    meditation.Add(meditationScore * 100);
                    ltexcit.Add(longTermExcitementScore * 100);
                    //pictGraph.ImageLocation = generateGraph();
                    pictGraph.Image = getGraphiImage();
                }
                else
                    pictGraph.Image = null;
                Thread.Sleep(delay);
            }
        }
        void a_NewAffectivEvent(the0nex.EmotivPower.BaseData.AffectivState.AffectivData Affective_Data)
        {
            if (!isDisposed)
                lock (this)
                {
                    {
                        try
                        {
                            this.Invoke((d)delegate()
                            {
                                try
                                {
                                    TextWriter csv = File.AppendText("out.csv");
                                    txtExcitement.Text = "" + Affective_Data.ExcitementShortTerm;
                                    txtEngagement.Text = "" + Affective_Data.EngagementBoredom;
                                    txtFrustration.Text = "" + Affective_Data.Frustration;
                                    txtMeditation.Text = "" + Affective_Data.Meditation;
                                    txtLTExcit.Text = "" + Affective_Data.ExcitementLongTerm;
                                    csv.Write(DateTime.Now + "," + Affective_Data.ExcitementShortTerm + "," + Affective_Data.EngagementBoredom + "," + Affective_Data.Frustration + "," + Affective_Data.Meditation + "," + Affective_Data.ExcitementLongTerm + "\n");
                                    csv.Close();

                                    server.excitement = Affective_Data.ExcitementShortTerm * 100;
                                    server.engagement = Affective_Data.EngagementBoredom * 100;
                                    server.meditation = Affective_Data.Meditation * 100;
                                    server.frustration=Affective_Data.Frustration * 100;
                                    server.ltexcit = Affective_Data.ExcitementLongTerm * 100;

                                    if (showGraph)
                                    {
                                        excitement.Add(Affective_Data.ExcitementShortTerm * 100);
                                        engagement.Add(Affective_Data.EngagementBoredom * 100);
                                        frustration.Add(Affective_Data.Frustration * 100);
                                        meditation.Add(Affective_Data.Meditation * 100);
                                        ltexcit.Add(Affective_Data.ExcitementLongTerm * 100);
                                        //pictGraph.ImageLocation = generateGraph();
                                        pictGraph.Image = getGraphiImage();
                                    }
                                    else
                                        pictGraph.Image = null;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.StackTrace);
                                    //System.Windows.Forms.MessageBox.Show("myEmotivPower_NewFacialEvent Error");
                                }
                            });
                        }
                        catch (Exception ox)
                        {
                            Console.WriteLine("Dont allow to continue");
                        }
                    }
                }
        }
        
        delegate void d();
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSource.SelectedIndex == 0)
            {
                lblIP.Visible = true;
                txtIP.Visible = true;
                lblPort.Visible = true;
                txtPort.Visible = true;
                btnStart.Visible = true;
                //btnStart.Left=498;
                lblDelay.Left = 404;
                txtDelay.Left = 460;
            }else{
                lblIP.Visible = false;
                txtIP.Visible = false;
                lblPort.Visible = false;
                txtPort.Visible = false;
                btnStart.Visible = true;
                //btnStart.Left = 274;
                lblDelay.Left=180;
                txtDelay.Left=236;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                if (cbEmotiv.Checked)
                {
                    bool error = false;
                    try
                    {
                        if (cbxSource.SelectedIndex == 0)
                        {
                            isemoComposer = true;
                            engine.RemoteConnect(txtIP.Text, ushort.Parse(txtPort.Text));
                        }
                        else
                        {
                            isemoComposer = false;
                            engine.Connect();
                        }
                    }
                    catch (Exception ex)
                    {
                        error = true;
                    }
                    if (!error)
                    {
                        gbDisplay.Enabled = true;                        
                        initGraph();
                        initFile();
                        txtDelay.Enabled = false;
                        cbxSource.Enabled = false;
                        txtIP.Enabled = false;
                        txtPort.Enabled = false;
                        txtSvrIP.Enabled = false;
                        txtSvrPort.Enabled = false;
                        cbServer.Enabled = false;
                        cbScreenCap.Enabled = false;
                        cbWebCamCap.Enabled = false;
                        //isDisposed = false;
                        //this.Disposed += new EventHandler(Form1_Disposed);
                        isRetrieving = true;
                        int temp;
                        if (!int.TryParse(txtDelay.Text, out temp))
                            txtDelay.Text = 500 + "";
                        emotivThread = new Thread(updateEmotivData);
                        emotivThread.Start();
                    }                   
                }
                if (cbServer.Checked)
                {
                    server.configure(txtSvrIP.Text, int.Parse(txtSvrPort.Text));
                    server.start();
                }
                if (cbWebCamCap.Checked)
                    webcam.Start();
                if (cbScreenCap.Checked)
                    encoder.Start();
                if (mouseBehavior.Checked)
                {
                    FileInfo fs = new FileInfo(frequencyDestination);
                    frequencyWriter = new StreamWriter(frequencyDestination);//File.AppendText(frequencyDestination);

                    HookManager.MouseMove += HookManager_Moved;
                    mouseBehavior.Enabled = false;


                    FileInfo fs1 = new FileInfo(clicksDestination);
                    clicksWriter = new StreamWriter(clicksDestination);//File.AppendText(clicksDestination);

                    HookManager.MouseUp += HookManager_MouseUp;
                    HookManager.MouseDown += HookManager_MouseDown;
                    selfReport.Enabled = false;
                }
                if (selfReport.Checked)
                {
                    selfreport = new Main();
                    selfreport.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, 0);
                    //selfReport.Location = new Point(Screen.PrimaryScreen.Bounds.Width - selfReport.Width, 0);
                    
                    //Thread t = new ThreadStart(selfreport.Activate);
                }
                if (PSRcheckbox.Checked)
                {
                    psr = new Process();
                    psr.EnableRaisingEvents = false;
                    psr.StartInfo.FileName = @"psr";
                    psr.StartInfo.Arguments = @"/start /output E:\psr.zip";
                    psr.Start();
                    PSRcheckbox.Enabled = false;
                }
                
                btnStart.Text = "Stop";
            }
            else
            {
                if (cbEmotiv.Checked)
                {
                    stop();
                    txtDelay.Enabled = true;
                    cbxSource.Enabled = true;
                    txtIP.Enabled = true;
                    txtPort.Enabled = true;
                    txtSvrIP.Enabled = true;
                    txtSvrPort.Enabled = true;
                    cbServer.Enabled = true;
                    cbScreenCap.Enabled = true;
                    cbWebCamCap.Enabled = true;
                }
                if (cbServer.Checked)
                    server.stop();
                if (cbWebCamCap.Checked)
                    webcam.Stop();
                if (cbScreenCap.Checked)
                    encoder.Stop();
                if (selfReport.Checked)
                {
                    selfreport.Close();
                }
                if (mouseBehavior.Checked)
                {
                    selfReport.Checked = true;
                    clicksWriter.Close();
                    HookManager.MouseUp -= HookManager_MouseUp;
                    HookManager.MouseUp -= HookManager_MouseDown;


                    mouseBehavior.Enabled = true;
                    frequencyWriter.Close();
                    HookManager.MouseMove += HookManager_Moved;
                }
                if (PSRcheckbox.Checked)
                {
                    Process p = new Process();
                    p.StartInfo.FileName = "psr";
                    p.StartInfo.Arguments = "/stop";
                    p.Start();
                    PSRcheckbox.Enabled = true;
                    //psr.StartInfo.FileName = "psr /stop";
                    //psr.Start();
                }
                if (MessageBox.Show("Save data?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    saveCSV.ShowDialog();
                
                btnStart.Text = "Start";

                
            }
        }

        private void stop()
        {
            if (cbEmotiv.Checked)
            {
                isRetrieving = false;
                userID = -1;
                gbDisplay.Enabled = false;
                pictGraph.Image = null;
                pictGraph.Refresh();
                txtExcitement.Text = "";
                txtEngagement.Text = "";
                txtMeditation.Text = "";
                txtFrustration.Text = "";
                txtLTExcit.Text = "";

                longTermExcitementScore = 0;
                shortTermExcitementScore = 0;
                meditationScore = 0;
                frustrationScore = 0;
                boredomScore = 0;



                cbGraph.Checked = false;
                server.stop();
                if (emotivThread != null && emotivThread.IsAlive)
                    emotivThread.Join();
                engine.Disconnect();

                
                
            }
        }

        private void saveCSV_FileOk(object sender, CancelEventArgs e)
        {
            Thread.Sleep(1000);
            if(cbEmotiv.Checked)
                File.Copy("out.csv", saveCSV.FileName,true);
            string name = saveCSV.FileName.Substring(0, saveCSV.FileName.LastIndexOf("."));
            if(cbScreenCap.Checked)
                File.Copy("out-screen.wmv", name + "-screen" + ".wmv");
            if(cbWebCamCap.Checked)
                File.Copy("out-webcam.wmv", name + "-webcam" + ".wmv");
            if (mouseBehavior.Checked)
            {
                File.Copy("Clicks.txt", name + "-clicks" + ".txt");
                File.Copy("Frequency.txt", name + "-movement" + ".txt");
            }
            if (selfReport.Checked)
                File.Copy("EmotionAnnotation.csv", name + "-annotation" + ".csv");
        }

        private void cbServer_CheckedChanged(object sender, EventArgs e)
        {
            toggleServer(cbServer.Checked);
        }
        private void toggleServer(bool value)
        {
            lblSvrIP.Visible = value;
            txtSvrIP.Visible = value;
            lblSvrPort.Visible = value;
            txtSvrPort.Visible = value;
            btnSvrLaunch.Visible = value;
        }

        private void btnSvrLaunch_Click(object sender, EventArgs e)
        {
            if (btnSvrLaunch.Text == "Start")
            {
                btnSvrLaunch.Text = "Stop";
                server.configure(txtSvrIP.Text, int.Parse(txtSvrPort.Text));
                server.start();
            }
            else
            {
                btnSvrLaunch.Text = "Start";
                server.stop();
            }
        }

        private void gbDisplay_Enter(object sender, EventArgs e)
        {

        }

        private void cbGraph_CheckedChanged(object sender, EventArgs e)
        {
            showGraph = cbGraph.Checked;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDisposed = true;
            if(isRetrieving)
                stop();
            Dispose();
        }

        private void saveUserProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveProfile.ShowDialog();            
        }

        private void EmotivDataManager_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
             notifyIcon.Visible = true;
             this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
             notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void cmEmotiv_CheckedChanged(object sender, EventArgs e)
        {
            gbSettings.Enabled = cbEmotiv.Checked;
            gbDisplay.Enabled = cbEmotiv.Checked;
            gbServer.Enabled = cbEmotiv.Checked;
        }

        //Mouse Frequency
        private void HookManager_Moved(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
            frequencyWriter.WriteLine("{0} {1}: {2}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), e.Location);
        }


        private void HookManager_MouseUp(object sender, MouseEventArgs e)
        {
            if (nTime != 0)
            {
                timer1.Stop();
                clicksWriter.WriteLine("Duration: {0} ms", nTime.ToString());
                nTime = 0;
            }
        }

        private void HookManager_MouseDown(object sender, MouseEventArgs e)
        {
            clicksWriter.WriteLine("{0} {1}: {2} Button ", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), e.Button);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nTime++;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            nTime2++;
        }

    }
}
