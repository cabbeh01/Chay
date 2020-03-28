namespace Warecast.ControlsSuite
{
    partial class ConversationCtrl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridConversationMessages = new System.Windows.Forms.DataGridView();
            this.LeftIndentCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageBalloonOwnerDrawColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RightIndentCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridConversationMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // gridConversationMessages
            // 
            this.gridConversationMessages.AllowUserToAddRows = false;
            this.gridConversationMessages.AllowUserToDeleteRows = false;
            this.gridConversationMessages.AllowUserToResizeColumns = false;
            this.gridConversationMessages.AllowUserToResizeRows = false;
            this.gridConversationMessages.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.gridConversationMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridConversationMessages.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridConversationMessages.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.gridConversationMessages.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridConversationMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridConversationMessages.ColumnHeadersVisible = false;
            this.gridConversationMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LeftIndentCol,
            this.MessageBalloonOwnerDrawColumn,
            this.RightIndentCol});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridConversationMessages.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridConversationMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridConversationMessages.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridConversationMessages.Location = new System.Drawing.Point(0, 0);
            this.gridConversationMessages.Name = "gridConversationMessages";
            this.gridConversationMessages.ReadOnly = true;
            this.gridConversationMessages.RowHeadersVisible = false;
            this.gridConversationMessages.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridConversationMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridConversationMessages.ShowCellErrors = false;
            this.gridConversationMessages.ShowEditingIcon = false;
            this.gridConversationMessages.ShowRowErrors = false;
            this.gridConversationMessages.Size = new System.Drawing.Size(623, 186);
            this.gridConversationMessages.TabIndex = 63;
            this.gridConversationMessages.VirtualMode = true;
            this.gridConversationMessages.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridConversationMessages_CellPainting);
            this.gridConversationMessages.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gridConversationMessages_CellValueNeeded);
            this.gridConversationMessages.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridConversationMessages_NewRowNeeded);
            this.gridConversationMessages.RowHeightInfoNeeded += new System.Windows.Forms.DataGridViewRowHeightInfoNeededEventHandler(this.gridConversationMessages_RowHeightInfoNeeded);
            this.gridConversationMessages.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridConversationMessages_Scroll);
            // 
            // LeftIndentCol
            // 
            this.LeftIndentCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.LeftIndentCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.LeftIndentCol.HeaderText = "Left Indent";
            this.LeftIndentCol.Name = "LeftIndentCol";
            this.LeftIndentCol.ReadOnly = true;
            this.LeftIndentCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LeftIndentCol.Width = 80;
            // 
            // MessageBalloonOwnerDrawColumn
            // 
            this.MessageBalloonOwnerDrawColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.MessageBalloonOwnerDrawColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.MessageBalloonOwnerDrawColumn.HeaderText = "Balloon Ownerdraw";
            this.MessageBalloonOwnerDrawColumn.Name = "MessageBalloonOwnerDrawColumn";
            this.MessageBalloonOwnerDrawColumn.ReadOnly = true;
            // 
            // RightIndentCol
            // 
            this.RightIndentCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.RightIndentCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.RightIndentCol.HeaderText = "Right Indent";
            this.RightIndentCol.Name = "RightIndentCol";
            this.RightIndentCol.ReadOnly = true;
            this.RightIndentCol.Width = 80;
            // 
            // ConversationCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gridConversationMessages);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConversationCtrl";
            this.Size = new System.Drawing.Size(623, 186);
            ((System.ComponentModel.ISupportInitialize)(this.gridConversationMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gridConversationMessages;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeftIndentCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageBalloonOwnerDrawColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RightIndentCol;
    }
}
