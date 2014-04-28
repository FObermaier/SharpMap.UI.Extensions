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

using System.Drawing;
using System.Windows.Forms;

namespace SharpMap.Forms.Controls.Base
{
    public class EnhancedComboBox : ComboBox
    {

        private readonly ToolStripDropDown _popupDropDown = new ToolStripDropDown();
        private ToolStripControlHost _controlHost;

        protected Control UserControl = null;

        public EnhancedComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

// ReSharper disable InconsistentNaming
        public const uint WM_COMMAND = 0x0111;
        public const uint WM_USER = 0x0400;
        public const uint WM_REFLECT = WM_USER + 0x1C00;
        public const uint WM_LBUTTONDOWN = 0x0201;

        public const uint CBN_DROPDOWN = 7;
        public const uint CBN_CLOSEUP = 8;

        public static uint HIWORD(int n)
        {
            return (uint)(n >> 16) & 0xffff;
        }
// ReSharper restore InconsistentNaming

        public override bool PreProcessMessage(ref Message m)
        {
            if (m.Msg == (WM_REFLECT + WM_COMMAND))
            {
                if (HIWORD((int)m.WParam) == CBN_DROPDOWN)
                    return false;
            }
            return base.PreProcessMessage(ref m);
        }


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN)
            {
                ShowDropDown();
                return;
            }

            if (m.Msg == (WM_REFLECT + WM_COMMAND))
            {
                switch (HIWORD((int)m.WParam))
                {
                    case CBN_DROPDOWN:
                        ShowDropDown();
                        return;

                    case CBN_CLOSEUP:
                        //if ((DateTime.Now - m_sShowTime).Seconds > 1)
                        HideDropDown();
                        return;
                }
            }

            base.WndProc(ref m);
        }

        protected void HideDropDown()
        {
            _popupDropDown.Visible = false;
        }

        protected void ShowDropDown()
        {


            if (_controlHost == null)
            {
                if (UserControl == null)
                {
                    var lb = new Label();
                    lb.Text = "No control";
                    _controlHost = new ToolStripControlHost(lb);
                }
                else
                {
                    _controlHost = new ToolStripControlHost(UserControl);
                }
            }

            _controlHost.Padding = new Padding(1);
            _controlHost.Margin = new Padding(0);
            _popupDropDown.Padding = new Padding(0);
            _popupDropDown.Margin = new Padding(0);

            if (_popupDropDown.Items.Count == 0)
            {
                _popupDropDown.Items.Add(_controlHost);

            }

            Point loc = this.Parent.PointToScreen(this.Location);

            Screen currentScreen = Screen.FromPoint(loc);
            Rectangle screenRect = currentScreen.WorkingArea;

            if (loc.X < screenRect.X)
                loc.X = screenRect.X;
            else if ((loc.X + _popupDropDown.Width) > screenRect.Right)
                loc.X = screenRect.Right - _popupDropDown.Width;

            if ((loc.Y + this.Height + _popupDropDown.Height) > screenRect.Bottom)
                loc.Offset(0, -_popupDropDown.Height);
            else
                loc.Offset(0, this.Height);

            _popupDropDown.Show(loc.X, loc.Y);
            //_PopupDropDown.Show();
        }
    }
}