using System;

namespace SharpMap.Forms.Controls.Color
{
    partial class ColorSelector
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._colorCellMatrix = new SharpMap.Forms.Controls.Color.ColorCellMatrix();
            this._colorCellWheel = new SharpMap.Forms.Controls.Color.ColorCellWheel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this._colorLists = new SharpMap.Forms.Controls.Color.ColorLists();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._colorComponentEditorRgb = new SharpMap.Forms.Controls.Color.ColorComponentEditor();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this._colorComponentEditorCmyk = new SharpMap.Forms.Controls.Color.ColorComponentEditor();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this._colorComponentEditorHsl = new SharpMap.Forms.Controls.Color.ColorComponentEditor();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panelActColor = new System.Windows.Forms.Panel();
            this.panelNewColor = new System.Windows.Forms.Panel();
            this.textBoxARGB = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(290, 226);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this._colorCellMatrix);
            this.tabPage1.Controls.Add(this._colorCellWheel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(282, 200);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hex";
            // 
            // _colorCellMatrix
            // 
            this._colorCellMatrix.CellBorderColor = System.Drawing.Color.Empty;
            this._colorCellMatrix.CellColumns = 1;
            this._colorCellMatrix.CellRows = 16;
            this._colorCellMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this._colorCellMatrix.Location = new System.Drawing.Point(217, 3);
            this._colorCellMatrix.MinimumSize = new System.Drawing.Size(12, 193);
            this._colorCellMatrix.Name = "_colorCellMatrix";
            this._colorCellMatrix.SelectedColor = System.Drawing.Color.Empty;
            this._colorCellMatrix.Size = new System.Drawing.Size(60, 193);
            this._colorCellMatrix.TabIndex = 8;
            this._colorCellMatrix.SelectedColorChanged += new System.EventHandler(this.tomColorSelector_SelectedColorChanged);
            // 
            // _colorCellWheel
            // 
            this._colorCellWheel.CellBorderColor = System.Drawing.Color.Black;
            this._colorCellWheel.Dock = System.Windows.Forms.DockStyle.Left;
            this._colorCellWheel.Location = new System.Drawing.Point(3, 3);
            this._colorCellWheel.MinimumSize = new System.Drawing.Size(170, 160);
            this._colorCellWheel.Name = "_colorCellWheel";
            this._colorCellWheel.SelectedColor = System.Drawing.Color.Empty;
            this._colorCellWheel.Size = new System.Drawing.Size(214, 192);
            this._colorCellWheel.TabIndex = 7;
            this._colorCellWheel.SelectedColorChanged += new System.EventHandler(this.tomColorSelector_SelectedColorChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.White;
            this.tabPage5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage5.Controls.Add(this._colorLists);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(282, 200);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Palette";
            // 
            // _colorLists
            // 
            this._colorLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this._colorLists.Location = new System.Drawing.Point(3, 3);
            this._colorLists.Name = "_colorLists";
            this._colorLists.SelectedColor = System.Drawing.Color.Empty;
            this._colorLists.Size = new System.Drawing.Size(274, 192);
            this._colorLists.TabIndex = 0;
            this._colorLists.SelectedColorChanged += new System.EventHandler(this.tomColorSelector_SelectedColorChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this._colorComponentEditorRgb);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(282, 200);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RGB";
            // 
            // _colorComponentEditorRgb
            // 
            this._colorComponentEditorRgb.ColorModel = SharpMap.Forms.Controls.Color.ColorModel.RGB;
            this._colorComponentEditorRgb.Dock = System.Windows.Forms.DockStyle.Fill;
            this._colorComponentEditorRgb.Location = new System.Drawing.Point(3, 3);
            this._colorComponentEditorRgb.Name = "_colorComponentEditorRgb";
            this._colorComponentEditorRgb.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this._colorComponentEditorRgb.Size = new System.Drawing.Size(274, 192);
            this._colorComponentEditorRgb.TabIndex = 2;
            this._colorComponentEditorRgb.SelectedColorChanged += new System.EventHandler(this.tomColorSelector_SelectedColorChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this._colorComponentEditorCmyk);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(282, 200);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CMYK";
            // 
            // _colorComponentEditorCmyk
            // 
            this._colorComponentEditorCmyk.ColorModel = SharpMap.Forms.Controls.Color.ColorModel.CMYK;
            this._colorComponentEditorCmyk.Dock = System.Windows.Forms.DockStyle.Fill;
            this._colorComponentEditorCmyk.Location = new System.Drawing.Point(3, 3);
            this._colorComponentEditorCmyk.Name = "_colorComponentEditorCmyk";
            this._colorComponentEditorCmyk.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(129)))));
            this._colorComponentEditorCmyk.Size = new System.Drawing.Size(274, 192);
            this._colorComponentEditorCmyk.TabIndex = 2;
            this._colorComponentEditorCmyk.SelectedColorChanged += new System.EventHandler(this.tomColorSelector_SelectedColorChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage4.Controls.Add(this._colorComponentEditorHsl);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(282, 200);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "HSL";
            // 
            // _colorComponentEditorHsl
            // 
            this._colorComponentEditorHsl.ColorModel = SharpMap.Forms.Controls.Color.ColorModel.HSL;
            this._colorComponentEditorHsl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._colorComponentEditorHsl.Location = new System.Drawing.Point(3, 3);
            this._colorComponentEditorHsl.Name = "_colorComponentEditorHsl";
            this._colorComponentEditorHsl.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._colorComponentEditorHsl.Size = new System.Drawing.Size(274, 192);
            this._colorComponentEditorHsl.TabIndex = 2;
            this._colorComponentEditorHsl.SelectedColorChanged += new System.EventHandler(this.tomColorSelector_SelectedColorChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(236, 231);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(51, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // panelActColor
            // 
            this.panelActColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActColor.Location = new System.Drawing.Point(7, 233);
            this.panelActColor.Name = "panelActColor";
            this.panelActColor.Size = new System.Drawing.Size(33, 22);
            this.panelActColor.TabIndex = 3;
            // 
            // panelNewColor
            // 
            this.panelNewColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNewColor.Location = new System.Drawing.Point(39, 233);
            this.panelNewColor.Name = "panelNewColor";
            this.panelNewColor.Size = new System.Drawing.Size(33, 22);
            this.panelNewColor.TabIndex = 4;
            // 
            // textBoxARGB
            // 
            this.textBoxARGB.Location = new System.Drawing.Point(79, 234);
            this.textBoxARGB.Name = "textBoxARGB";
            this.textBoxARGB.Size = new System.Drawing.Size(73, 20);
            this.textBoxARGB.TabIndex = 5;
            // 
            // ColorSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxARGB);
            this.Controls.Add(this.panelNewColor);
            this.Controls.Add(this.panelActColor);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl);
            this.Name = "ColorSelector";
            this.Size = new System.Drawing.Size(290, 260);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private ColorCellMatrix _colorCellMatrix;
        private ColorCellWheel _colorCellWheel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Panel panelActColor;
        private System.Windows.Forms.Panel panelNewColor;
        private System.Windows.Forms.TabPage tabPage5;
        private ColorLists _colorLists;
        private ColorComponentEditor _colorComponentEditorRgb;
        private ColorComponentEditor _colorComponentEditorCmyk;
        private ColorComponentEditor _colorComponentEditorHsl;
        private System.Windows.Forms.TextBox textBoxARGB;


        private void tomCellMatrix_Load(object sender, EventArgs e)
        {
            int b = 256 - 32;

            _colorCellMatrix.Cells[0][0].FillColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);

            for (int i = 0; i < 15; i++)
            {
                _colorCellMatrix.Cells[i + 1][0].FillColor = System.Drawing.Color.FromArgb(b, b, b);

                b -= 16;
            }
        }
    }
}
