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

namespace SharpMap.Forms.Controls.Base
{
    /// <summary>
    /// Class to draw an arrow head
    /// </summary>
    internal static class Arrow
    {
        /// <summary>
        /// Enumeration of orientation values
        /// </summary>
        internal enum Orientation
        {
            /// <summary>
            /// Upward
            /// </summary>
            Up,
            /// <summary>
            /// Right
            /// </summary>
            Right,

            /// <summary>
            /// Down
            /// </summary>
            Down,

            /// <summary>
            /// Left
            /// </summary>
            Left,

            /// <summary>
            /// North or <see cref="Up"/>
            /// </summary>
            [Obsolete("Use Orientation.Up")]
            North = Up,

            /// <summary>
            /// East or <see cref="Right"/>
            /// </summary>
            [Obsolete("Use Orientation.Right")]
            East = Right,
            /// <summary>
            /// South or <see cref="Down"/>
            /// </summary>
            [Obsolete("Use Orientation.Down")]
            South = Down,

            /// <summary>
            /// West or <see cref="Left"/>
            /// </summary>
            [Obsolete("Use Orientation.Left")]
            West = Left
        }

        /// <summary>
        /// Creates an arrow head
        /// </summary>
        /// <param name="orientation">The pointing direction</param>
        /// <param name="location">The position of the arrow</param>
        /// <param name="arrowSize">The size of the arrow</param>
        /// <returns>An array of three points that define the arrow head</returns>
        public static Point[] CreateArrow(Orientation orientation, Point location, int arrowSize)
        {
            var halfArrowSize = arrowSize / 2;

            int dx1 = 0, dx2 = 0, dy1 = 0, dy2 = 0;

            switch (orientation)
            {
                case Orientation.Up:
                    dx1 = halfArrowSize; dy1 = arrowSize;
                    dx2 = -halfArrowSize; dy2 = arrowSize;
                    break;

                case Orientation.Right:
                    dx1 = -arrowSize; dy1 = +halfArrowSize;
                    dx2 = -arrowSize; dy2 = -halfArrowSize;
                    break;

                case Orientation.Down:
                    dx1 = halfArrowSize; dy1 = -arrowSize;
                    dx2 = -halfArrowSize; dy2 = -arrowSize;
                    break;

                case Orientation.Left:
                    dx1 = arrowSize; dy1 = +halfArrowSize;
                    dx2 = arrowSize; dy2 = -halfArrowSize;
                    break;

            }


            return new[]
            {
                new Point(location.X,location.Y),
                new Point(location.X+dx1,location.Y+dy1),
                new Point(location.X+dx2,location.Y+dy2),
                new Point(location.X,location.Y)
            };


        }

        /// <summary>
        /// Method to draw an arrow head
        /// </summary>
        /// <param name="g">The graphics object</param>
        /// <param name="orientation">The pointing direction</param>
        /// <param name="location">The position of the arrow</param>
        /// <param name="arrowSize">The size of the arrow</param>
        /// <param name="lineColor"></param>
        /// <param name="fillColor"></param>
        public static void DrawArrow(Graphics g, Orientation orientation, Point location, int arrowSize, 
            System.Drawing.Color lineColor = new System.Drawing.Color(),
            System.Drawing.Color fillColor = new System.Drawing.Color())
        {

            if (lineColor == System.Drawing.Color.Empty)
                lineColor = System.Drawing.Color.White;

            if (fillColor == System.Drawing.Color.Empty)
                fillColor = System.Drawing.Color.Black;

            var pnt = CreateArrow(orientation, location, arrowSize);

            using (var b = new SolidBrush(fillColor))
                g.FillPolygon(b, pnt);

            using (var p = new Pen(lineColor, 1))
                g.DrawPolygon(p, pnt);
        }
    }
}