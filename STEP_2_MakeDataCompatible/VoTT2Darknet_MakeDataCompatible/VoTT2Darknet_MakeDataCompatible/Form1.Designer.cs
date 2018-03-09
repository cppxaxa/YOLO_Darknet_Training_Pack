namespace VoTT2Darknet_MakeDataCompatible
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtVottResultsPath = new System.Windows.Forms.TextBox();
            this.btnBrowseVottResultsPath = new System.Windows.Forms.Button();
            this.btnMakeCompatible = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "VoTT_Results Path";
            // 
            // txtVottResultsPath
            // 
            this.txtVottResultsPath.Location = new System.Drawing.Point(12, 28);
            this.txtVottResultsPath.Name = "txtVottResultsPath";
            this.txtVottResultsPath.Size = new System.Drawing.Size(379, 20);
            this.txtVottResultsPath.TabIndex = 1;
            // 
            // btnBrowseVottResultsPath
            // 
            this.btnBrowseVottResultsPath.Location = new System.Drawing.Point(397, 28);
            this.btnBrowseVottResultsPath.Name = "btnBrowseVottResultsPath";
            this.btnBrowseVottResultsPath.Size = new System.Drawing.Size(32, 20);
            this.btnBrowseVottResultsPath.TabIndex = 2;
            this.btnBrowseVottResultsPath.Text = "...";
            this.btnBrowseVottResultsPath.UseVisualStyleBackColor = true;
            this.btnBrowseVottResultsPath.Click += new System.EventHandler(this.btnBrowseVottResultsPath_Click);
            // 
            // btnMakeCompatible
            // 
            this.btnMakeCompatible.Location = new System.Drawing.Point(313, 54);
            this.btnMakeCompatible.Name = "btnMakeCompatible";
            this.btnMakeCompatible.Size = new System.Drawing.Size(116, 23);
            this.btnMakeCompatible.TabIndex = 3;
            this.btnMakeCompatible.Text = "Make Compatible";
            this.btnMakeCompatible.UseVisualStyleBackColor = true;
            this.btnMakeCompatible.Click += new System.EventHandler(this.btnMakeCompatible_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 87);
            this.Controls.Add(this.btnMakeCompatible);
            this.Controls.Add(this.btnBrowseVottResultsPath);
            this.Controls.Add(this.txtVottResultsPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Make VoTT Data Compatible";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVottResultsPath;
        private System.Windows.Forms.Button btnBrowseVottResultsPath;
        private System.Windows.Forms.Button btnMakeCompatible;
    }
}

