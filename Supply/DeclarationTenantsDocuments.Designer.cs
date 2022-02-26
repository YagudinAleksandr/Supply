
namespace Supply
{
    partial class DeclarationTenantsDocuments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationTenantsDocuments));
            this.label1 = new System.Windows.Forms.Label();
            this.cbHostels = new System.Windows.Forms.ComboBox();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Общежитие";
            // 
            // cbHostels
            // 
            this.cbHostels.FormattingEnabled = true;
            this.cbHostels.Location = new System.Drawing.Point(97, 10);
            this.cbHostels.Name = "cbHostels";
            this.cbHostels.Size = new System.Drawing.Size(105, 21);
            this.cbHostels.TabIndex = 1;
            // 
            // BTN_Create
            // 
            this.BTN_Create.Location = new System.Drawing.Point(64, 78);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(92, 23);
            this.BTN_Create.TabIndex = 2;
            this.BTN_Create.Text = "Сформировать";
            this.BTN_Create.UseVisualStyleBackColor = true;
            this.BTN_Create.Click += new System.EventHandler(this.BTN_Create_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(12, 37);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(189, 23);
            this.pbProgress.TabIndex = 3;
            // 
            // DeclarationTenantsDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 113);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.BTN_Create);
            this.Controls.Add(this.cbHostels);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeclarationTenantsDocuments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет по документам";
            this.Load += new System.EventHandler(this.DeclarationTenantsDocuments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbHostels;
        private System.Windows.Forms.Button BTN_Create;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}