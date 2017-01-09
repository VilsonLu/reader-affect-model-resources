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
    public partial class EmotionPanel2 : UserControl {
        public EmotionPanel2() {
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

        public Image Neg3Image {
            get { return pbNeg3.BackgroundImage; }
            set {
                pbNeg3.BackgroundImage = value;
                Invalidate();
            }
        }

        public Image Neg2Image {
            get { return pbNeg2.BackgroundImage; }
            set {
                pbNeg2.BackgroundImage = value;
                Invalidate();
            }
        }

        public Image Neg1Image {
            get { return pbNeg1.BackgroundImage; }
            set {
                pbNeg1.BackgroundImage = value;
                Invalidate();
            }
        }

        public Image Pos3Image {
            get { return pbPos3.BackgroundImage; }
            set {
                pbPos3.BackgroundImage = value;
                Invalidate();
            }
        }

        public Image Pos2Image {
            get { return pbPos2.BackgroundImage; }
            set {
                pbPos2.BackgroundImage = value;
                Invalidate();
            }
        }

        public Image Pos1Image {
            get { return pbPos1.BackgroundImage; }
            set {
                pbPos1.BackgroundImage = value;
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

        private void tbIntensity_Scroll(object sender, EventArgs e) {

        }
    }
}
