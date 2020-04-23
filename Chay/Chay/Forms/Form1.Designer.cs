namespace Chay
{
    partial class Form1
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Kalle");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Lena");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Klas");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Serv 1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Serv 2");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Serv 3");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Serv 4");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pHeader = new System.Windows.Forms.Panel();
            this.btnMiniMize = new System.Windows.Forms.Button();
            this.btnMaxMize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnServermanager = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.Label();
            this.twServers = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRemainingWords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cDConnected = new Chay.Components.ConnectionDisplay();
            this.lblNameServer = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.conversationCtrl = new Warecast.ControlsSuite.ConversationCtrl();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbxSend = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.pHeader.Controls.Add(this.btnMiniMize);
            this.pHeader.Controls.Add(this.btnMaxMize);
            this.pHeader.Controls.Add(this.btnExit);
            this.pHeader.Controls.Add(this.lblUser);
            this.pHeader.Controls.Add(this.btnProfile);
            this.pHeader.Controls.Add(this.btnSettings);
            this.pHeader.Controls.Add(this.btnServermanager);
            this.pHeader.Controls.Add(this.Logo);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(822, 63);
            this.pHeader.TabIndex = 0;
            this.pHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PHeader_MouseDown);
            this.pHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            // 
            // btnMiniMize
            // 
            this.btnMiniMize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMiniMize.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnMiniMize.FlatAppearance.BorderSize = 0;
            this.btnMiniMize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMiniMize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiniMize.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMiniMize.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMiniMize.Location = new System.Drawing.Point(696, 0);
            this.btnMiniMize.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnMiniMize.Name = "btnMiniMize";
            this.btnMiniMize.Size = new System.Drawing.Size(42, 27);
            this.btnMiniMize.TabIndex = 12;
            this.btnMiniMize.Text = "🗕";
            this.btnMiniMize.UseVisualStyleBackColor = false;
            this.btnMiniMize.Click += new System.EventHandler(this.btnMiniMize_Click);
            // 
            // btnMaxMize
            // 
            this.btnMaxMize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaxMize.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnMaxMize.FlatAppearance.BorderSize = 0;
            this.btnMaxMize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMaxMize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxMize.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxMize.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMaxMize.Location = new System.Drawing.Point(738, 0);
            this.btnMaxMize.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnMaxMize.Name = "btnMaxMize";
            this.btnMaxMize.Size = new System.Drawing.Size(42, 27);
            this.btnMaxMize.TabIndex = 11;
            this.btnMaxMize.Text = "🗖";
            this.btnMaxMize.UseVisualStyleBackColor = false;
            this.btnMaxMize.Click += new System.EventHandler(this.btnMaxMize_Click);
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
            this.btnExit.Location = new System.Drawing.Point(780, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(42, 27);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.SteelBlue;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblUser.Location = new System.Drawing.Point(643, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUser.Size = new System.Drawing.Size(31, 15);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "user";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.SteelBlue;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProfile.Location = new System.Drawing.Point(310, 7);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(110, 56);
            this.btnProfile.TabIndex = 9;
            this.btnProfile.Text = "Profil";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSettings.Location = new System.Drawing.Point(200, 7);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(110, 56);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "Inställningar";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnServermanager
            // 
            this.btnServermanager.BackColor = System.Drawing.Color.SteelBlue;
            this.btnServermanager.FlatAppearance.BorderSize = 0;
            this.btnServermanager.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnServermanager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServermanager.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServermanager.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnServermanager.Location = new System.Drawing.Point(90, 7);
            this.btnServermanager.Name = "btnServermanager";
            this.btnServermanager.Size = new System.Drawing.Size(110, 56);
            this.btnServermanager.TabIndex = 7;
            this.btnServermanager.Text = "Server Hanterare";
            this.btnServermanager.UseVisualStyleBackColor = false;
            this.btnServermanager.Click += new System.EventHandler(this.BtnServermanager_Click);
            // 
            // Logo
            // 
            this.Logo.AutoSize = true;
            this.Logo.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logo.Location = new System.Drawing.Point(13, 13);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(53, 25);
            this.Logo.TabIndex = 3;
            this.Logo.Text = "Chay";
            // 
            // twServers
            // 
            this.twServers.BackColor = System.Drawing.Color.LightSteelBlue;
            this.twServers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.twServers.Dock = System.Windows.Forms.DockStyle.Left;
            this.twServers.Location = new System.Drawing.Point(10, 35);
            this.twServers.Name = "twServers";
            treeNode1.Name = "Node4";
            treeNode1.Text = "Kalle";
            treeNode2.Name = "Node6";
            treeNode2.Text = "Lena";
            treeNode3.Name = "Node7";
            treeNode3.Text = "Klas";
            treeNode4.Name = "Node0";
            treeNode4.Text = "Serv 1";
            treeNode5.Name = "Node1";
            treeNode5.Text = "Serv 2";
            treeNode6.Name = "Node0";
            treeNode6.Text = "Serv 3";
            treeNode7.Name = "Node1";
            treeNode7.Text = "Serv 4";
            this.twServers.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            this.twServers.ShowLines = false;
            this.twServers.ShowPlusMinus = false;
            this.twServers.ShowRootLines = false;
            this.twServers.Size = new System.Drawing.Size(200, 402);
            this.twServers.TabIndex = 1;
            this.twServers.DoubleClick += new System.EventHandler(this.twServers_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lblRemainingWords);
            this.panel1.Controls.Add(this.twServers);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(200, 437);
            this.panel1.TabIndex = 2;
            // 
            // lblRemainingWords
            // 
            this.lblRemainingWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemainingWords.AutoSize = true;
            this.lblRemainingWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingWords.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblRemainingWords.Location = new System.Drawing.Point(149, 412);
            this.lblRemainingWords.Name = "lblRemainingWords";
            this.lblRemainingWords.Size = new System.Drawing.Size(48, 25);
            this.lblRemainingWords.TabIndex = 5;
            this.lblRemainingWords.Text = "504";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(40, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(122, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Servrar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.cDConnected);
            this.panel2.Controls.Add(this.lblNameServer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(200, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 101);
            this.panel2.TabIndex = 3;
            // 
            // cDConnected
            // 
            this.cDConnected.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cDConnected.Location = new System.Drawing.Point(462, 53);
            this.cDConnected.Name = "cDConnected";
            this.cDConnected.Size = new System.Drawing.Size(172, 45);
            this.cDConnected.TabIndex = 4;
            // 
            // lblNameServer
            // 
            this.lblNameServer.AutoSize = true;
            this.lblNameServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameServer.Location = new System.Drawing.Point(22, 16);
            this.lblNameServer.Name = "lblNameServer";
            this.lblNameServer.Size = new System.Drawing.Size(63, 25);
            this.lblNameServer.TabIndex = 3;
            this.lblNameServer.Text = "None";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel5.Controls.Add(this.conversationCtrl);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(200, 164);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(622, 262);
            this.panel5.TabIndex = 8;
            // 
            // conversationCtrl
            // 
            this.conversationCtrl.BackColor = System.Drawing.Color.Transparent;
            this.conversationCtrl.BalloonBackColor = System.Drawing.Color.SteelBlue;
            this.conversationCtrl.BalloonTextPadding = new System.Windows.Forms.Padding(10);
            this.conversationCtrl.DataSource = null;
            this.conversationCtrl.DateColumnName = "";
            this.conversationCtrl.DateTimeRegionHeight = ((uint)(20u));
            this.conversationCtrl.DateTimeTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.conversationCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conversationCtrl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conversationCtrl.IdColumnName = "";
            this.conversationCtrl.IsIncomingColumnName = "";
            this.conversationCtrl.Location = new System.Drawing.Point(0, 0);
            this.conversationCtrl.LongTimeSett = false;
            this.conversationCtrl.Margin = new System.Windows.Forms.Padding(4);
            this.conversationCtrl.MeBalloonPadding = new System.Windows.Forms.Padding(10, 20, 20, 10);
            this.conversationCtrl.MeCellPadding = new System.Windows.Forms.Padding(10);
            this.conversationCtrl.MessageColumnName = "";
            this.conversationCtrl.MessageToDateTimeVerticalIndent = 10;
            this.conversationCtrl.MeText = "Mig";
            this.conversationCtrl.MinimalBalloonWidth = 250;
            this.conversationCtrl.Name = "conversationCtrl";
            this.conversationCtrl.RemoteBalloonPadding = new System.Windows.Forms.Padding(20, 20, 10, 10);
            this.conversationCtrl.RemoteCellPadding = new System.Windows.Forms.Padding(10);
            this.conversationCtrl.RemoteText = "Du";
            this.conversationCtrl.Size = new System.Drawing.Size(622, 262);
            this.conversationCtrl.TabIndex = 8;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSend.Location = new System.Drawing.Point(515, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(107, 74);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Skicka";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbxSend
            // 
            this.tbxSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSend.Location = new System.Drawing.Point(0, 0);
            this.tbxSend.MaxLength = 512;
            this.tbxSend.Multiline = true;
            this.tbxSend.Name = "tbxSend";
            this.tbxSend.Size = new System.Drawing.Size(515, 74);
            this.tbxSend.TabIndex = 4;
            this.tbxSend.TextChanged += new System.EventHandler(this.tbxSend_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.tbxSend);
            this.panel4.Controls.Add(this.btnSend);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(200, 426);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(622, 74);
            this.panel4.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(822, 500);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pHeader);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 390);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.TreeView twServers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Logo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNameServer;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnServermanager;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbxSend;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Panel panel4;
        private Components.ConnectionDisplay cDConnected;
        private Warecast.ControlsSuite.ConversationCtrl conversationCtrl;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMiniMize;
        private System.Windows.Forms.Button btnMaxMize;
        private System.Windows.Forms.Label lblRemainingWords;
    }
}

