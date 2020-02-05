namespace VZTestFunctionApp01
{
    partial class MICMakeSure
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
            this.MICOKbutton = new System.Windows.Forms.Button();
            this.MICNCbutton = new System.Windows.Forms.Button();
            this.MICMakeSurelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MICOKbutton
            // 
            this.MICOKbutton.Font = new System.Drawing.Font("幼圆", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MICOKbutton.Location = new System.Drawing.Point(51, 140);
            this.MICOKbutton.Name = "MICOKbutton";
            this.MICOKbutton.Size = new System.Drawing.Size(186, 66);
            this.MICOKbutton.TabIndex = 0;
            this.MICOKbutton.Text = " 是";
            this.MICOKbutton.UseVisualStyleBackColor = true;
            this.MICOKbutton.Click += new System.EventHandler(this.MICOKbutton_Click);
            // 
            // MICNCbutton
            // 
            this.MICNCbutton.Font = new System.Drawing.Font("幼圆", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MICNCbutton.Location = new System.Drawing.Point(274, 140);
            this.MICNCbutton.Name = "MICNCbutton";
            this.MICNCbutton.Size = new System.Drawing.Size(183, 66);
            this.MICNCbutton.TabIndex = 1;
            this.MICNCbutton.Text = "否";
            this.MICNCbutton.UseVisualStyleBackColor = true;
            this.MICNCbutton.Click += new System.EventHandler(this.MICNCbutton_Click);
            // 
            // MICMakeSurelabel
            // 
            this.MICMakeSurelabel.AutoSize = true;
            this.MICMakeSurelabel.Font = new System.Drawing.Font("幼圆", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MICMakeSurelabel.Location = new System.Drawing.Point(76, 45);
            this.MICMakeSurelabel.Name = "MICMakeSurelabel";
            this.MICMakeSurelabel.Size = new System.Drawing.Size(351, 38);
            this.MICMakeSurelabel.TabIndex = 2;
            this.MICMakeSurelabel.Text = "MIC录音波形是否OK";
            // 
            // MICMakeSure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 254);
            this.Controls.Add(this.MICMakeSurelabel);
            this.Controls.Add(this.MICNCbutton);
            this.Controls.Add(this.MICOKbutton);
            this.Name = "MICMakeSure";
            this.Text = "MICMakeSure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MICOKbutton;
        private System.Windows.Forms.Button MICNCbutton;
        private System.Windows.Forms.Label MICMakeSurelabel;
    }
}