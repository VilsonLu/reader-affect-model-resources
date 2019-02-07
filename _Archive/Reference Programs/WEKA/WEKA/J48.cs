using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using weka.core.converters;

namespace WEKA
{
    class J48 : Classifier
    {
        public J48(ConverterUtils.DataSource sourcefile, String outputClass) : base(sourcefile, outputClass)       
        {

        }
    }
}
