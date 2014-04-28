namespace TomControls
{
    partial class TomCellWheelViewer
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
            this.SuspendLayout();
            // 
            // TomCellWheelViewer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TomCellWheelViewer2";
            this.Load += new System.EventHandler(this.TomCellWheelViewer_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TomCellWheelViewer_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TomCellWheelViewer_MouseClick);
            this.Resize += new System.EventHandler(this.TomCellWheelViewer_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
