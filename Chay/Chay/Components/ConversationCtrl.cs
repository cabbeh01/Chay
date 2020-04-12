using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Collections;
using System.Security.Cryptography;


namespace Warecast.ControlsSuite
{
    public partial class ConversationCtrl : UserControl
    {
        #region public properties
        //---------------------------------------------------------------------------------------------------
        DataTable m_DataSource = null;
        [Browsable(true)]
        public DataTable DataSource
        {
          get { return m_DataSource; }
          set { m_DataSource = value; }
        }
        //---------------------------------------------------------------------------------------------------
        String m_IdColumnName = string.Empty;
        public String IdColumnName
        {
            get { return m_IdColumnName; }
            set { m_IdColumnName = value.Trim(); }
        }
        //---------------------------------------------------------------------------------------------------
        String m_MessageColumnName = string.Empty;
        public String MessageColumnName
        {
            get { return m_MessageColumnName; }
            set { m_MessageColumnName = value.Trim(); }
        }
        //---------------------------------------------------------------------------------------------------
        String m_DateColumnName = string.Empty;
        public String DateColumnName
        {
            get { return m_DateColumnName; }
            set { m_DateColumnName = value.Trim(); }
        }
        //---------------------------------------------------------------------------------------------------
        String m_IsIncomingColumnName = string.Empty;
        public String IsIncomingColumnName
        {
            get { return m_IsIncomingColumnName; }
            set { m_IsIncomingColumnName = value.Trim(); }
        }
        //---------------------------------------------------------------------------------------------------
        [Browsable(true)]
        Padding m_MeCellPadding = new Padding(10, 10, 10, 10);
        public Padding MeCellPadding
        {
          get { return m_MeCellPadding; }
          set { m_MeCellPadding = value; }
        }
        //---------------------------------------------------------------------------------------------------
        [Browsable(true)]
        Padding m_RemoteCellPadding = new Padding(10, 10, 10, 10);
        public Padding RemoteCellPadding
        {
          get { return m_RemoteCellPadding; }
          set { m_RemoteCellPadding = value; }
        }
        //---------------------------------------------------------------------------------------------------
        [Browsable(true)]
        Padding m_MeBalloonPadding = new Padding(10, 20, 20, 10);
        public Padding MeBalloonPadding
        {
          get { return m_MeBalloonPadding; }
          set { m_MeBalloonPadding = value; }
        }
        //---------------------------------------------------------------------------------------------------
        [Browsable(true)]
        Padding m_RemoteBalloonPadding = new Padding(20, 20, 10, 10);
        public Padding RemoteBalloonPadding
        {
          get { return m_RemoteBalloonPadding; }
          set { m_RemoteBalloonPadding = value; }
        }
        //---------------------------------------------------------------------------------------------------
        [Browsable(true)]
        Padding m_BalloonTextPadding = new Padding(10, 10, 10, 10);
        public Padding BalloonTextPadding
        {
          get { return m_BalloonTextPadding; }
          set { m_BalloonTextPadding = value; }
        }
        //---------------------------------------------------------------------------------------------------
        uint m_DateTimeRegionHeight = 20;
        public uint DateTimeRegionHeight
        {
          get { return m_DateTimeRegionHeight; }
          set { m_DateTimeRegionHeight = value; }
        }
        //---------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------------
        String m_MeText = "Jag";
        public String MeText
        {
            get { return m_MeText; }
            set { m_MeText = value; }
        }
        //---------------------------------------------------------------------------------------------------
        String m_RemoteText = "Du";
        public String RemoteText
        {
            get { return m_RemoteText; }
            set { m_RemoteText = value; }
        }
        //---------------------------------------------------------------------------------------------------
        [Browsable(true)]
        Color m_DateTimeTextColor = Color.FromArgb(225, 243, 243, 243);
        public Color DateTimeTextColor
        {
          get { return m_DateTimeTextColor; }
          set { m_DateTimeTextColor = value; }
        }
        //---------------------------------------------------------------------------------------------------
        [Browsable(true)]
        Color m_BalloonBackColor = Color.Orange;
        public Color BalloonBackColor
        {
          get { return m_BalloonBackColor; }
          set { m_BalloonBackColor = value; }
        }
        //---------------------------------------------------------------------------------------------------
        int m_MinimalBalloonWidth = 250;
        public int MinimalBalloonWidth
        {
          get { return m_MinimalBalloonWidth; }
          set { m_MinimalBalloonWidth = value; }
        }
        //---------------------------------------------------------------------------------------------------
        int m_MessageToDateTimeVerticalIndent = 10;
        public int MessageToDateTimeVerticalIndent
        {
          get { return m_MessageToDateTimeVerticalIndent; }
          set { m_MessageToDateTimeVerticalIndent = value; }
        }
        #endregion

        #region public methods
        //---------------------------------------------------------------------------------------------------
        public ConversationCtrl()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------------------------------------
        public bool Rebind()
        {
            if (!ValidateBinding())
                return false;

            gridConversationMessages.RowCount = 0;
            RefreshData();
            return true;
        }
        #endregion end public

        #region private methods
        //---------------------------------------------------------------------------------------------------
        private bool ValidateBinding()
        {
            if (m_DataSource == null ||
               m_IdColumnName == string.Empty ||
               m_MessageColumnName == string.Empty ||
               m_DateColumnName == string.Empty ||
               m_IsIncomingColumnName == string.Empty)
                return false;

            if (!m_DataSource.Columns.Contains(m_IdColumnName) ||
                !m_DataSource.Columns.Contains(m_MessageColumnName) ||
                !m_DataSource.Columns.Contains(m_DateColumnName) ||
                !m_DataSource.Columns.Contains(m_IsIncomingColumnName)) //one of the columns cannot be found
                return false;

            //verify types of columns to avoid crash
            if (m_DataSource.Columns[m_IdColumnName].DataType != typeof(uint) &&
                m_DataSource.Columns[m_IdColumnName].DataType != typeof(UInt16) &&
                m_DataSource.Columns[m_IdColumnName].DataType != typeof(UInt32) &&
                m_DataSource.Columns[m_IdColumnName].DataType != typeof(UInt64) &&
                m_DataSource.Columns[m_IdColumnName].DataType != typeof(Int16) &&
                m_DataSource.Columns[m_IdColumnName].DataType != typeof(Int32) &&
                m_DataSource.Columns[m_IdColumnName].DataType != typeof(Int64) &&
                m_DataSource.Columns[m_IdColumnName].DataType != typeof(ulong))
            {
                //TODO: add more numeric types if you need....
                //not unsigned number
                return false;
            }

            if (m_DataSource.Columns[m_MessageColumnName].DataType != typeof(String) &&
                m_DataSource.Columns[m_MessageColumnName].DataType != typeof(string))
            {
                //not a string
                return false;
            }

            if (m_DataSource.Columns[m_DateColumnName].DataType != typeof(DateTime))
            {
                //not a string
                return false;
            }

            if (m_DataSource.Columns[m_IsIncomingColumnName].DataType != typeof(bool) &&
                m_DataSource.Columns[m_IsIncomingColumnName].DataType != typeof(Boolean))
            {
                //not a boolean
                return false;
            }
            return true;
        }
        //---------------------------------------------------------------------------------------------------
        private void RefreshData()
        {
            //keep the row before refresh;
            gridConversationMessages.RowCount = 0;
            gridConversationMessages.Invalidate();
            int keepRowIndex = gridConversationMessages.FirstDisplayedScrollingRowIndex;

            gridConversationMessages.RowCount = m_DataSource.Rows.Count;
            if (keepRowIndex < 0 || keepRowIndex >= m_DataSource.Rows.Count)
            {
                keepRowIndex = m_DataSource.Rows.Count - 1;
            }
            if (keepRowIndex >= 0)
                gridConversationMessages.FirstDisplayedScrollingRowIndex = keepRowIndex;
        }
        //---------------------------------------------------------------------------------------------------

        /*     Send message to board
         * DataRow newRow = m_DataSource.NewRow();
            newRow[m_DateColumnName] = DateTime.Now;
            newRow[m_MessageColumnName] = txtMessage.Text;
            newRow[m_IsIncomingColumnName] = false;
            m_DataSource.Rows.Add(newRow);

            txtMessage.Clear();
            txtMessage.Focus();
            RefreshData();

            if (m_DataSource.Rows.Count > 0)
                gridConversationMessages.FirstDisplayedScrollingRowIndex = m_DataSource.Rows.Count - 1; //scroll to new message
                */

        //---------------------------------------------------------------------------------------------------
        #endregion private

        #region mesages grid virtual mode events and painting
        //---------------------------------------------------------------------------------------------------
        private int GetCalculateRowHeight(int rowIndex)
        {
            int rowHeight = 0;
            if (m_DataSource.Rows.Count == 0)
                return rowHeight;
            if (rowIndex >= m_DataSource.Rows.Count)
                return rowHeight;

            DataRow row = m_DataSource.Rows[rowIndex];
            bool isMessageIncoming = (bool)row[m_IsIncomingColumnName];
            String messageText = (String)row[m_MessageColumnName];

            Graphics graphicsCtxt = CreateGraphics();
            graphicsCtxt.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphicsCtxt.PixelOffsetMode = PixelOffsetMode.Half;

            //now measure text height...
            //get the message cell area...
            Rectangle paddedImageBounds = Rectangle.Empty;
            Font font = gridConversationMessages.Columns[1].DefaultCellStyle.Font;
            int columnCurrentWidth = gridConversationMessages.Columns[1].Width;
            
            //pad the widht
            int widthMargins = 0;
            int heightFullMargins = 0;
            if (isMessageIncoming)
            {
                widthMargins = (m_RemoteBalloonPadding.Right + m_RemoteBalloonPadding.Left);
                widthMargins += (m_BalloonTextPadding.Right + m_BalloonTextPadding.Left);
                heightFullMargins = (m_RemoteBalloonPadding.Top + m_RemoteBalloonPadding.Bottom);
                heightFullMargins += (m_BalloonTextPadding.Top + m_BalloonTextPadding.Bottom);
            }
            else
            {
                widthMargins = (m_MeBalloonPadding.Right + m_MeBalloonPadding.Left);
                widthMargins += (m_BalloonTextPadding.Right + m_BalloonTextPadding.Left);
                heightFullMargins = (m_RemoteBalloonPadding.Top + m_MeBalloonPadding.Bottom);
                heightFullMargins += (m_BalloonTextPadding.Top + m_BalloonTextPadding.Bottom);
            }

            columnCurrentWidth -= widthMargins;
            StringFormat stringFormat = new StringFormat(StringFormatFlags.NoClip);
            SizeF sizeForMeasure = new SizeF(columnCurrentWidth, 100000);
            SizeF sizef = graphicsCtxt.MeasureString(messageText, font, columnCurrentWidth, stringFormat);

            graphicsCtxt.Dispose();

            rowHeight = (int)sizef.Height + (int)m_DateTimeRegionHeight + heightFullMargins + m_MessageToDateTimeVerticalIndent;
            return rowHeight;
        }
        //---------------------------------------------------------------------------------------------------
        private void gridConversationMessages_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex>m_DataSource.Rows.Count - 1)
                return;

            e.Handled = true;

            Graphics graphicsCtxt = e.Graphics;
            graphicsCtxt.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle paddedImageBounds = Rectangle.Empty;
            Font font = gridConversationMessages.Columns[e.ColumnIndex].DefaultCellStyle.Font;
            graphicsCtxt.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphicsCtxt.PixelOffsetMode = PixelOffsetMode.Half;
            SolidBrush backBrush = new SolidBrush(gridConversationMessages.BackgroundColor);
            graphicsCtxt.FillRectangle(backBrush, e.CellBounds);

            DataRow row = m_DataSource.Rows[e.RowIndex];
            bool isMessageIncoming = (bool)row[m_IsIncomingColumnName];
            String messageText = (String)row[m_MessageColumnName];

            if (e.ColumnIndex == 0 || e.ColumnIndex == 2)
            {
                SolidBrush fontBrush = new SolidBrush(gridConversationMessages.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor);
                if (e.ColumnIndex == 0)
                {
                    if (!isMessageIncoming)
                    {
                        //first column is ME title / image 
                        paddedImageBounds = RectangleUtils.GetPaddedRectangle(e.CellBounds, m_MeCellPadding);
                        graphicsCtxt.DrawString(m_MeText, font, fontBrush, paddedImageBounds.Location);
                    }
                }
                else
                {
                    if (isMessageIncoming)
                    {
                        //third column is remote party title/image
                        StringFormat remoteStringFormat = new StringFormat();
                        remoteStringFormat.Alignment = StringAlignment.Far;
                        paddedImageBounds = RectangleUtils.GetPaddedRectangle(e.CellBounds, m_RemoteCellPadding);
                        graphicsCtxt.DrawString(m_RemoteText, font, fontBrush, paddedImageBounds, remoteStringFormat);
                    }
                }
                fontBrush.Dispose();
            }

            if (e.ColumnIndex == 1)
            {
                DateTime messageDateTime = (DateTime)row[m_DateColumnName];

                //second column is message balloon with date/time, message text, message states.
                SolidBrush fontBrush = new SolidBrush(gridConversationMessages.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor);
                Color balloonColor = balloonColor = m_BalloonBackColor;
                GraphicsPath balloonPath = null;
                Rectangle textRectangleExternal = new Rectangle();
                if (isMessageIncoming)
                    textRectangleExternal = RectangleUtils.GetPaddedRectangle(e.CellBounds, m_RemoteBalloonPadding);
                else
                    textRectangleExternal = RectangleUtils.GetPaddedRectangle(e.CellBounds, m_MeBalloonPadding);

                Rectangle textRectangle = RectangleUtils.GetPaddedRectangle(textRectangleExternal, m_BalloonTextPadding);

                RectangleF textRectangleF = new RectangleF(textRectangle.Location.X, textRectangle.Location.Y, textRectangle.Size.Width, textRectangle.Size.Height);
                int charFitter = 0, linesFilled = 0;
                StringFormat stringFormat = new StringFormat(StringFormatFlags.NoClip);
                SizeF sizef = e.Graphics.MeasureString(messageText, font, textRectangleF.Size, stringFormat);
                    
                //generate and fix and draw balloon to be closer to text
                if (isMessageIncoming)
                {
                    paddedImageBounds = RectangleUtils.GetPaddedRectangle(e.CellBounds, m_RemoteBalloonPadding);
                    int newWidth = (int)sizef.Width + m_BalloonTextPadding.Left + m_BalloonTextPadding.Right + 10;
                    if (paddedImageBounds.Width > newWidth)
                    {
                        if (newWidth < m_MinimalBalloonWidth)
                            newWidth = m_MinimalBalloonWidth;
                        paddedImageBounds.X += (paddedImageBounds.Width - newWidth);
                        paddedImageBounds.Width = newWidth;
                    }
                    balloonPath = RectangleUtils.Create(paddedImageBounds, 8, RectangleUtils.RectangleCorners.BottomLeft | RectangleUtils.RectangleCorners.BottomRight | RectangleUtils.RectangleCorners.TopLeft);
                        
                    //add triangle arrow
                    balloonPath.AddLine(new Point(paddedImageBounds.Right, paddedImageBounds.Top), new Point(e.CellBounds.Right, e.CellBounds.Top + m_RemoteBalloonPadding.Top));
                    balloonPath.AddLine(new Point(e.CellBounds.Right, e.CellBounds.Top + m_RemoteBalloonPadding.Top), new Point(paddedImageBounds.Right, paddedImageBounds.Top + m_RemoteBalloonPadding.Right));
                    balloonPath.CloseFigure();
                }
                else
                {
                    paddedImageBounds = RectangleUtils.GetPaddedRectangle(e.CellBounds, m_MeBalloonPadding);
                    int newWidth = (int)sizef.Width + m_BalloonTextPadding.Left + m_BalloonTextPadding.Right + 10;
                    if (paddedImageBounds.Width > newWidth)
                    {
                        paddedImageBounds.Width = newWidth;
                        if (paddedImageBounds.Width < m_MinimalBalloonWidth)
                            paddedImageBounds.Width = m_MinimalBalloonWidth;
                    }
                    balloonPath = new GraphicsPath();
                    balloonPath.StartFigure();
                    balloonPath.AddPath(RectangleUtils.Create(paddedImageBounds, 8, RectangleUtils.RectangleCorners.BottomLeft | RectangleUtils.RectangleCorners.BottomRight | RectangleUtils.RectangleCorners.TopRight), false);

                    //add triangle arrow
                    balloonPath.AddLine(paddedImageBounds.Location, new Point(e.CellBounds.Location.X, e.CellBounds.Location.Y + m_MeBalloonPadding.Top));
                    balloonPath.AddLine(new Point(e.CellBounds.Location.X, e.CellBounds.Location.Y + m_MeBalloonPadding.Top), new Point(paddedImageBounds.Location.X, paddedImageBounds.Location.Y + m_MeBalloonPadding.Left));
                    balloonPath.CloseFigure();
                }

                Region balloonRegion = null;
                balloonRegion = new System.Drawing.Region(balloonPath);
                SolidBrush balloonBrush = new SolidBrush(balloonColor);
                graphicsCtxt.FillRegion(balloonBrush, balloonRegion);

                textRectangle = RectangleUtils.GetPaddedRectangle(paddedImageBounds, m_BalloonTextPadding);
                textRectangleF = new RectangleF(textRectangle.Location.X, textRectangle.Location.Y, textRectangle.Size.Width, textRectangle.Size.Height);
                graphicsCtxt.DrawString(messageText, font, fontBrush, textRectangleF);


                //draw time in the right bottom part
                Brush dateTimeBrush = new SolidBrush(m_DateTimeTextColor);
                StringFormat dateStringFormat = new StringFormat(StringFormatFlags.NoWrap);
                dateStringFormat.Alignment = StringAlignment.Far;
                Rectangle dateTimeRectangle = RectangleUtils.GetPaddedRectangle(paddedImageBounds, m_BalloonTextPadding);
                dateTimeRectangle.Offset(0, dateTimeRectangle.Size.Height - (int)m_DateTimeRegionHeight);
                dateTimeRectangle.Size = new Size(dateTimeRectangle.Size.Width, (int)m_DateTimeRegionHeight);
                sizef = e.Graphics.MeasureString(messageDateTime.ToLongTimeString(), font, dateTimeRectangle.Size, dateStringFormat, out charFitter, out linesFilled);
                graphicsCtxt.DrawString(messageDateTime.ToLongTimeString(), font, dateTimeBrush, dateTimeRectangle, dateStringFormat);
                dateTimeBrush.Dispose();
                fontBrush.Dispose();
                balloonBrush.Dispose();
            }

            backBrush.Dispose();
        }
        //---------------------------------------------------------------------------------------------------
        private void gridConversationMessages_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (m_DataSource.Rows.Count == 0 || e.RowIndex<0 || e.RowIndex>=m_DataSource.Rows.Count)
                e.Value = uint.MaxValue;
            else
            {
                e.Value = m_DataSource.Rows[e.RowIndex]; //every column will contain just id for message. the rest is done on paint event
            }
        }
        //---------------------------------------------------------------------------------------------------
        private void gridConversationMessages_RowHeightInfoNeeded(object sender, DataGridViewRowHeightInfoNeededEventArgs e)
        {
            if (DesignMode)
                return;

            e.Height = GetCalculateRowHeight(e.RowIndex);
        }
        //---------------------------------------------------------------------------------------------------
        private void gridConversationMessages_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (DesignMode)
                return;
            return;
        }
        //---------------------------------------------------------------------------------------------------
        private void gridConversationMessages_Scroll(object sender, ScrollEventArgs e)
        {
            if (DesignMode)
                return;
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                if (e.NewValue >= m_DataSource.Rows.Count)
                {
                    if (m_DataSource.Rows.Count > 0)
                        e.NewValue = m_DataSource.Rows.Count - 1;
                    return;
                }
            }
        }
        //---------------------------------------------------------------------------------------------------
        #endregion 

        #region Rectangle Utils for drawing and calculation
        //---------------------------------------------------------------------------------------------------
        public abstract class RectangleUtils
        {
            //following code is not mine, I copied it from some place in internet and slightly modified it
            public enum RectangleCorners
            {
                None = 0, TopLeft = 1, TopRight = 2, BottomLeft = 4, BottomRight = 8,
                All = TopLeft | TopRight | BottomLeft | BottomRight
            }

            public static Rectangle GetPaddedRectangle(Rectangle rect, System.Windows.Forms.Padding pad)
            {
                return new Rectangle(rect.X + pad.Left,
                                      rect.Y + pad.Top,
                                      rect.Width - (pad.Left + pad.Right),
                                      rect.Height - (pad.Top + pad.Bottom));
            }
            //---------------------------------------------------------------------------------------------------
            public static GraphicsPath Create(int x, int y, int width, int height,
                                              int radius, RectangleCorners corners)
            {
                int xw = x + width;
                int yh = y + height;
                int xwr = xw - radius;
                int yhr = yh - radius;
                int xr = x + radius;
                int yr = y + radius;
                int r2 = radius * 2;
                int xwr2 = xw - r2;
                int yhr2 = yh - r2;

                GraphicsPath p = new GraphicsPath();
                p.StartFigure();

                //Top Left Corner
                if ((RectangleCorners.TopLeft & corners) == RectangleCorners.TopLeft)
                {
                    p.AddArc(x, y, r2, r2, 180, 90);
                }
                else
                {
                    p.AddLine(x, yr, x, y);
                    p.AddLine(x, y, xr, y);
                }

                //Top Edge
                p.AddLine(xr, y, xwr, y);

                //Top Right Corner
                if ((RectangleCorners.TopRight & corners) == RectangleCorners.TopRight)
                {
                    p.AddArc(xwr2, y, r2, r2, 270, 90);
                }
                else
                {
                    p.AddLine(xwr, y, xw, y);
                    p.AddLine(xw, y, xw, yr);
                }

                //Right Edge
                p.AddLine(xw, yr, xw, yhr);

                //Bottom Right Corner
                if ((RectangleCorners.BottomRight & corners) == RectangleCorners.BottomRight)
                {
                    p.AddArc(xwr2, yhr2, r2, r2, 0, 90);
                }
                else
                {
                    p.AddLine(xw, yhr, xw, yh);
                    p.AddLine(xw, yh, xwr, yh);
                }

                //Bottom Edge
                p.AddLine(xwr, yh, xr, yh);

                //Bottom Left Corner
                if ((RectangleCorners.BottomLeft & corners) == RectangleCorners.BottomLeft)
                {
                    p.AddArc(x, yhr2, r2, r2, 90, 90);
                }
                else
                {
                    p.AddLine(xr, yh, x, yh);
                    p.AddLine(x, yh, x, yhr);
                }

                //Left Edge
                p.AddLine(x, yhr, x, yr);

                p.CloseFigure();
                return p;
            }
            //---------------------------------------------------------------------------------------------------
            public static GraphicsPath Create(Rectangle rect, int radius, RectangleCorners c)
            { return Create(rect.X, rect.Y, rect.Width, rect.Height, radius, c); }
            //---------------------------------------------------------------------------------------------------
            public static GraphicsPath Create(int x, int y, int width, int height, int radius)
            { return Create(x, y, width, height, radius, RectangleCorners.All); }
            //---------------------------------------------------------------------------------------------------
            public static GraphicsPath Create(Rectangle rect, int radius)
            { return Create(rect.X, rect.Y, rect.Width, rect.Height, radius); }
            //---------------------------------------------------------------------------------------------------
            public static GraphicsPath Create(int x, int y, int width, int height)
            { return Create(x, y, width, height, 5); }
            //---------------------------------------------------------------------------------------------------
            public static GraphicsPath Create(Rectangle rect)
            { return Create(rect.X, rect.Y, rect.Width, rect.Height); }
            //---------------------------------------------------------------------------------------------------
        }
        #endregion 
    }
}
