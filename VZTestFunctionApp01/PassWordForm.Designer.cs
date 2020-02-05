namespace VZTestFunctionApp01
{
    partial class PassWordForm
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
            this.PassWordbutton = new System.Windows.Forms.Button();
            this.PassWordtextBox = new System.Windows.Forms.TextBox();
            this.PassWordlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PassWordbutton
            // 
            this.PassWordbutton.Location = new System.Drawing.Point(131, 141);
            this.PassWordbutton.Name = "PassWordbutton";
            this.PassWordbutton.Size = new System.Drawing.Size(192, 46);
            this.PassWordbutton.TabIndex = 0;
            this.PassWordbutton.Text = "确认";
            this.PassWordbutton.UseVisualStyleBackColor = true;
            this.PassWordbutton.Click += new System.EventHandler(this.PassWordbutton_Click);
            // 
            // PassWordtextBox
            // 
            this.PassWordtextBox.Location = new System.Drawing.Point(131, 68);
            this.PassWordtextBox.Name = "PassWordtextBox";
            this.PassWordtextBox.PasswordChar = '*';
            this.PassWordtextBox.Size = new System.Drawing.Size(191, 25);
            this.PassWordtextBox.TabIndex = 1;
            this.PassWordtextBox.TextChanged += new System.EventHandler(this.PassWordtextBox_TextChanged);
            // 
            // PassWordlabel
            // 
            this.PassWordlabel.AutoSize = true;
            this.PassWordlabel.Location = new System.Drawing.Point(184, 31);
            this.PassWordlabel.Name = "PassWordlabel";
            this.PassWordlabel.Size = new System.Drawing.Size(82, 15);
            this.PassWordlabel.TabIndex = 2;
            this.PassWordlabel.Text = "输入密码：";
            // 
            // PassWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 255);
            this.Controls.Add(this.PassWordlabel);
            this.Controls.Add(this.PassWordtextBox);
            this.Controls.Add(this.PassWordbutton);
            this.Name = "PassWordForm";
            this.Text = "PassWordForm";
            this.Load += new System.EventHandler(this.PassWordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PassWordbutton;
        private System.Windows.Forms.TextBox PassWordtextBox;
        private System.Windows.Forms.Label PassWordlabel;
    }
}