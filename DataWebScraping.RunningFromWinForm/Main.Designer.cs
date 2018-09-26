namespace DataWebScraping.RunningFromWinForm
{
    partial class Main
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
            this.wbViewer = new System.Windows.Forms.WebBrowser();
            this.btnRunConfiguration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wbViewer
            // 
            this.wbViewer.Location = new System.Drawing.Point(2, 1);
            this.wbViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbViewer.Name = "wbViewer";
            this.wbViewer.Size = new System.Drawing.Size(410, 250);
            this.wbViewer.TabIndex = 0;
            // 
            // btnRunConfiguration
            // 
            this.btnRunConfiguration.Location = new System.Drawing.Point(27, 277);
            this.btnRunConfiguration.Name = "btnRunConfiguration";
            this.btnRunConfiguration.Size = new System.Drawing.Size(75, 23);
            this.btnRunConfiguration.TabIndex = 1;
            this.btnRunConfiguration.Text = "Run";
            this.btnRunConfiguration.UseVisualStyleBackColor = true;
            this.btnRunConfiguration.Click += new System.EventHandler(this.btnRunConfiguration_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 324);
            this.Controls.Add(this.btnRunConfiguration);
            this.Controls.Add(this.wbViewer);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbViewer;
        private System.Windows.Forms.Button btnRunConfiguration;
    }
}

