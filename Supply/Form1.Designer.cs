
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
            this.BTN_CreatePaymentOrder = new System.Windows.Forms.Button();
            this.BTN_OrderToElectricity = new System.Windows.Forms.Button();
            this.TV_HostelInformation = new System.Windows.Forms.TreeView();
            this.LB_AsyncProcesses = new System.Windows.Forms.Label();
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
            // BTN_CreatePaymentOrder
            // 
            this.BTN_CreatePaymentOrder.Location = new System.Drawing.Point(15, 195);
            this.BTN_CreatePaymentOrder.Name = "BTN_CreatePaymentOrder";
            this.BTN_CreatePaymentOrder.Size = new System.Drawing.Size(183, 57);
            this.BTN_CreatePaymentOrder.TabIndex = 6;
            this.BTN_CreatePaymentOrder.Text = "Сформировать платёжные поручения";
            this.BTN_CreatePaymentOrder.UseVisualStyleBackColor = true;
            this.BTN_CreatePaymentOrder.Click += new System.EventHandler(this.BTN_CreatePaymentOrder_Click);
            // 
            // BTN_OrderToElectricity
            // 
            this.BTN_OrderToElectricity.Location = new System.Drawing.Point(16, 258);
            this.BTN_OrderToElectricity.Name = "BTN_OrderToElectricity";
            this.BTN_OrderToElectricity.Size = new System.Drawing.Size(183, 55);
            this.BTN_OrderToElectricity.TabIndex = 7;
            this.BTN_OrderToElectricity.Text = "Сформировать договора на электроэнергию";
            this.BTN_OrderToElectricity.UseVisualStyleBackColor = true;
            this.BTN_OrderToElectricity.Click += new System.EventHandler(this.BTN_OrderToElectricity_Click);
            // 
            // TV_HostelInformation
            // 
            this.TV_HostelInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TV_HostelInformation.Location = new System.Drawing.Point(205, 69);
            this.TV_HostelInformation.Name = "TV_HostelInformation";
            this.TV_HostelInformation.Size = new System.Drawing.Size(615, 385);
            this.TV_HostelInformation.TabIndex = 9;
            this.TV_HostelInformation.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_HostelInformation_NodeMouseDoubleClick);
            // 
            // LB_AsyncProcesses
            // 
            this.LB_AsyncProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LB_AsyncProcesses.AutoSize = true;
            this.LB_AsyncProcesses.Location = new System.Drawing.Point(12, 463);
            this.LB_AsyncProcesses.Name = "LB_AsyncProcesses";
            this.LB_AsyncProcesses.Size = new System.Drawing.Size(0, 13);
            this.LB_AsyncProcesses.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 485);
            this.Controls.Add(this.LB_AsyncProcesses);
            this.Controls.Add(this.TV_HostelInformation);
            this.Controls.Add(this.BTN_OrderToElectricity);
            this.Controls.Add(this.BTN_CreatePaymentOrder);
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
        private System.Windows.Forms.Button BTN_CreatePaymentOrder;
        private System.Windows.Forms.Button BTN_OrderToElectricity;
        private System.Windows.Forms.TreeView TV_HostelInformation;
        private System.Windows.Forms.Label LB_AsyncProcesses;
    }
}

