namespace MapControlApplication3
{
    partial class Createshapefile
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_ref = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.text_path = new System.Windows.Forms.TextBox();
            this.btn_path = new System.Windows.Forms.Button();
            this.combo_type = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "现有空间参考:";
            // 
            // text_ref
            // 
            this.text_ref.Location = new System.Drawing.Point(141, 88);
            this.text_ref.Name = "text_ref";
            this.text_ref.Size = new System.Drawing.Size(162, 25);
            this.text_ref.TabIndex = 5;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(33, 192);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 6;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(228, 192);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "保存路径：";
            // 
            // text_path
            // 
            this.text_path.Location = new System.Drawing.Point(118, 134);
            this.text_path.Name = "text_path";
            this.text_path.Size = new System.Drawing.Size(144, 25);
            this.text_path.TabIndex = 10;
            // 
            // btn_path
            // 
            this.btn_path.Location = new System.Drawing.Point(268, 134);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(35, 23);
            this.btn_path.TabIndex = 11;
            this.btn_path.Text = "...";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // combo_type
            // 
            combo_type.FormattingEnabled = true;
            combo_type.Items.AddRange(new object[] {
            "point",
            "polyline",
            "polygon"});
            combo_type.Location = new System.Drawing.Point(88, 39);
            combo_type.Name = "combo_type";
            combo_type.Size = new System.Drawing.Size(215, 23);
            combo_type.TabIndex = 12;
            // 
            // Createshapefile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 242);
            this.Controls.Add(combo_type);
            this.Controls.Add(this.btn_path);
            this.Controls.Add(this.text_path);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.text_ref);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Createshapefile";
            this.Text = "新建Shapefile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox combo_type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public  System.Windows.Forms.TextBox text_ref;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_path;
        private System.Windows.Forms.Button btn_path;
    }
}