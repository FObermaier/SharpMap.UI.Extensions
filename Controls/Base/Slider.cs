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
using System.Windows.Forms;

namespace SharpMap.Forms.Controls.Base
{
    /// <summary>
    /// A slider control to pick a value
    /// </summary>
    [Serializable]
    public class Slider : Control
    {
        private double _minimum;
        private double _maximum = 100;
        private double _value = 50;
        private bool _integerValues;

        private int _markerSize = 7;
        private MarkerAlignment _markerAlignement = MarkerAlignment.Center;
        private Orientation _orientation = Orientation.Horizontal;
        private bool _showLine = true;

        /// <summary>
        /// Event raised when the <see cref="Minimum"/> value has changed
        /// </summary>
        public event EventHandler MinimumChanged;
        /// <summary>
        /// Event raised when the <see cref="Maximum"/> value has changed
        /// </summary>
        public event EventHandler MaximumChanged;
        /// <summary>
        /// Event raised when the <see cref="Value"/> has changed
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// Event raised when the <see cref="MarkerSize"/> value has changed
        /// </summary>
        public event EventHandler MarkerSizeChanged;

        /// <summary>
        /// Event raised when the <see cref="MarkerAlignment"/> value has changed
        /// </summary>
        public event EventHandler MarkerAlignmentChanged;

        /// <summary>
        /// Event raised when the <see cref="Orientation"/> value has changed
        /// </summary>
        public event EventHandler OrientationChanged;

        /// <summary>
        /// Event raised when the <see cref="IntegerValues"/> value has changed
        /// </summary>
        public event EventHandler IntegerValuesChanged;

        /// <summary>
        /// Event raised when the <see cref="ShowLine"/> value has changed
        /// </summary>
        public event EventHandler ShowLineChanged;

        /// <summary>
        /// Event invoker for the <see cref="MinimumChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnMinimumChanged(EventArgs e)
        {
            if (MinimumChanged != null)
                MinimumChanged(this, e);
        }

        /// <summary>
        /// Event invoker for the <see cref="MaximumChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnMaximumChanged(EventArgs e)
        {
            if (MaximumChanged != null)
                MaximumChanged(this, e);
        }

        /// <summary>
        /// Event invoker for the <see cref="ValueChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        /// <summary>
        /// Event invoker for the <see cref="MarkerSizeChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnMarkerSizeChanged(EventArgs e)
        {
            if (MarkerSizeChanged != null)
                MarkerSizeChanged(this, e);
        }

        /// <summary>
        /// Event invoker for the <see cref="MarkerAlignmentChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnMarkerAlignmentChanged(EventArgs e)
        {
            if (MarkerAlignmentChanged != null)
                MarkerAlignmentChanged(this, e);
        }

        /// <summary>
        /// Event invoker for the <see cref="OrientationChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnOrientationChanged(EventArgs e)
        {
            if (OrientationChanged != null)
                OrientationChanged(this, e);
        }

        /// <summary>
        /// Event invoker for the <see cref="IntegerValuesChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnIntegerValuesChanged(EventArgs e)
        {
            if (IntegerValuesChanged != null)
                IntegerValuesChanged(this, e);
        }

        /// <summary>
        /// Event invoker for the <see cref="ShowLineChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnShowLineChanged(EventArgs e)
        {
            if (ShowLineChanged != null)
            {
                ShowLineChanged(this, e);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the mimimum value that can be chosen
        /// </summary>
        [Category("Behavior")]
        [Description("The minimum value that can be chosen by the slider")]
        [DefaultValue(0d)]
        public double Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                if (_integerValues)
                    value = Math.Round(value, MidpointRounding.AwayFromZero);
                
                if (value == _minimum)
                    return;

                _minimum = value;
                OnMinimumChanged(EventArgs.Empty);
                if (Value < _minimum)
                {
                    Value = _minimum;
                }
                else
                {
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the maximum value that can be chosen
        /// </summary>
        [Category("Behavior")]
        [Description("The maximum value that can be chosen by the slider")]
        [DefaultValue(100d)]
        public double Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                if (_integerValues)
                    value = Math.Round(value, MidpointRounding.AwayFromZero);

                if (value == _maximum)
                    return;
                
                _maximum = value;
                OnMaximumChanged(EventArgs.Empty);
                if (value > _maximum)
                {
                    Value = _maximum;
                }
                else
                {
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the currently chosen value
        /// </summary>
        [Category("Behavior")]
        [Description("The currently chosen value")]
        [DefaultValue(50d)]
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_integerValues)
                    value = Math.Round(value, MidpointRounding.AwayFromZero);

                if (value < _minimum) value = _minimum;
                if (value > _maximum) value = _maximum;

                if (value == _value)
                    return;

                _value = value;
                OnValueChanged(EventArgs.Empty);
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the size of the marker
        /// </summary>
        [Category("Appearance")]
        [Description("The currently chosen value")]
        [DefaultValue(7)]
        public int MarkerSize
        {
            get
            {
                return _markerSize;
            }
            set
            {
                if (value == _markerSize)
                    return;

                _markerSize = value;
                OnMarkerSizeChanged(EventArgs.Empty);
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the position of the marker
        /// </summary>
        [Description("Position where the marker should be displayed")]
        [Category("Appearance")]
        [DefaultValue(MarkerAlignment.Center)]
        public MarkerAlignment MarkerAlignement
        {
            get
            {
                return _markerAlignement;
            }
            set
            {
                if (value == _markerAlignement)
                    return;

                _markerAlignement = value;
                OnMarkerAlignmentChanged(EventArgs.Empty);
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the orientation of the slider
        /// </summary>
        [Description("The orientation of the slider control")]
        [Category("Appearance")]
        [DefaultValue(Orientation.Horizontal)]
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
                Refresh();
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether or not the control should return integer values
        /// </summary>
        [Description("Controls whether integer values are used")]
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool IntegerValues
        {
            get
            {
                return _integerValues;
            }
            set
            {
                if (value == _integerValues)
                    return;

                _integerValues = value;
                OnIntegerValuesChanged(EventArgs.Empty);

                if (value)
                {
                    Minimum = Math.Round(_minimum, MidpointRounding.AwayFromZero);
                    Maximum = Math.Round(_maximum, MidpointRounding.AwayFromZero);
                    Value = Math.Round(_value, MidpointRounding.AwayFromZero);
                }
                else
                {
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if a base line should be displayed or not
        /// </summary>
        [Category("Appearance")]
        [Description("If set, a baseline is drawn")]
        [DefaultValue(true)]
        public bool ShowLine
        {
            get
            {
                return _showLine;
            }
            set
            {
                if (_showLine == value)
                    return;

                _showLine = value;
                OnShowLineChanged(EventArgs.Empty);
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var sm = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.HighQuality;

            if (Maximum == Minimum) Maximum = Maximum + 1;

            var v = (_value - Minimum) / (Maximum - Minimum);

            var p1 = new Point();
            var p2 = new Point();

            var pm = new Point();
            var arrowOrientation = Arrow.Orientation.Right;

            if (Orientation == Orientation.Horizontal)
            {
                int wdt = ClientRectangle.Width - 2 * _markerSize;
                int x = (int)Math.Round(wdt * v) + _markerSize;

                switch (_markerAlignement)
                {
                    case MarkerAlignment.Center:
                        {
                            p1 = new Point(_markerSize + 1, Height / 2);
                            p2 = new Point(Width - _markerSize - 1, Height / 2);
                            pm = new Point(x, Height / 2);
                            arrowOrientation = Arrow.Orientation.Up;
                        }
                        break;
                    case MarkerAlignment.LeftTop:
                        {
                            p1 = new Point(_markerSize + 1, 1);
                            p2 = new Point(Width - _markerSize - 1, 1);
                            pm = new Point(x, 1);
                            arrowOrientation = Arrow.Orientation.Up;
                        }
                        break;
                    case MarkerAlignment.RightBottom:
                        {
                            p1 = new Point(_markerSize + 1, Height - 1);
                            p2 = new Point(Width - _markerSize - 1, Height - 1);
                            pm = new Point(x, Height - 1);
                            arrowOrientation = Arrow.Orientation.Down;
                        }
                        break;
                }

            }
            else
            {
                int hgt = ClientRectangle.Height - 2 * _markerSize;
                int y = (int)Math.Round(hgt - (hgt * v)) + _markerSize;

                switch (_markerAlignement)
                {
                    case MarkerAlignment.Center:
                        {
                            p1 = new Point(Width / 2, _markerSize + 1);
                            p2 = new Point(Width / 2, Height - _markerSize - 1);
                            pm = new Point(Width / 2, y);
                            arrowOrientation = Arrow.Orientation.Left;

                        }
                        break;
                    case MarkerAlignment.LeftTop:
                        {
                            p1 = new Point(1, _markerSize + 1);
                            p2 = new Point(1, Height - _markerSize - 1);
                            pm = new Point(1, y);
                            arrowOrientation = Arrow.Orientation.Left;
                        }
                        break;
                    case MarkerAlignment.RightBottom:
                        {
                            p1 = new Point(Width - 1, _markerSize + 1);
                            p2 = new Point(Width - 1, Height - _markerSize - 1);
                            pm = new Point(Width - 1, y);
                            arrowOrientation = Arrow.Orientation.Right;
                        }
                        break;
                }

            }

            if (_showLine)
            {
                var p = new Pen(ForeColor, (float)1.0) {DashStyle = DashStyle.Dot};

                g.DrawLine(p, p1, p2);
                p.Dispose();
            }

            Arrow.DrawArrow(g, arrowOrientation, pm, _markerSize, BackColor, ForeColor);

            //Restore old smoothing mode
            g.SmoothingMode = sm;
        }

        private double ComputeValue(int x, int y)
        {
            double sz, v;
            if (Orientation == Orientation.Horizontal)
            {
                sz = Width - MarkerSize * 2 - 2;
                v = x;
            }
            else
            {
                sz = Height - MarkerSize * 2 - 2;
                v = y;
            }

            var vv = ((v - MarkerSize) / sz) * (_maximum - _minimum) + _minimum;

            if (Orientation == Orientation.Vertical)
            {
                vv = _maximum - vv;
            }
            return vv;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                Value = ComputeValue(e.X, e.Y);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                Value = ComputeValue(e.X, e.Y);
            }
        }
    }
}