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
            this.TV_Hostels.Location = new System.Drawing.Point(13, 13);
            this.TV_Hostels.Name = "TV_Hostels";
            this.TV_Hostels.Size = new System.Drawing.Size(1136, 720);
            this.TV_Hostels.TabIndex = 0;
            // 
            // HostelInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 745);
            this.Controls.Add(this.TV_Hostels);
            this.Name = "HostelInformation";
            this.Text = "Данные по общежитию";
            this.Shown += new System.EventHandler(this.HostelInformation_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TV_Hostels;
    }
}