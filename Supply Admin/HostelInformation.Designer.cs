namespace Supply_Admin
{
    partial class HostelInformation
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
            this.TV_Hostels = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // TV_Hostels
            // 
            this.TV_Hostels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TV_Hostels.Location = new System.Drawing.Point(10, 11);
            this.TV_Hostels.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TV_Hostels.Name = "TV_Hostels";
            this.TV_Hostels.Size = new System.Drawing.Size(853, 586);
            this.TV_Hostels.TabIndex = 0;
            // 
            // HostelInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 605);
            this.Controls.Add(this.TV_Hostels);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HostelInformation";
            this.Text = "Данные по общежитию";
            this.Shown += new System.EventHandler(this.HostelInformation_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TV_Hostels;
    }
}