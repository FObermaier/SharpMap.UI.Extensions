using System.Drawing;
using System.Windows.Forms;

namespace SharpMap.Forms.Controls.Color
{
    public partial class ColorListBox : ListBox
    {
        public ColorListBox()
        {
            base.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        }

        private bool _hideColorLabel;

        /// <summary>
        /// Gets or sets a value indicating if the color label should be displayed
        /// </summary>
        public bool HideColorLabel
        {
            get
            {
                return _hideColorLabel;
            }
            set
            {
                _hideColorLabel = value;
            }
        }

        public System.Drawing.Color GetSelectedColor()
        {
            if (SelectedIndex < 0) return System.Drawing.Color.Empty;

            return ColorExtensions.GetColorFromName(Items[SelectedIndex].ToString());
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {

            base.OnDrawItem(e);

            if (DesignMode && Items.Count == 0)
            {
                if (e.Index == 0)
                {
                    e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                    e.Graphics.DrawString(Name, e.Font, SystemBrushes.WindowText, e.Bounds);
                }
                return;
            }

            string name = Items[e.Index].ToString();
            System.Drawing.Color color = ColorExtensions.GetColorFromName(name);

            if (!_hideColorLabel)
            {
                if (e.Index != ListBox.NoMatches)
                {

                    var colorRect = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Height, e.Bounds.Height);
                    colorRect.Inflate(new Size(-2, -2));

                    var textRect = new Rectangle(e.Bounds.Left + e.Bounds.Height, e.Bounds.Top, e.Bounds.Width - e.Bounds.Height, e.Bounds.Height);
                    textRect.Inflate(new Size(-2, -2));

                    e.DrawBackground();
                    using (var solidBrush = new SolidBrush(color))
                    {
                        e.Graphics.FillRectangle(solidBrush, colorRect);
                    }

                    Brush brush;

                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        brush = SystemBrushes.HighlightText;
                    }
                    else
                    {
                        brush = SystemBrushes.WindowText;
                    }

                    e.Graphics.DrawString(name, Font, brush, textRect);

                    e.DrawFocusRectangle();


                }

            }
            else
            {

                Rectangle colorRect = e.Bounds;

                SolidBrush solidBrush = new SolidBrush(color);

                if (!MultiColumn)
                {
                    colorRect.Inflate(new Size(-2, -2));

                    e.DrawBackground();
                    e.Graphics.FillRectangle(solidBrush, colorRect);
                    solidBrush.Dispose();

                    Brush brush;

                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;
                    else
                        brush = SystemBrushes.WindowText;

                    e.DrawFocusRectangle();

                    brush.Dispose();
                }
                else
                {
                    e.Graphics.FillRectangle(solidBrush, colorRect);
                }
            }
        }
    }
}
