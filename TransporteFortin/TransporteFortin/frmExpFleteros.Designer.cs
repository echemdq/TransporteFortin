namespace TransporteFortin
{
    partial class frmExpFleteros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label9 = new System.Windows.Forms.Label();
            this.cmbFletero = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 158;
            this.label9.Text = "Fletero Destino";
            // 
            // cmbFletero
            // 
            this.cmbFletero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFletero.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.cmbFletero.FormattingEnabled = true;
            this.cmbFletero.Location = new System.Drawing.Point(111, 6);
            this.cmbFletero.Name = "cmbFletero";
            this.cmbFletero.Size = new System.Drawing.Size(422, 21);
            this.cmbFletero.TabIndex = 157;
            // 
            // frmExpFleteros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 262);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbFletero);
            this.Name = "frmExpFleteros";
            this.Text = "frmExpFleteros";
            this.Load += new System.EventHandler(this.frmExpFleteros_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbFletero;
    }
}