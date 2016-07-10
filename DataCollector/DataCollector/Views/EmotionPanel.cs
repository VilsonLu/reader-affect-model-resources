using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollector.Views {
    public partial class EmotionPanel : UserControl {
        public EmotionPanel() {
            InitializeComponent();
        }

        public String Label {
            get { return lblAffectiveDimension.Text; }
            set {
                lblAffectiveDimension.Text = value;
                Invalidate();
            }
        }

        public String Description {
            get { return lblDescription.Text; }
            set {
                lblDescription.Text = value;
                Invalidate();
            }
        }

        public Image PositiveImage {
            get { return pbPositive.BackgroundImage; }
            set {
                pbPositive.BackgroundImage = value;
                Invalidate();
            }
        }

        public Image NegativeImage {
            get { return pbNegative.BackgroundImage; }
            set {
                pbNegative.BackgroundImage = value;
                Invalidate();
            }
        }

        public Int32 IntensityValue {
            get { return tbIntensity.Value; }
            set {
                tbIntensity.Value = value;
                Invalidate();
            }
        }

        public void Reset() {
            tbIntensity.Value = 0;
        }
    }
}
