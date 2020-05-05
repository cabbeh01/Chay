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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerManager));
            this.pHeader = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblServerhanterare = new System.Windows.Forms.Label();
            this.lbxOut = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbxIp = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbxServername = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxPickServer = new System.Windows.Forms.GroupBox();
            this.gbxServerlist = new System.Windows.Forms.GroupBox();
            this.btnServerUp = new System.Windows.Forms.Button();
            this.btnServerDown = new System.Windows.Forms.Button();
            this.pHeader.SuspendLayout();
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
            this.pHeader.Controls.Add(this.btnExit);
            this.pHeader.Controls.Add(this.lblServerhanterare);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(2, 2);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(632, 63);
            this.pHeader.TabIndex = 2;
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
            this.btnExit.Location = new System.Drawing.Point(590, -1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(42, 27);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // lblServerhanterare
            // 
            this.lblServerhanterare.AutoSize = true;
            this.lblServerhanterare.Font = new System.Drawing.Font("Myriad Pro Cond", 25.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerhanterare.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblServerhanterare.Location = new System.Drawing.Point(229, 10);
            this.lblServerhanterare.Name = "lblServerhanterare";
            this.lblServerhanterare.Size = new System.Drawing.Size(183, 40);
            this.lblServerhanterare.TabIndex = 18;
            this.lblServerhanterare.Text = "Serverhanterare";
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
            this.lbxOut.SelectedIndexChanged += new System.EventHandler(this.LbxOut_SelectedIndexChanged);
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
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
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
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
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
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("Myriad Pro Cond", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblIP.Location = new System.Drawing.Point(17, 107);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(72, 25);
            this.lblIP.TabIndex = 14;
            this.lblIP.Text = "IP-Adress";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Myriad Pro Cond", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPort.Location = new System.Drawing.Point(226, 107);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 25);
            this.lblPort.TabIndex = 15;
            this.lblPort.Text = "Port";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Myriad Pro Cond", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblServer.Location = new System.Drawing.Point(17, 42);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(93, 25);
            this.lblServer.TabIndex = 16;
            this.lblServer.Text = "Servernamn";
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
            this.tbxServername.MaxLength = 25;
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
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // gbxPickServer
            // 
            this.gbxPickServer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbxPickServer.Controls.Add(this.lblServer);
            this.gbxPickServer.Controls.Add(this.btnSave);
            this.gbxPickServer.Controls.Add(this.panel2);
            this.gbxPickServer.Controls.Add(this.panel1);
            this.gbxPickServer.Controls.Add(this.lblPort);
            this.gbxPickServer.Controls.Add(this.lblIP);
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
            this.btnServerUp.Click += new System.EventHandler(this.BtnServerUp_Click);
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
            this.btnServerDown.Click += new System.EventHandler(this.BtnServerDown_Click);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServerManager";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "ServerManager";
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
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
        private System.Windows.Forms.ListBox lbxOut;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbxIp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbxServername;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblServerhanterare;
        private System.Windows.Forms.GroupBox gbxPickServer;
        private System.Windows.Forms.GroupBox gbxServerlist;
        private System.Windows.Forms.Button btnServerUp;
        private System.Windows.Forms.Button btnServerDown;
        private System.Windows.Forms.Button btnExit;
    }
}