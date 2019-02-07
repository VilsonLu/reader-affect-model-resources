using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Preprocessing.Brainwaves;
using Preprocessing.Mouse;
using Preprocessing.Context;
using Preprocessing.Emotion;
using System.IO;

namespace Preprocessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //test();
            //trial();
            //aplusix();
            //testing();
            //codetests();
            //run();  //this!
            //window();
            //compute();
            //removeBrokenWindows();
            //getFiles();
            //extractEmotion();
        }

        public void extractEmotion()
        {
            //int[] emotionIndex = { };
            int confidence = 37;
            int excitement = 38;
            int frustration = 39;
            int interest = 40;
            int difficulty = 41;
            String _confidence = "";
            String _excitement = "";
            String _frustration = "";
            String _interest = "";
            String _difficulty = "";
            String root = @"B:\Test Subjects (new 5) (DELETED)\";//@"D:\A Files\THESIS\DATA\RAW\MERGED (FIXED) (DELETED)\";
            DirectoryInfo dir = new DirectoryInfo(root);
            IEnumerable<DirectoryInfo> folders = dir.EnumerateDirectories();
            
            foreach(DirectoryInfo di in folders)
            {
                DirectoryInfo dirFolder = new DirectoryInfo(di.FullName);
                IEnumerable<FileInfo> files = dirFolder.EnumerateFiles(); Console.WriteLine("Count: {0}", files.Count());
                StreamWriter write = new StreamWriter(root + di.Name + " emotion.csv"); Console.WriteLine(root + di.Name + " emotion.csv");
                for (int i = 0; i < files.Count(); i++ )
                {
                    //Console.WriteLine("READ: {0}", fi.FullName);
                    StreamReader read = new StreamReader(di.FullName+@"\"+i+".csv");
                    if (!read.EndOfStream)
                    {

                        String[] line = read.ReadLine().Split(',');

                        _confidence = line[confidence - 1];
                        _excitement = line[excitement - 1];
                        _frustration = line[frustration - 1];
                        _interest = line[interest - 1];
                        _difficulty = line[difficulty - 1];
                        write.WriteLine("{0},{1},{2},{3},{4}", _confidence, _excitement, _frustration, _interest, _difficulty);
                    }
                    read.Close();
                }
                write.Close();
            }
            
        }

        public void getFiles()
        {
            String root = @"C:\Octave\3.2.4_gcc-4.4.0\include\octave-3.2.4\octave\";
            DirectoryInfo dir = new DirectoryInfo(root);
            IEnumerable<FileInfo> files = dir.EnumerateFiles();
            FileInfo[] ls = files.ToArray();
            Console.WriteLine(ls.Length);
            foreach(FileInfo fi in ls)
            {
                Console.WriteLine("#include \"{0}\"", fi.Name);
            }
        }

        public void window()
        {
            /*
            String root = @"A:\THESIS\DATA\RAW\";
            String filename;
            String currentStudent;
            String destination;
            Console.WriteLine("window");
            Windowing wEven = new Windowing(@"A:\thesis\DATA\RAW\Carlo\EEG, mouse behavior, context, emotion.csv", @"A:\thesis\DATA\RAW\Carlo\Windowed", 2, true);
            Windowing wOdd = new Windowing(@"A:\thesis\DATA\RAW\Carlo\EEG, mouse behavior, context, emotion.csv", @"A:\thesis\DATA\RAW\Carlo\Windowed", 2, false);
        
             */
            String dir = @"A:\THESIS\DATA\RAW MERGED\";

            DirectoryInfo di = new DirectoryInfo(dir);
            IEnumerable<FileInfo> files = di.EnumerateFiles("*.csv"); files.ElementAt(1);
            FileInfo[] ls = files.ToArray(); Console.WriteLine(ls.Length);
            for (int i = 0; i < ls.Length; i++)
            {
                String newName = ls[i].Name.Split(')')[0];
                newName = newName.Substring(1);
                string newPath = System.IO.Path.Combine(dir, newName);
                System.IO.Directory.CreateDirectory(newPath);
                Window wOdd = new Window(ls[i].FullName, dir+newName+@"\", 2, 5, true);
                Window wEven = new Window(ls[i].FullName, dir+newName+@"\", 2, 5, false);
            }
        }

        public void run()
        {
            String root = @"B:\Test Subjects (new 5)\";
            //String contextroot = @"A:\THESIS\DATA\Context Processed\";
            DirectoryInfo di = new DirectoryInfo(root);
            DirectoryInfo[] dia = di.GetDirectories();
            List<String> directorylist = new List<String>();
            //List<String> nameOnly = new List<String>();
            foreach (DirectoryInfo d in dia)
            {
                //Console.WriteLine(d.ToString());
                directorylist.Add(root+d.ToString()+@"\");
                //nameOnly.Add(d.ToString());
            }
            String eeg = "its.csv";
            String click = "Clicks.txt";
            String frequency = "Frequency.txt";
            String emotion = "self-report.csv";
            String context = "Context.csv";

            foreach (String s in directorylist)
            {
                //MergeClick mc = new MergeClick(s + eeg, s + click, s + "PROCESSED.csv");
                //Movement m = new Movement(s + frequency, s + "Frequency output.csv");
                //MergeMovement mm = new MergeMovement(s + "PROCESSED.csv", s + "Frequency output.csv", s + "EEG, mouse behavior.csv");
                //ContextMerge cm = new ContextMerge(s + "EEG, mouse behavior.csv", s + context, s + "EEG, mouse behavior, context.csv");
                //EmotionMerge em = new EmotionMerge(s + "EEG, mouse behavior, context.csv", s + emotion, s + "EEG, mouse behavior, context, emotion.csv");
                String name = s+@"\window\";
                if(!Directory.Exists(name))
                {
                    Directory.CreateDirectory(name);
                }
                doWindow dw = new doWindow(s+@"EEG, mouse behavior, context, emotion.csv",name,1,2) ;
            }

            /*
             * Merge click with eeg
             * 
            foreach (String s in directorylist)
            {
                MergeClick mc = new MergeClick(s + eeg, s + click, s + "PROCESSED.csv");
            }
             * 
             * */


            /*
             * Frequency extract features
             * 
            foreach (String s in directorylist)
            {
                Movement m = new Movement(s + frequency, s + "Frequency output.csv");

            }
             * 
             * */

            /*
             * Merge frequency w/ eeg
             * 
            foreach (String s in directorylist)
            {
                MergeMovement mm = new MergeMovement(s + "PROCESSED.csv", s + "Frequency output.csv", s + "EEG, mouse behavior.csv");
            }
             * 
             * */

            /*
             * Merge context with eeg
             * 
            for (int i = 10; i < directorylist.Count; i++)
            {
                Console.WriteLine("CURRENT: {0}", nameOnly[i]);
                ContextMerge cm = new ContextMerge(directorylist[i] + "EEG, mouse behavior.csv", contextroot + nameOnly[i] + "-Context.csv", directorylist[i] + "EEG, mouse behavior, context.csv");
            }
             * 
             * */

            /*
            int i = 0;
            foreach (String s in directorylist)
            {
                Console.WriteLine("CURRENT: {0}", nameOnly[i]);
                EmotionMerge em = new EmotionMerge(s + "EEG, mouse behavior, context.csv", s + emotion, s + "EEG, mouse behavior, context, emotion.csv");
                i++;
            }
             * */
                //String mroot = @"A:\THESIS\DATA\RAW\Edliz\";
                //EmotionMerge em = new EmotionMerge(mroot + "EEG, mouse behavior, context.csv", mroot + emotion, mroot + "EEG, mouse behavior, context, emotion.csv");


            /*
            for (int i = 0; i < directorylist.Count; i++)
            {
                if (!nameOnly[i].Equals("Edliz") || !nameOnly[i].Equals("Jolleen"))
                {
                    Console.WriteLine("CURRENT: {0}", nameOnly[i]);
                    String rootdir = @"A:\THESIS\DATA\";
                    String namedir = rootdir + nameOnly[i];
                    DirectoryInfo dir = new DirectoryInfo(namedir);
                    //DirectoryInfo tempdir = new DirectoryInfo(namedir);
                    if (!dir.Exists)
                    {
                        dir.CreateSubdirectory(nameOnly[i]);
                    }
                    Window even = new Window(directorylist[i] + "EEG, mouse behavior, context, emotion.csv", namedir + "\\", 2, 5, false);
                    Window odd = new Window(directorylist[i] + "EEG, mouse behavior, context, emotion.csv", namedir + "\\", 2, 6, true);
                }
            }*/
            //Window even = new Window(@"A:\thesis\DATA\RAW\Aldwin\EEG, mouse behavior, context, emotion.csv", @"A:\thesis\DATA\RAW\Aldwin\TEST.csv", 2, 5, false);//(directorylist[i] + "EEG, mouse behavior, context, emotion.csv", namedir + "\\", 2, 5, false);
            //Window odd = new Window(@"A:\thesis\DATA\RAW\Aldwin\EEG, mouse behavior, context, emotion.csv", @"A:\thesis\DATA\RAW\Aldwin\TEST.csv", 2, 6, true);


        }


        public void testing()
        {
            String path = @"A:\THESIS\Student Data\Aldwin\";
            //Emotion.EmotionMergeEEGRemove cm = new Emotion.EmotionMergeEEGRemove(path + "its.csv", path + "self-report.csv", path + "contextmerge.csv");
            //ContextMerge cm = new ContextMerge(path + "its.csv", path + "context.csv", path + "merged with context.csv");
            //EmotionMerge em = new EmotionMerge(path + "merged with context.csv", path + "self-report.csv", path + "merged with context and emotion.csv");
            //Window w = new Window(path + "its.csv", path+@"\windowed\", 2, 5); //for second pass, increase the remove by 1
            MergeClick mc = new MergeClick(path + "its.csv", path + "Clicks.txt", path + "merged with clicks.csv");
        }
    
        public void test()
        {
            String emotiv = @"A:\CA20\ca20 - its.csv";
            String emotion = @"A:\CA20\manual emotion.csv";
            String destination = @"A:\CA20\output.csv";

            //EmotionAnnotation ea = new EmotionAnnotation(emotion, emotiv, destination);

            //String movement = @"A:\THESIS\Test Subjects\CA26\Test.txt";//@"A:\THESIS\Test Subjects\CA26\Frequency.txt";//@"A:\freq.txt";
            String[] movement = {   @"A:\THESIS\Student Data\CA20\ca20 - Frequency.txt",
                                    @"A:\THESIS\Student Data\CA24\Frequency.txt",
                                    @"A:\THESIS\Student Data\CA25\Frequency.txt",
                                    @"A:\THESIS\Student Data\CA26\Frequency.txt",
                                    @"A:\THESIS\Student Data\CA27\Frequency.txt",
                                };
            //String processedmovement = @"A:\THESIS\Test Subjects\CA26\Test-try.txt";//@"A:\THESIS\Test Subjects\CA26\Frequency - processed.txt";//@"A:\freq-test.txt";
            /*foreach (String s in movement)
            {
                Movement m = new Movement(s, s+" (PROCESSED).csv");
            }*/

            String context = @"A:\CA20\ca20 - manual annotation (context).csv";
            
            String processedcontex = @"A:\CA20\ test.csv";
            //ContextAnnotation ca = new ContextAnnotation(context, emotiv, processedcontex);

            String mouseandcontext = @"C:\Users\User\Documents\My Dropbox\THESIS\Data\processed CA25\ca25 - mouse and context processed.csv";
            String frequency = @"C:\Users\User\Documents\My Dropbox\THESIS\Data\processed CA25\CA25 Frequency - processed.csv";
            String dest = @"C:\Users\User\Documents\My Dropbox\THESIS\Data\processed CA25\new.csv";
            //TemporaryMerger tm = new TemporaryMerger(mouseandcontext, frequency, dest);


            //START AVERAGING PROCESS HERE!
            String eegAverage = @"A:\THESIS\Student Data\CA20\CA20 - its.csv";
            String eegDestination = eegAverage + "Averaged (1).csv";//@"A:\THESIS\Student Data\CA26\test-try.csv";
            //EEGAve e = new EEGAve(eegAverage, eegDestination);

            String contextAnnotation = @"A:\THESIS\Student Data\CA20\CA20 (Context Annotation).csv";
            String averagedEEG = eegDestination;
            String eegWithContext = contextAnnotation+" WITH CONTEXT (2).csv";
            //ContextAnnotationMOD camod = new ContextAnnotationMOD(contextAnnotation, averagedEEG, eegWithContext);

            String eeg1sec = @"A:\THESIS\Student Data\Preprocessed PREFINAL\CA26 - baseline-average.csv";
            String context5sec = @"A:\THESIS\Student Data\Preprocessed PREFINAL\CA26 (Context Annotation).csv";
            String output = eeg1sec+" WITH CONTEXT (2).csv";
            ContextAnnotationMOD camod = new ContextAnnotationMOD(context5sec, eeg1sec, output);

            String emotionAnnotation = @"";
            String eegWithEmotion = emotionAnnotation + " WITH EMOTION.csv";
            //EmotionAnnotationMOD ea = new EmotionAnnotationMOD(emotionAnnotation, averagedEEG, eegWithEmotion);

            String persecond = output;//@"A:\THESIS\Student Data\CA27\CA27 (Context Annotation).csv WITH CONTEXT.csv";
            String per5second = persecond+" 5sec.csv";//@"A:\THESIS\Student Data\CA27\CA27 (Context Annotation) 5 second.csv WITH CONTEXT.csv";
            //FiveSecondAverage fsa = new FiveSecondAverage(persecond, per5second, 5);
        }

        public void removeBrokenWindows()
        {
            String root = @"B:\Test Subjects (new 5)\";//@"A:\THESIS\DATA\RAW\MERGED (FIXED)\";
            String newRoot = @"B:\Test Subjects (new 5) (DELETED)\";//@"A:\THESIS\DATA\RAW\MERGED (FIXED) (DELETED)\";
            DirectoryInfo di = new DirectoryInfo(root);
            DirectoryInfo[] dia = di.GetDirectories();

            //DELETE FILES WITH LESS THAN 60KB SIZE
            foreach (DirectoryInfo d in dia)
            {
                DirectoryInfo newd = new DirectoryInfo(d.FullName+@"\window\");
                Console.WriteLine(d.FullName);
                
                IEnumerable<FileInfo> ie = newd.EnumerateFiles();
                Console.WriteLine("Original Count: {0}", ie.Count());
                foreach (FileInfo fi in ie)
                {
                    if (fi.Length <= 60000)
                    {
                        //Directory.Delete(fi.FullName);
                        System.IO.File.Delete(fi.FullName);
                        Console.WriteLine("DELETE: {0}", fi.FullName);
                    }
                }
            }
            
            DirectoryInfo newDi = new DirectoryInfo(root);
            DirectoryInfo[] newDia = newDi.GetDirectories();

            foreach (DirectoryInfo d in newDia)
            {
                DirectoryInfo newd = new DirectoryInfo(d.FullName + @"\window\");
                IEnumerable<FileInfo> ie = newd.EnumerateFiles();
                Console.WriteLine("New count: {0}", ie.Count());
                String newDirectory = newRoot + d.Name + @"\";
                if (!Directory.Exists(newDirectory))
                {
                    //Console.WriteLine("Create Folder: {0}", newDirectory);
                    Directory.CreateDirectory(newDirectory);
                }
                int i = 0;
                foreach(FileInfo f in ie)
                {
                    System.IO.File.Move(f.FullName, newDirectory + i + ".csv");
                    i++;
                }
            }
        }
        public void compute()
        {
            /*
            String windowFolder = @"\windowed\";
            String root = @"A:\thesis\DATA\RAW\";
            String targetFile = @"\EEG, mouse behavior, context, emotion.csv";
            String name;

            DirectoryInfo di = new DirectoryInfo(root);
            DirectoryInfo[] dia = di.GetDirectories();
            List<String> directorylist = new List<String>();
            List<String> nameOnly = new List<String>();
            foreach (DirectoryInfo d in dia)
            {
                Console.WriteLine(d.FullName + targetFile);
                Console.WriteLine(root + @"MERGED (FIXED)\" + d.ToString() + @"\");
                Directory.CreateDirectory(root + @"\MERGED (FIXED)\" + d.ToString());
                doWindow dw = new doWindow(d.FullName + targetFile, root + @"\MERGED (FIXED)\" + d.ToString() + @"\", 1, 2);
                //directorylist.Add(root + d.ToString() + @"\");
                //nameOnly.Add(d.ToString());
            }
            */

            String file = @"A:\thesis\DATA\RAW\Jolleen\EEG, mouse behavior, context, emotion.csv";
            String destination = @"A:\thesis\DATA\RAW\Carlo\window\";
            Windowing w = new Windowing(file,destination,2,true);

            //doWindow dw = new doWindow(file, destination, 5, 2);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MouseClickDialog.Title = "Browse Mouse click log";
            EEGLogClickDialog.Title = "Browse EEG log";
            EEGClickSave.Title = "Save As";
        }

        private void MouseClickButton_Click(object sender, EventArgs e)
        {
            MouseClickDialog.ShowDialog();
        }

        private void MouseClickDialog_FileOk(object sender, CancelEventArgs e)
        {
            MouseClickTextBox.Text = MouseClickDialog.FileName;
        }

        private void EEGLogClickDialog_FileOk(object sender, CancelEventArgs e)
        {
            EEGLogClickTextBox.Text = EEGLogClickDialog.FileName;
        }

        private void EEGLogClickButton_Click(object sender, EventArgs e)
        {
            EEGLogClickDialog.ShowDialog();
        }

        private void EEGClickSaveButton_Click(object sender, EventArgs e)
        {
            EEGClickSave.ShowDialog();
        }

        private void EEGClickSave_FileOk(object sender, CancelEventArgs e)
        {
            EEGClickOutputTextBox.Text = EEGClickSave.FileName;
        }

        private void MovementRAWButton_Click(object sender, EventArgs e)
        {
            MovementRAWDialog.ShowDialog();
        }

        private void MovementOuputButton_Click(object sender, EventArgs e)
        {
            MovementOutputDialog.ShowDialog();
        }

        private void MovementRAWDialog_FileOk(object sender, CancelEventArgs e)
        {
            MovementRAWTextBox.Text = MovementRAWDialog.FileName;
        }

        private void MovementOutputDialog_FileOk(object sender, CancelEventArgs e)
        {
            MovementOutputTextBox.Text = MovementOutputDialog.FileName;
        }

        private void ProcessedMovementButton_Click(object sender, EventArgs e)
        {
            ProcessedMovementDialog.ShowDialog();
        }

        private void MergeMovementEEGLogButton_Click(object sender, EventArgs e)
        {
            EEGLogMovementDialog.ShowDialog();
        }

        private void MergeMovementOuputButton_Click(object sender, EventArgs e)
        {
            MergeMovementOutputDialog.ShowDialog();
        }

        private void ProcessedMovementDialog_FileOk(object sender, CancelEventArgs e)
        {
            ProcessedMovementTextBox.Text = ProcessedMovementDialog.FileName;
        }

        private void EEGLogMovementDialog_FileOk(object sender, CancelEventArgs e)
        {
            MergeMovementEEGLogTextBox.Text = EEGLogMovementDialog.FileName;
        }

        private void MergeMovementOutputDialog_FileOk(object sender, CancelEventArgs e)
        {
            MergeMovementOutputTextBox.Text = MergeMovementOutputDialog.FileName;
        }

        private void DistilledContextButton_Click(object sender, EventArgs e)
        {
            DistilledContextDialog.ShowDialog();
        }

        private void EEGLogMergeContextButton_Click(object sender, EventArgs e)
        {
            EEGLogMergeContexDialog.ShowDialog();
        }

        private void MergeContextOutputButton_Click(object sender, EventArgs e)
        {
            MergeContextOuputDialog.ShowDialog();
        }

        private void DistilledContextDialog_FileOk(object sender, CancelEventArgs e)
        {
            DistilledContextTextBox.Text = DistilledContextDialog.FileName;
        }

        private void EEGLogMergeContexDialog_FileOk(object sender, CancelEventArgs e)
        {
            EEGLogMergeContextTextBox.Text = EEGLogMergeContexDialog.FileName;
        }

        private void EmotionDialog_FileOk(object sender, CancelEventArgs e)
        {
            EmotionTextBox.Text = EmotionDialog.FileName;
        }

        private void EmotionButton_Click(object sender, EventArgs e)
        {
            EmotionDialog.ShowDialog();
        }

        private void EEGLogEmotionDialog_FileOk(object sender, CancelEventArgs e)
        {
            EEGLogEmotionTextBox.Text = EEGLogEmotionDialog.FileName;
        }

        private void EEGLogEmotionButton_Click(object sender, EventArgs e)
        {
            EEGLogEmotionDialog.ShowDialog();
        }

        private void OutputEmotionMergeDialog_FileOk(object sender, CancelEventArgs e)
        {
            OutputEmotionMergeTextBox.Text = OutputEmotionMergeDialog.FileName;
        }

        private void OutputEmotionMergeButton_Click(object sender, EventArgs e)
        {
            OutputEmotionMergeDialog.ShowDialog();
        }

        private void MergeContextOuputDialog_FileOk(object sender, CancelEventArgs e)
        {
            OutputMergeContextTextBox.Text = MergeContextOuputDialog.FileName;
        }

        private void ProcessMovementButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(MovementRAWTextBox.Text))
            {
                Movement m = new Movement(MovementRAWTextBox.Text, MovementOutputTextBox.Text);
            }

        }

        private void EEGClickOK_Click(object sender, EventArgs e) 
        {
            if (File.Exists(MouseClickTextBox.Text) && File.Exists(EEGLogClickTextBox.Text))
            {
                
                MergeClick mc = new MergeClick(EEGLogClickTextBox.Text, MouseClickTextBox.Text, EEGClickOutputTextBox.Text);
            }
            else
            {
                //error!
            }
        }

        private void MergeMovementButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(ProcessedMovementTextBox.Text) && File.Exists(MergeMovementEEGLogTextBox.Text))
            {
                MergeMovement mm = new MergeMovement(MergeMovementEEGLogTextBox.Text, ProcessedMovementTextBox.Text, MergeMovementOutputTextBox.Text);
            }
        }

        private void MergeContextButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(DistilledContextTextBox.Text) && File.Exists(EEGLogMergeContextTextBox.Text))
            {
                ContextMerge cm = new ContextMerge(EEGLogMergeContextTextBox.Text, DistilledContextTextBox.Text, OutputMergeContextTextBox.Text);
            }
        }

        private void EmotionMergeButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(EmotionTextBox.Text) && File.Exists(EEGLogEmotionTextBox.Text))
            {
                EmotionMerge em = new EmotionMerge(EEGLogEmotionTextBox.Text, EmotionTextBox.Text, OutputEmotionMergeTextBox.Text);
            }
            else
                throw (new FileNotFoundException());
        }

        private void LogFileWindowButton_Click(object sender, EventArgs e)
        {
            LogFileWindowDialog.ShowDialog();
        }

        private void OutputDirectoryWindowButton_Click(object sender, EventArgs e)
        {
            DialogResult res = OutputDirectoryWindowDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                OutputDirectoryWindowTextBox.Text = OutputDirectoryWindowDialog.SelectedPath+@"\";
            }
        }

        private void OutputDirectoryWindowDialog_HelpRequest(object sender, EventArgs e)
        {
            OutputDirectoryWindowTextBox.Text = OutputDirectoryWindowDialog.SelectedPath;
        }

        private void LogFileWindowDialog_FileOk(object sender, CancelEventArgs e)
        {
            LogFileWindowTextBox.Text = LogFileWindowDialog.FileName;
        }

        private void WindowButton_Click(object sender, EventArgs e)
        {
            doWindow dw = new doWindow(LogFileWindowTextBox.Text, OutputDirectoryWindowTextBox.Text, 1, 2);
        }

    }
}
