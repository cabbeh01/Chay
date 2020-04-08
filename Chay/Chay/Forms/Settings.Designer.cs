namespace Chay
{
    partial class Settings
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
            this.pHeader = new System.Windows.Forms.Panel();
            this.lblInstallningar = new System.Windows.Forms.Label();
            this.lblMessagecolor = new System.Windows.Forms.Label();
            this.cbxChatColor = new System.Windows.Forms.ComboBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTimestamp = new System.Windows.Forms.Label();
            this.cbxTimeFormat = new System.Windows.Forms.ComboBox();
            this.pHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.pHeader.Controls.Add(this.lblInstallningar);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(2, 2);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(405, 63);
            this.pHeader.TabIndex = 3;
            this.pHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PHeader_MouseDown);
            this.pHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PHeader_MouseMove);
            // 
            // lblInstallningar
            // 
            this.lblInstallningar.AutoSize = true;
            this.lblInstallningar.Font = new System.Drawing.Font("Myriad Pro Cond", 25.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallningar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblInstallningar.Location = new System.Drawing.Point(130, 10);
            this.lblInstallningar.Name = "lblInstallningar";
            this.lblInstallningar.Size = new System.Drawing.Size(149, 40);
            this.lblInstallningar.TabIndex = 8;
            this.lblInstallningar.Text = "Inställningar";
            // 
            // lblMessagecolor
            // 
            this.lblMessagecolor.AutoSize = true;
            this.lblMessagecolor.Font = new System.Drawing.Font("Myriad Pro Cond", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessagecolor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMessagecolor.Location = new System.Drawing.Point(133, 97);
            this.lblMessagecolor.Name = "lblMessagecolor";
            this.lblMessagecolor.Size = new System.Drawing.Size(154, 32);
            this.lblMessagecolor.TabIndex = 6;
            this.lblMessagecolor.Text = "Meddelandefärg";
            // 
            // cbxChatColor
            // 
            this.cbxChatColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChatColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxChatColor.FormattingEnabled = true;
            this.cbxChatColor.Location = new System.Drawing.Point(137, 140);
            this.cbxChatColor.Name = "cbxChatColor";
            this.cbxChatColor.Size = new System.Drawing.Size(140, 21);
            this.cbxChatColor.TabIndex = 7;
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancle.FlatAppearance.BorderSize = 0;
            this.btnCancle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancle.Location = new System.Drawing.Point(127, 344);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 43);
            this.btnCancle.TabIndex = 10;
            this.btnCancle.Text = "Avbryt";
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(208, 344);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 43);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Spara";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.AutoSize = true;
            this.lblTimestamp.Font = new System.Drawing.Font("Myriad Pro Cond", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimestamp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTimestamp.Location = new System.Drawing.Point(133, 187);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(106, 32);
            this.lblTimestamp.TabIndex = 12;
            this.lblTimestamp.Text = "Tidsformat";
            // 
            // cbxTimeFormat
            // 
            this.cbxTimeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTimeFormat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxTimeFormat.FormattingEnabled = true;
            this.cbxTimeFormat.Location = new System.Drawing.Point(137, 222);
            this.cbxTimeFormat.Name = "cbxTimeFormat";
            this.cbxTimeFormat.Size = new System.Drawing.Size(140, 21);
            this.cbxTimeFormat.TabIndex = 13;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(409, 403);
            this.Controls.Add(this.cbxTimeFormat);
            this.Controls.Add(this.lblTimestamp);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.cbxChatColor);
            this.Controls.Add(this.lblMessagecolor);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "Settings";
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label lblMessagecolor;
        private System.Windows.Forms.ComboBox cbxChatColor;
        private System.Windows.Forms.Label lblInstallningar;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTimestamp;
        private System.Windows.Forms.ComboBox cbxTimeFormat;
    }
}