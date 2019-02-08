using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using weka.core.converters;

namespace WEKA
{
    class MLP : Classifier
    {
        public MLP(ConverterUtils.DataSource sourcefile, String outputClass) : base(sourcefile, outputClass)
        {
            Class = new weka.classifiers.functions.MultilayerPerceptron();
        }


    }
}
