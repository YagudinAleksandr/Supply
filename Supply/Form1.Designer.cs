
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
            this.TB_Search = new System.Windows.Forms.TextBox();
            this.BTN_Search = new System.Windows.Forms.Button();
            this.BTN_Archive = new System.Windows.Forms.Button();
            this.BTN_PaymentOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1109, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // LB_UserName
            // 
            this.LB_UserName.AutoSize = true;
            this.LB_UserName.Location = new System.Drawing.Point(132, 46);
            this.LB_UserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_UserName.Name = "LB_UserName";
            this.LB_UserName.Size = new System.Drawing.Size(46, 17);
            this.LB_UserName.TabIndex = 1;
            this.LB_UserName.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Вы вошли как:";
            // 
            // LB_Hostels
            // 
            this.LB_Hostels.FormattingEnabled = true;
            this.LB_Hostels.ItemHeight = 16;
            this.LB_Hostels.Location = new System.Drawing.Point(20, 85);
            this.LB_Hostels.Margin = new System.Windows.Forms.Padding(4);
            this.LB_Hostels.Name = "LB_Hostels";
            this.LB_Hostels.Size = new System.Drawing.Size(243, 100);
            this.LB_Hostels.TabIndex = 4;
            this.LB_Hostels.SelectedIndexChanged += new System.EventHandler(this.LB_Hostels_SelectedIndexChanged);
            // 
            // BTN_CreateOrders
            // 
            this.BTN_CreateOrders.Location = new System.Drawing.Point(19, 245);
            this.BTN_CreateOrders.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_CreateOrders.Name = "BTN_CreateOrders";
            this.BTN_CreateOrders.Size = new System.Drawing.Size(244, 38);
            this.BTN_CreateOrders.TabIndex = 5;
            this.BTN_CreateOrders.Text = "Сформировать договора";
            this.BTN_CreateOrders.UseVisualStyleBackColor = true;
            this.BTN_CreateOrders.Click += new System.EventHandler(this.BTN_CreateOrders_Click);
            // 
            // BTN_CreatePaymentOrder
            // 
            this.BTN_CreatePaymentOrder.Location = new System.Drawing.Point(19, 291);
            this.BTN_CreatePaymentOrder.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_CreatePaymentOrder.Name = "BTN_CreatePaymentOrder";
            this.BTN_CreatePaymentOrder.Size = new System.Drawing.Size(244, 70);
            this.BTN_CreatePaymentOrder.TabIndex = 6;
            this.BTN_CreatePaymentOrder.Text = "Сформировать платёжные поручения";
            this.BTN_CreatePaymentOrder.UseVisualStyleBackColor = true;
            this.BTN_CreatePaymentOrder.Click += new System.EventHandler(this.BTN_CreatePaymentOrder_Click);
            // 
            // BTN_OrderToElectricity
            // 
            this.BTN_OrderToElectricity.Location = new System.Drawing.Point(21, 431);
            this.BTN_OrderToElectricity.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_OrderToElectricity.Name = "BTN_OrderToElectricity";
            this.BTN_OrderToElectricity.Size = new System.Drawing.Size(244, 68);
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
            this.TV_HostelInformation.Location = new System.Drawing.Point(273, 85);
            this.TV_HostelInformation.Margin = new System.Windows.Forms.Padding(4);
            this.TV_HostelInformation.Name = "TV_HostelInformation";
            this.TV_HostelInformation.Size = new System.Drawing.Size(819, 473);
            this.TV_HostelInformation.TabIndex = 9;
            this.TV_HostelInformation.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_HostelInformation_NodeMouseDoubleClick);
            // 
            // LB_AsyncProcesses
            // 
            this.LB_AsyncProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LB_AsyncProcesses.AutoSize = true;
            this.LB_AsyncProcesses.Location = new System.Drawing.Point(16, 570);
            this.LB_AsyncProcesses.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_AsyncProcesses.Name = "LB_AsyncProcesses";
            this.LB_AsyncProcesses.Size = new System.Drawing.Size(0, 17);
            this.LB_AsyncProcesses.TabIndex = 10;
            // 
            // TB_Search
            // 
            this.TB_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Search.Location = new System.Drawing.Point(579, 43);
            this.TB_Search.Name = "TB_Search";
            this.TB_Search.Size = new System.Drawing.Size(414, 22);
            this.TB_Search.TabIndex = 11;
            // 
            // BTN_Search
            // 
            this.BTN_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Search.Location = new System.Drawing.Point(999, 38);
            this.BTN_Search.Name = "BTN_Search";
            this.BTN_Search.Size = new System.Drawing.Size(93, 32);
            this.BTN_Search.TabIndex = 12;
            this.BTN_Search.Text = "Поиск";
            this.BTN_Search.UseVisualStyleBackColor = true;
            this.BTN_Search.Click += new System.EventHandler(this.BTN_Search_Click);
            // 
            // BTN_Archive
            // 
            this.BTN_Archive.Location = new System.Drawing.Point(19, 192);
            this.BTN_Archive.Name = "BTN_Archive";
            this.BTN_Archive.Size = new System.Drawing.Size(244, 46);
            this.BTN_Archive.TabIndex = 13;
            this.BTN_Archive.Text = "Архив жильцов по общежитию";
            this.BTN_Archive.UseVisualStyleBackColor = true;
            this.BTN_Archive.Click += new System.EventHandler(this.BTN_Archive_Click);
            // 
            // BTN_PaymentOrders
            // 
            this.BTN_PaymentOrders.Location = new System.Drawing.Point(19, 368);
            this.BTN_PaymentOrders.Name = "BTN_PaymentOrders";
            this.BTN_PaymentOrders.Size = new System.Drawing.Size(243, 56);
            this.BTN_PaymentOrders.TabIndex = 14;
            this.BTN_PaymentOrders.Text = "Платежные поручения по общежитию";
            this.BTN_PaymentOrders.UseVisualStyleBackColor = true;
            this.BTN_PaymentOrders.Click += new System.EventHandler(this.BTN_PaymentOrders_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 597);
            this.Controls.Add(this.BTN_PaymentOrders);
            this.Controls.Add(this.BTN_Archive);
            this.Controls.Add(this.BTN_Search);
            this.Controls.Add(this.TB_Search);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.TextBox TB_Search;
        private System.Windows.Forms.Button BTN_Search;
        private System.Windows.Forms.Button BTN_Archive;
        private System.Windows.Forms.Button BTN_PaymentOrders;
    }
}

