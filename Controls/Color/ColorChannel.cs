using System;
using System.Windows.Forms;

namespace SharpMap.Forms.Controls.Color
{
    public partial class ColorChannel : UserControl
    {
        private ColorChannelType _colorChannelType = ColorChannelType.None;
        bool _valueChanging;

        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        public ColorChannel()
        {
            InitializeComponent();
            Structure();
        }

        /// <summary>
        /// Event raised when the <see cref="ColorChannelType"/> has changed
        /// </summary>
        public event EventHandler ColorChannelTypeChanged;

        /// <summary>
        /// Event raised when the <see cref="Value"/> has changed;
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// Event raised when the <see cref="Minimum"/> value has changed;
        /// </summary>
        public event EventHandler MinimumChanged;

        /// <summary>
        /// Event raised when the <see cref="Maximum"/> value has changed;
        /// </summary>
        public event EventHandler MaximumChanged;

        /// <summary>
        /// Event raised when the <see cref="Color0"/> value has changed;
        /// </summary>
        public event EventHandler Color0Changed;

        /// <summary>
        /// Event raised when the <see cref="Color1"/> value has changed;
        /// </summary>
        public event EventHandler Color1Changed;

        /// <summary>
        /// Event invoker for the <see cref="ColorChannelTypeChanged"/> event
        /// </summary>
        /// <param name="e">The event arguments</param>
        protected virtual void OnColorChannelTypeChanged(EventArgs e)
        {
            var relativeValue = (Value - Minimum)/(Maximum - Minimum);

            if (ColorChannelTypeChanged != null)
                ColorChannelTypeChanged(this, e);
            
            Structure();

            Value = Minimum + relativeValue*(Maximum - Minimum);
        }

        /// <summary>
        /// Event invoker for the <see cref="ValueChanged"/> event.
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        /// <summary>
        /// Event invoker for the <see cref="MinimumChanged"/> event.
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnMinimumChanged(EventArgs e)
        {
            if (MinimumChanged != null)
                MinimumChanged(this, e);
        }

        /// <summary>
        /// Event invoker for the <see cref="MaximumChanged"/> event.
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnMaximumChanged(EventArgs e)
        {
            if (MaximumChanged != null)
                MaximumChanged(this, e);

            if (Maximum <= 1f)
            {
                numericUpDown.DecimalPlaces = 2;
                numericUpDown.Increment = (decimal)0.01f;
            }
            else
            {
                numericUpDown.DecimalPlaces = 0;
                numericUpDown.Increment = 1;
            }
        }

        /// <summary>
        /// Event invoker for the <see cref="Color0Changed"/> event.
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnColor0Changed(EventArgs e)
        {
            if (Color0Changed != null)
                Color0Changed(this, e);
            tomPaletteSlider.Refresh();
        }

        /// <summary>
        /// Event invoker for the <see cref="Color1Changed"/> event.
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnColor1Changed(EventArgs e)
        {
            if (Color1Changed != null)
                Color1Changed(this, e);
            tomPaletteSlider.Refresh();
        }

        /// <summary>
        /// Gets or sets a value indication the <see cref="ColorChannelType"/> has changed.
        /// </summary>
        public ColorChannelType ColorChannelType
        {
            get
            {
                return _colorChannelType;
            }
            set
            {
                if (value == _colorChannelType)
                    return;

                _colorChannelType = value;
                OnColorChannelTypeChanged(EventArgs.Empty);
            }
        }

        private void Structure()
        {
            Minimum = 0;
            switch (ColorChannelType)
            {
                case ColorChannelType.Hue:
                    Maximum = 360;
                    tomPaletteSlider.Items.CreateHue();
                    break;
                case ColorChannelType.Light:
                    Maximum = 1f;
                    tomPaletteSlider.Items.CreateLight();
                    break;
                case ColorChannelType.Saturation:
                    Maximum = 1f;
                    tomPaletteSlider.Items.CreateSaturation();
                    break;
                default:
                    Maximum = 255;
                    tomPaletteSlider.Items.CreateStandardItems();
                    break;
            }

            switch (_colorChannelType)
            {
                case ColorChannelType.None:
                    Color0 = System.Drawing.Color.White;
                    Color1 = System.Drawing.Color.Black;
                    ChannelName = "N:";
                    break;
                case ColorChannelType.Red:
                    Color0 = System.Drawing.Color.Black;
                    Color1 = System.Drawing.Color.Red;
                    ChannelName = "R:";
                    break;
                case ColorChannelType.Green:
                    Color0 = System.Drawing.Color.Black;
                    Color1 = System.Drawing.Color.FromArgb(0,255, 0);
                    ChannelName = "G:";
                    break;
                case ColorChannelType.Blue:
                    Color0 = System.Drawing.Color.Black;
                    Color1 = System.Drawing.Color.Blue;
                    ChannelName = "B:";
                    break;
                case ColorChannelType.Cyan:
                    Color0 = System.Drawing.Color.White;
                    Color1 = System.Drawing.Color.Cyan;
                    ChannelName = "C:";
                    break;
                case ColorChannelType.Magenta:
                    Color0 = System.Drawing.Color.White;
                    Color1 = System.Drawing.Color.Magenta;
                    ChannelName = "M:";
                    break;
                case ColorChannelType.Yellow:
                    Color0 = System.Drawing.Color.White;
                    Color1 = System.Drawing.Color.Yellow;
                    ChannelName = "Y:";
                    break;
                case ColorChannelType.Color:
                    Color0 = System.Drawing.Color.White;
                    Color1 = System.Drawing.Color.Black;
                    ChannelName = "K:";
                    break;
                case ColorChannelType.Alpha:
                    Color0 = System.Drawing.Color.Transparent;
                    Color1 = System.Drawing.Color.Black;
                    ChannelName = "A:";
                    break;
                case ColorChannelType.Hue:
                    Maximum = 360;
                    ChannelName = "H:";
                    tomPaletteSlider.Refresh();
                    break;
                case ColorChannelType.Light:
                    ChannelName = "L:";
                    Maximum = 1f;
                    tomPaletteSlider.Refresh();
                    break;
                case ColorChannelType.Saturation:
                    ChannelName = "S:";
                    Maximum = 1f;
                    tomPaletteSlider.Refresh();
                    break;
            }
        }

        /// <summary>
        /// Gets or sets the name for the color channed
        /// </summary>
        public string ChannelName
        {
            get
            {
                return labelChannelName.Text;
            }
            private set
            {
                labelChannelName.Text = value;
            }
        }


        /// <summary>
        /// Gets or sets a value indicating the value of the color channel
        /// </summary>
        public float Value
        {
            get
            {
                return (float)numericUpDown.Value;
            }
            set
            {
                if (value == Value)
                    return;

                _valueChanging = true;
                
                numericUpDown.Value = (decimal)value;
                tomPaletteSlider.Value = value;

                _valueChanging = false;

                OnValueChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the maximum value for the color channel
        /// </summary>
        public float Maximum
        {
            get
            {
                return (float)numericUpDown.Maximum;
            }
            set
            {
                if (value == Value)
                    return;

                numericUpDown.Maximum = (decimal)value;
                OnMaximumChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the minimum value for the color channel
        /// </summary>
        public float Minimum
        {
            get
            {
                return (float)numericUpDown.Minimum;
            }
            set
            {
                if (value == Value)
                    return;

                numericUpDown.Minimum = (decimal)value;
                OnMinimumChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the color at position 0
        /// </summary>
        public System.Drawing.Color Color0
        {
            get
            {
                return tomPaletteSlider.MinimumColor;
            }
            set
            {
                tomPaletteSlider.MinimumColor = value;
                OnColor0Changed(EventArgs.Empty);
            }
        }

        public System.Drawing.Color Color1
        {
            
            get
            {
                if (ColorChannelType == ColorChannelType.Light)
                {
                    return tomPaletteSlider.Items[1].Color;
                }
                return tomPaletteSlider.MaximumColor;
            }
            set
            {
                if (ColorChannelType == ColorChannelType.Light)
                {
                    tomPaletteSlider.Items.ChangeItem(1, value);
                }
                else
                {
                    tomPaletteSlider.MaximumColor = value;
                }
                tomPaletteSlider.Refresh();
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_valueChanging) return;
            Value = (float)numericUpDown.Value;
        }

        private void tomPaletteSlider_ValueChanged(object sender, EventArgs e)
        {
            if (_valueChanging) return;
            Value = (float)tomPaletteSlider.Value;
        }

        
    }
}
