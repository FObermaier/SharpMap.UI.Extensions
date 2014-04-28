using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SharpMap.Forms.Controls.Color
{
    public class ColorCellList : ColorCellBase
    {
        private readonly List<ColorCell> _cells = new List<ColorCell>();
        
        private int _cellCount = 15;

        private System.Drawing.Color _colorFrom = System.Drawing.Color.FromArgb(255 - 16, 255 - 16, 255 - 16);
        private System.Drawing.Color _colorTo = System.Drawing.Color.Black;


        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        public ColorCellList()
        {
            Initialize();
        }

        /// <summary>
        /// Event raised when when <see cref="CellCount"/> has changed.
        /// </summary>
        public event EventHandler CellCountChanged;

        /// <summary>
        /// Event raised when when <see cref="ColorFrom"/> has changed.
        /// </summary>
        public event EventHandler ColorFromChanged;

        /// <summary>
        /// Event raised when when <see cref="ColorTo"/> has changed.
        /// </summary>
        public event EventHandler ColorToChanged;

        /// <summary>
        /// Event invoker for the <see cref="ColorFromChanged"/> event
        /// </summary>
        /// <param name="e">The event arguments</param>
        protected virtual void OnColorFromChanged(EventArgs e)
        {
            if (ColorFromChanged != null)
                ColorFromChanged(this, e);
        }

        /// <summary>
        /// Event invoker for the <see cref="ColorToChanged"/> event
        /// </summary>
        /// <param name="e">The event arguments</param>
        protected virtual void OnColorToChanged(EventArgs e)
        {
            if (ColorToChanged != null)
                ColorToChanged(this, e);
        }

        /// <summary>
        /// Event invoker for the <see cref="CellCountChanged"/> event
        /// </summary>
        /// <param name="e">The event arguments</param>
        protected virtual void OnCellCountChanged(EventArgs e)
        {
            if (CellCountChanged != null)
                CellCountChanged(this, e);
        }

        /// <summary>
        /// Gets or set a value indicating the number of color cells displayed
        /// </summary>
        [Description("The number of color cells in the list")]
        [Category("Appearance")]
        [DefaultValue(15)]
        public int CellCount
        {
            get
            {
                return _cellCount;
            }
            set
            {
                if (value == 0)
                if (_cellCount == value)
                    return;

                _cellCount = Math.Max(1, value);

                OnCellCountChanged(EventArgs.Empty);
                Initialize();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the first color
        /// </summary>
        [Description("The starting color int the list")]
        [Category("Behavior")]
        public System.Drawing.Color ColorFrom
        {
            get
            {
                return _colorFrom;
            }
            set
            {
                if (value == _colorFrom)
                    return;

                _colorFrom = value;
                OnColorFromChanged(EventArgs.Empty);
                Initialize();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the last color
        /// </summary>
        [Description("The last color int the list")]
        [Category("Behavior")]
        public System.Drawing.Color ColorTo
        {
            get
            {
                return _colorTo;
            }
            set
            {
                if (value == _colorTo)
                    return;

                _colorTo = value;
                OnColorToChanged(EventArgs.Empty);
                Initialize();
            }
        }


        protected override void OnInitialize()
        {
            var width = Convert.ToInt32(2*CellRadius*CellCount);
            var height = Convert.ToInt32(2*CellRadius) + 1;
            MinimumSize = new Size(width, height);

            _cells.Clear();

            var cellsWidth = _cellCount * (CellRadius * 2.0);
            var left = Width / 2.0 - cellsWidth / 2.0;

            for (int i = 0; i < _cellCount; i++)
            {
                var c = ColorExtensions.InterpolateColor(0, _colorFrom, _cellCount - 1, _colorTo, i);

                var p = new Point((int)left + i * CellRadius * 2 + CellRadius, Height / 2);
                _cells.Add(new ColorCell(p, CellRadius, c, CellBorderColor));
            }
        }

        protected override Image CreateImage()
        {
            var res = new Bitmap(Width, Height);
            using (var g = Graphics.FromImage(res))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                using (var cbp = new Pen(new SolidBrush(CellBorderColor), 1))
                for (int i = 0; i < _cells.Count; i++)
                {

                    var c = _cells[i];
                    switch (CellStyle)
                    {
                        case ColorCellStyle.Circle:
                            c.DrawCircle(g, cbp);
                            break;
                        case ColorCellStyle.Hexagon:
                            c.DrawHexagon(g, cbp);
                            break;
                        case ColorCellStyle.Square:
                            c.DrawSquare(g, cbp);
                            break;
                    }
                }
            }
            return res;
        }

        protected override void OnResize(EventArgs e)
        {
            Initialize();
        }

        protected override ColorCell FindColorCell(Point pt)
        {
            for (int i = 0; i < _cells.Count; i++)
            {
                int dx = Math.Abs(_cells[i].Center.X - pt.X);
                int dy = Math.Abs(_cells[i].Center.Y - pt.Y);

                if (dx < _cells[i].Radius & dy < _cells[i].Radius)
                {
                    return _cells[i];
                }
            }

            return null;
        }

        protected override ColorCell FindColorCell(System.Drawing.Color color)
        {
            System.Drawing.Color c1 = System.Drawing.Color.FromArgb(color.R, color.G, color.B);

            for (int i = 0; i < _cells.Count; i++)
            {
                if (_cells[i].FillColor == c1)
                    return _cells[i];

            }
            return null;
        }

    }
}
