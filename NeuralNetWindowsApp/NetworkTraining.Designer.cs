namespace NeuralNetWindowsApp
{
    partial class NetworkTraining
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
            this.pickFileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pickFileBtn
            // 
            this.pickFileBtn.Location = new System.Drawing.Point(61, 36);
            this.pickFileBtn.Name = "pickFileBtn";
            this.pickFileBtn.Size = new System.Drawing.Size(193, 95);
            this.pickFileBtn.TabIndex = 0;
            this.pickFileBtn.Text = "Pick Sound File";
            this.pickFileBtn.UseVisualStyleBackColor = true;
            this.pickFileBtn.Click += new System.EventHandler(this.pickFileBtn_Click);
            // 
            // NetworkTraining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 554);
            this.Controls.Add(this.pickFileBtn);
            this.Name = "NetworkTraining";
            this.Text = "NetworkTraining";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetworkTraining_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pickFileBtn;
    }
}