namespace Chay.Forms
{
    partial class Profile
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
            System.Windows.Forms.Panel pHeader;
            System.Windows.Forms.Panel pHeader2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.lblProfil = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbxChatName = new System.Windows.Forms.TextBox();
            this.lblChattnamn = new System.Windows.Forms.Label();
            this.btnCancleProf = new System.Windows.Forms.Button();
            this.btnSaveProf = new System.Windows.Forms.Button();
            this.dlgOpenImage = new System.Windows.Forms.OpenFileDialog();
            this.btnLogout = new System.Windows.Forms.Button();
            this.rpbxImage = new Chay.Components.RoundPicturebox();
            pHeader = new System.Windows.Forms.Panel();
            pHeader2 = new System.Windows.Forms.Panel();
            pHeader.SuspendLayout();
            pHeader2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpbxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            pHeader.BackColor = System.Drawing.Color.SteelBlue;
            pHeader.Controls.Add(pHeader2);
            pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pHeader.Location = new System.Drawing.Point(2, 2);
            pHeader.Name = "pHeader";
            pHeader.Size = new System.Drawing.Size(392, 63);
            pHeader.TabIndex = 8;
            // 
            // pHeader2
            // 
            pHeader2.BackColor = System.Drawing.Color.SteelBlue;
            pHeader2.Controls.Add(this.lblProfil);
            pHeader2.Dock = System.Windows.Forms.DockStyle.Top;
            pHeader2.Location = new System.Drawing.Point(0, 0);
            pHeader2.Name = "pHeader2";
            pHeader2.Size = new System.Drawing.Size(392, 63);
            pHeader2.TabIndex = 9;
            pHeader2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PHeader2_MouseDown);
            pHeader2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PHeader2_MouseMove);
            // 
            // lblProfil
            // 
            this.lblProfil.AutoSize = true;
            this.lblProfil.Font = new System.Drawing.Font("Myriad Pro Cond", 25.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfil.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblProfil.Location = new System.Drawing.Point(164, 10);
            this.lblProfil.Name = "lblProfil";
            this.lblProfil.Size = new System.Drawing.Size(72, 40);
            this.lblProfil.TabIndex = 24;
            this.lblProfil.Text = "Profil";
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnUpload.Enabled = false;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(167, 190);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(64, 21);
            this.btnUpload.TabIndex = 18;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.tbxChatName);
            this.panel2.Location = new System.Drawing.Point(94, 261);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 33);
            this.panel2.TabIndex = 20;
            // 
            // tbxChatName
            // 
            this.tbxChatName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxChatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxChatName.Location = new System.Drawing.Point(20, 8);
            this.tbxChatName.Name = "tbxChatName";
            this.tbxChatName.Size = new System.Drawing.Size(159, 15);
            this.tbxChatName.TabIndex = 0;
            // 
            // lblChattnamn
            // 
            this.lblChattnamn.AutoSize = true;
            this.lblChattnamn.Font = new System.Drawing.Font("Myriad Pro Cond", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChattnamn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblChattnamn.Location = new System.Drawing.Point(90, 226);
            this.lblChattnamn.Name = "lblChattnamn";
            this.lblChattnamn.Size = new System.Drawing.Size(113, 32);
            this.lblChattnamn.TabIndex = 8;
            this.lblChattnamn.Text = "Chatt namn";
            // 
            // btnCancleProf
            // 
            this.btnCancleProf.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancleProf.FlatAppearance.BorderSize = 0;
            this.btnCancleProf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancleProf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancleProf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancleProf.Location = new System.Drawing.Point(135, 344);
            this.btnCancleProf.Name = "btnCancleProf";
            this.btnCancleProf.Size = new System.Drawing.Size(64, 31);
            this.btnCancleProf.TabIndex = 23;
            this.btnCancleProf.Text = "Avbryt";
            this.btnCancleProf.UseVisualStyleBackColor = false;
            this.btnCancleProf.Click += new System.EventHandler(this.BtnCancleProf_Click);
            // 
            // btnSaveProf
            // 
            this.btnSaveProf.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSaveProf.FlatAppearance.BorderSize = 0;
            this.btnSaveProf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSaveProf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProf.Location = new System.Drawing.Point(205, 344);
            this.btnSaveProf.Name = "btnSaveProf";
            this.btnSaveProf.Size = new System.Drawing.Size(64, 31);
            this.btnSaveProf.TabIndex = 24;
            this.btnSaveProf.Text = "Spara";
            this.btnSaveProf.UseVisualStyleBackColor = false;
            this.btnSaveProf.Click += new System.EventHandler(this.BtnSaveProf_Click);
            // 
            // dlgOpenImage
            // 
            this.dlgOpenImage.FileName = "openFileDialog1";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnLogout.Location = new System.Drawing.Point(319, 71);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(72, 21);
            this.btnLogout.TabIndex = 26;
            this.btnLogout.Text = "Logga ut";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // rpbxImage
            // 
            this.rpbxImage.BackColor = System.Drawing.Color.AliceBlue;
            this.rpbxImage.Location = new System.Drawing.Point(152, 71);
            this.rpbxImage.Name = "rpbxImage";
            this.rpbxImage.Size = new System.Drawing.Size(100, 100);
            this.rpbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rpbxImage.TabIndex = 25;
            this.rpbxImage.TabStop = false;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(396, 387);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.rpbxImage);
            this.Controls.Add(this.btnSaveProf);
            this.Controls.Add(this.btnCancleProf);
            this.Controls.Add(this.lblChattnamn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Profile";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "Profile";
            pHeader.ResumeLayout(false);
            pHeader2.ResumeLayout(false);
            pHeader2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpbxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbxChatName;
        private System.Windows.Forms.Label lblChattnamn;
        private System.Windows.Forms.Button btnCancleProf;
        private System.Windows.Forms.Label lblProfil;
        private System.Windows.Forms.Button btnSaveProf;
        private Components.RoundPicturebox rpbxImage;
        private System.Windows.Forms.OpenFileDialog dlgOpenImage;
        private System.Windows.Forms.Button btnLogout;
    }
}