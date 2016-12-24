namespace ProjectCsharp
{
    partial class Dialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog));
            this.btnExit = new System.Windows.Forms.Button();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.lblShowIndex = new System.Windows.Forms.Label();
            this.minuizeImg = new System.Windows.Forms.PictureBox();
            this.exitImg = new System.Windows.Forms.PictureBox();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblShowMessage = new System.Windows.Forms.Label();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minuizeImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitImg)).BeginInit();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Green;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.Location = new System.Drawing.Point(152, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(119, 32);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Ok";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.DarkGreen;
            this.titlePanel.Controls.Add(this.lblShowIndex);
            this.titlePanel.Controls.Add(this.minuizeImg);
            this.titlePanel.Controls.Add(this.exitImg);
            this.titlePanel.Location = new System.Drawing.Point(2, -1);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(447, 62);
            this.titlePanel.TabIndex = 6;
            // 
            // lblShowIndex
            // 
            this.lblShowIndex.AutoSize = true;
            this.lblShowIndex.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowIndex.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblShowIndex.Location = new System.Drawing.Point(10, 20);
            this.lblShowIndex.Name = "lblShowIndex";
            this.lblShowIndex.Size = new System.Drawing.Size(116, 25);
            this.lblShowIndex.TabIndex = 13;
            this.lblShowIndex.Text = "<showIndex>";
            // 
            // minuizeImg
            // 
            this.minuizeImg.Image = ((System.Drawing.Image)(resources.GetObject("minuizeImg.Image")));
            this.minuizeImg.Location = new System.Drawing.Point(1158, 11);
            this.minuizeImg.Name = "minuizeImg";
            this.minuizeImg.Size = new System.Drawing.Size(38, 33);
            this.minuizeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minuizeImg.TabIndex = 12;
            this.minuizeImg.TabStop = false;
            // 
            // exitImg
            // 
            this.exitImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitImg.BackgroundImage")));
            this.exitImg.Image = ((System.Drawing.Image)(resources.GetObject("exitImg.Image")));
            this.exitImg.Location = new System.Drawing.Point(1207, 11);
            this.exitImg.Name = "exitImg";
            this.exitImg.Size = new System.Drawing.Size(37, 33);
            this.exitImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitImg.TabIndex = 11;
            this.exitImg.TabStop = false;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.DarkGreen;
            this.panelFooter.Controls.Add(this.pictureBox1);
            this.panelFooter.Controls.Add(this.pictureBox2);
            this.panelFooter.Controls.Add(this.btnExit);
            this.panelFooter.Location = new System.Drawing.Point(2, 156);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(447, 62);
            this.panelFooter.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1158, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1207, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // lblShowMessage
            // 
            this.lblShowMessage.AutoSize = true;
            this.lblShowMessage.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowMessage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblShowMessage.Location = new System.Drawing.Point(12, 83);
            this.lblShowMessage.Name = "lblShowMessage";
            this.lblShowMessage.Size = new System.Drawing.Size(116, 25);
            this.lblShowMessage.TabIndex = 14;
            this.lblShowMessage.Text = "<showIndex>";
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 213);
            this.Controls.Add(this.lblShowMessage);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.titlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog";
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minuizeImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitImg)).EndInit();
            this.panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label lblShowIndex;
        private System.Windows.Forms.PictureBox minuizeImg;
        private System.Windows.Forms.PictureBox exitImg;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblShowMessage;
    }
}