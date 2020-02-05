namespace VZTestFunctionApp01
{
    partial class FormShowTips
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
            this.ShowTipstextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ShowTipstextBox
            // 
            this.ShowTipstextBox.BackColor = System.Drawing.SystemColors.Control;
            this.ShowTipstextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ShowTipstextBox.Font = new System.Drawing.Font("幼圆", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowTipstextBox.Location = new System.Drawing.Point(42, 58);
            this.ShowTipstextBox.Name = "ShowTipstextBox";
            this.ShowTipstextBox.ReadOnly = true;
            this.ShowTipstextBox.Size = new System.Drawing.Size(402, 48);
            this.ShowTipstextBox.TabIndex = 1;
            // 
            // FormShowTips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 254);
            this.Controls.Add(this.ShowTipstextBox);
            this.Name = "FormShowTips";
            this.Text = "FormShowTips";
            this.Activated += new System.EventHandler(this.FormShowTips_Activated);
            this.Load += new System.EventHandler(this.FormShowTips_Load);
            this.VisibleChanged += new System.EventHandler(this.FormShowTips_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ShowTipstextBox;
    }
}