
namespace Supply
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.LB_UserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LB_Hostels = new System.Windows.Forms.ListBox();
            this.BTN_CreateOrders = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.TV_HostelInformation = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(832, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // LB_UserName
            // 
            this.LB_UserName.AutoSize = true;
            this.LB_UserName.Location = new System.Drawing.Point(99, 37);
            this.LB_UserName.Name = "LB_UserName";
            this.LB_UserName.Size = new System.Drawing.Size(35, 13);
            this.LB_UserName.TabIndex = 1;
            this.LB_UserName.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Вы вошли как:";
            // 
            // LB_Hostels
            // 
            this.LB_Hostels.FormattingEnabled = true;
            this.LB_Hostels.Location = new System.Drawing.Point(15, 69);
            this.LB_Hostels.Name = "LB_Hostels";
            this.LB_Hostels.Size = new System.Drawing.Size(183, 82);
            this.LB_Hostels.TabIndex = 4;
            this.LB_Hostels.SelectedIndexChanged += new System.EventHandler(this.LB_Hostels_SelectedIndexChanged);
            // 
            // BTN_CreateOrders
            // 
            this.BTN_CreateOrders.Location = new System.Drawing.Point(15, 158);
            this.BTN_CreateOrders.Name = "BTN_CreateOrders";
            this.BTN_CreateOrders.Size = new System.Drawing.Size(183, 31);
            this.BTN_CreateOrders.TabIndex = 5;
            this.BTN_CreateOrders.Text = "Сформировать договора";
            this.BTN_CreateOrders.UseVisualStyleBackColor = true;
            this.BTN_CreateOrders.Click += new System.EventHandler(this.BTN_CreateOrders_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 31);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 232);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(183, 31);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(15, 269);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(183, 31);
            this.button4.TabIndex = 8;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // TV_HostelInformation
            // 
            this.TV_HostelInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TV_HostelInformation.Location = new System.Drawing.Point(205, 69);
            this.TV_HostelInformation.Name = "TV_HostelInformation";
            this.TV_HostelInformation.Size = new System.Drawing.Size(615, 404);
            this.TV_HostelInformation.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 485);
            this.Controls.Add(this.TV_HostelInformation);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BTN_CreateOrders);
            this.Controls.Add(this.LB_Hostels);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB_UserName);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер общежитий";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label LB_UserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LB_Hostels;
        private System.Windows.Forms.Button BTN_CreateOrders;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TreeView TV_HostelInformation;
    }
}

