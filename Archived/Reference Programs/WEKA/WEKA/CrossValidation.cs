using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using weka.core;

namespace WEKA
{
    class CrossValidation : Validation
    {
        public CrossValidation(Instances data, String classAtrtibute, int fold) : base(data, classAtrtibute)
        {

        }

    }
}
