namespace SequencerDemo
{
    partial class UC_Trackbar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUid = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.trkBar = new System.Windows.Forms.TrackBar();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trkBar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUid
            // 
            this.lblUid.AutoSize = true;
            this.lblUid.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUid.Location = new System.Drawing.Point(9, 65);
            this.lblUid.Name = "lblUid";
            this.lblUid.Size = new System.Drawing.Size(29, 12);
            this.lblUid.TabIndex = 8;
            this.lblUid.Text = "label1";
            // 
            // lblValue
            // 
            this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValue.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(0, 249);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(50, 15);
            this.lblValue.TabIndex = 7;
            this.lblValue.Text = "0";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trkBar
            // 
            this.trkBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkBar.AutoSize = false;
            this.trkBar.LargeChange = 1;
            this.trkBar.Location = new System.Drawing.Point(4, 18);
            this.trkBar.Maximum = 100;
            this.trkBar.Name = "trkBar";
            this.trkBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trkBar.Size = new System.Drawing.Size(42, 233);
            this.trkBar.TabIndex = 6;
            this.trkBar.TickFrequency = 2;
            this.trkBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Location = new System.Drawing.Point(0, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(50, 13);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_Trackbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUid);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.trkBar);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_Trackbar";
            this.Size = new System.Drawing.Size(50, 267);
            ((System.ComponentModel.ISupportInitialize)(this.trkBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TrackBar trkBar;
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblUid;
    }
}
