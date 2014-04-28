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

namespace SharpMap.Forms.Controls.Color
{
    /// <summary>
    /// Color reperesentation in <see cref="ColorModel.HSL"/>
    /// </summary>
    public struct HlsColor
    {
        private int _h;
        private byte _l;
        private byte _s;

        /// <summary>
        /// Hue value
        /// </summary>
        public float H
        {
            get { return _h; }
            set
            {
                value = AdjustHue(value);

                if (value < 0f || value > 360f)
                    throw new ArgumentOutOfRangeException("value");

                _h = (int)Math.Round(value, MidpointRounding.AwayFromZero);
            }
        }

        /// <summary>
        /// Method to move hue value in the range [0f; 360f[
        /// </summary>
        /// <param name="hue">The initial hue value</param>
        /// <returns>The adujusted hue value</returns>
        private static float AdjustHue(float hue)
        {
            while (hue < 0)
                hue += 360f;
            return hue%360f;
        }

        /// <summary>
        /// Lightness value
        /// </summary>
        public float L
        {
            get { return ScaleToFloat(_l); }
            set { _l = ClampToByte(value); }
        }

        /// <summary>
        /// Saturation value
        /// </summary>
        public float S
        {
            get { return ScaleToFloat(_s); }
            set { _s = ClampToByte(value); }
        }

        private static byte ClampToByte(float value)
        {
            const float scale = 2.55f;

            if (value < 0f) value = 0f;
            if (value > 1f) value = 1f;
            value *= 100f;

            return Convert.ToByte(value*scale);
        }

        private static float ScaleToFloat(byte value)
        {
            const float scale = 100f/255f;
            return Math.Min(1f, scale*value);
        }

        /// <summary>
        /// Conversion operator from <see cref="System.Drawing.Color"/> to <see cref="HlsColor"/> 
        /// </summary>
        /// <param name="value">The color</param>
        /// <returns>The color</returns>
        public static implicit operator HlsColor(System.Drawing.Color value)
        {
            var hls = new HlsColor
            {
                H = value.GetHue(),
                L = value.GetBrightness(),
                S = value.GetSaturation()
            };

            return hls;
        }

        /// <summary>
        /// Conversion operator from <see cref="HlsColor"/> to <see cref="System.Drawing.Color"/> 
        /// </summary>
        /// <param name="value">The color</param>
        /// <returns>The color</returns>
        public static implicit operator System.Drawing.Color(HlsColor value)
        {
            var h = (double)value.H;
            var l = (double)value.L;
            var s = (double)value.S;

            // RGB component values
            byte r, g, b; 

            if (s == 0d)
            {
                r = g = b = (byte)(l * 255d);
            }
            else
            {
                float rm2;

                if (l <= 0.5f)
                    rm2 = (float)(l + l * s);
                else
                    rm2 = (float)(l + s - l * s);

                var rm1 = (float)(2.0f * l - rm2);

                r = GetRgbFromHue(rm1, rm2, (float)(h + 120.0f));
                g = GetRgbFromHue(rm1, rm2, (float)(h));
                b = GetRgbFromHue(rm1, rm2, (float)(h - 120.0f));
            }

            return System.Drawing.Color.FromArgb(r, g, b);
        }

        private static byte GetRgbFromHue(float rm1, float rm2, float rh)
        {
            rh = AdjustHue(rh);
            if (rh < 60.0f)
                rm1 = rm1 + (rm2 - rm1) * rh / 60.0f;
            else if (rh < 180.0f)
                rm1 = rm2;
            else if (rh < 240.0f)
                rm1 = rm1 + (rm2 - rm1) * (240.0f - rh) / 60.0f;

            return (byte)(rm1 * 255);
        }

        /// <summary>
        /// Computes the weighted euclidian distance to <paramref name="other"/> color
        /// </summary>
        /// <param name="other">The other color</param>
        /// <returns>The distance</returns>
        public double Distance(HlsColor other)
        {
            var h = (H - other.H)*1d;
            var l = (L - other.L)*100d;
            var s = (S - other.S)*100d;

            h = 0.5d*h*h;
            l *= l;
            s = 0.5d*s*s;

            return Math.Sqrt(h + l + s);
        }
    }
}