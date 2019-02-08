using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using weka.classifiers;
using weka.core;

namespace WEKA
{
    class Validation
    {
        Evaluation eval;

        public Evaluation Evaluator
        {
            get
            {
                return eval;
            }

            set
            {
                eval = value;
            }
        }

        public Validation(Instances data, String classAttribute)
        {
            data.setClass(data.attribute(classAttribute));
            eval = new Evaluation(data);
        }


    }
}
