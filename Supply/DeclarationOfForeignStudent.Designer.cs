
namespace Supply
{
    partial class DeclarationOfForeignStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationOfForeignStudent));
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.PB_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.LB_ProgressInf = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Общежитие";
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(105, 10);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(121, 24);
            this.CB_Hostels.TabIndex = 1;
            this.CB_Hostels.SelectionChangeCommitted += new System.EventHandler(this.CB_Hostels_SelectionChangeCommitted);
            // 
            // BTN_Create
            // 
            this.BTN_Create.Location = new System.Drawing.Point(233, 10);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(131, 24);
            this.BTN_Create.TabIndex = 2;
            this.BTN_Create.Text = "Сформировать";
            this.BTN_Create.UseVisualStyleBackColor = true;
            this.BTN_Create.Click += new System.EventHandler(this.BTN_Create_Click);
            // 
            // PB_ProgressBar
            // 
            this.PB_ProgressBar.Location = new System.Drawing.Point(16, 85);
            this.PB_ProgressBar.Name = "PB_ProgressBar";
            this.PB_ProgressBar.Size = new System.Drawing.Size(348, 29);
            this.PB_ProgressBar.TabIndex = 3;
            // 
            // LB_ProgressInf
            // 
            this.LB_ProgressInf.AutoSize = true;
            this.LB_ProgressInf.Location = new System.Drawing.Point(128, 65);
            this.LB_ProgressInf.Name = "LB_ProgressInf";
            this.LB_ProgressInf.Size = new System.Drawing.Size(121, 17);
            this.LB_ProgressInf.TabIndex = 4;
            this.LB_ProgressInf.Text = "Формирование...";
            // 
            // DeclarationOfForeignStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 126);
            this.Controls.Add(this.LB_ProgressInf);
            this.Controls.Add(this.PB_ProgressBar);
            this.Controls.Add(this.BTN_Create);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeclarationOfForeignStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет о сторонних студентак";
            this.Shown += new System.EventHandler(this.DeclarationOfForeignStudent_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.Button BTN_Create;
        private System.Windows.Forms.ProgressBar PB_ProgressBar;
        private System.Windows.Forms.Label LB_ProgressInf;
    }
}