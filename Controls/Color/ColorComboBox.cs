using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SharpMap.Forms.Controls.Base;

namespace SharpMap.Forms.Controls.Color
{
    public class ColorComboBox : EnhancedComboBox
    {
        private readonly ColorSelector _colorSelector = new ColorSelector();

        private System.Drawing.Color _color;

        /// <summary>
        /// Gets or sets the selected color
        /// </summary>
        public System.Drawing.Color SelectedColor
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                _colorSelector.SelectedColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        public ColorComboBox()
        {
            UserControl = _colorSelector;
            _colorSelector.SelectedColorChanged += new EventHandler(tomColorSelector_SelectedColorChanged);
        }


        void tomColorSelector_SelectedColorChanged(object sender, EventArgs e)
        {
            var tcs = sender as ColorSelector;
            if (tcs == null || tcs != _colorSelector)
                throw new InvalidOperationException();

            SelectedColor = tcs.SelectedColor;
            
            HideDropDown();
            Invalidate();
        }


        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            using (var hb = new HatchBrush(HatchStyle.SmallCheckerBoard, 
                                           System.Drawing.Color.Black, 
                                           System.Drawing.Color.White))
            using (var sb = new SolidBrush(_color))
            {
                e.Graphics.FillRectangle(hb, e.Bounds);
                e.Graphics.FillRectangle(sb, e.Bounds);
            }
        }
    }
}
