using System;
using SharpMap.Forms.Controls.Palette;

namespace SharpMap.Forms.Controls.Color
{
    partial class ColorChannel
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tomPaletteSlider = new SharpMap.Forms.Controls.Palette.PaletteSlider();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.labelChannelName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.Controls.Add(this.tomPaletteSlider, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.numericUpDown, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.labelChannelName, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(265, 25);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tomPaletteSlider
            // 
            this.tomPaletteSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tomPaletteSlider.Location = new System.Drawing.Point(20, 0);
            this.tomPaletteSlider.Margin = new System.Windows.Forms.Padding(0);
            this.tomPaletteSlider.MarkerSize = 9;
            this.tomPaletteSlider.Maximum = 255D;
            this.tomPaletteSlider.MaximumColor = System.Drawing.Color.Indigo;
            this.tomPaletteSlider.Minimum = 0D;
            this.tomPaletteSlider.MinimumColor = System.Drawing.Color.White;
            this.tomPaletteSlider.Name = "tomPaletteSlider";
            this.tomPaletteSlider.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.tomPaletteSlider.Size = new System.Drawing.Size(195, 25);
            this.tomPaletteSlider.TabIndex = 2;
            this.tomPaletteSlider.Value = 0D;
            this.tomPaletteSlider.ValueChanged += new System.EventHandler(this.tomPaletteSlider_ValueChanged);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown.Location = new System.Drawing.Point(218, 3);
            this.numericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown.TabIndex = 1;
            this.numericUpDown.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // labelChannelName
            // 
            this.labelChannelName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelChannelName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelChannelName.Location = new System.Drawing.Point(3, 6);
            this.labelChannelName.Name = "labelChannelName";
            this.labelChannelName.Size = new System.Drawing.Size(14, 13);
            this.labelChannelName.TabIndex = 3;
            this.labelChannelName.Text = "X:";
            this.labelChannelName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColorChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ColorChannel";
            this.Size = new System.Drawing.Size(265, 25);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private PaletteSlider tomPaletteSlider;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.TextBox labelChannelName;

    }
}
