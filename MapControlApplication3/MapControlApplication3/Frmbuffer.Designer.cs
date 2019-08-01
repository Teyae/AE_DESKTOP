namespace MapControlApplication3
{
    partial class Frmbuffer
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
            this.combo_layer = new System.Windows.Forms.ComboBox();
            this.combo_unit = new System.Windows.Forms.ComboBox();
            this.text_dis = new System.Windows.Forms.TextBox();
            this.text_path = new System.Windows.Forms.TextBox();
            this.btn_path = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层选择：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "距离：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "输出路径：";
            // 
            // combo_layer
            // 
            this.combo_layer.FormattingEnabled = true;
            this.combo_layer.Location = new System.Drawing.Point(117, 36);
            this.combo_layer.Name = "combo_layer";
            this.combo_layer.Size = new System.Drawing.Size(206, 23);
            this.combo_layer.TabIndex = 3;
            // 
            // combo_unit
            // 
            this.combo_unit.FormattingEnabled = true;
            this.combo_unit.Items.AddRange(new object[] {
            "Meters",
            "Kilometers",
            "Miles",
            "Centimeters",
            "Inches",
            ""});
            this.combo_unit.Location = new System.Drawing.Point(239, 88);
            this.combo_unit.Name = "combo_unit";
            this.combo_unit.Size = new System.Drawing.Size(84, 23);
            this.combo_unit.TabIndex = 4;
            // 
            // text_dis
            // 
            this.text_dis.Location = new System.Drawing.Point(117, 86);
            this.text_dis.Name = "text_dis";
            this.text_dis.Size = new System.Drawing.Size(111, 25);
            this.text_dis.TabIndex = 5;
            // 
            // text_path
            // 
            this.text_path.Location = new System.Drawing.Point(117, 142);
            this.text_path.Name = "text_path";
            this.text_path.Size = new System.Drawing.Size(149, 25);
            this.text_path.TabIndex = 6;
            // 
            // btn_path
            // 
            this.btn_path.Location = new System.Drawing.Point(283, 142);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(40, 26);
            this.btn_path.TabIndex = 7;
            this.btn_path.Text = "...";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(250, 206);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(73, 26);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(155, 206);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(73, 26);
            this.btn_ok.TabIndex = 10;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // Frmbuffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 266);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_path);
            this.Controls.Add(this.text_path);
            this.Controls.Add(this.text_dis);
            this.Controls.Add(this.combo_unit);
            this.Controls.Add(this.combo_layer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frmbuffer";
            this.Text = "Frmbuffer";
            this.Load += new System.EventHandler(this.Frmbuffer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_layer;
        private System.Windows.Forms.ComboBox combo_unit;
        private System.Windows.Forms.TextBox text_dis;
        private System.Windows.Forms.TextBox text_path;
        private System.Windows.Forms.Button btn_path;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
    }
}