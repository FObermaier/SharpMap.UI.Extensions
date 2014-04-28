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
using System.Drawing;
using SharpMap.Forms.Controls.Base;

namespace SharpMap.Forms.Controls.Color
{
    /// <summary>
    /// A color cell definition
    /// </summary>
    [Serializable]
    public class ColorCell
    {
        public Point Center;
        public int Radius;

        public System.Drawing.Color FillColor;
        public System.Drawing.Color BorderColor;

        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        public ColorCell()
        {
        }

        /// <summary>
        /// Creates an instance of this class using the provided values
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="fillColor">The fill color</param>
        /// <param name="borderColor">The border color</param>
        public ColorCell(Point center, int radius, System.Drawing.Color fillColor, System.Drawing.Color borderColor)
        {
            Center = center;
            Radius = radius;
            FillColor = fillColor;
            BorderColor = borderColor;
        }

        internal void DrawCircle(Graphics g, Pen pen = null, Brush brush = null)
        {
            if (brush != null)
            {
                g.FillEllipse(brush, Rectangle());
            }
            else
            {
                using (var b = new SolidBrush(FillColor))
                {
                    g.FillEllipse(b, Rectangle());
                }
            }

            if (pen != null)
            {
                g.DrawEllipse(pen, Rectangle());
            }
            else
            {
                using (var p = new Pen(BorderColor, 1))
                {
                    g.DrawEllipse(p, Rectangle());
                }
            }
        }

        internal void DrawHexagon(Graphics g, Pen pen = null, Brush brush = null)
        {
            Point[] hex  = Hexagon();

            if (brush != null)
            {
                g.FillPolygon(brush, hex);
            }
            else
            {
                using (var b = new SolidBrush(FillColor))
                {
                    g.FillPolygon(b, hex);
                }
            }

            if (pen != null)
            {
                g.DrawPolygon(pen, hex);
            }
            else
            {
                using (var p = new Pen(BorderColor, 1))
                {
                    g.DrawPolygon(p, hex);
                }
            }
        }

        internal void DrawSquare(Graphics g, Pen pen = null, Brush brush = null)
        {

            if (brush != null)
            {
                g.FillRectangle(brush, Rectangle());
            }
            else
            {
                using (var b = new SolidBrush(FillColor))
                {
                    g.FillRectangle(b, Rectangle());
                }
            }

            if (pen != null)
            {
                g.DrawRectangle(pen, Rectangle());
            }
            else
            {
                using (var p = new Pen(BorderColor, 1))
                {
                    g.DrawRectangle(p, Rectangle());
                }
            }
        }

        internal Rectangle Rectangle()
        {
            return new Rectangle(Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
        }

        /*
        private double HexSide()
        {
            return 30.0 * MathUtility.DegToRad * Radius + 1;
        }
        */

        internal Point[] Hexagon90()
        {
            Point[] hex = new Point[7];

            for (int sd = 0; sd < 6; sd++)
            {
                double a1 = (sd * 60.0d + 30.0d - 90d);

                a1*= MathUtility.DegToRad;

                hex[sd] = new Point(
                      Center.X + (int)Math.Round(Radius * Math.Cos(a1)),
                      Center.Y + (int)Math.Round(Radius * Math.Sin(a1))
                );

            }

            hex[6] = hex[0];

            return hex;
        }

        private Point[] Hexagon()
        {

            Point[] hex = new Point[7];

            for (int sd = 0; sd < 6; sd++)
            {
                double a1 = (sd * 60.0d + 30.0d);

                a1 *= MathUtility.DegToRad;

                hex[sd] = new Point(
                      Center.X + (int)Math.Round(Radius * Math.Cos(a1)),
                      Center.Y + (int)Math.Round(Radius * Math.Sin(a1))
                );

            }

            hex[6] = hex[0];

            return hex;
        }

    }
}
