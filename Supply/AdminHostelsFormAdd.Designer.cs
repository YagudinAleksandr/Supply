
namespace Supply
{
    partial class AdminHostelsFormAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminHostelsFormAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_HostelName = new System.Windows.Forms.TextBox();
            this.TB_FlatsCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_EnterancesCount = new System.Windows.Forms.TextBox();
            this.CB_Addresses = new System.Windows.Forms.ComboBox();
            this.CB_Managers = new System.Windows.Forms.ComboBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Кол-во этажей";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Адрес";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Заведующий";
            // 
            // TB_HostelName
            // 
            this.TB_HostelName.Location = new System.Drawing.Point(124, 10);
            this.TB_HostelName.Name = "TB_HostelName";
            this.TB_HostelName.Size = new System.Drawing.Size(122, 20);
            this.TB_HostelName.TabIndex = 4;
            // 
            // TB_FlatsCount
            // 
            this.TB_FlatsCount.Location = new System.Drawing.Point(124, 41);
            this.TB_FlatsCount.Name = "TB_FlatsCount";
            this.TB_FlatsCount.Size = new System.Drawing.Size(62, 20);
            this.TB_FlatsCount.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Кол-во подъездов";
            // 
            // TB_EnterancesCount
            // 
            this.TB_EnterancesCount.Location = new System.Drawing.Point(382, 41);
            this.TB_EnterancesCount.Name = "TB_EnterancesCount";
            this.TB_EnterancesCount.Size = new System.Drawing.Size(62, 20);
            this.TB_EnterancesCount.TabIndex = 7;
            // 
            // CB_Addresses
            // 
            this.CB_Addresses.FormattingEnabled = true;
            this.CB_Addresses.Location = new System.Drawing.Point(124, 70);
            this.CB_Addresses.Name = "CB_Addresses";
            this.CB_Addresses.Size = new System.Drawing.Size(436, 21);
            this.CB_Addresses.TabIndex = 8;
            this.CB_Addresses.SelectedIndexChanged += new System.EventHandler(this.CB_Addresses_SelectedIndexChanged);
            // 
            // CB_Managers
            // 
            this.CB_Managers.FormattingEnabled = true;
            this.CB_Managers.Location = new System.Drawing.Point(124, 100);
            this.CB_Managers.Name = "CB_Managers";
            this.CB_Managers.Size = new System.Drawing.Size(436, 21);
            this.CB_Managers.TabIndex = 9;
            this.CB_Managers.SelectedIndexChanged += new System.EventHandler(this.CB_Managers_SelectedIndexChanged);
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(467, 140);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(93, 23);
            this.BTN_Save.TabIndex = 10;
            this.BTN_Save.Text = "Сохранить";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // AdminHostelsFormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 176);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.CB_Managers);
            this.Controls.Add(this.CB_Addresses);
            this.Controls.Add(this.TB_EnterancesCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_FlatsCount);
            this.Controls.Add(this.TB_HostelName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminHostelsFormAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление общежития";
            this.Shown += new System.EventHandler(this.AdminHostelsFormAdd_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_HostelName;
        private System.Windows.Forms.TextBox TB_FlatsCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_EnterancesCount;
        private System.Windows.Forms.ComboBox CB_Addresses;
        private System.Windows.Forms.ComboBox CB_Managers;
        private System.Windows.Forms.Button BTN_Save;
    }
}