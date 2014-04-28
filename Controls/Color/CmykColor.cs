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

namespace SharpMap.Forms.Controls.Color
{
    /// <summary>
    /// Color definition according to <see cref="ColorModel.CMYK"/>
    /// </summary>
    public struct CmykColor
    {
        /// <summary>
        /// Cyan value
        /// </summary>
        public byte C;

        /// <summary>
        /// Magenta value
        /// </summary>
        public byte M;

        /// <summary>
        /// Yellow value
        /// </summary>
        public byte Y;

        /// <summary>
        /// K value
        /// </summary>
        public byte K;

        /// <summary>
        /// Conversion operator from <see cref="CmykColor"/> to <see cref="System.Drawing.Color"/>
        /// </summary>
        /// <param name="value">The color</param>
        /// <returns>The color</returns>
        public static implicit operator System.Drawing.Color(CmykColor value)
        {
            var c = value.C / 255d;
            var m = value.M / 255d;
            var y = value.Y / 255d;
            var k = value.K / 255d;

            var r = c * (1d - k) + k;
            var g = m * (1d - k) + k;
            var b = y * (1d - k) + k;

            r = (1d - r) * 255d + 0.5d;
            g = (1d - g) * 255d + 0.5d;
            b = (1d - b) * 255d + 0.5d;

            return System.Drawing.Color.FromArgb((byte)r, (byte)g, (byte)b);
        }

        /// <summary>
        /// Conversion operator from <see cref="System.Drawing.Color"/> to <see cref="CmykColor"/>
        /// </summary>
        /// <param name="value">The color</param>
        /// <returns>The color</returns>
        public static implicit operator CmykColor(System.Drawing.Color value)
        {
            CmykColor cmykColor;

            var r = 1d - value.R / 255d;
            var g = 1d - value.G / 255d;
            var b = 1d - value.B / 255d;

            var k = r < g ? r : g;
            if (b < k) k = b;

            var c = (r - k) / (1d - k);
            var m = (g - k) / (1d - k);
            var y = (b - k) / (1d - k);

            c = (c * 255d) + 0.5d;
            m = (m * 255d) + 0.5d;
            y = (y * 255d) + 0.5d;
            k = (k * 255d) + 0.5d;

            cmykColor.C = (byte)c;
            cmykColor.M = (byte)m;
            cmykColor.Y = (byte)y;
            cmykColor.K = (byte)k;

            return cmykColor;
        }
    }
}