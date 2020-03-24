namespace Chay.Components
{
    partial class ConnectionDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.rpbxStatus = new Chay.Components.RoundPicturebox();
            ((System.ComponentModel.ISupportInitialize)(this.rpbxStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Uppkopplad";
            // 
            // rpbxStatus
            // 
            this.rpbxStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rpbxStatus.BackColor = System.Drawing.Color.SeaGreen;
            this.rpbxStatus.Location = new System.Drawing.Point(135, 11);
            this.rpbxStatus.Name = "rpbxStatus";
            this.rpbxStatus.Size = new System.Drawing.Size(20, 20);
            this.rpbxStatus.TabIndex = 6;
            this.rpbxStatus.TabStop = false;
            // 
            // ConnectionDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rpbxStatus);
            this.Controls.Add(this.label2);
            this.Name = "ConnectionDisplay";
            this.Size = new System.Drawing.Size(175, 46);
            ((System.ComponentModel.ISupportInitialize)(this.rpbxStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private RoundPicturebox rpbxStatus;
    }
}
