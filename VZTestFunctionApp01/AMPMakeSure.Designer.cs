namespace VZTestFunctionApp01
{
    partial class AMPMakeSure
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
            this.AMPOKbutton = new System.Windows.Forms.Button();
            this.AMPNCbutton = new System.Windows.Forms.Button();
            this.AMPMakeSurelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AMPOKbutton
            // 
            this.AMPOKbutton.Font = new System.Drawing.Font("幼圆", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AMPOKbutton.Location = new System.Drawing.Point(51, 140);
            this.AMPOKbutton.Name = "AMPOKbutton";
            this.AMPOKbutton.Size = new System.Drawing.Size(176, 66);
            this.AMPOKbutton.TabIndex = 0;
            this.AMPOKbutton.Text = "是";
            this.AMPOKbutton.UseVisualStyleBackColor = true;
            this.AMPOKbutton.Click += new System.EventHandler(this.AMPOKbutton_Click);
            // 
            // AMPNCbutton
            // 
            this.AMPNCbutton.Font = new System.Drawing.Font("幼圆", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AMPNCbutton.Location = new System.Drawing.Point(270, 140);
            this.AMPNCbutton.Name = "AMPNCbutton";
            this.AMPNCbutton.Size = new System.Drawing.Size(168, 66);
            this.AMPNCbutton.TabIndex = 1;
            this.AMPNCbutton.Text = "否";
            this.AMPNCbutton.UseVisualStyleBackColor = true;
            this.AMPNCbutton.Click += new System.EventHandler(this.AMPNCbutton_Click);
            // 
            // AMPMakeSurelabel
            // 
            this.AMPMakeSurelabel.AutoSize = true;
            this.AMPMakeSurelabel.Font = new System.Drawing.Font("幼圆", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AMPMakeSurelabel.Location = new System.Drawing.Point(82, 54);
            this.AMPMakeSurelabel.Name = "AMPMakeSurelabel";
            this.AMPMakeSurelabel.Size = new System.Drawing.Size(329, 38);
            this.AMPMakeSurelabel.TabIndex = 2;
            this.AMPMakeSurelabel.Text = "音频是否正确输出";
            // 
            // AMPMakeSure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 254);
            this.Controls.Add(this.AMPMakeSurelabel);
            this.Controls.Add(this.AMPNCbutton);
            this.Controls.Add(this.AMPOKbutton);
            this.Name = "AMPMakeSure";
            this.Text = "AMPMakeSure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AMPOKbutton;
        private System.Windows.Forms.Button AMPNCbutton;
        private System.Windows.Forms.Label AMPMakeSurelabel;
    }
}