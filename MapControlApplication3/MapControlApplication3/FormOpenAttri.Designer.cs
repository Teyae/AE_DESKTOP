namespace MapControlApplication3
{
    partial class FormOpenAttri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOpenAttri));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAllFeature = new System.Windows.Forms.ToolStripButton();
            this.btnSelectedFeature = new System.Windows.Forms.ToolStripButton();
            this.lblCount = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(614, 490);
            this.dataGridView1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAllFeature,
            this.btnSelectedFeature,
            this.lblCount});
            this.toolStrip1.Location = new System.Drawing.Point(0, 463);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(614, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAllFeature
            // 
            this.btnAllFeature.Image = ((System.Drawing.Image)(resources.GetObject("btnAllFeature.Image")));
            this.btnAllFeature.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAllFeature.Name = "btnAllFeature";
            this.btnAllFeature.Size = new System.Drawing.Size(89, 24);
            this.btnAllFeature.Text = "全部要素";
            this.btnAllFeature.Click += new System.EventHandler(this.btnAllFeature_Click);
            // 
            // btnSelectedFeature
            // 
            this.btnSelectedFeature.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectedFeature.Image")));
            this.btnSelectedFeature.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectedFeature.Name = "btnSelectedFeature";
            this.btnSelectedFeature.Size = new System.Drawing.Size(89, 24);
            this.btnSelectedFeature.Text = "选择要素";
            this.btnSelectedFeature.Click += new System.EventHandler(this.btnSelectedFeature_Click);
            // 
            // lblCount
            // 
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 24);
            // 
            // FormOpenAttri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 490);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormOpenAttri";
            this.Text = "FormOpenAttri";
            this.Load += new System.EventHandler(this.FormOpenAttri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAllFeature;
        private System.Windows.Forms.ToolStripButton btnSelectedFeature;
        private System.Windows.Forms.ToolStripLabel lblCount;
    }
}