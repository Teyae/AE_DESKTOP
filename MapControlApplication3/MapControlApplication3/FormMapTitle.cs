using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapControlApplication3
{
    public partial class FormMapTitle : Form
    {
        private Color panelcolor;

        public Color Panelcolor
        {
            get { return panelcolor; }
            set { panelcolor = value; }
        }
        private string maptitle;

        public string Maptitle
        {
            get { return maptitle; }
            set { maptitle = value; }
        }
        private double angle;

        public double Angle
        {
            get { return angle; }
            set { angle = value; }
        }
        public FormMapTitle()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
             if (colorDialog3.ShowDialog() == DialogResult.OK) ;
                 panel1.BackColor = colorDialog3.Color;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            angle = System.Convert.ToDouble(textbox_angle.Text);
            maptitle = textbox_title.Text;
            panelcolor = panel1.BackColor;
            this.Close();
        }

      
    }
}
