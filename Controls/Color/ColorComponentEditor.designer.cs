using System;

namespace SharpMap.Forms.Controls.Color
{
    partial class ColorComponentEditor
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
            this._channel1 = new SharpMap.Forms.Controls.Color.ColorChannel();
            this._channel2 = new SharpMap.Forms.Controls.Color.ColorChannel();
            this._channel3 = new SharpMap.Forms.Controls.Color.ColorChannel();
            this._channel4 = new SharpMap.Forms.Controls.Color.ColorChannel();
            this._channel5 = new SharpMap.Forms.Controls.Color.ColorChannel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this._channel1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this._channel2, 0, 1);
            this.tableLayoutPanel.Controls.Add(this._channel3, 0, 2);
            this.tableLayoutPanel.Controls.Add(this._channel4, 0, 3);
            this.tableLayoutPanel.Controls.Add(this._channel5, 0, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(280, 170);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // _channel1
            // 
            this._channel1.BackColor = System.Drawing.Color.Transparent;
            this._channel1.Color0 = System.Drawing.Color.White;
            this._channel1.Color1 = System.Drawing.Color.Black;
            this._channel1.ColorChannelType = SharpMap.Forms.Controls.Color.ColorChannelType.None;
            this._channel1.Dock = System.Windows.Forms.DockStyle.Top;
            this._channel1.Location = new System.Drawing.Point(3, 3);
            this._channel1.Maximum = 255F;
            this._channel1.Minimum = 0F;
            this._channel1.Name = "_channel1";
            this._channel1.Size = new System.Drawing.Size(274, 25);
            this._channel1.TabIndex = 0;
            this._channel1.Value = 128F;
            this._channel1.ValueChanged += new System.EventHandler(this.tomChannel_ValueChange);
            // 
            // _channel2
            // 
            this._channel2.BackColor = System.Drawing.Color.Transparent;
            this._channel2.Color0 = System.Drawing.Color.White;
            this._channel2.Color1 = System.Drawing.Color.Black;
            this._channel2.ColorChannelType = SharpMap.Forms.Controls.Color.ColorChannelType.None;
            this._channel2.Dock = System.Windows.Forms.DockStyle.Top;
            this._channel2.Location = new System.Drawing.Point(3, 37);
            this._channel2.Maximum = 255F;
            this._channel2.Minimum = 0F;
            this._channel2.Name = "_channel2";
            this._channel2.Size = new System.Drawing.Size(274, 25);
            this._channel2.TabIndex = 1;
            this._channel2.Value = 128F;
            this._channel2.ValueChanged += new System.EventHandler(this.tomChannel_ValueChange);
            // 
            // _channel3
            // 
            this._channel3.BackColor = System.Drawing.Color.Transparent;
            this._channel3.Color0 = System.Drawing.Color.White;
            this._channel3.Color1 = System.Drawing.Color.Black;
            this._channel3.ColorChannelType = SharpMap.Forms.Controls.Color.ColorChannelType.None;
            this._channel3.Dock = System.Windows.Forms.DockStyle.Top;
            this._channel3.Location = new System.Drawing.Point(3, 71);
            this._channel3.Maximum = 255F;
            this._channel3.Minimum = 0F;
            this._channel3.Name = "_channel3";
            this._channel3.Size = new System.Drawing.Size(274, 25);
            this._channel3.TabIndex = 2;
            this._channel3.Value = 128F;
            this._channel3.ValueChanged += new System.EventHandler(this.tomChannel_ValueChange);
            // 
            // _channel4
            // 
            this._channel4.BackColor = System.Drawing.Color.Transparent;
            this._channel4.Color0 = System.Drawing.Color.White;
            this._channel4.Color1 = System.Drawing.Color.Black;
            this._channel4.ColorChannelType = SharpMap.Forms.Controls.Color.ColorChannelType.None;
            this._channel4.Dock = System.Windows.Forms.DockStyle.Top;
            this._channel4.Location = new System.Drawing.Point(3, 105);
            this._channel4.Maximum = 255F;
            this._channel4.Minimum = 0F;
            this._channel4.Name = "_channel4";
            this._channel4.Size = new System.Drawing.Size(274, 25);
            this._channel4.TabIndex = 3;
            this._channel4.Value = 128F;
            this._channel4.ValueChanged += new System.EventHandler(this.tomChannel_ValueChange);
            // 
            // _channel5
            // 
            this._channel5.BackColor = System.Drawing.Color.Transparent;
            this._channel5.Color0 = System.Drawing.Color.White;
            this._channel5.Color1 = System.Drawing.Color.Black;
            this._channel5.ColorChannelType = SharpMap.Forms.Controls.Color.ColorChannelType.None;
            this._channel5.Dock = System.Windows.Forms.DockStyle.Top;
            this._channel5.Location = new System.Drawing.Point(3, 139);
            this._channel5.Maximum = 255F;
            this._channel5.Minimum = 0F;
            this._channel5.Name = "_channel5";
            this._channel5.Size = new System.Drawing.Size(274, 25);
            this._channel5.TabIndex = 4;
            this._channel5.Value = 128F;
            this._channel5.ValueChanged += new System.EventHandler(this.tomChannel_ValueChange);
            // 
            // ColorComponentEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ColorComponentEditor";
            this.Size = new System.Drawing.Size(280, 170);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private ColorChannel _channel1;
        private ColorChannel _channel2;
        private ColorChannel _channel3;
        private ColorChannel _channel4;
        private ColorChannel _channel5;

    }
}
