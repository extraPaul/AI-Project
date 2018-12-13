namespace NeuralNetWindowsApp
{
    partial class PermutationGeneratorTest
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
            this.resultTxtBox = new System.Windows.Forms.RichTextBox();
            this.testBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resultTxtBox
            // 
            this.resultTxtBox.Location = new System.Drawing.Point(12, 135);
            this.resultTxtBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resultTxtBox.Name = "resultTxtBox";
            this.resultTxtBox.Size = new System.Drawing.Size(376, 197);
            this.resultTxtBox.TabIndex = 0;
            this.resultTxtBox.Text = "";
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(146, 44);
            this.testBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(102, 50);
            this.testBtn.TabIndex = 1;
            this.testBtn.Text = "Run Test";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // PermutationGeneratorTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 352);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.resultTxtBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PermutationGeneratorTest";
            this.Text = "PermutationGeneratorTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PermutationGeneratorTest_FormClosing);
            this.Load += new System.EventHandler(this.PermutationGeneratorTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox resultTxtBox;
        private System.Windows.Forms.Button testBtn;
    }
}