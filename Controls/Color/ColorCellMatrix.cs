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
using SharpMap.Forms.Controls.Base;

namespace SharpMap.Forms.Controls.Color
{
    public class ColorCellMatrix : ColorCellBase
    {
        private int _cellRows = 2;
        private int _cellColumns = 8;

        /// <summary>
        /// Gets the matrix of <see cref="ColorCell"/>s.
        /// </summary>
        public ColorCell [][] Cells { get; protected set; }

        protected override ColorCell FindColorCell(System.Drawing.Color color)
        {
            var c = System.Drawing.Color.FromArgb(255, color);
            for (var row = 0; row < _cellRows; row++)
            {
                for (var col = 0; col < _cellColumns; col++)
                {
                    if (Cells[row][col].FillColor == c)
                    {
                        return Cells[row][col];
                    }

                }
            }
            return null;
        }

        /// <summary>
        /// Event raised when the <see cref="CellRows"/> have changed
        /// </summary>
        public event EventHandler CellRowsChanged;

        /// <summary>
        /// Event invoker for the <see cref="CellRowsChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnCellRowsChanged(EventArgs e)
        {
            if (CellRowsChanged != null)
                CellRowsChanged(this, e);

            Initialize();
        }

        /// <summary>
        /// Gets or sets a value indicating the number of matrix rows
        /// </summary>
        [DefaultValue(2)]
        public virtual int CellRows
        {
            get
            {
                return _cellRows;
            }
            set
            {
                value = Math.Max(1, value);
                
                if (value == _cellRows) return;
                _cellRows = value;

                OnCellRowsChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Event raised when <see cref="CellColumns"/> has changed
        /// </summary>
        /// 
        public EventHandler CellColumnsChanged;

        /// <summary>
        /// Event invoker for the <see cref="CellColumnsChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnCellColumnsChanged(EventArgs e)
        {
            if (CellColumnsChanged != null)
                CellColumnsChanged(this, e);

            Initialize();
        }

        /// <summary>
        /// Gets or sets a value indicating the number of columns
        /// </summary>
        [DefaultValue(8)]
        public virtual int CellColumns
        {
            get
            {
                return _cellColumns;
            }
            set
            {
                value = Math.Max(1, value);
                if (value == _cellColumns)
                    return;
                _cellColumns = value;
                OnCellColumnsChanged(EventArgs.Empty);
            }
        }

        public ColorCellMatrix()
        {
            Initialize();
        }

        protected static ColorCell[][] CreateColorCells(int row, int cols)
        {
            var res = new ColorCell[row][];
            for (var i = 0; i < row; i++)
            {
                res[i] = new ColorCell[cols];
            }
            return res;
        }

        protected override void OnInitialize()
        {
            var width = Convert.ToInt32(2*CellRadius*CellColumns);
            var height = Convert.ToInt32(2*CellRadius * CellRows) + 1;
            MinimumSize = new Size(width, height);

            Cells = CreateColorCells(_cellRows, _cellColumns);

            var interWidth = 2 * (int)(CellRadius * Math.Cos(MathUtility.DegToRad *30.0 )) + 1;

            Point start;

            var diameter = 2 * CellRadius;

            if (CellStyle == ColorCellStyle.Hexagon)
            {

                int matrixWidth;
                int matrixHeight;


                if (_cellRows == 1)
                {
                    matrixWidth = _cellColumns * interWidth;
                    matrixHeight = diameter;

                    start = new Point(
                        (int)((Width - matrixWidth) / 2.0) + interWidth / 2,
                        (int)((Height - matrixHeight) / 2.0) + diameter / 2);

                }
                else
                {
                    matrixWidth = (_cellColumns * 2 + 1) * (interWidth / 2) + _cellColumns;
                    matrixHeight = (int)(2 * CellRadius+(_cellRows - 1) * 1.5 * CellRadius);

                    //Start = new Point(
                    //(int)((Width - MatrixWidth) / 2.0),
                    //(int)((Height - MatrixHeight) / 2.0)
                    //);
                    start = new Point(
                       (int)((Width - matrixWidth) / 2.0) + interWidth / 2,
                       (int)((Height - matrixHeight) / 2.0) + diameter / 2);
                }



            }
            else
            {
                start = new Point(Width / 2 - (_cellColumns * CellRadius) + CellRadius,
                                  Height / 2 - _cellRows * CellRadius + CellRadius);

            }

            for (int row = 0; row < _cellRows; row++)
            {
                for (int col = 0; col < _cellColumns; col++)
                {
                    if (CellStyle == ColorCellStyle.Hexagon)
                    {
                        Point p = new Point(
                                            start.X + interWidth * col,
                                            (int)(start.Y + (CellRadius*1.5) * row)
                                            );

                        if (row % 2 != 0)
                        {
                            p.X += interWidth / 2;
                        }

                        Cells[row][col] = new ColorCell(p, CellRadius, System.Drawing.Color.Red, System.Drawing.Color.Black);
                    }
                    else
                    {
                        Point p = new Point(start.X + CellRadius * col * 2, start.Y + CellRadius * row * 2);
                        Cells[row][col] = new ColorCell(p, CellRadius, System.Drawing.Color.Red, System.Drawing.Color.Black);
                    }
                }
            }

        }

        protected override Image CreateImage()
        {

            var res = new Bitmap(Width, Height);
            using (var g = Graphics.FromImage(res))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                for (var row = 0; row < _cellRows; row++)
                {
                    for (var col = 0; col < _cellColumns; col++)
                    {
                        var c = Cells[row][col];
                        if (c.FillColor.A != 255)
                        {

                            var hb = new HatchBrush(HatchStyle.SmallCheckerBoard, System.Drawing.Color.Black,
                                System.Drawing.Color.White);

                            switch (CellStyle)
                            {
                                case ColorCellStyle.Hexagon:
                                    c.DrawHexagon(g, new Pen(System.Drawing.Color.Transparent), hb);
                                    break;
                                case ColorCellStyle.Circle:
                                    c.DrawCircle(g, new Pen(System.Drawing.Color.Transparent), hb);
                                    break;
                                case ColorCellStyle.Square:
                                    c.DrawSquare(g, new Pen(System.Drawing.Color.Transparent), hb);
                                    break;
                            }
                            hb.Dispose();
                        }

                        switch (CellStyle)
                        {
                            case ColorCellStyle.Hexagon:
                                c.DrawHexagon(g);
                                break;
                            case ColorCellStyle.Circle:
                                c.DrawCircle(g);
                                break;
                            case ColorCellStyle.Square:
                                c.DrawSquare(g);
                                break;
                        }
                    }
                }
            }
            return res;
        }

        protected override ColorCell FindColorCell(Point location)
        {
            for (int row = 0; row < _cellRows; row++)
            {
                for (int col = 0; col < _cellColumns; col++)
                {
                    if (Cells[row][col] != null)
                    {

                        var r = Cells[row][col].Rectangle();

                        if (r.Contains(location))
                        {
                            switch (CellStyle)
                            {
                                case ColorCellStyle.Hexagon:
                                case ColorCellStyle.Circle:
                                    {
                                        var dx = Math.Abs(Cells[row][col].Center.X - location.X);
                                        var dy = Math.Abs(Cells[row][col].Center.Y - location.Y);

                                        if (dx < Cells[row][col].Radius & dy < Cells[row][col].Radius)
                                        {
                                            return Cells[row][col];
                                        }
                                    }
                                    break;

                                case ColorCellStyle.Square:
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
