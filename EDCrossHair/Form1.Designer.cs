namespace EDCrossHair
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
            this.bufferedPanel = new EDCrossHair.BufferedPanel();
            this.SuspendLayout();
            // 
            // bufferedPanel
            // 
            this.bufferedPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bufferedPanel.AutoSize = true;
            this.bufferedPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bufferedPanel.Location = new System.Drawing.Point(0, 0);
            this.bufferedPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bufferedPanel.Name = "bufferedPanel";
            this.bufferedPanel.programFocus = false;
            this.bufferedPanel.Size = new System.Drawing.Size(2, 2);
            this.bufferedPanel.TabIndex = 0;
            this.bufferedPanel.xDraw = 0;
            this.bufferedPanel.xScreen = 0;
            this.bufferedPanel.yDraw = 0;
            this.bufferedPanel.yScreen = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1, 1);
            this.Controls.Add(this.bufferedPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BufferedPanel bufferedPanel;
    }
}

