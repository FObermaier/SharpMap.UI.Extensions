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
    internal static class MathUtility
    {
        public const double HalfPI = Math.PI*0.5D;
        
        public const double TwoPI = Math.PI*2D;
        
        public const double DegToRad = Math.PI/180d;

        public const double RadToDeg = 180d/Math.PI;

        /// <summary>
        /// Method to compute an angle form the <paramref name="self"/>'s x and y component
        /// </summary>
        /// <param name="self">The point</param>
        /// <returns>An angle</returns>
        internal static double AngleFromPoint(this Point self)
        {

            var angle = Math.Atan2(self.Y, self.X);
            return angle * RadToDeg;
        }

        /// <summary>
        /// Method to compute an angle form the <paramref name="self"/>'s x and y component
        /// </summary>
        /// <param name="self">The point</param>
        /// <returns>An angle</returns>
        internal static double AngleFromPoint(this PointF self)
        {

            var angle = Math.Atan2(self.Y, self.X);
            return angle * RadToDeg;
        }

        public static double AngleFromPoints(PointF center, PointF p1, PointF p2)
        {
            var pp1 = new PointF(p1.X - center.X, p1.Y - center.Y);
            var pp2 = new PointF(p2.X - center.X, p2.Y - center.Y);

            var a1 = AngleFromPoint(pp1);
            var a2 = AngleFromPoint(pp2);

            return a2 - a1;

        }

        public static bool InsidePolygon(Point[] polygon, Point p)
        {
            //http://astronomy.swin.edu.au/~pbourke/geometry/insidepoly/
            //
            // Slick algorithm that checks if a point is inside a polygon.  Checks how may time a line
            // origination from point will cross each side.  An odd result means inside polygon.
            //

            var n = polygon.Length;

            var counter = 0;
            int i;

            PointF p1 = polygon[0];
            for (i = 1; i <= n; i++)
            {
                PointF p2 = polygon[i % n];
                if (p.Y > Math.Min(p1.Y, p2.Y))
                {
                    if (p.Y <= Math.Max(p1.Y, p2.Y))
                    {
                        if (p.X <= Math.Max(p1.X, p2.X))
                        {
                            if (p1.Y != p2.Y)
                            {
                                var xinters = (p.Y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y) + p1.X;
                                if (p1.X == p2.X || p.X <= xinters)
                                    counter++;
                            }
                        }
                    }
                }
                p1 = p2;
            }

            return counter % 2 != 0;
        }

        public static bool InsidePolygon(PointF[] polygon, PointF p)
        {
            //http://astronomy.swin.edu.au/~pbourke/geometry/insidepoly/
            //
            // Slick algorithm that checks if a point is inside a polygon.  Checks how may time a line
            // origination from point will cross each side.  An odd result means inside polygon.
            //

            var n = polygon.Length;

            var counter = 0;
            int i;

            var p1 = polygon[0];
            for (i = 1; i <= n; i++)
            {
                var p2 = polygon[i % n];
                if (p.Y > Math.Min(p1.Y, p2.Y))
                {
                    if (p.Y <= Math.Max(p1.Y, p2.Y))
                    {
                        if (p.X <= Math.Max(p1.X, p2.X))
                        {
                            if (p1.Y != p2.Y)
                            {
                                var xinters = (p.Y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y) + p1.X;
                                if (p1.X == p2.X || p.X <= xinters)
                                    counter++;
                            }
                        }
                    }
                }
                p1 = p2;
            }

            return counter % 2 != 0;
        }
    }
}