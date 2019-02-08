using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using weka.core.converters;
using weka.classifiers;
using weka.core;
using System.Windows.Forms;

namespace WEKA
{
    class Classifier //: MachineLearning
    {
        private weka.classifiers.Classifier clas;
        private Instances data;
        private ConverterUtils.DataSource source;
        private bool built = false;
        private String outputClass;

        public String OutputClass
        {
            get
            {
                return outputClass;
            }
        }
        public bool isBuilt
        {
            get
            {
                return built;
            }
        }

        public weka.classifiers.Classifier Class
        {
            get
            {
                return clas;
            }

            set
            {
                clas = value;
            }
        }
        //String outputClass;

        public Classifier(ConverterUtils.DataSource sourcefile, String outputClass)
        {
            try
            {
                this.source = sourcefile;
                data = source.getDataSet();
                data.setClass(data.attribute(outputClass));
                this.outputClass = outputClass;
            }
            catch (java.lang.Exception ex)
                {
                ex.printStackTrace();
                MessageBox.Show(this.GetType().FullName + " classifier building failed!", "WEKA", MessageBoxButtons.OK);
            }/*
            finally
            {
                clas.buildClassifier(data);
                built = true;
                Console.WriteLine("Building " + this.GetType().FullName + " SUCCESSFUL", "WEKA", MessageBoxButtons.OK);
                //MessageBox.Show( + " classifier building failed!", "WEKA", MessageBoxButtons.OK);
            }*/
        }

        public void Label(Instances unlabeled)
        {
            if (isBuilt)
            {
                Instances labeled = new Instances(unlabeled);
                for (int i = 0; i < unlabeled.numInstances(); i++)
                {
                    double emotionLabel = clas.classifyInstance(unlabeled.instance(i));

                }
            }
            else
            {

            }
        }



        
    }
}
