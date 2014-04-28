using System;
using System.Windows.Forms;
using System.Drawing;

namespace SharpMap.Forms.Controls.Palette
{
    public class PaletteBase : Control
    {
        private Orientation _orientation = Orientation.Horizontal;
        internal PaletteItemList Items = new PaletteItemList();

        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        public PaletteBase()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

        }

        /// <summary>
        /// Event raised when the <see cref="Orientation"/> has changed
        /// </summary>
        public event EventHandler OrientationChanged;

        /// <summary>
        /// Event invoker for the <see cref="OrientationChanged"/> event.
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnOrientationChanged(EventArgs e)
        {
            if (OrientationChanged != null)
            {
                OrientationChanged(this, e);
            }

            Invalidate();
        }

        /// <summary>
        /// Gets or sets a value indicating the orientation of the control
        /// </summary>
        public Orientation Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                if (value == _orientation)
                    return;

                _orientation = value;
                OnOrientationChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the minimum value
        /// </summary>
        public double Minimum
        {
            get
            {
                return Items.Min;
            }
            set
            {
                Items.Min = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the color that is associated with <see cref="Minimum"/>
        /// </summary>
        public System.Drawing.Color MinimumColor
        {
            set
            {
                Items.MinColor = value;
                Invalidate();
            }
            get
            {
                return Items.MinColor;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the maximum value
        /// </summary>
        public double Maximum
        {
            set
            {
                Items.Max = value;
                Invalidate();
            }
            get
            {
                return Items.Max;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the color that is associated with <see cref="Maximum"/>
        /// </summary>
        public System.Drawing.Color MaximumColor
        {
            set
            {
                Items.MaxColor = value;
                Invalidate();
            }
            get
            {
                return Items.MaxColor;
            }
        }
   
        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void Draw(Graphics g)
        {
            if (Items != null)
            {
                Items.Draw(g, ClientRectangle, Orientation);
            }
        }

        protected double GetValue(Point location)
        {
            double sz, v;

            if (Orientation == Orientation.Horizontal)
            {
                sz = ClientRectangle.Width;
                v = location.X;
            }
            else
            {
                sz = ClientRectangle.Height;
                v = Height - location.Y;
            }

            double vv = 1 - ((sz - v) / sz);
            vv = vv * (Maximum - Minimum) + Minimum;

            if (vv < Minimum) vv = Minimum;
            if (vv > Maximum) vv = Maximum;

            if (v == 0)
                vv = Minimum;
            if (v == sz)
                vv = Maximum;

            return vv;


        }

        public System.Drawing.Color GetColor(double value)
        {
            return Items.GetColor(value);
        }

    }
}