using System;
using System.Net.Security;
using System.Windows.Forms;

namespace SharpMap.Forms.Controls.Color
{
    public partial class ColorComponentEditor : UserControl
    {
        private ColorModel _colorModel = ColorModel.RGB;

        public ColorComponentEditor()
        {
            InitializeComponent();
            Structure();
        }

        /// <summary>
        /// Event raised when the <see cref="ColorModel"/> has changed
        /// </summary>
        public event EventHandler ColorModelChanged;

        /// <summary>
        /// Event invoker for the <see cref="ColorModelChanged"/> event.
        /// </summary>
        /// <param name="e">The event's argument</param>
        protected virtual void OnColorModelChanged(EventArgs e)
        {
            Structure();

            if (ColorModelChanged != null)
                ColorModelChanged(this, e);
        }

        /// <summary>
        /// Gets or sets a value indicating the color model displayed
        /// </summary>
        public ColorModel ColorModel
        {
            get
            {
                return _colorModel;
            }
            set
            {
                if (value == _colorModel)
                    return;

                _colorModel = value;
                OnColorModelChanged(EventArgs.Empty);
            }
        }

        private void Structure()
        {
            SuspendLayout();

            switch (_colorModel)
            {
                case ColorModel.RGB:
                    {
                        _channel1.ColorChannelType = ColorChannelType.Red;
                        _channel2.ColorChannelType = ColorChannelType.Green;
                        _channel3.ColorChannelType = ColorChannelType.Blue;
                        _channel4.ColorChannelType = ColorChannelType.Alpha;
                        _channel5.ColorChannelType = ColorChannelType.None;
                        _channel5.Visible = false;
                    }
                    break;
                case ColorModel.CMYK:
                    {
                        _channel1.ColorChannelType = ColorChannelType.Cyan;
                        _channel2.ColorChannelType = ColorChannelType.Magenta;
                        _channel3.ColorChannelType = ColorChannelType.Yellow;
                        _channel4.ColorChannelType = ColorChannelType.Color;
                        _channel5.ColorChannelType = ColorChannelType.Alpha;
                        _channel5.Visible = true;
                    }
                    break;
                case ColorModel.HSL:
                    {
                        _channel1.ColorChannelType = ColorChannelType.Hue;
                        _channel2.ColorChannelType = ColorChannelType.Light;
                        _channel3.ColorChannelType = ColorChannelType.Saturation;
                        _channel4.ColorChannelType = ColorChannelType.Alpha;
                        _channel5.ColorChannelType = ColorChannelType.None;
                        _channel5.Visible = false;
                    }
                    break;
            }

            SetColor();

            ResumeLayout();
        }

        private System.Drawing.Color _color = System.Drawing.Color.Red;

        /// <summary>
        /// Gets or sets a value indicating the current color
        /// </summary>
        public System.Drawing.Color SelectedColor
        {
            get
            {
                return _color;
            }
            set
            {
                if (value == _color)
                    return;
                
                _color = value;
                SetColor();

                OnSelectedColorChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Event raised when <see cref="SelectedColor"/> has changed
        /// </summary>
        public event EventHandler SelectedColorChanged;

        /// <summary>
        /// Event invoker for the <see cref="SelectedColorChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnSelectedColorChanged(EventArgs e)
        {
            if (SelectedColorChanged != null)
                SelectedColorChanged(this, e);
        }

        private void SetColor()
        {
            switch (_colorModel)
            {
                case ColorModel.RGB:
                    {
                        _channel1.Value = _color.R;
                        _channel2.Value = _color.G;
                        _channel3.Value = _color.B;
                        _channel4.Value = _color.A;
                    }
                    break;
                case ColorModel.CMYK:
                    var cmykColor = (CmykColor)_color;

                    _channel1.Value = cmykColor.C;
                    _channel2.Value = cmykColor.M;
                    _channel3.Value = cmykColor.Y;
                    _channel4.Value = cmykColor.K;
                    _channel5.Value = _color.A;

                    break;
                case ColorModel.HSL:

                    var hlsColor = (HlsColor) _color;
                    _channel1.Value = (int)Math.Round(hlsColor.H, MidpointRounding.AwayFromZero);
                    _channel2.Value = (int)Math.Round(hlsColor.L, MidpointRounding.AwayFromZero);
                    _channel3.Value = (int)Math.Round(hlsColor.S, MidpointRounding.AwayFromZero);

                    var tmpColor = (System.Drawing.Color)new HlsColor{ H= hlsColor.H, L = 0.5f, S = 1f };
                    _channel2.Color1 = tmpColor;
                    _channel3.Color1 = tmpColor;

                    _channel4.Value = _color.A;
                    break;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Structure();
        }

        private void tomChannel_ValueChange(object sender, EventArgs e)
        {
           
            System.Drawing.Color newColor = System.Drawing.Color.Empty;

            switch (_colorModel)
            {
                case ColorModel.RGB:
                    newColor = System.Drawing.Color.FromArgb(
                        Convert.ToByte(_channel4.Value),
                        Convert.ToByte(_channel1.Value),
                        Convert.ToByte(_channel2.Value),
                        Convert.ToByte(_channel3.Value));
                    break;

                case ColorModel.CMYK:
                    var cmykColor = new CmykColor
                    {
                        C = (byte) _channel1.Value,
                        M = (byte) _channel2.Value,
                        Y = (byte) _channel3.Value,
                        K = (byte) _channel4.Value
                    };
                    newColor = System.Drawing.Color.FromArgb(Convert.ToByte(_channel5.Value), cmykColor);
                    break;

                case ColorModel.HSL:
                    var hlsColor = new HlsColor
                    {
                        H = _channel1.Value,
                        L = _channel2.Value,
                        S = _channel3.Value
                    };

                    var tmpColor = new HlsColor{ H = hlsColor.H, L = 0.5f, S = 1f};

                    _channel2.Color1 = tmpColor;
                    _channel3.Color1 = tmpColor;

                    newColor = System.Drawing.Color.FromArgb(Convert.ToByte(_channel4.Value), hlsColor);
                    break;
            }

            SelectedColor = newColor;
        }
    }
}
