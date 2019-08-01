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
    public partial class FrmPointSymbol : Form
    {
        private double size;

        public double Size1
        {
            get { return size; }
            set { size = value; }
        }
        private Color panelcolor;

        public Color Panelcolor
        {
            get { return panelcolor; }
            set { panelcolor = value; }
        }
        private Color paneloutsidecolor;

        public Color Paneloutsidecolor
        {
            get { return paneloutsidecolor; }
            set { paneloutsidecolor = value; }
        }
        private bool useoutline;

        public bool Useoutline
        {
            get { return useoutline; }
            set { useoutline = value; }
        }
        private double numOutlineSize;

        public double NumOutlineSize
        {
            get { return numOutlineSize; }
            set { numOutlineSize = value; }
        }

        public FrmPointSymbol()
        {
            InitializeComponent();
        }
        
        
        private void panel_color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) ;
            panel_color.BackColor = colorDialog1.Color;

        }

        private void panel_linecolor_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK) ;
             panel_linecolor.BackColor = colorDialog2.Color;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            size = System.Convert.ToDouble(nud_size.Value);
            panelcolor = panel_color.BackColor;
            paneloutsidecolor = panel_linecolor.BackColor;
            numOutlineSize = System.Convert.ToDouble(nud_linesize.Value);
            useoutline = checkBox1.Checked;
            this.Close(); 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            panel_linecolor.Enabled = true;
            panel_linecolor.BackColor = System.Drawing.Color.White;
            nud_linesize.Enabled = true;              //为什么只会响应一次？
        }


    }
}
