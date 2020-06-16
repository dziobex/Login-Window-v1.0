namespace Login
{
    partial class LoggedWindow
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
            this.mainImage = new System.Windows.Forms.PictureBox();
            this.info = new System.Windows.Forms.Label();
            this.creationDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // mainImage
            // 
            this.mainImage.Image = global::Login.Properties.Resources.lennyfin;
            this.mainImage.Location = new System.Drawing.Point(42, 102);
            this.mainImage.Name = "mainImage";
            this.mainImage.Size = new System.Drawing.Size(360, 328);
            this.mainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mainImage.TabIndex = 0;
            this.mainImage.TabStop = false;
            // 
            // info
            // 
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.info.Location = new System.Drawing.Point(-1, 36);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(443, 31);
            this.info.TabIndex = 1;
            this.info.Text = "label1";
            this.info.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // creationDate
            // 
            this.creationDate.AutoSize = true;
            this.creationDate.Location = new System.Drawing.Point(66, 435);
            this.creationDate.Name = "creationDate";
            this.creationDate.Size = new System.Drawing.Size(35, 13);
            this.creationDate.TabIndex = 2;
            this.creationDate.Text = "label1";
            // 
            // LoggedWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 457);
            this.Controls.Add(this.creationDate);
            this.Controls.Add(this.info);
            this.Controls.Add(this.mainImage);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(458, 496);
            this.MinimumSize = new System.Drawing.Size(458, 496);
            this.Name = "LoggedWindow";
            this.Text = "LoggedWindow";
            ((System.ComponentModel.ISupportInitialize)(this.mainImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainImage;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Label creationDate;
    }
}