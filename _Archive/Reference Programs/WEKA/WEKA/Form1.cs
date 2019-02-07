using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using weka.core.converters;

namespace WEKA
{
    public partial class Form1 : Form
    {
        private weka.classifiers.trees.J48 c45 = new weka.classifiers.trees.J48();
        private weka.classifiers.lazy.IBk knn = new weka.classifiers.lazy.IBk();
        private weka.classifiers.functions.MultilayerPerceptron mlp = new weka.classifiers.functions.MultilayerPerceptron();

        private String _confidenceSource;
        private String _excitementSource;
        private String _frustrationSource;
        private String _interestSource;
        private int _knnK = 1;

        private StreamWriter write;
        public Form1()
        {
            InitializeComponent();
            //buildSpecific();
            //batchProcess(@"C:\Users\John Boy\Desktop\DATA SET (NORMALIZED)\GAMMA\No Mouse");
        }

        public bool loadINI()
        {
            try
            {
                StreamReader readINI = new StreamReader("load.ini");
                while (!readINI.EndOfStream)
                {
                    String line = readINI.ReadLine().Trim();   
                    if (String.IsNullOrEmpty(line))
                    {
                        String[] temp = line.Split(']');
                        if (temp.Length == 2)
                        {
                            if (temp[0].ToLower().EndsWith("confidence"))
                                _confidenceSource = temp[1];
                            else if (temp[0].ToLower().EndsWith("excitement"))
                                _excitementSource = temp[1];
                            else if (temp[0].ToLower().EndsWith("frustration"))
                                _frustrationSource = temp[1];
                            else if (temp[0].ToLower().EndsWith("interest"))
                                _interestSource = temp[1];
                            else if(temp[0].ToLower().EndsWith("k"))
                                Int32.TryParse(temp[1].Trim(), out _knnK);                                   
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }  
        }

        /// <summary>
        /// Used for batch processing
        /// </summary>
        /// <remarks>
        /// Must have Train set and Test set (pairings) in filename:
        /// Example: Train Set (C-RATING), Test Set (C-RATING)
        /// </remarks>
        /// <param name="contents"></param>
        /// <param name="output"></param>
        /// <param name="KNN"></param>
        /// <param name="J48"></param>
        /// <param name="MLP"></param>
        public void batchProcess(String contents, String output, bool KNN, bool J48, bool MLP)
        {
            //String contents = @"";
            DirectoryInfo dir = new DirectoryInfo(contents);
            IEnumerable<FileInfo> files = dir.EnumerateFiles();


            TrainTest c = new TrainTest("C-RATING");
            TrainTest e = new TrainTest("E-RATING");
            TrainTest f = new TrainTest("F-RATING");
            TrainTest i = new TrainTest("I-RATING");
            TrainTest[] traintestfull = { c, e, f, i };

            foreach (FileInfo fi in files)
            {
                if (fi.Name.Contains("C-Rating"))
                {
                    if (fi.Name.Contains("Train Set"))
                        c.Train = fi.FullName;
                    else if (fi.Name.Contains("Test Set"))
                        c.Test = fi.FullName;
                    
                }
                else if (fi.Name.Contains("E-Rating"))
                {
                    if (fi.Name.Contains("Train Set"))
                        e.Train = fi.FullName;
                    else if (fi.Name.Contains("Test Set"))
                        e.Test = fi.FullName;
                }
                else if (fi.Name.Contains("F-Rating"))
                {
                    if (fi.Name.Contains("Train Set"))
                        f.Train = fi.FullName;
                    else if (fi.Name.Contains("Test Set"))
                        f.Test = fi.FullName;
                }
                else if (fi.Name.Contains("I-Rating"))
                {
                    if (fi.Name.Contains("Train Set"))
                        i.Train = fi.FullName;
                    else if (fi.Name.Contains("Test Set"))
                        i.Test = fi.FullName;
                }
            }

            write = new StreamWriter(output);
            write.AutoFlush = true;
            foreach (TrainTest tt in traintestfull)
            {
                ConverterUtils.DataSource train = new ConverterUtils.DataSource(tt.Train);
                ConverterUtils.DataSource test = new ConverterUtils.DataSource(tt.Test);

                //J48
                if (J48)
                {
                    PercentageSplit j48 = new PercentageSplit(new weka.classifiers.trees.J48(), train.getDataSet(), test.getDataSet(), tt.Class);
                    write.WriteLine("J48: {0}", tt.Train);
                    writeStrings(j48.evaluate());
                    write.WriteLine("\n\n");
                    write.Flush();
                    Console.WriteLine("FINISHED {0}", tt.Train);
                }

                if (MLP)
                {
                    PercentageSplit mlp = new PercentageSplit(new weka.classifiers.functions.MultilayerPerceptron(), train.getDataSet(), test.getDataSet(), tt.Class);
                    write.WriteLine("MLP: {0}", tt.Train);
                    writeStrings(mlp.evaluate());
                    write.WriteLine("\n\n");
                    write.Flush();
                    Console.WriteLine("FINISHED {0}", tt.Train);
                }
                
                //KNN k = 5,10,15,20
                if (KNN)
                {
                    for (int k = 5; k != 25; k += 5)
                    {
                        PercentageSplit knn = new PercentageSplit(new weka.classifiers.lazy.IBk(k), train.getDataSet(), test.getDataSet(), tt.Class);
                        write.WriteLine("\n\n{0}\t k = {1}", tt.Train, k);
                        writeStrings(knn.evaluate());
                        write.Flush();
                        Console.WriteLine("FINISHED {0}", tt.Train);

                    }
                }
                
            
            }
            write.Flush();
            write.Close();
        }

        public void buildSpecific()
        {
            //FFT
            String cTrainFFT = @"B:\DATA SET\Train Set (20) (FFT) (MOUSE) (C-Rating).arff";
            String eTrainFFT = @"B:\DATA SET\Train Set (20) (FFT) (MOUSE) (E-Rating).arff";
            String fTrainFFT = @"B:\DATA SET\Train Set (20) (FFT) (MOUSE) (F-Rating).arff";
            String iTrainFFT = @"B:\DATA SET\Train Set (20) (FFT) (MOUSE) (I-Rating).arff";

            String cTestFFT = @"B:\DATA SET\Test Set (5) (FFT) (MOUSE) (C-Rating).arff";
            String eTestFFT = @"B:\DATA SET\Test Set (5) (FFT) (MOUSE) (E-Rating).arff";
            String fTestFFT = @"B:\DATA SET\Test Set (5) (FFT) (MOUSE) (F-Rating).arff";
            String iTestFFT = @"B:\DATA SET\Test Set (5) (FFT) (MOUSE) (I-Rating).arff";

            String[] TrainFFT = { cTrainFFT, eTrainFFT, fTrainFFT, iTrainFFT };
            String[] TestFFT = { cTestFFT, eTestFFT, fTestFFT, iTestFFT};

            //Statistical
            String cTrainSTAT = @"B:\DATA SET\Train Set (20) (STAT) (MOUSE) (C-Rating).arff";
            String eTrainSTAT = @"B:\DATA SET\Train Set (20) (STAT) (MOUSE) (E-Rating).arff";
            String fTrainSTAT = @"B:\DATA SET\Train Set (20) (STAT) (MOUSE) (F-Rating).arff";
            String iTrainSTAT = @"B:\DATA SET\Train Set (20) (STAT) (MOUSE) (I-Rating).arff";

            String cTestSTAT = @"B:\DATA SET\Test Set (5) (STAT) (MOUSE) (C-Rating).arff";
            String eTestSTAT = @"B:\DATA SET\Test Set (5) (STAT) (MOUSE) (E-Rating).arff";
            String fTestSTAT = @"B:\DATA SET\Test Set (5) (STAT) (MOUSE) (F-Rating).arff";
            String iTestSTAT = @"B:\DATA SET\Test Set (5) (STAT) (MOUSE) (I-Rating).arff";

            String[] TrainSTAT = { cTrainSTAT, eTrainSTAT, fTrainSTAT, iTrainSTAT};
            String[] TestSTAT = { cTestSTAT, eTestSTAT, fTestSTAT, iTestSTAT};

            //Mouse
            String mcTrainSTAT = @"B:\DATA SET\Train Set (20) (MOUSE) (C-Rating).arff";
            String meTrainSTAT = @"B:\DATA SET\Train Set (20) (MOUSE) (E-Rating).arff";
            String mfTrainSTAT = @"B:\DATA SET\Train Set (20) (MOUSE) (F-Rating).arff";
            String miTrainSTAT = @"B:\DATA SET\Train Set (20) (MOUSE) (I-Rating).arff";

            String mcTestSTAT = @"B:\DATA SET\Test Set (5) (MOUSE) (C-Rating).arff";
            String meTestSTAT = @"B:\DATA SET\Test Set (5) (MOUSE) (E-Rating).arff";
            String mfTestSTAT = @"B:\DATA SET\Test Set (5) (MOUSE) (F-Rating).arff";
            String miTestSTAT = @"B:\DATA SET\Test Set (5) (MOUSE) (I-Rating).arff";

            String[] mTrainSTAT = { mcTrainSTAT, meTrainSTAT, mfTrainSTAT, miTrainSTAT};
            String[] mTestSTAT = { mcTestSTAT, meTestSTAT, mfTestSTAT, miTestSTAT};

            String[] labels = {"C-RATING", "E-RATING", "F-RATING", "I-RATING"};

            List<String[]> allTrain = new List<String[]>();
            List<String[]> allTest = new List<String[]>();
            allTrain.Add(TrainFFT); allTrain.Add(TrainSTAT); allTrain.Add(mTrainSTAT);
            allTest.Add(TestFFT); allTest.Add(TestSTAT); allTest.Add(mTestSTAT);
            write = new StreamWriter("results.txt");

            
            write.AutoFlush = true;
            for (int a = 2; a < allTrain.Count; a++ )
            {
                //KNN k = 5,10,15,20
                for (int k = 5; k != 25; k += 5)
                {
                    for (int i = 0; i < TrainFFT.Length; i++)
                    {
                        ConverterUtils.DataSource train = new ConverterUtils.DataSource(allTrain[a][i]);
                        ConverterUtils.DataSource test = new ConverterUtils.DataSource(allTest[a][i]);
                        PercentageSplit knn = new PercentageSplit(new weka.classifiers.lazy.IBk(k), train.getDataSet(), test.getDataSet(), labels[i]);
                        write.WriteLine("\n\n{0}\t k = {1}", allTrain[a][i], k);
                        writeStrings(knn.evaluate());
                        write.Flush();
                        Console.WriteLine("FINISHED {0}", allTrain[a][i]);
                    }
                }
            }
            
            /*
             * C45
             * 
            write.AutoFlush = true;
            for (int a = 0; a < allTrain.Count; a++)
            {
                for (int i = 0; i < allTrain[a].Length; i++)
                {
                    ConverterUtils.DataSource train = new ConverterUtils.DataSource(allTrain[a][i]);
                    ConverterUtils.DataSource test = new ConverterUtils.DataSource(allTest[a][i]);
                    PercentageSplit c45 = new PercentageSplit(new weka.classifiers.trees.J48(), train.getDataSet(), test.getDataSet(), labels[i]);
                    write.WriteLine("\n\n{0}", allTrain[a][i]);
                    writeStrings(c45.evaluate());
                    write.Flush();
                    Console.WriteLine("FINISHED {0}", allTrain[a][i]);
                    
                }
            }*/
            write.Flush();
            write.Close();
            

        }

        public void build()
        {
            String trainSource = @"B:\DATA SET\Train Set (20).arff";
            String testSource = @"B:\DATA SET\Test Set (5).arff";
            String Class = "Dominant Emotion";
            int k = 3;
            ConverterUtils.DataSource train = new ConverterUtils.DataSource(trainSource); 
            ConverterUtils.DataSource test = new ConverterUtils.DataSource(testSource);
            String dominantString = "Dominant Emotion";
            int dominantIndex = train.getDataSet().attribute(dominantString).index();
            //Console.WriteLine("{0} index: {1}",dominantString, dominantIndex);

            write = new StreamWriter("write.txt");

            PercentageSplit ps = new PercentageSplit(new weka.classifiers.trees.J48(), train.getDataSet(), test.getDataSet(), Class);//new PercentageSplit(new weka.classifiers.trees.J48(), data.getDataSet(), Class, 79.3280);
            writeStrings(ps.evaluate());
            write.Flush();
            write.Close();
            //KNN _knn = new KNN( data,Class, k);
        }


        public void writeStrings(String[] toWrite)
        {
            foreach (String s in toWrite)
            {
                write.WriteLine(s);
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            directoryDialog.ShowDialog();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            outputDialog.ShowDialog();
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            try
            {
                batchProcess(directoryTextBox.Text, outputTextBox.Text, knnCheckBox.Checked, j48CheckBox.Checked, mlpCheckBox.Checked);
            }
            catch (DirectoryNotFoundException dnfex)
            {
                MessageBox.Show(dnfex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void directoryDialog_HelpRequest(object sender, EventArgs e)
        {
            directoryTextBox.Text = directoryDialog.SelectedPath;
        }

        private void outputDialog_FileOk_1(object sender, CancelEventArgs e)
        {
            outputTextBox.Text = outputDialog.FileName;
        }
    }

    public class TrainTest
    {
        String train;
        String test;
        String cl;

        public String Train { get { return train; } set { train = value; } }
        public String Test { get { return test; } set { test = value; } }
        public String Class { get { return cl; } set { cl = value; } }



        public TrainTest(String trainDir, String testDir)
        {
            train = trainDir;
            test = testDir;
            
        }

        public TrainTest(String cl)
        {
            this.cl = cl;
        }
            
    }
}
