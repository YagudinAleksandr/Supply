namespace Supply_Admin
{
    partial class MainMenu
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
            this.GB_Hostels = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LL_Rooms = new System.Windows.Forms.LinkLabel();
            this.LL_SupplyManagers = new System.Windows.Forms.LinkLabel();
            this.LL_Hostels = new System.Windows.Forms.LinkLabel();
            this.LL_Marks = new System.Windows.Forms.LinkLabel();
            this.LL_Categories = new System.Windows.Forms.LinkLabel();
            this.LL_Objects = new System.Windows.Forms.LinkLabel();
            this.LL_Rates = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTN_OrderEl = new System.Windows.Forms.Button();
            this.BTN_Orders = new System.Windows.Forms.Button();
            this.BTN_BenefitOrders = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_Hostels
            // 
            this.GB_Hostels.Location = new System.Drawing.Point(9, 37);
            this.GB_Hostels.Margin = new System.Windows.Forms.Padding(2);
            this.GB_Hostels.Name = "GB_Hostels";
            this.GB_Hostels.Padding = new System.Windows.Forms.Padding(2);
            this.GB_Hostels.Size = new System.Drawing.Size(122, 189);
            this.GB_Hostels.TabIndex = 0;
            this.GB_Hostels.TabStop = false;
            this.GB_Hostels.Text = "Общежития";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.Settings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1102, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // Settings
            // 
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(79, 20);
            this.Settings.Text = "Настройки";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.LL_Rooms);
            this.panel1.Controls.Add(this.LL_SupplyManagers);
            this.panel1.Controls.Add(this.LL_Hostels);
            this.panel1.Controls.Add(this.LL_Marks);
            this.panel1.Controls.Add(this.LL_Categories);
            this.panel1.Controls.Add(this.LL_Objects);
            this.panel1.Controls.Add(this.LL_Rates);
            this.panel1.Location = new System.Drawing.Point(9, 269);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 306);
            this.panel1.TabIndex = 3;
            // 
            // LL_Rooms
            // 
            this.LL_Rooms.AutoSize = true;
            this.LL_Rooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LL_Rooms.Location = new System.Drawing.Point(4, 64);
            this.LL_Rooms.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LL_Rooms.Name = "LL_Rooms";
            this.LL_Rooms.Size = new System.Drawing.Size(77, 20);
            this.LL_Rooms.TabIndex = 6;
            this.LL_Rooms.TabStop = true;
            this.LL_Rooms.Text = "Комнаты";
            this.LL_Rooms.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Rooms_LinkClicked);
            // 
            // LL_SupplyManagers
            // 
            this.LL_SupplyManagers.AutoSize = true;
            this.LL_SupplyManagers.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LL_SupplyManagers.Location = new System.Drawing.Point(4, 37);
            this.LL_SupplyManagers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LL_SupplyManagers.Name = "LL_SupplyManagers";
            this.LL_SupplyManagers.Size = new System.Drawing.Size(184, 18);
            this.LL_SupplyManagers.TabIndex = 5;
            this.LL_SupplyManagers.TabStop = true;
            this.LL_SupplyManagers.Text = "Заведующие общежитий";
            this.LL_SupplyManagers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_SupplyManagers_LinkClicked);
            // 
            // LL_Hostels
            // 
            this.LL_Hostels.AutoSize = true;
            this.LL_Hostels.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LL_Hostels.Location = new System.Drawing.Point(4, 11);
            this.LL_Hostels.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LL_Hostels.Name = "LL_Hostels";
            this.LL_Hostels.Size = new System.Drawing.Size(197, 18);
            this.LL_Hostels.TabIndex = 4;
            this.LL_Hostels.TabStop = true;
            this.LL_Hostels.Text = "Управление общежитиями";
            this.LL_Hostels.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Hostels_LinkClicked);
            // 
            // LL_Marks
            // 
            this.LL_Marks.AutoSize = true;
            this.LL_Marks.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LL_Marks.Location = new System.Drawing.Point(2, 272);
            this.LL_Marks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LL_Marks.Name = "LL_Marks";
            this.LL_Marks.Size = new System.Drawing.Size(137, 18);
            this.LL_Marks.TabIndex = 3;
            this.LL_Marks.TabStop = true;
            this.LL_Marks.Text = "Реквизиты НИМИ";
            // 
            // LL_Categories
            // 
            this.LL_Categories.AutoSize = true;
            this.LL_Categories.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LL_Categories.Location = new System.Drawing.Point(4, 115);
            this.LL_Categories.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LL_Categories.Name = "LL_Categories";
            this.LL_Categories.Size = new System.Drawing.Size(186, 18);
            this.LL_Categories.TabIndex = 2;
            this.LL_Categories.TabStop = true;
            this.LL_Categories.Text = "Категории проживающих";
            this.LL_Categories.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Categories_LinkClicked);
            // 
            // LL_Objects
            // 
            this.LL_Objects.AutoSize = true;
            this.LL_Objects.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LL_Objects.Location = new System.Drawing.Point(4, 175);
            this.LL_Objects.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LL_Objects.Name = "LL_Objects";
            this.LL_Objects.Size = new System.Drawing.Size(73, 18);
            this.LL_Objects.TabIndex = 1;
            this.LL_Objects.TabStop = true;
            this.LL_Objects.Text = "Объекты";
            this.LL_Objects.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Objects_LinkClicked);
            // 
            // LL_Rates
            // 
            this.LL_Rates.AutoSize = true;
            this.LL_Rates.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LL_Rates.Location = new System.Drawing.Point(4, 145);
            this.LL_Rates.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LL_Rates.Name = "LL_Rates";
            this.LL_Rates.Size = new System.Drawing.Size(112, 18);
            this.LL_Rates.TabIndex = 0;
            this.LL_Rates.TabStop = true;
            this.LL_Rates.Text = "Типы тарифов";
            this.LL_Rates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Rates_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BTN_BenefitOrders);
            this.groupBox1.Controls.Add(this.BTN_OrderEl);
            this.groupBox1.Controls.Add(this.BTN_Orders);
            this.groupBox1.Location = new System.Drawing.Point(831, 43);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(262, 233);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Документы";
            // 
            // BTN_OrderEl
            // 
            this.BTN_OrderEl.Location = new System.Drawing.Point(4, 64);
            this.BTN_OrderEl.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_OrderEl.Name = "BTN_OrderEl";
            this.BTN_OrderEl.Size = new System.Drawing.Size(253, 32);
            this.BTN_OrderEl.TabIndex = 1;
            this.BTN_OrderEl.Text = "Договора доп.услуги";
            this.BTN_OrderEl.UseVisualStyleBackColor = true;
            this.BTN_OrderEl.Click += new System.EventHandler(this.BTN_OrderEl_Click);
            // 
            // BTN_Orders
            // 
            this.BTN_Orders.Location = new System.Drawing.Point(4, 26);
            this.BTN_Orders.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_Orders.Name = "BTN_Orders";
            this.BTN_Orders.Size = new System.Drawing.Size(253, 32);
            this.BTN_Orders.TabIndex = 0;
            this.BTN_Orders.Text = "Список договоров";
            this.BTN_Orders.UseVisualStyleBackColor = true;
            this.BTN_Orders.Click += new System.EventHandler(this.BTN_Orders_Click);
            // 
            // BTN_BenefitOrders
            // 
            this.BTN_BenefitOrders.Location = new System.Drawing.Point(6, 102);
            this.BTN_BenefitOrders.Name = "BTN_BenefitOrders";
            this.BTN_BenefitOrders.Size = new System.Drawing.Size(251, 33);
            this.BTN_BenefitOrders.TabIndex = 2;
            this.BTN_BenefitOrders.Text = "Дополнительные соглашения льготники";
            this.BTN_BenefitOrders.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 585);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GB_Hostels);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер общежитий";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_Hostels;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Settings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel LL_Objects;
        private System.Windows.Forms.LinkLabel LL_Rates;
        private System.Windows.Forms.LinkLabel LL_Categories;
        private System.Windows.Forms.LinkLabel LL_Marks;
        private System.Windows.Forms.LinkLabel LL_Hostels;
        private System.Windows.Forms.LinkLabel LL_SupplyManagers;
        private System.Windows.Forms.LinkLabel LL_Rooms;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTN_Orders;
        private System.Windows.Forms.Button BTN_OrderEl;
        private System.Windows.Forms.Button BTN_BenefitOrders;
    }
}