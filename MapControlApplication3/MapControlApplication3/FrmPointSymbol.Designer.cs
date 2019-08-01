namespace MapControlApplication3
{
    partial class FrmPointSymbol
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel_color = new System.Windows.Forms.Panel();
            this.nud_size = new System.Windows.Forms.NumericUpDown();
            this.nud_linesize = new System.Windows.Forms.NumericUpDown();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_linecolor = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_linesize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "渲染颜色：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "大小/宽度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "边框颜色：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkBox1.Location = new System.Drawing.Point(44, 127);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "使用边框";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // panel_color
            // 
            this.panel_color.BackColor = System.Drawing.Color.White;
            this.panel_color.Location = new System.Drawing.Point(131, 31);
            this.panel_color.Name = "panel_color";
            this.panel_color.Size = new System.Drawing.Size(29, 27);
            this.panel_color.TabIndex = 5;
            this.panel_color.Click += new System.EventHandler(this.panel_color_Click);
            // 
            // nud_size
            // 
            this.nud_size.Location = new System.Drawing.Point(131, 78);
            this.nud_size.Name = "nud_size";
            this.nud_size.Size = new System.Drawing.Size(42, 25);
            this.nud_size.TabIndex = 6;
            // 
            // nud_linesize
            // 
            this.nud_linesize.Enabled = false;
            this.nud_linesize.Location = new System.Drawing.Point(109, 82);
            this.nud_linesize.Name = "nud_linesize";
            this.nud_linesize.Size = new System.Drawing.Size(42, 25);
            this.nud_linesize.TabIndex = 7;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(139, 310);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "边框宽度：";
            // 
            // panel_linecolor
            // 
            this.panel_linecolor.BackColor = System.Drawing.Color.Silver;
            this.panel_linecolor.Enabled = false;
            this.panel_linecolor.Location = new System.Drawing.Point(109, 36);
            this.panel_linecolor.Name = "panel_linecolor";
            this.panel_linecolor.Size = new System.Drawing.Size(29, 27);
            this.panel_linecolor.TabIndex = 6;
            this.panel_linecolor.Click += new System.EventHandler(this.panel_linecolor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nud_linesize);
            this.groupBox1.Controls.Add(this.panel_linecolor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(30, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 123);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "边框设置";
            // 
            // FrmPointSymbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 360);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.nud_size);
            this.Controls.Add(this.panel_color);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmPointSymbol";
            this.Text = "FrmPointSymbol";
            ((System.ComponentModel.ISupportInitialize)(this.nud_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_linesize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel_color;
        private System.Windows.Forms.NumericUpDown nud_size;
        public System.Windows.Forms.NumericUpDown nud_linesize;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Panel panel_linecolor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}