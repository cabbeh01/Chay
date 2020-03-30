namespace Chay.Forms
{
    partial class ServerManager
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
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbxOut = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbxIp = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbxServername = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxPickServer = new System.Windows.Forms.GroupBox();
            this.gbxServerlist = new System.Windows.Forms.GroupBox();
            this.btnServerDown = new System.Windows.Forms.Button();
            this.btnServerUp = new System.Windows.Forms.Button();
            this.pHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbxPickServer.SuspendLayout();
            this.gbxServerlist.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.pHeader.Controls.Add(this.label5);
            this.pHeader.Controls.Add(this.panel3);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(2, 2);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(632, 63);
            this.pHeader.TabIndex = 2;
            this.pHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.pHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myriad Pro Cond", 25.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(229, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 40);
            this.label5.TabIndex = 18;
            this.label5.Text = "Serverhanterare";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(570, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(58, 28);
            this.panel3.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnClose.Location = new System.Drawing.Point(8, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 26);
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Location = new System.Drawing.Point(88, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 26);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbxOut
            // 
            this.lbxOut.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxOut.FormattingEnabled = true;
            this.lbxOut.ItemHeight = 15;
            this.lbxOut.Location = new System.Drawing.Point(20, 42);
            this.lbxOut.Name = "lbxOut";
            this.lbxOut.Size = new System.Drawing.Size(217, 274);
            this.lbxOut.TabIndex = 8;
            this.lbxOut.SelectedIndexChanged += new System.EventHandler(this.lbxOut_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnAdd.Location = new System.Drawing.Point(20, 322);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 24);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnRemove.Location = new System.Drawing.Point(56, 322);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(30, 24);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "-";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.tbxIp);
            this.panel2.Location = new System.Drawing.Point(20, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 33);
            this.panel2.TabIndex = 12;
            // 
            // tbxIp
            // 
            this.tbxIp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIp.Location = new System.Drawing.Point(20, 8);
            this.tbxIp.Name = "tbxIp";
            this.tbxIp.Size = new System.Drawing.Size(159, 15);
            this.tbxIp.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.tbxPort);
            this.panel1.Location = new System.Drawing.Point(229, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(96, 33);
            this.panel1.TabIndex = 13;
            // 
            // tbxPort
            // 
            this.tbxPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPort.Location = new System.Drawing.Point(20, 8);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(55, 15);
            this.tbxPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myriad Pro Cond", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(17, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "IP-Adress";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myriad Pro Cond", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(226, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myriad Pro Cond", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(17, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Servernamn";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.tbxServername);
            this.panel4.Location = new System.Drawing.Point(20, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 33);
            this.panel4.TabIndex = 15;
            // 
            // tbxServername
            // 
            this.tbxServername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxServername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxServername.Location = new System.Drawing.Point(20, 8);
            this.tbxServername.Name = "tbxServername";
            this.tbxServername.Size = new System.Drawing.Size(159, 15);
            this.tbxServername.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnSave.Location = new System.Drawing.Point(20, 172);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 31);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Spara";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbxPickServer
            // 
            this.gbxPickServer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbxPickServer.Controls.Add(this.label4);
            this.gbxPickServer.Controls.Add(this.btnSave);
            this.gbxPickServer.Controls.Add(this.panel2);
            this.gbxPickServer.Controls.Add(this.panel1);
            this.gbxPickServer.Controls.Add(this.label3);
            this.gbxPickServer.Controls.Add(this.label1);
            this.gbxPickServer.Controls.Add(this.panel4);
            this.gbxPickServer.Enabled = false;
            this.gbxPickServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxPickServer.Font = new System.Drawing.Font("Myriad Pro Cond", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPickServer.ForeColor = System.Drawing.SystemColors.Window;
            this.gbxPickServer.Location = new System.Drawing.Point(290, 71);
            this.gbxPickServer.Name = "gbxPickServer";
            this.gbxPickServer.Size = new System.Drawing.Size(335, 224);
            this.gbxPickServer.TabIndex = 18;
            this.gbxPickServer.TabStop = false;
            this.gbxPickServer.Text = "Vald server";
            // 
            // gbxServerlist
            // 
            this.gbxServerlist.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbxServerlist.Controls.Add(this.btnServerUp);
            this.gbxServerlist.Controls.Add(this.btnServerDown);
            this.gbxServerlist.Controls.Add(this.lbxOut);
            this.gbxServerlist.Controls.Add(this.btnRemove);
            this.gbxServerlist.Controls.Add(this.btnAdd);
            this.gbxServerlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxServerlist.Font = new System.Drawing.Font("Myriad Pro Cond", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxServerlist.ForeColor = System.Drawing.SystemColors.Window;
            this.gbxServerlist.Location = new System.Drawing.Point(19, 71);
            this.gbxServerlist.Name = "gbxServerlist";
            this.gbxServerlist.Size = new System.Drawing.Size(265, 373);
            this.gbxServerlist.TabIndex = 19;
            this.gbxServerlist.TabStop = false;
            this.gbxServerlist.Text = "Serverar";
            // 
            // btnServerDown
            // 
            this.btnServerDown.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnServerDown.FlatAppearance.BorderSize = 0;
            this.btnServerDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnServerDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServerDown.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnServerDown.Location = new System.Drawing.Point(207, 322);
            this.btnServerDown.Name = "btnServerDown";
            this.btnServerDown.Size = new System.Drawing.Size(30, 24);
            this.btnServerDown.TabIndex = 11;
            this.btnServerDown.Text = "↓";
            this.btnServerDown.UseVisualStyleBackColor = false;
            this.btnServerDown.Click += new System.EventHandler(this.btnServerDown_Click);
            // 
            // btnServerUp
            // 
            this.btnServerUp.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnServerUp.FlatAppearance.BorderSize = 0;
            this.btnServerUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnServerUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServerUp.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnServerUp.Location = new System.Drawing.Point(171, 322);
            this.btnServerUp.Name = "btnServerUp";
            this.btnServerUp.Size = new System.Drawing.Size(30, 24);
            this.btnServerUp.TabIndex = 12;
            this.btnServerUp.Text = "↑";
            this.btnServerUp.UseVisualStyleBackColor = false;
            this.btnServerUp.Click += new System.EventHandler(this.btnServerUp_Click);
            // 
            // ServerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(636, 475);
            this.Controls.Add(this.gbxServerlist);
            this.Controls.Add(this.gbxPickServer);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServerManager";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "ServerManager";
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.gbxPickServer.ResumeLayout(false);
            this.gbxPickServer.PerformLayout();
            this.gbxServerlist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lbxOut;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbxIp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbxServername;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbxPickServer;
        private System.Windows.Forms.GroupBox gbxServerlist;
        private System.Windows.Forms.Button btnServerUp;
        private System.Windows.Forms.Button btnServerDown;
    }
}