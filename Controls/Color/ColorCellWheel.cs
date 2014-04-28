using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using SharpMap.Forms.Controls.Base;

namespace SharpMap.Forms.Controls.Color
{

    [Serializable]
    public class ColorCellWheel : ColorCellMatrix
    {
        private int _cellCount = 17;
        private Point[] _bigCellPoly;

        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        public ColorCellWheel()
        {
            Initialize();
            base.CellColumns = base.CellRows = _cellCount;
        }


        /// <summary>
        /// Function to find the <see cref="ColorCell"/> at the given <paramref name="color"/>.
        /// </summary>
        /// <param name="color">The color</param>
        /// <returns>The matching color cell or null</returns>
        protected override ColorCell FindColorCell(System.Drawing.Color color)
        {
            for (int row = 0; row < _cellCount; row++)
            {
                for (int col = 0; col < _cellCount; col++)
                {
                    if (Cells[row][col] != null)
                    {

                        if (Cells[row][col].FillColor == color)
                        {
                            return Cells[row][col];
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Event raised when the <see cref="CellCount"/> has changed
        /// </summary>
        public event EventHandler CellCountChanged;

        /// <summary>
        /// Event invoker for the <see cref="CellCountChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnCellCountChanged(EventArgs e)
        {
            if (CellCountChanged != null)
                CellCountChanged(this, e);

            Initialize();
        }

        /// <summary>
        /// Gets or sets a value indicating the number of cells displayed
        /// </summary>
        [Description("The number of color cells per axis")]
        [DefaultValue(17)]
        public int CellCount
        {
            get
            {
                return _cellCount;
            }
            set
            {
                value = Math.Max(3, value);
                if (value%2 == 0) value += 1;

                if (value == _cellCount)
                    return;

                _cellCount = value;
                base.CellColumns = base.CellRows = _cellCount;

                OnCellCountChanged(EventArgs.Empty);
            }           
        }

        /// <summary>
        /// Gets or sets a value indicating the <see cref="ColorCellStyle"/> of this control
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ColorCellStyle CellStyle { get { return base.CellStyle; } set { } }

        /// <summary>
        /// Gets or sets a value indicating the number of columns
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override int CellColumns { get { return base.CellColumns; } set{} }

        /// <summary>
        /// Gets or sets a value indicating the number of matrix rows
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override int CellRows { get { return base.CellColumns; } set {} }

        protected override void OnInitialize()
        {
            var interWidth = 2 * (int)(CellRadius * Math.Cos(MathUtility.DegToRad * 30.0));            
            var width = Convert.ToInt32(CellCount*interWidth);
            MinimumSize = new Size(width, width-interWidth); 
            
            Cells = CreateColorCells(CellCount, CellCount);

            var diameter = 2 * CellRadius;
            
            var matrixWidth = _cellCount  * interWidth;
            var matrixHeight = (int)(2 * CellRadius + (_cellCount - 1) * 1.5 * CellRadius);

            var start = new Point(
                (int)((Width - matrixWidth) / 2.0) ,
                (int)((Height - matrixHeight) / 2.0) + diameter / 2);

            var chk = (_cellCount - 1) / 2;

            if (chk % 2 == 0)
            {
                start.X += interWidth/2;
            }
          

            for (int row = 0; row < _cellCount; row++)
            {
                for (int col = 0; col < _cellCount; col++)
                {
                    var p = new Point(start.X + interWidth * col, (int)
                                     (start.Y + (CellRadius * 1.5) * row));

                    if (row % 2 != 0)
                    {
                        p.X += interWidth / 2;
                    }

                    Cells[row][col] = new ColorCell(p, CellRadius, System.Drawing.Color.Empty, System.Drawing.Color.Empty);
                }
            }


            var cnt = _cellCount / 2;

            var center = Cells[cnt][cnt].Center;

            var bigcellHeight =matrixWidth/2+CellRadius/2;

            var bigCell = new ColorCell(center, bigcellHeight, System.Drawing.Color.Red, System.Drawing.Color.Black);
            _bigCellPoly= bigCell.Hexagon90();

            var cell = FindColorCell(center);

            if (cell != null)
            {
                cell.FillColor = System.Drawing.Color.White;
                cell.BorderColor = System.Drawing.Color.Black;
            }

            for (int row = 0; row < _cellCount; row++)
            {
                for (int col = 0; col < _cellCount; col++)
                {
                    var currentPoint = Cells[row][col].Center;

                    if (MathUtility.InsidePolygon(_bigCellPoly, currentPoint))
                    {
                        var dist = Math.Sqrt(Math.Pow(center.X - currentPoint.X, 2) + Math.Pow(center.Y - currentPoint.Y, 2));

                        int x = currentPoint.X - center.X;
                        int y = currentPoint.Y - center.Y;

                        var h = (int)(new Point(x, y).AngleFromPoint());

                        var r = dist / ((_cellCount * interWidth)/2d);
                        var l = (float)(1.0 - r);

                        Cells[row][col].FillColor = new HlsColor {H = h, L = l, S = 1f};
                        Cells[row][col].BorderColor = CellBorderColor;
                    }
                }
            }

        }
       
        protected override Image CreateImage()
        {
            var res = new Bitmap(Width, Height);

            using(var g = Graphics.FromImage(res))
            {    
                g.SmoothingMode = SmoothingMode.HighQuality;
                for (int row = 0; row < _cellCount; row++)
                {
                    for (int col = 0; col < _cellCount; col++)
                    {

                        if (Cells != null)
                        {
                            var c = Cells[row][col];

                            if (c != null)
                            {
                                if (c.FillColor != System.Drawing.Color.Empty)
                                {
                                    c.DrawHexagon(g);
                                }
                            }
                        }
                    }
                }
            }

            return res;
        }


        protected override ColorCell FindColorCell(Point pt)
        {
            for (int row = 0; row < _cellCount; row++)
            {
                for (int col = 0; col < _cellCount; col++)
                {
                    if (Cells[row][col] != null)
                    {
                        if (Cells[row][col].FillColor != System.Drawing.Color.Empty)
                        {
                            int dx = Math.Abs(Cells[row][col].Center.X - pt.X);
                            int dy = Math.Abs(Cells[row][col].Center.Y - pt.Y);

                            if (dx < Cells[row][col].Radius & dy < Cells[row][col].Radius)
                            {
                                return Cells[row][col];
                            }
                        }
                    }
                }
            }

            return null;
        }

    }
}
