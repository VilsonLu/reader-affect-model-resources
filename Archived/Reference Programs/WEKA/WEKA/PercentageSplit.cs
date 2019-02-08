using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using weka.core;
using weka.classifiers;

namespace WEKA
{
    class PercentageSplit : Validation
    {
        int trainSize;
        //Evaluation eval;
        weka.classifiers.Classifier classifier;
        Instances train;
        Instances test;
        /*
        public PercentageSplit(weka.classifiers.Classifier c, Instances data, String classAttribute, double trainSize) : base(data, classAttribute)
        {
            this.classifier = c;
            Evaluator = new Evaluation(data);
            this.trainSize = (int) (data.numInstances() * trainSize / 100);
            Console.WriteLine("train size: {0}", this.trainSize);
            //train = new Instances(data, 1, data.numInstances());//train = new Instances(data, 0, this.trainSize);
            Console.WriteLine(data.numInstances());
            //test = new Instances(data, this.trainSize, data.numInstances() - 1);
            train.setClass(train.attribute(classAttribute));
            //test.setClass(test.attribute(classAttribute));
            classifier.buildClassifier(train);
        }*/

        public PercentageSplit(weka.classifiers.Classifier c, Instances train, Instances test, String classAttribute)
            : base(train, classAttribute)
        {
            this.classifier = c;
            this.train = train;
            this.test = test;

            this.train.setClass(this.train.attribute(classAttribute));
            this.test.setClass(this.test.attribute(classAttribute));
            this.classifier.buildClassifier(train);
        }

        public String[] evaluate()
        {
            Evaluator.evaluateModel(classifier, test);
            String[] ret = new String[5];
            ret[0] = "Accuracy :\t" + Evaluator.pctCorrect() + " %";
            ret[1] = "Weighted F-Meausre :\t" + Evaluator.weightedFMeasure();
            ret[2] = "Weighted Recall :\t" + Evaluator.weightedRecall();
            ret[3] = "Weighted Precision :\t" + Evaluator.weightedPrecision();
            ret[4] = "\n"+Evaluator.toMatrixString();
            return ret;

            //classifier.
            //System.IO.StreamWriter write = new System.IO.StreamWriter("write.txt");
            //write.WriteLine(Evaluator.toSummaryString());
            //write.WriteLine(Evaluator.toMatrixString());
            //write.WriteLine(Evaluator.weightedFMeasure());Evaluator.a
            //write.Close();
            //Console.WriteLine(Evaluator.toSummaryString());
            //Console.WriteLine(Evaluator.toMatrixString());
            //Console.WriteLine(Evaluator.weightedPrecision());
            //Console.WriteLine(Evaluator.weightedRecall());
            //Console.WriteLine(Evaluator.weightedFMeasure());
        }
    }
}
