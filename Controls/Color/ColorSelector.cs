using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SharpMap.Forms.Controls.Color
{
    public partial class ColorSelector : UserControl
    {
        private System.Drawing.Color _initialColor = System.Drawing.Color.Empty;
        private System.Drawing.Color _newColor = System.Drawing.Color.Empty;
        
        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        public ColorSelector()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Event raised when the <see cref="SelectedColor"/> has changed
        /// </summary>
        public event EventHandler SelectedColorChanged;

        /// <summary>
        /// Event invoker for the <see cref="SelectedColorChanged"/> event.
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnSelectedColorChanged(EventArgs e)
        {
            if (SelectedColorChanged != null)
                SelectedColorChanged(this, e);
        }

        /// <summary>
        /// Gets or sets a value indicating the selected color
        /// </summary>
        public System.Drawing.Color SelectedColor
        {
            get
            {
                return _newColor;
            }
            set
            {
                if (value == _newColor)
                    return;

                _newColor = value;
                Structure();
                OnSelectedColorChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the intital color
        /// </summary>
        public System.Drawing.Color InitialColor
        {
            get
            {
                return _initialColor;
            }
            set
            {
                if (value == _initialColor)
                    return;

                _initialColor = value;

                Structure();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            tomCellMatrix_Load(_colorCellMatrix, EventArgs.Empty);
        }


        private void Structure()
        {
            var hb = new HatchBrush(HatchStyle.SmallCheckerBoard, System.Drawing.Color.Black, System.Drawing.Color.White);

            using (var g1 = panelActColor.CreateGraphics())
            {
                g1.FillRectangle(hb, panelActColor.ClientRectangle);
                g1.FillRectangle(new SolidBrush(_initialColor), panelActColor.ClientRectangle);
            }

            using (var g2 = panelNewColor.CreateGraphics())
            {
                g2.FillRectangle(hb, panelNewColor.ClientRectangle);
                g2.FillRectangle(new SolidBrush(_newColor), panelNewColor.ClientRectangle);
            }
            hb.Dispose();

            _colorCellWheel.SelectedColor = _initialColor;
            _colorCellMatrix.SelectedColor = _initialColor;

            _colorLists.SelectedColor = _initialColor;

            _colorComponentEditorRgb.SelectedColor = _initialColor;
            _colorComponentEditorCmyk.SelectedColor = _initialColor;
            _colorComponentEditorHsl.SelectedColor = _initialColor;

        }

        private void tomCellMatrix_SelectionChange(int row, int col)
        {
            System.Drawing.Color c = _colorCellMatrix.SelectedColor;
            _colorCellWheel.SelectedColor = c;

            ColorChanged(c);
        }

        private void ColorChanged(System.Drawing.Color C)
        {

            _newColor = C;

            HatchBrush hb = new HatchBrush(HatchStyle.SmallCheckerBoard, System.Drawing.Color.Black, System.Drawing.Color.White);

            Graphics g2 = panelNewColor.CreateGraphics();

            g2.FillRectangle(hb, panelNewColor.ClientRectangle);
            g2.FillRectangle(new SolidBrush(_newColor), panelNewColor.ClientRectangle);

            g2.Dispose();
            hb.Dispose();
            
            
            textBoxARGB.Text = string.Format(string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", _newColor.R, _newColor.G, _newColor.B, _newColor.A));

            _colorCellMatrix.SelectedColor = _newColor;
            _colorCellWheel.SelectedColor = _newColor;

            if (tabControl.SelectedIndex != 1)
            {
                _colorLists.SelectedColor = _newColor;
            }

            if (tabControl.SelectedIndex != 2)
            {
                _colorComponentEditorRgb.SelectedColor = _newColor;
            }

            if (tabControl.SelectedIndex != 3)
            {
                _colorComponentEditorCmyk.SelectedColor = _newColor;
            }

            if (tabControl.SelectedIndex != 4)
            {
                _colorComponentEditorHsl.SelectedColor = _newColor;
            }
        }

        private void tomColorSelector_SelectedColorChanged(object sender, EventArgs e)
        {
            var tcs = sender as ColorSelector;
            if (tcs != null)
            {
                SelectedColor = tcs.SelectedColor;
                return;
            }

            var tcl = sender as ColorLists;
            if (tcl != null)
            {
                SelectedColor = tcl.SelectedColor;
                return;
            }

            var tcw = sender as ColorCellWheel;
            if (tcw != null)
            {
                SelectedColor = tcw.SelectedColor;
                return;
            }

            var tcm = sender as ColorCellMatrix;
            if (tcm != null)
            {
                SelectedColor = tcm.SelectedColor;
                return;
            }

            //throw new NotImplementedException();
        }
    }
}
