
using System;
using System.ComponentModel;
// Copyright 2013 - Felix Obermaier (www.ivv-aachen.de)
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

using System.Globalization;
using System.Windows.Forms;
using SharpMap.Rendering.Thematics;

namespace SharpMap.Forms.Controls.Color
{
    public class ColorBlendControl : ListView
    {
        private ColorBlend _colorBlend;
        
        public ColorBlendControl()
        {
            AllowColumnReorder = false;
            LabelEdit = true;
            Columns.AddRange(new []
            {
                new ColumnHeader {
                    Text = Properties.Resources.colorBlendControl_Position, 
                    TextAlign = HorizontalAlignment.Right },
                new ColumnHeader
                {
                    Text = Properties.Resources.colorBlendControl_Color, 
                    TextAlign = HorizontalAlignment.Center
            }});

            View = View.Details;
            OwnerDraw = true;
        }

        /// <summary>
        /// Event raised when the <see cref="ColorBlend"/> value has changed
        /// </summary>
        public event EventHandler ColorBlendChanged;

        /// <summary>
        /// Event invoker for the <see cref="ColorBlendChanged"/> event
        /// </summary>
        /// <param name="e">The event's arguments</param>
        protected virtual void OnColorBlendChanged(EventArgs e)
        {
            Items.Clear();

            for (var i = 0; i < _colorBlend.Colors.Length; i++)
            {
                Items.Add(CreateColorBlendItem(_colorBlend.Positions[i], _colorBlend.Colors[i]));
            }
            
            if (ColorBlendChanged != null)
                ColorBlendChanged(this, e);

            Refresh();
        }

        private static ListViewItem CreateColorBlendItem(float pos, System.Drawing.Color col)
        {
            var res = new ListViewItem
            {
                Text = pos.ToString("N4", NumberFormatInfo.CurrentInfo),
                UseItemStyleForSubItems = false
            };

            res.SubItems.Add(new ListViewItem.ListViewSubItem(res, string.Empty, 
                             DefaultForeColor, col, DefaultFont));

            return res;
        }

        private ColorBlend CreateColorBlend()
        {
            if (Items.Count < 2)
                return null;

            var poss = new float[Items.Count];
            var cols = new System.Drawing.Color[Items.Count];
            for (var i = 0; i < Items.Count; i++)
            {
                poss[i] = float.Parse(Items[i].Text, NumberStyles.Number, NumberFormatInfo.CurrentInfo);
                cols[i] = Items[i].SubItems[1].BackColor;
            }
            return new ColorBlend(cols, poss);
        }

        /// <summary>
        /// Gets or sets a value indicating the current color blend
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ColorBlend ColorBlend
        {
            get { return CreateColorBlend(); }
            set
            {
                if (ReferenceEquals(value, _colorBlend))
                    return;

                _colorBlend = value;
                OnColorBlendChanged(EventArgs.Empty);
            }
        }

        protected override void OnAfterLabelEdit(LabelEditEventArgs e)
        {
            float value;
            if (!float.TryParse(e.Label, NumberStyles.Number, NumberFormatInfo.CurrentInfo, out value))
            {
                e.CancelEdit = true;
                return;
            }
            base.OnAfterLabelEdit(e);

            Items[e.Item].Text = value.ToString("N4", NumberFormatInfo.CurrentInfo);
            Sort();
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (e.Button == MouseButtons.Left)
            {
                var info = HitTest(e.Location);
                if (info.SubItem == null) return;
            }
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);

            var colorWidth = ClientSize.Width - Columns[0].Width - 1;
            Columns[1].Width = colorWidth;
        }

        protected override void OnColumnWidthChanging(ColumnWidthChangingEventArgs e)
        {
            base.OnColumnWidthChanging(e);

            var colorWidth = ClientSize.Width - Columns[0].Width - 1;
            Columns[1].Width = colorWidth;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
