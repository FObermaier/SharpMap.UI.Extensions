using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SharpMap.Forms.Controls.Base;

namespace SharpMap.Forms.Controls.Palette
{
    public class PaletteSlider : PaletteBase
    {
        private double _value = -1;
        private int _markerSize = 9;

        /// <summary>
        /// Event raised when the <see cref="Value"/> has changed
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// Event invoker for the <see cref="ValueChanged"/> event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);

            Refresh();
        }

        /// <summary>
        /// Gets or sets the current value of the palette slider
        /// </summary>
        [Description("The current value of the palette slider")]
        [Category("Behavior")]
        [DefaultValue(0f)]
        public double Value
        {
            get
            {
                if (_value == -1) Value = Minimum;
                return _value;
            }
            set
            {
                if (value == _value)
                    return;

                _value = value;
                OnValueChanged(EventArgs.Empty);

            }
        }

        /// <summary>
        /// Event raised when the <see cref="MarkerSize"/> value has changed
        /// </summary>
        public event EventHandler MarkerSizeChanged;

        /// <summary>
        /// Event invoker for the <see cref="MarkerSizeChanged"/> event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMarkerSizeChanged(EventArgs e)
        {
            if (MarkerSizeChanged != null)
                MarkerSizeChanged(this, e);

            Invalidate();
        }

        /// <summary>
        /// Gets or sets a value indicating the size of the marker
        /// </summary>
        [Description("The size of the marker")]
        [Category("Appearance")]
        public int MarkerSize
        {
            get
            {
                return _markerSize;
            }
            set
            {
                if (_markerSize == value)
                    return;

                _markerSize = value;
                OnMarkerSizeChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Method to draw the palette
        /// </summary>
        /// <param name="g"></param>
        private void Draw(Graphics g)
        {
            if (Maximum == Minimum) return;
            var sm = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.HighQuality;

            var v = (_value - Minimum) / (Maximum - Minimum);

            if (Orientation == Orientation.Horizontal)
            {
                int x = (int)Math.Round(ClientRectangle.Width * v);

                Arrow.DrawArrow(g, Arrow.Orientation.North, new Point(x, 0), _markerSize);
                Arrow.DrawArrow(g, Arrow.Orientation.South, new Point(x, ClientRectangle.Height), _markerSize);
            }
            else
            {
                int y = (int)Math.Round(Height - (ClientRectangle.Height * v));

                Arrow.DrawArrow(g, Arrow.Orientation.West, new Point(0, y), _markerSize);
                Arrow.DrawArrow(g, Arrow.Orientation.East, new Point(ClientRectangle.Width, y), _markerSize);
            }
            g.SmoothingMode = sm;


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Draw(e.Graphics);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                Value = GetValue(e.Location);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                Value = GetValue(e.Location);
            }
        }

    }
}