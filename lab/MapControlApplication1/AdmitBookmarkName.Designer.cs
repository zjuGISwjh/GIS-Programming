namespace MapControlApplication1
{
    partial class AdmitBookmarkName
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
            this.tbBookmarkname = new System.Windows.Forms.TextBox();
            this.btnAdimit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbBookmarkname
            // 
            this.tbBookmarkname.Location = new System.Drawing.Point(13, 13);
            this.tbBookmarkname.Name = "tbBookmarkname";
            this.tbBookmarkname.Size = new System.Drawing.Size(100, 21);
            this.tbBookmarkname.TabIndex = 0;
            this.tbBookmarkname.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnAdimit
            // 
            this.btnAdimit.Location = new System.Drawing.Point(119, 13);
            this.btnAdimit.Name = "btnAdimit";
            this.btnAdimit.Size = new System.Drawing.Size(60, 23);
            this.btnAdimit.TabIndex = 1;
            this.btnAdimit.Text = "OK";
            this.btnAdimit.UseVisualStyleBackColor = true;
            this.btnAdimit.Click += new System.EventHandler(this.btnAdimit_Click);
            // 
            // AdmitBookmarkName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.btnAdimit);
            this.Controls.Add(this.tbBookmarkname);
            this.Name = "AdmitBookmarkName";
            this.Text = "AdmitBookmarkName";
            this.Load += new System.EventHandler(this.AdmitBookmarkName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbBookmarkname;
        private System.Windows.Forms.Button btnAdimit;
    }
}