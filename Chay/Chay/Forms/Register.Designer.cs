﻿namespace Chay
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.pHeader = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.lblRUser = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.plRepass = new System.Windows.Forms.Panel();
            this.tbxRepassword = new System.Windows.Forms.TextBox();
            this.lblRegPassre = new System.Windows.Forms.Label();
            this.lblRegister = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblShpass = new System.Windows.Forms.Label();
            this.bCbxShowPass = new Chay.BigCheckbox();
            this.pHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.plRepass.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.pHeader.Controls.Add(this.btnExit);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(2, 2);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(477, 63);
            this.pHeader.TabIndex = 10;
            this.pHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PHeader_MouseDown);
            this.pHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PHeader_MouseMove);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.IndianRed;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExit.Location = new System.Drawing.Point(435, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(42, 27);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.tbxUsername);
            this.panel2.Location = new System.Drawing.Point(179, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 33);
            this.panel2.TabIndex = 0;
            // 
            // tbxUsername
            // 
            this.tbxUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUsername.Location = new System.Drawing.Point(20, 8);
            this.tbxUsername.MaxLength = 30;
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(159, 15);
            this.tbxUsername.TabIndex = 0;
            // 
            // lblRUser
            // 
            this.lblRUser.AutoSize = true;
            this.lblRUser.Font = new System.Drawing.Font("Myriad Pro Cond", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRUser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblRUser.Location = new System.Drawing.Point(98, 142);
            this.lblRUser.Name = "lblRUser";
            this.lblRUser.Size = new System.Drawing.Size(79, 25);
            this.lblRUser.TabIndex = 8;
            this.lblRUser.Text = "Username";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.tbxPassword);
            this.panel1.Location = new System.Drawing.Point(179, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 33);
            this.panel1.TabIndex = 1;
            // 
            // tbxPassword
            // 
            this.tbxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassword.Location = new System.Drawing.Point(20, 8);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '•';
            this.tbxPassword.Size = new System.Drawing.Size(159, 15);
            this.tbxPassword.TabIndex = 0;
            this.tbxPassword.TextChanged += new System.EventHandler(this.TbxPassword_TextChanged);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Myriad Pro Cond", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPass.Location = new System.Drawing.Point(103, 179);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(72, 25);
            this.lblPass.TabIndex = 7;
            this.lblPass.Text = "Password";
            // 
            // plRepass
            // 
            this.plRepass.BackColor = System.Drawing.SystemColors.Window;
            this.plRepass.Controls.Add(this.tbxRepassword);
            this.plRepass.Location = new System.Drawing.Point(179, 215);
            this.plRepass.Name = "plRepass";
            this.plRepass.Size = new System.Drawing.Size(200, 33);
            this.plRepass.TabIndex = 2;
            // 
            // tbxRepassword
            // 
            this.tbxRepassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxRepassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRepassword.Location = new System.Drawing.Point(20, 8);
            this.tbxRepassword.Name = "tbxRepassword";
            this.tbxRepassword.PasswordChar = '•';
            this.tbxRepassword.Size = new System.Drawing.Size(159, 15);
            this.tbxRepassword.TabIndex = 0;
            this.tbxRepassword.TextChanged += new System.EventHandler(this.TbxRepassword_TextChanged);
            // 
            // lblRegPassre
            // 
            this.lblRegPassre.AutoSize = true;
            this.lblRegPassre.Font = new System.Drawing.Font("Myriad Pro Cond", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegPassre.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblRegPassre.Location = new System.Drawing.Point(82, 218);
            this.lblRegPassre.Name = "lblRegPassre";
            this.lblRegPassre.Size = new System.Drawing.Size(95, 25);
            this.lblRegPassre.TabIndex = 6;
            this.lblRegPassre.Text = "Re-Password";
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Font = new System.Drawing.Font("Myriad Pro Cond", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegister.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblRegister.Location = new System.Drawing.Point(193, 89);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(98, 38);
            this.lblRegister.TabIndex = 9;
            this.lblRegister.Text = "Register";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(246, 307);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 43);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(165, 307);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 43);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // lblShpass
            // 
            this.lblShpass.AutoSize = true;
            this.lblShpass.Font = new System.Drawing.Font("Myriad Pro Cond", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShpass.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblShpass.Location = new System.Drawing.Point(260, 253);
            this.lblShpass.Name = "lblShpass";
            this.lblShpass.Size = new System.Drawing.Size(97, 25);
            this.lblShpass.TabIndex = 11;
            this.lblShpass.Text = "Visa lösenord";
            // 
            // bCbxShowPass
            // 
            this.bCbxShowPass.Check = true;
            this.bCbxShowPass.Img = ((System.Drawing.Image)(resources.GetObject("bCbxShowPass.Img")));
            this.bCbxShowPass.Location = new System.Drawing.Point(359, 254);
            this.bCbxShowPass.Name = "bCbxShowPass";
            this.bCbxShowPass.Size = new System.Drawing.Size(20, 20);
            this.bCbxShowPass.TabIndex = 3;
            this.bCbxShowPass.Click += new System.EventHandler(this.BCbxShowPass_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(481, 377);
            this.Controls.Add(this.lblShpass);
            this.Controls.Add(this.bCbxShowPass);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblRegister);
            this.Controls.Add(this.plRepass);
            this.Controls.Add(this.lblRegPassre);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblRUser);
            this.Controls.Add(this.pHeader);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.pHeader.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.plRepass.ResumeLayout(false);
            this.plRepass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Label lblRUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Panel plRepass;
        private System.Windows.Forms.TextBox tbxRepassword;
        private System.Windows.Forms.Label lblRegPassre;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBack;
        private BigCheckbox bCbxShowPass;
        private System.Windows.Forms.Label lblShpass;
        private System.Windows.Forms.Button btnExit;
    }
}