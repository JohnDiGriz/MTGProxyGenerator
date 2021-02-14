namespace ProxyGenerator
{
    partial class MTGProxyGenerator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MTGProxyGenerator));
            this.goButton = new System.Windows.Forms.Button();
            this.destinationButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.decklistTextBox = new System.Windows.Forms.TextBox();
            this.loadingBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loadingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // goButton
            // 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.Location = new System.Drawing.Point(344, 413);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(160, 41);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // destinationButton
            // 
            this.destinationButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.destinationButton.Location = new System.Drawing.Point(176, 413);
            this.destinationButton.Name = "destinationButton";
            this.destinationButton.Size = new System.Drawing.Size(164, 41);
            this.destinationButton.TabIndex = 2;
            this.destinationButton.Text = "Destination";
            this.destinationButton.UseVisualStyleBackColor = true;
            this.destinationButton.Click += new System.EventHandler(this.destinationButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.messageLabel.Location = new System.Drawing.Point(12, 469);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(56, 32);
            this.messageLabel.TabIndex = 3;
            this.messageLabel.Text = "test";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decklistTextBox
            // 
            this.decklistTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.decklistTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.decklistTextBox.Location = new System.Drawing.Point(12, 12);
            this.decklistTextBox.Multiline = true;
            this.decklistTextBox.Name = "decklistTextBox";
            this.decklistTextBox.PlaceholderText = "Copy decklist here...";
            this.decklistTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.decklistTextBox.Size = new System.Drawing.Size(492, 395);
            this.decklistTextBox.TabIndex = 1;
            // 
            // loadingBox
            // 
            this.loadingBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingBox.Image = ((System.Drawing.Image)(resources.GetObject("loadingBox.Image")));
            this.loadingBox.Location = new System.Drawing.Point(344, 471);
            this.loadingBox.Name = "loadingBox";
            this.loadingBox.Size = new System.Drawing.Size(160, 30);
            this.loadingBox.TabIndex = 4;
            this.loadingBox.TabStop = false;
            this.loadingBox.Visible = false;
            // 
            // MTGProxyGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 513);
            this.Controls.Add(this.loadingBox);
            this.Controls.Add(this.decklistTextBox);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.destinationButton);
            this.Controls.Add(this.goButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(534, 560);
            this.Name = "MTGProxyGenerator";
            this.Text = "MTGProxyGenerator";
            ((System.ComponentModel.ISupportInitialize)(this.loadingBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button destinationButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox decklistTextBox;
        private System.Windows.Forms.PictureBox loadingBox;
    }
}

