using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SharpMap.Forms.Controls.Color
{
    public partial class ColorLists : UserControl
    {
        private bool _valueChanging;

        private static readonly string[] Named;

        static ColorLists()
        {
            Named = GetColors();
        }

        private static string[] GetColors()
        {
            //create a generic list of strings
            var colors = new List<string>();
            //get the color names from the Known color enum
            string[] colorNames = Enum.GetNames(typeof(KnownColor));
            //iterate thru each string in the colorNames array
            foreach (string colorName in colorNames)
            {
                //cast the colorName into a KnownColor
                var knownColor = (KnownColor)Enum.Parse(typeof(KnownColor), colorName);
                //check if the knownColor variable is a System color
                if (knownColor > KnownColor.Transparent && knownColor < KnownColor.ButtonFace)
                {
                    //add it to our list
                    colors.Add(colorName);
                }
            }
            //return the color list
            return colors.ToArray();
        }
 
        public ColorLists()
        {
            InitializeComponent();

            comboBoxList.Items.Add(Properties.Resources.colorList_KnownColors);
            comboBoxList.Items.Add(Properties.Resources.colorList_WebSafe);
        }

        private void Structure()
        {
            _colorListBox.Items.Clear();
            if (comboBoxList.SelectedIndex == 0)
            {
                foreach (var colorName in Named)
                {
                    _colorListBox.Items.Add(colorName);
                }
            }
            else
            {
                foreach (var colorCode in ColorExtensions.WebSafe)
                {
                    _colorListBox.Items.Add(colorCode);
                }
            }
        }

        private System.Drawing.Color _color = System.Drawing.Color.Empty;
        
        /// <summary>
        /// Gets or sets a value indicating the selected color
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
                FindColor();

                OnSelectedColorChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Event raised when the selected color has changed
        /// </summary>
        public event EventHandler SelectedColorChanged;

        /// <summary>
        /// Event invoker for the <see cref="SelectedColorChanged"/> event
        /// </summary>
        /// <param name="e">The event arguments</param>
        protected virtual void OnSelectedColorChanged(EventArgs e)
        {
            if (SelectedColorChanged != null)
                SelectedColorChanged(this, e);
        }

        private void FindColor()
        {
            _valueChanging = true;
            string name = "";
            _colorListBox.SelectedIndex = -1;
            _valueChanging = false;

            if (comboBoxList.SelectedIndex < 0)
            {
                return;
            }

            if (comboBoxList.SelectedIndex == 0)
            {
                foreach (string s in _colorListBox.Items)
                {
                    System.Drawing.Color c = System.Drawing.Color.FromName(s);

                    c = System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);

                    if (c.Equals(_color) | (c.R==_color.R && c.G==_color.G && c.B==_color.B && c.A==_color.A))
                    {
                        name = s;
                        break;
                    }
                }
            }
            else
            {
                name = string.Format("#{0:X2}{1:X2}{2:X2}", _color.R, _color.G, _color.B);
            }

            int i = _colorListBox.FindString(name);

            _valueChanging = true;
            if (i >= 0 & name !="")
            {
                _colorListBox.SelectedIndex = i;
            }
            else
            {
                _colorListBox.SelectedIndex = -1;
            }
            _valueChanging = false;
        }

        protected override void OnLoad(EventArgs e) 
        {
            comboBoxList.SelectedIndex = 0;
            Structure();
            FindColor();
        }
    }
}
