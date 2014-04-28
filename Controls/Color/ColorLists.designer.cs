using System;

namespace SharpMap.Forms.Controls.Color
{
    partial class ColorLists
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
            this.comboBoxList = new System.Windows.Forms.ComboBox();
            this._colorListBox = new ColorListBox();
            this.SuspendLayout();
            // 
            // comboBoxList
            // 
            this.comboBoxList.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxList.FormattingEnabled = true;
            this.comboBoxList.Location = new System.Drawing.Point(0, 0);
            this.comboBoxList.Name = "comboBoxList";
            this.comboBoxList.Size = new System.Drawing.Size(336, 21);
            this.comboBoxList.TabIndex = 0;
            this.comboBoxList.SelectedIndexChanged += new System.EventHandler(this.comboBoxList_SelectedIndexChanged);
            // 
            // tomColorListBox
            // 
            this._colorListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._colorListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._colorListBox.FormattingEnabled = true;
            this._colorListBox.ItemHeight = 20;
            this._colorListBox.Location = new System.Drawing.Point(0, 21);
            this._colorListBox.Name = "_colorListBox";
            this._colorListBox.Size = new System.Drawing.Size(336, 239);
            this._colorListBox.TabIndex = 1;
            this._colorListBox.SelectedIndexChanged += new System.EventHandler(this.tomColorListBox_SelectedIndexChanged);
            // 
            // TomColorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._colorListBox);
            this.Controls.Add(this.comboBoxList);
            this.Name = "TomColorList";
            this.Size = new System.Drawing.Size(336, 260);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxList;
        private ColorListBox _colorListBox;

        private void comboBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Structure();
            FindColor();
        }

        private void tomColorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _color = _colorListBox.GetSelectedColor();

            if (!_valueChanging)
            {
                OnSelectedColorChanged(EventArgs.Empty);
            }
        }
    }
}
