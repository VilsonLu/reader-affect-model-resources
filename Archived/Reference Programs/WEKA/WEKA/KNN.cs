using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using weka.core.converters;


namespace WEKA
{
    class KNN : Classifier
    {
        int k;
        
        public KNN(ConverterUtils.DataSource sourcefile, String outputClass, int k) : base(sourcefile, outputClass)
        {
            this.k = k;
            Class = new weka.classifiers.lazy.IBk(k);
        }

    }
}
