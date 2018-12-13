namespace NeuralNetWindowsApp
{
    partial class Home
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
            this.trainNetworkBtn = new System.Windows.Forms.Button();
            this.saveNetworkBtn = new System.Windows.Forms.Button();
            this.loadNetworkBtn = new System.Windows.Forms.Button();
            this.loadSoundFileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trainNetworkBtn
            // 
            this.trainNetworkBtn.Location = new System.Drawing.Point(212, 31);
            this.trainNetworkBtn.Margin = new System.Windows.Forms.Padding(2);
            this.trainNetworkBtn.Name = "trainNetworkBtn";
            this.trainNetworkBtn.Size = new System.Drawing.Size(126, 57);
            this.trainNetworkBtn.TabIndex = 0;
            this.trainNetworkBtn.Text = "Train Network";
            this.trainNetworkBtn.UseVisualStyleBackColor = true;
            this.trainNetworkBtn.Click += new System.EventHandler(this.trainNetworkBtn_Click);
            // 
            // saveNetworkBtn
            // 
            this.saveNetworkBtn.AccessibleDescription = "saveNetworkBtn";
            this.saveNetworkBtn.Location = new System.Drawing.Point(212, 136);
            this.saveNetworkBtn.Name = "saveNetworkBtn";
            this.saveNetworkBtn.Size = new System.Drawing.Size(126, 49);
            this.saveNetworkBtn.TabIndex = 1;
            this.saveNetworkBtn.Text = "Save Network";
            this.saveNetworkBtn.UseVisualStyleBackColor = true;
            this.saveNetworkBtn.Click += new System.EventHandler(this.saveNetworkBtn_Click);
            // 
            // loadNetworkBtn
            // 
            this.loadNetworkBtn.Location = new System.Drawing.Point(32, 31);
            this.loadNetworkBtn.Margin = new System.Windows.Forms.Padding(2);
            this.loadNetworkBtn.Name = "loadNetworkBtn";
            this.loadNetworkBtn.Size = new System.Drawing.Size(123, 57);
            this.loadNetworkBtn.TabIndex = 2;
            this.loadNetworkBtn.Text = "Load Network";
            this.loadNetworkBtn.UseVisualStyleBackColor = true;
            this.loadNetworkBtn.Click += new System.EventHandler(this.loadNetworkBtn_Click);
            // 
            // loadSoundFileBtn
            // 
            this.loadSoundFileBtn.Location = new System.Drawing.Point(32, 136);
            this.loadSoundFileBtn.Name = "loadSoundFileBtn";
            this.loadSoundFileBtn.Size = new System.Drawing.Size(123, 49);
            this.loadSoundFileBtn.TabIndex = 3;
            this.loadSoundFileBtn.Text = "load Sound File";
            this.loadSoundFileBtn.UseVisualStyleBackColor = true;
            this.loadSoundFileBtn.Click += new System.EventHandler(this.loadSoundFileBtn_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 234);
            this.Controls.Add(this.loadSoundFileBtn);
            this.Controls.Add(this.loadNetworkBtn);
            this.Controls.Add(this.saveNetworkBtn);
            this.Controls.Add(this.trainNetworkBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button trainNetworkBtn;
        private System.Windows.Forms.Button saveNetworkBtn;
        private System.Windows.Forms.Button loadNetworkBtn;
        private System.Windows.Forms.Button loadSoundFileBtn;
    }
}