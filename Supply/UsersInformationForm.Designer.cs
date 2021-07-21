namespace Supply
{
    partial class UsersInformationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersInformationForm));
            this.RTB_News = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RTB_News
            // 
            this.RTB_News.Location = new System.Drawing.Point(13, 25);
            this.RTB_News.Name = "RTB_News";
            this.RTB_News.ReadOnly = true;
            this.RTB_News.Size = new System.Drawing.Size(775, 413);
            this.RTB_News.TabIndex = 0;
            this.RTB_News.Text = "";
            // 
            // UsersInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RTB_News);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UsersInformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новости системы";
            this.Shown += new System.EventHandler(this.UsersInformationForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTB_News;
    }
}