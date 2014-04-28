// Copyright 2011 - 2013 - Tomaso Tonelli (tomaso.tonelli (at) gmail.com)
// Copyright 2013 - Felix Obermaier (www.ivv-aachen.de)
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
using System.Collections.Generic;

namespace SharpMap.Forms.Controls.Color
{
    public static class ColorExtensions
    {
        public static string[] WebSafe = {
        "#FFFFFF", 	"#FFFFCC", 	"#FFFF99", 	"#FFFF66", 	"#FFFF33", 	"#FFFF00",
        "#FFCCFF", 	"#FFCCCC", 	"#FFCC99", 	"#FFCC66", 	"#FFCC33", 	"#FFCC00",
        "#FF99FF", 	"#FF99CC", 	"#FF9999", 	"#FF9966", 	"#FF9933", 	"#FF9900",
        "#FF66FF", 	"#FF66CC", 	"#FF6699", 	"#FF6666", 	"#FF6633", 	"#FF6600",
        "#FF33FF", 	"#FF33CC", 	"#FF3399", 	"#FF3366", 	"#FF3333", 	"#FF3300",
        "#FF00FF", 	"#FF00CC", 	"#FF0099", 	"#FF0066", 	"#FF0033", 	"#FF0000",
                                                                           
        "#CCFFFF", 	"#CCFFCC", 	"#CCFF99", 	"#CCFF66", 	"#CCFF33", 	"#CCFF00",
        "#CCCCFF", 	"#CCCCCC", 	"#CCCC99", 	"#CCCC66", 	"#CCCC33", 	"#CCCC00",
        "#CC99FF", 	"#CC99CC", 	"#CC9999", 	"#CC9966", 	"#CC9933", 	"#CC9900",
        "#CC66FF", 	"#CC66CC", 	"#CC6699", 	"#CC6666", 	"#CC6633", 	"#CC6600",
        "#CC33FF", 	"#CC33CC", 	"#CC3399", 	"#CC3366", 	"#CC3333", 	"#CC3300",
        "#CC00FF", 	"#CC00CC", 	"#CC0099", 	"#CC0066", 	"#CC0033", 	"#CC0000",
                                                                           
        "#99FFFF", 	"#99FFCC", 	"#99FF99", 	"#99FF66", 	"#99FF33", 	"#99FF00",
        "#99CCFF", 	"#99CCCC", 	"#99CC99", 	"#99CC66", 	"#99CC33", 	"#99CC00",
        "#9999FF", 	"#9999CC", 	"#999999", 	"#999966", 	"#999933", 	"#999900",
        "#9966FF", 	"#9966CC", 	"#996699", 	"#996666", 	"#996633", 	"#996600",
        "#9933FF", 	"#9933CC", 	"#993399", 	"#993366", 	"#993333", 	"#993300",
        "#9900FF", 	"#9900CC", 	"#990099", 	"#990066", 	"#990033", 	"#990000",
                                                                           
        "#66FFFF", 	"#66FFCC", 	"#66FF99", 	"#66FF66", 	"#66FF33", 	"#66FF00",
        "#66CCFF", 	"#66CCCC", 	"#66CC99", 	"#66CC66", 	"#66CC33", 	"#66CC00",
        "#6699FF", 	"#6699CC", 	"#669999", 	"#669966", 	"#669933", 	"#669900",
        "#6666FF", 	"#6666CC", 	"#666699", 	"#666666", 	"#666633", 	"#666600",
        "#6633FF", 	"#6633CC", 	"#663399", 	"#663366", 	"#663333", 	"#663300",
        "#6600FF", 	"#6600CC", 	"#660099", 	"#660066", 	"#660033", 	"#660000",
                                                                           
        "#33FFFF", 	"#33FFCC", 	"#33FF99", 	"#33FF66", 	"#33FF33", 	"#33FF00",
        "#33CCFF", 	"#33CCCC", 	"#33CC99", 	"#33CC66", 	"#33CC33", 	"#33CC00",
        "#3399FF", 	"#3399CC", 	"#339999", 	"#339966", 	"#339933", 	"#339900",
        "#3366FF", 	"#3366CC", 	"#336699", 	"#336666", 	"#336633", 	"#336600",
        "#3333FF", 	"#3333CC", 	"#333399", 	"#333366", 	"#333333", 	"#333300",
        "#3300FF", 	"#3300CC", 	"#330099", 	"#330066", 	"#330033", 	"#330000",
                                                                           
        "#00FFFF", 	"#00FFCC", 	"#00FF99", 	"#00FF66", 	"#00FF33", 	"#00FF00",
        "#00CCFF", 	"#00CCCC", 	"#00CC99", 	"#00CC66", 	"#00CC33", 	"#00CC00",
        "#0099FF", 	"#0099CC", 	"#009999", 	"#009966", 	"#009933", 	"#009900",
        "#0066FF", 	"#0066CC", 	"#006699", 	"#006666", 	"#006633", 	"#006600",
        "#0033FF", 	"#0033CC", 	"#003399", 	"#003366", 	"#003333", 	"#003300",
        "#0000FF", 	"#0000CC", 	"#000099", 	"#000066", 	"#000033", 	"#000000"
        };

        public static string[] TomPaletteBase;

        static ColorExtensions()
        {
            var p = new List<string>();
 
            for (int i = 0; i <= 255; i+=15)
            {
                string sc = "#" + string.Format("{0:X2}{1:X2}{2:X2}", i, i, i);
                p.Add(sc);
            }

  	        p.Add("#FF0000");
  	        p.Add("#00FF00");
  	        p.Add("#0000FF");
  	        p.Add("#FFFF00");
  	        p.Add("#00FFFF");
  	        p.Add("#FF00FF");
  	        p.Add("#C0C0C0");

            for (var h = 0f; h < 360f; h += 10f)
                for (var l = 0.25f; l <= 0.75; l += 1f/16f)
                {
                    System.Drawing.Color c = new HlsColor { H = h, L = l, S = 1f };

                    var sc = "#" + string.Format("{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B);
                    p.Add(sc);
                }

            TomPaletteBase = p.ToArray();

        }

        public static System.Drawing.Color GetColorFromName(string colorName)
        {
            System.Drawing.Color color = System.Drawing.Color.Empty;

            if (colorName.Substring(0, 1) == "#")
            {
                if (colorName.Length == 7)
                {
                    var r = Convert.ToInt32(colorName.Substring(1, 2), 16);
                    var g = Convert.ToInt32(colorName.Substring(3, 2), 16);
                    var b = Convert.ToInt32(colorName.Substring(5, 2), 16);

                    color = System.Drawing.Color.FromArgb(r, g, b);
                }

            }
            else
            {
                color = System.Drawing.Color.FromName(colorName);
            }

            return color;

        }
        /// <summary>
        /// Method to interpolate between two colors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="c1">The first color</param>
        /// <param name="v2"></param>
        /// <param name="c2">The second color</param>
        /// <param name="v"></param>
        /// <returns>The interpolated color</returns>
        public static System.Drawing.Color InterpolateColor(double v1, System.Drawing.Color c1, 
                                                            double v2, System.Drawing.Color c2, double v)
        {
            var ratio = (v - v1) / (v2 - v1);

            var a = (int)Math.Round((c2.A - (double)c1.A) * ratio + c1.A);
            var r = (int)Math.Round((c2.R - (double)c1.R) * ratio + c1.R);
            var g = (int)Math.Round((c2.G - (double)c1.G) * ratio + c1.G);
            var b = (int)Math.Round((c2.B - (double)c1.B) * ratio + c1.B);

            return System.Drawing.Color.FromArgb(a, r, g, b);

        }

        /// <summary>
        /// Method to find a color that is most 
        /// </summary>
        /// <param name="colors">An array of color values</param>
        /// <param name="color">A color</param>
        /// <returns>The color that matches <paramref name="color"/> most.</returns>
        public static System.Drawing.Color FindNearestColor(
            this IList<System.Drawing.Color> colors,
            System.Drawing.Color color)
        {
            var hlsColor = (HlsColor) color;
            var distance = double.MaxValue;
            var resColor = new HlsColor();

            if (colors == null || colors.Count == 0)
                throw new ArgumentException("colors");

            foreach (var c in colors)
            {
                var testHlsColor = (HlsColor) c;
                var d = hlsColor.Distance(testHlsColor);
                if (d < distance)
                {
                    distance = d;
                    if (distance == 0d) return testHlsColor;
                    resColor = testHlsColor;
                }
            }
            
            return resColor;

        }
    }
}