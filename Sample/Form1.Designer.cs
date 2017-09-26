namespace Sample
{
    partial class MainFrm
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
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtPrompt = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtQuality = new System.Windows.Forms.TextBox();
            this.lblQuality = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.picFP = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picFP)).BeginInit();
            this.SuspendLayout();
            //
            // lblPrompt
            //
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(357, 21);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(43, 13);
            this.lblPrompt.TabIndex = 0;
            this.lblPrompt.Text = "Prompt:";
            //
            // txtPrompt
            //
            this.txtPrompt.Location = new System.Drawing.Point(360, 46);
            this.txtPrompt.Name = "txtPrompt";
            this.txtPrompt.Size = new System.Drawing.Size(220, 20);
            this.txtPrompt.TabIndex = 1;
            //
            // txtStatus
            //
            this.txtStatus.Location = new System.Drawing.Point(360, 102);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(220, 20);
            this.txtStatus.TabIndex = 3;
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(357, 77);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            //
            // txtQuality
            //
            this.txtQuality.Location = new System.Drawing.Point(360, 164);
            this.txtQuality.Name = "txtQuality";
            this.txtQuality.Size = new System.Drawing.Size(220, 20);
            this.txtQuality.TabIndex = 5;
            //
            // lblQuality
            //
            this.lblQuality.AutoSize = true;
            this.lblQuality.Location = new System.Drawing.Point(357, 139);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(74, 13);
            this.lblQuality.TabIndex = 4;
            this.lblQuality.Text = "Image Quality:";
            //
            // btnConnect
            //
            this.btnConnect.Location = new System.Drawing.Point(360, 206);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(127, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect Sensor";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            //
            // btnRegister
            //
            this.btnRegister.Enabled = false;
            this.btnRegister.Location = new System.Drawing.Point(360, 252);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(127, 23);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            //
            // btnVerify
            //
            this.btnVerify.Enabled = false;
            this.btnVerify.Location = new System.Drawing.Point(360, 296);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(127, 23);
            this.btnVerify.TabIndex = 8;
            this.btnVerify.Text = "Verify(1:N)";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            //
            // picFP
            //
            this.picFP.Location = new System.Drawing.Point(3, 3);
            this.picFP.Name = "picFP";
            this.picFP.Size = new System.Drawing.Size(280, 360);
            this.picFP.TabIndex = 9;
            this.picFP.TabStop = false;
            //
            // MainFrm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 389);
            this.Controls.Add(this.picFP);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtQuality);
            this.Controls.Add(this.lblQuality);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtPrompt);
            this.Controls.Add(this.lblPrompt);
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sample";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtPrompt;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtQuality;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.PictureBox picFP;
    }
}
