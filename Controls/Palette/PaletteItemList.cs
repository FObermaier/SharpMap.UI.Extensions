using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SharpMap.Forms.Controls.Palette
{
    internal class PaletteItemList : List<PaletteItem>
    {

        public PaletteItemList()
        {
            CreateStandardItems();
        }


        public void Add(double value, System.Drawing.Color c)
        {
            Add(new PaletteItem(value, c));
            Sort();
        }

        internal void ChangeItem(int index, double value)
        {
            var itm = this[index];
            itm.Value = value;
            this[index] = itm;
            Sort();
        }

        internal void ChangeItem(int index, System.Drawing.Color value)
        {
            var itm = this[index];
            itm.Color = value;
            this[index] = itm;
        }

        public double Min
        {
            get
            {
                if (Count <= 0) return double.NaN;
                return this[0].Value;
            }

            set
            {
                if (Count > 0) ChangeItem(0, value);
            }
        }

        public System.Drawing.Color MinColor
        {
            get
            {
                return Count <= 0 ? System.Drawing.Color.Empty : base[0].Color;
            }
            set
            {
                if (Count > 0) ChangeItem(0, value);
            }
        }

        public double Max
        {
            get
            {
                return Count <= 0 ? double.NaN : base[Count - 1].Value;
            }
            set
            {
                if (Count > 0) ChangeItem(Count-1, value);
            }
        }

        public System.Drawing.Color MaxColor
        {
            get
            {
                return Count <= 0 ? System.Drawing.Color.Empty : base[Count - 1].Color;
            }
            set
            {
                if (Count > 0) ChangeItem(Count-1, value);
            }
        }

        internal void CreateHue()
        {
            Clear();
            Add(0, System.Drawing.Color.FromArgb(255, 0, 0));
            Add(30, System.Drawing.Color.FromArgb(255, 127, 0));
            Add(60, System.Drawing.Color.FromArgb(255, 255, 0));
            Add(90, System.Drawing.Color.FromArgb(127, 255, 0));
            Add(120, System.Drawing.Color.FromArgb(0, 255, 0));
            Add(150, System.Drawing.Color.FromArgb(0, 255, 127));
            Add(180, System.Drawing.Color.FromArgb(0, 255, 255));
            Add(210, System.Drawing.Color.FromArgb(0, 127, 255));
            Add(240, System.Drawing.Color.FromArgb(0, 0, 255));
            Add(270, System.Drawing.Color.FromArgb(127, 0, 255));
            Add(300, System.Drawing.Color.FromArgb(255, 0, 255));
            Add(330, System.Drawing.Color.FromArgb(255, 0, 128));
            Add(360, System.Drawing.Color.FromArgb(255, 0, 0));
        }

        internal void CreateLight()
        {
            Clear();
            Add(0f, System.Drawing.Color.Black);
            Add(0.5f, System.Drawing.Color.Empty);
            Add(1f, System.Drawing.Color.White);
        }

        internal void CreateSaturation()
        {
            Clear();
            Add(0f, System.Drawing.Color.Gray);
            Add(1f, System.Drawing.Color.White);
        }

        internal void CreateStandardItems()
        {
            Clear();
            Add(0, System.Drawing.Color.White);
            Add(255, System.Drawing.Color.Indigo);
        }

        public System.Drawing.Color GetColor(double value)
        {
            for (int i = 0; i < Count - 1; i++)
            {

                if (base[i].Value == value) return base[i].Color;
                if (base[i + 1].Value == value) return base[i + 1].Color;

                if (value > base[i].Value & value < base[i + 1].Value)
                {
                    var d = (value - base[i].Value) / (base[i + 1].Value - base[i].Value);

                    int A = (int)((base[i + 1].Color.A - base[i].Color.A) * d + base[i].Color.A);
                    int R = (int)((base[i + 1].Color.R - base[i].Color.R) * d + base[i].Color.R);
                    int G = (int)((base[i + 1].Color.G - base[i].Color.G) * d + base[i].Color.G);
                    int B = (int)((base[i + 1].Color.B - base[i].Color.B) * d + base[i].Color.B);

                    return System.Drawing.Color.FromArgb(A, R, G, B);
                }

            }

            return System.Drawing.Color.Transparent;
        }

        public void Draw(Graphics g, Rectangle r, Orientation orientation)
        {

            DrawBack(g, r);
            DrawPalette(g, r, orientation);

        }


        //private void DrawLinearGradientRect(Graphics g, Orientation o, Rectangle r, Color c1, Color c2)
        //{
        //    LinearGradientBrush Gb = new LinearGradientBrush(r, c1, c2, LinearGradientMode.Horizontal);

        //    g.FillRectangle(Gb, r);

        //}

        public void DrawPalette(Graphics g, Rectangle r, Orientation orientation)
        {
            var delta = Max - Min;


            if (orientation == Orientation.Horizontal)
            {
                var rate = delta / r.Width;

                for (int i = 0; i < r.Width; i++)
                {
                    System.Drawing.Color c = GetColor(Min + i * rate);
                    g.FillRectangle(new SolidBrush(c), i, 0, 1, r.Height);
                }

            }
            else
            {
                var rate = delta / r.Height;

                for (int i = 0; i < r.Height; i++)
                {
                    System.Drawing.Color c = GetColor(Min + i * rate);
                    g.FillRectangle(new SolidBrush(c), 0, i, r.Width, 1);
                }
            }
        }

        public void DrawBack(Graphics g, Rectangle r)
        {
            using (var hb = new HatchBrush(HatchStyle.SmallCheckerBoard, 
                                           System.Drawing.Color.Black,
                                           System.Drawing.Color.White))
            {
                g.FillRectangle(hb, r);
            }
        }
    }
}
