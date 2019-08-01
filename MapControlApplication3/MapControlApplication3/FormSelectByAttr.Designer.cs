namespace MapControlApplication3
{
    partial class FormSelectByAttr
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
            this.combo_layer = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_like = new System.Windows.Forms.Button();
            this.btn_null = new System.Windows.Forms.Button();
            this.btn_all = new System.Windows.Forms.Button();
            this.btn_notequal = new System.Windows.Forms.Button();
            this.btn_lt = new System.Windows.Forms.Button();
            this.btn_or = new System.Windows.Forms.Button();
            this.btn_gt = new System.Windows.Forms.Button();
            this.btn_and = new System.Windows.Forms.Button();
            this.btn_equal = new System.Windows.Forms.Button();
            this.textbox_sql = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.listBox_attri = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "SELECT * FROM LAYER WHERE";
            // 
            // combo_layer
            // 
            this.combo_layer.FormattingEnabled = true;
            this.combo_layer.Location = new System.Drawing.Point(135, 23);
            this.combo_layer.Name = "combo_layer";
            this.combo_layer.Size = new System.Drawing.Size(245, 23);
            this.combo_layer.TabIndex = 2;
            this.combo_layer.SelectedIndexChanged += new System.EventHandler(this.combo_layer_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_like);
            this.groupBox1.Controls.Add(this.btn_null);
            this.groupBox1.Controls.Add(this.btn_all);
            this.groupBox1.Controls.Add(this.btn_notequal);
            this.groupBox1.Controls.Add(this.btn_lt);
            this.groupBox1.Controls.Add(this.btn_or);
            this.groupBox1.Controls.Add(this.btn_gt);
            this.groupBox1.Controls.Add(this.btn_and);
            this.groupBox1.Controls.Add(this.btn_equal);
            this.groupBox1.Location = new System.Drawing.Point(223, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 215);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运算符";
            // 
            // btn_like
            // 
            this.btn_like.Location = new System.Drawing.Point(18, 165);
            this.btn_like.Name = "btn_like";
            this.btn_like.Size = new System.Drawing.Size(54, 29);
            this.btn_like.TabIndex = 9;
            this.btn_like.Text = "Like";
            this.btn_like.UseVisualStyleBackColor = true;
            this.btn_like.Click += new System.EventHandler(this.btn_like_Click);
            // 
            // btn_null
            // 
            this.btn_null.Location = new System.Drawing.Point(78, 165);
            this.btn_null.Name = "btn_null";
            this.btn_null.Size = new System.Drawing.Size(54, 29);
            this.btn_null.TabIndex = 8;
            this.btn_null.Text = "\'\'";
            this.btn_null.UseVisualStyleBackColor = true;
            this.btn_null.Click += new System.EventHandler(this.btn_null_Click);
            // 
            // btn_all
            // 
            this.btn_all.Location = new System.Drawing.Point(78, 130);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(54, 29);
            this.btn_all.TabIndex = 7;
            this.btn_all.Text = "*";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // btn_notequal
            // 
            this.btn_notequal.Location = new System.Drawing.Point(18, 130);
            this.btn_notequal.Name = "btn_notequal";
            this.btn_notequal.Size = new System.Drawing.Size(54, 29);
            this.btn_notequal.TabIndex = 6;
            this.btn_notequal.Text = "<>";
            this.btn_notequal.UseVisualStyleBackColor = true;
            this.btn_notequal.Click += new System.EventHandler(this.btn_notequal_Click);
            // 
            // btn_lt
            // 
            this.btn_lt.Location = new System.Drawing.Point(18, 95);
            this.btn_lt.Name = "btn_lt";
            this.btn_lt.Size = new System.Drawing.Size(54, 29);
            this.btn_lt.TabIndex = 4;
            this.btn_lt.Text = "<";
            this.btn_lt.UseVisualStyleBackColor = true;
            this.btn_lt.Click += new System.EventHandler(this.btn_lt_Click);
            // 
            // btn_or
            // 
            this.btn_or.Location = new System.Drawing.Point(82, 60);
            this.btn_or.Name = "btn_or";
            this.btn_or.Size = new System.Drawing.Size(54, 29);
            this.btn_or.TabIndex = 3;
            this.btn_or.Text = "Or";
            this.btn_or.UseVisualStyleBackColor = true;
            this.btn_or.Click += new System.EventHandler(this.btn_or_Click);
            // 
            // btn_gt
            // 
            this.btn_gt.Location = new System.Drawing.Point(18, 60);
            this.btn_gt.Name = "btn_gt";
            this.btn_gt.Size = new System.Drawing.Size(54, 29);
            this.btn_gt.TabIndex = 2;
            this.btn_gt.Text = ">";
            this.btn_gt.UseVisualStyleBackColor = true;
            this.btn_gt.Click += new System.EventHandler(this.btn_gt_Click);
            // 
            // btn_and
            // 
            this.btn_and.Location = new System.Drawing.Point(82, 25);
            this.btn_and.Name = "btn_and";
            this.btn_and.Size = new System.Drawing.Size(54, 29);
            this.btn_and.TabIndex = 1;
            this.btn_and.Text = "And";
            this.btn_and.UseVisualStyleBackColor = true;
            this.btn_and.Click += new System.EventHandler(this.btn_and_Click);
            // 
            // btn_equal
            // 
            this.btn_equal.Location = new System.Drawing.Point(18, 25);
            this.btn_equal.Name = "btn_equal";
            this.btn_equal.Size = new System.Drawing.Size(54, 29);
            this.btn_equal.TabIndex = 0;
            this.btn_equal.Text = "=";
            this.btn_equal.UseVisualStyleBackColor = true;
            this.btn_equal.Click += new System.EventHandler(this.btn_equal_Click);
            // 
            // textbox_sql
            // 
            this.textbox_sql.Location = new System.Drawing.Point(45, 328);
            this.textbox_sql.Multiline = true;
            this.textbox_sql.Name = "textbox_sql";
            this.textbox_sql.Size = new System.Drawing.Size(335, 72);
            this.textbox_sql.TabIndex = 5;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(56, 425);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 6;
            this.btn_clear.Text = "清除";
            this.btn_clear.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(174, 425);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 7;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(305, 425);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // listBox_attri
            // 
            this.listBox_attri.FormattingEnabled = true;
            this.listBox_attri.ItemHeight = 15;
            this.listBox_attri.Location = new System.Drawing.Point(45, 71);
            this.listBox_attri.Name = "listBox_attri";
            this.listBox_attri.Size = new System.Drawing.Size(156, 214);
            this.listBox_attri.TabIndex = 9;
            this.listBox_attri.DoubleClick += new System.EventHandler(this.listBox_attri_DoubleClick);
            // 
            // FormSelectByAttr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 484);
            this.Controls.Add(this.listBox_attri);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.textbox_sql);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.combo_layer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormSelectByAttr";
            this.Text = "FormSelectByAttr";
            this.Load += new System.EventHandler(this.FormSelectByAttr_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_layer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_like;
        private System.Windows.Forms.Button btn_null;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.Button btn_notequal;
        private System.Windows.Forms.Button btn_lt;
        private System.Windows.Forms.Button btn_or;
        private System.Windows.Forms.Button btn_gt;
        private System.Windows.Forms.Button btn_and;
        private System.Windows.Forms.Button btn_equal;
        private System.Windows.Forms.TextBox textbox_sql;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ListBox listBox_attri;
    }
}