
namespace Supply
{
    partial class DeclarationHostels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeclarationHostels));
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Hostels = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_Places = new System.Windows.Forms.ComboBox();
            this.ChB_AllHostel = new System.Windows.Forms.CheckBox();
            this.ChB_EmptyPlaces = new System.Windows.Forms.CheckBox();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Общежитие";
            // 
            // CB_Hostels
            // 
            this.CB_Hostels.FormattingEnabled = true;
            this.CB_Hostels.Location = new System.Drawing.Point(85, 45);
            this.CB_Hostels.Name = "CB_Hostels";
            this.CB_Hostels.Size = new System.Drawing.Size(74, 21);
            this.CB_Hostels.TabIndex = 1;
            this.CB_Hostels.SelectedIndexChanged += new System.EventHandler(this.CB_Hostels_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество мест";
            // 
            // CB_Places
            // 
            this.CB_Places.FormattingEnabled = true;
            this.CB_Places.Location = new System.Drawing.Point(265, 45);
            this.CB_Places.Name = "CB_Places";
            this.CB_Places.Size = new System.Drawing.Size(63, 21);
            this.CB_Places.TabIndex = 3;
            this.CB_Places.SelectedIndexChanged += new System.EventHandler(this.CB_Places_SelectedIndexChanged);
            // 
            // ChB_AllHostel
            // 
            this.ChB_AllHostel.AutoSize = true;
            this.ChB_AllHostel.Location = new System.Drawing.Point(15, 12);
            this.ChB_AllHostel.Name = "ChB_AllHostel";
            this.ChB_AllHostel.Size = new System.Drawing.Size(181, 17);
            this.ChB_AllHostel.TabIndex = 4;
            this.ChB_AllHostel.Text = "Полная сводка по общежитию";
            this.ChB_AllHostel.UseVisualStyleBackColor = true;
            this.ChB_AllHostel.CheckedChanged += new System.EventHandler(this.ChB_AllHostel_CheckedChanged);
            // 
            // ChB_EmptyPlaces
            // 
            this.ChB_EmptyPlaces.AutoSize = true;
            this.ChB_EmptyPlaces.Location = new System.Drawing.Point(212, 13);
            this.ChB_EmptyPlaces.Name = "ChB_EmptyPlaces";
            this.ChB_EmptyPlaces.Size = new System.Drawing.Size(150, 17);
            this.ChB_EmptyPlaces.TabIndex = 5;
            this.ChB_EmptyPlaces.Text = "Только пустые комнаты";
            this.ChB_EmptyPlaces.UseVisualStyleBackColor = true;
            // 
            // BTN_Create
            // 
            this.BTN_Create.Location = new System.Drawing.Point(212, 87);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(140, 23);
            this.BTN_Create.TabIndex = 6;
            this.BTN_Create.Text = "Сформировать отчет";
            this.BTN_Create.UseVisualStyleBackColor = true;
            this.BTN_Create.Click += new System.EventHandler(this.BTN_Create_Click);
            // 
            // DeclarationHostels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 122);
            this.Controls.Add(this.BTN_Create);
            this.Controls.Add(this.ChB_EmptyPlaces);
            this.Controls.Add(this.ChB_AllHostel);
            this.Controls.Add(this.CB_Places);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CB_Hostels);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeclarationHostels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сводка по общежитиям";
            this.Load += new System.EventHandler(this.DeclarationHostels_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Hostels;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_Places;
        private System.Windows.Forms.CheckBox ChB_AllHostel;
        private System.Windows.Forms.CheckBox ChB_EmptyPlaces;
        private System.Windows.Forms.Button BTN_Create;
    }
}