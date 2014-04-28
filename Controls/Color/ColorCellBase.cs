// Copyright 2011 - 2013 - Tomaso Tonelli (tomaso.tonelli (at) gmail.com)
//
// This file is part of SharpMap.
// SharpMap is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// SharpMap is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with SharpMap; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SharpMap.Forms.Controls.Color
{
    [ToolboxItem(false)]
    [Serializable]
    public class ColorCellBase : Control
    {
        private Image _bitmap;

        private bool _showSelection = true;
        private int _cellRadius = 6;
        private ColorCellStyle _cellStyle = ColorCellStyle.Hexagon;
        private ColorCell _selectedColorCell;
        private System.Drawing.Color _cellBorderColor = System.Drawing.Color.Empty;

        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        protected ColorCellBase()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        /// <summary>
        /// Event raised when the <see cref="ShowSelection"/> property has changed
        /// </summary>
        public event EventHandler ShowSelectionChanged;

        /// <summary>
        /// Event raised when the <see cref="CellRadius"/> value has changed
        /// </summary>
        public event EventHandler CellRadiusChanged;

        /// <summary>
        /// Event raised when the cell style has changed
        /// </summary>
        public event EventHandler CellStyleChanged;

        /// <summary>
        /// Event raised when <see cref="CellBorderColor"/> has changed
        /// </summary>
        public event EventHandler CellBorderColorChanged;

        /// <summary>
        /// Event raised when the value of <see cref="SelectedColor"/> has changed
        /// </summary>
        public event EventHandler SelectedColorChanged;

        /// <summary>
        /// Event invoker for the <see cref="CellRadiusChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnCellRadiusChanged(EventArgs e)
        {
            if (CellRadiusChanged != null)
                CellRadiusChanged(this, e);

            Initialize();
        }

        /// <summary>
        /// Event invoker for the <see cref="ShowSelectionChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        private void OnShowSelectionChanged(EventArgs e)
        {
            if (ShowSelectionChanged != null)
                ShowSelectionChanged(this, e);
            Refresh();
        }

        /// <summary>
        /// Event invoker for the <see cref="SelectedColorChanged"/> event.
        /// </summary>
        /// <param name="e">The event's argument</param>
        protected void OnSelectedColorChanged(EventArgs e)
        {
            if (SelectedColorChanged != null)
                SelectedColorChanged(this, e);
            Refresh();
        }

        /// <summary>
        /// Event invoker for the <see cref="CellStyleChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        private void OnCellStyleChanged(EventArgs e)
        {
            if (CellStyleChanged != null)
            {
                CellStyleChanged(this, e);
            }
            Initialize();
        }

        /// <summary>
        /// Event invoker for the <see cref="CellBorderColorChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnCellBorderColorChanged(EventArgs e)
        {
            if (CellBorderColorChanged != null)
                CellBorderColorChanged(this, e);
            Initialize();
        }


        /// <summary>
        /// Gets or sets a value indicating that the selected color cell should be emphasized
        /// </summary>
        [Description("The selected color should be emphasized")]
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowSelection
        {
            get
            {
                return _showSelection;
            }
            set
            {
                if (value == _showSelection)
                    return;

                _showSelection = value;
                OnShowSelectionChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the selected color cell
        /// </summary>
        protected ColorCell SelectedColorCell
        {
            get { return _selectedColorCell; }
            set
            {
                if (value == _selectedColorCell)
                    return;

                _selectedColorCell = value;
                OnSelectedColorChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the selected color.
        /// </summary>
        /// <remarks></remarks>
        [Description("The selected color")]
        [Category("Behavior")]
        [DefaultValue(0)]
        public System.Drawing.Color SelectedColor
        {
            get
            {
                return SelectedColorCell == null
                    ? System.Drawing.Color.Empty
                    : SelectedColorCell.FillColor;
            }

            set
            {
                if (value == SelectedColor)
                    return;

                SelectedColorCell = FindColorCell(value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the <see cref="ColorCellStyle"/> of this control
        /// </summary>
        [Description("")]
        [Category("Appearance")]
        [DefaultValue(ColorCellStyle.Hexagon)]
        public virtual ColorCellStyle CellStyle
        {
            get
            {
                return _cellStyle;
            }
            set
            {
                if (_cellStyle == value)
                    return;

                _cellStyle = value;
                _bitmap = null;
                OnCellStyleChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the border color of the cell
        /// </summary>
        [Category("Appearance")]
        public System.Drawing.Color CellBorderColor
        {
            get
            {
                return _cellBorderColor;
            }
            set
            {
                if (value == _cellBorderColor)
                    return;

                _cellBorderColor = value;
                OnCellBorderColorChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the size of the cell radii
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(6)]
        public int CellRadius
        {
            get
            {
                return _cellRadius;
            }
            set
            {
                value = Math.Max(3, value);
                if (_cellRadius == value) return;
                
                _cellRadius = value;
                OnCellRadiusChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Function to find the <see cref="ColorCell"/> at the given <paramref name="location"/>.
        /// </summary>
        /// <param name="location">The location</param>
        /// <returns>The matching color cell or null</returns>
        protected virtual ColorCell FindColorCell(Point location)
        {
            return null;
        }

        /// <summary>
        /// Function to find the <see cref="ColorCell"/> at the given <paramref name="color"/>.
        /// </summary>
        /// <param name="color">The color</param>
        /// <returns>The matching color cell or null</returns>
        protected virtual ColorCell FindColorCell(System.Drawing.Color color)
        {
            return null;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectedColorCell = FindColorCell(e.Location);
            }
            base.OnMouseClick(e);
        }

        /// <summary>
        /// Function to create the color cell image
        /// </summary>
        /// <returns>An image for the color cell</returns>
        protected virtual Image CreateImage()
        {
            return new Bitmap(Width, Height);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Initialize();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            var g = pe.Graphics;
            var sm = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.HighQuality;

            if (_bitmap == null)
                _bitmap = CreateImage();

            g.DrawImage(_bitmap, new Point(0, 0));

            if (ShowSelection && SelectedColorCell != null)
            {
                for (int x = 0; x < 2; x++)
                {
                    var psel = x == 0
                        ? new Pen(System.Drawing.Color.Black, 3)
                        : new Pen(System.Drawing.Color.White, 1);

                    var brushsel = new SolidBrush(System.Drawing.Color.Transparent);

                    switch (CellStyle)
                    {
                        case ColorCellStyle.Hexagon:
                            _selectedColorCell.DrawHexagon(g, psel, brushsel);
                            break;
                        case ColorCellStyle.Circle:
                            _selectedColorCell.DrawCircle(g, psel, brushsel);
                            break;
                        case ColorCellStyle.Square:
                            _selectedColorCell.DrawSquare(g, psel, brushsel);
                            break;

                    }

                    brushsel.Dispose();
                    psel.Dispose();
                }

            }
            g.SmoothingMode = sm;
            
        }

        protected void Initialize()
        {
            if (_bitmap != null)
            {
                _bitmap.Dispose();
                _bitmap = null;
            }

            var selectedColorCell = SelectedColorCell;
            OnInitialize();

            if (selectedColorCell != null)
            {
                SelectedColorCell = FindColorCell(selectedColorCell.FillColor);
            }
            
            Refresh();
        }

        protected virtual void OnInitialize()
        {
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}