namespace Supply_Admin
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BTN_CreateOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HostelsSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.RoomSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.DG_View_Peoples = new System.Windows.Forms.DataGridView();
            this.COL_NumberOfOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Surename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Hostel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_StartOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EndOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_ToTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_Benefit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_Create_Human = new System.Windows.Forms.Button();
            this.BTN_UpdateTable = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Peoples)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1526, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.экспортВExcelToolStripMenuItem,
            this.BTN_CreateOrders,
            this.toolStripSeparator1,
            this.CloseToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // экспортВExcelToolStripMenuItem
            // 
            this.экспортВExcelToolStripMenuItem.Name = "экспортВExcelToolStripMenuItem";
            this.экспортВExcelToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.экспортВExcelToolStripMenuItem.Text = "Экспорт в Excel";
            // 
            // BTN_CreateOrders
            // 
            this.BTN_CreateOrders.Name = "BTN_CreateOrders";
            this.BTN_CreateOrders.Size = new System.Drawing.Size(267, 26);
            this.BTN_CreateOrders.Text = "Создать документы Word";
            this.BTN_CreateOrders.Click += new System.EventHandler(this.BTN_CreateOrders_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(264, 6);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.CloseToolStripMenuItem.Text = "Выход";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HostelsSettings,
            this.RoomSettings});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // HostelsSettings
            // 
            this.HostelsSettings.Name = "HostelsSettings";
            this.HostelsSettings.Size = new System.Drawing.Size(262, 26);
            this.HostelsSettings.Text = "Настройки общежитиий";
            this.HostelsSettings.Click += new System.EventHandler(this.HostelsSettings_Click);
            // 
            // RoomSettings
            // 
            this.RoomSettings.Name = "RoomSettings";
            this.RoomSettings.Size = new System.Drawing.Size(262, 26);
            this.RoomSettings.Text = "Настройки комнат";
            this.RoomSettings.Click += new System.EventHandler(this.RoomSettings_Click);
            // 
            // DG_View_Peoples
            // 
            this.DG_View_Peoples.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View_Peoples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View_Peoples.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_NumberOfOrder,
            this.COL_Surename,
            this.COL_Name,
            this.COL_Patronymic,
            this.COL_PhoneNumber,
            this.COL_Status,
            this.COL_Room,
            this.COL_Hostel,
            this.COL_StartOrder,
            this.COL_EndOrder,
            this.COL_ToTime,
            this.COL_Benefit});
            this.DG_View_Peoples.Location = new System.Drawing.Point(12, 107);
            this.DG_View_Peoples.Name = "DG_View_Peoples";
            this.DG_View_Peoples.ReadOnly = true;
            this.DG_View_Peoples.RowHeadersWidth = 51;
            this.DG_View_Peoples.RowTemplate.Height = 24;
            this.DG_View_Peoples.Size = new System.Drawing.Size(1501, 469);
            this.DG_View_Peoples.TabIndex = 1;
            this.DG_View_Peoples.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DG_View_Peoples_RowHeaderMouseDoubleClick);
            // 
            // COL_NumberOfOrder
            // 
            this.COL_NumberOfOrder.HeaderText = "Номер договора";
            this.COL_NumberOfOrder.MinimumWidth = 6;
            this.COL_NumberOfOrder.Name = "COL_NumberOfOrder";
            this.COL_NumberOfOrder.ReadOnly = true;
            this.COL_NumberOfOrder.Width = 125;
            // 
            // COL_Surename
            // 
            this.COL_Surename.HeaderText = "Фамилия";
            this.COL_Surename.MinimumWidth = 6;
            this.COL_Surename.Name = "COL_Surename";
            this.COL_Surename.ReadOnly = true;
            this.COL_Surename.Width = 125;
            // 
            // COL_Name
            // 
            this.COL_Name.HeaderText = "Имя";
            this.COL_Name.MinimumWidth = 6;
            this.COL_Name.Name = "COL_Name";
            this.COL_Name.ReadOnly = true;
            this.COL_Name.Width = 125;
            // 
            // COL_Patronymic
            // 
            this.COL_Patronymic.HeaderText = "Отчество";
            this.COL_Patronymic.MinimumWidth = 6;
            this.COL_Patronymic.Name = "COL_Patronymic";
            this.COL_Patronymic.ReadOnly = true;
            this.COL_Patronymic.Width = 125;
            // 
            // COL_PhoneNumber
            // 
            this.COL_PhoneNumber.HeaderText = "Номер телефона";
            this.COL_PhoneNumber.MinimumWidth = 6;
            this.COL_PhoneNumber.Name = "COL_PhoneNumber";
            this.COL_PhoneNumber.ReadOnly = true;
            this.COL_PhoneNumber.Width = 125;
            // 
            // COL_Status
            // 
            this.COL_Status.HeaderText = "Статус договора";
            this.COL_Status.MinimumWidth = 6;
            this.COL_Status.Name = "COL_Status";
            this.COL_Status.ReadOnly = true;
            this.COL_Status.Width = 125;
            // 
            // COL_Room
            // 
            this.COL_Room.HeaderText = "Комната №";
            this.COL_Room.MinimumWidth = 6;
            this.COL_Room.Name = "COL_Room";
            this.COL_Room.ReadOnly = true;
            this.COL_Room.Width = 125;
            // 
            // COL_Hostel
            // 
            this.COL_Hostel.HeaderText = "Общежитие №";
            this.COL_Hostel.MinimumWidth = 6;
            this.COL_Hostel.Name = "COL_Hostel";
            this.COL_Hostel.ReadOnly = true;
            this.COL_Hostel.Width = 125;
            // 
            // COL_StartOrder
            // 
            this.COL_StartOrder.HeaderText = "Договор вступает в силу с";
            this.COL_StartOrder.MinimumWidth = 6;
            this.COL_StartOrder.Name = "COL_StartOrder";
            this.COL_StartOrder.ReadOnly = true;
            this.COL_StartOrder.Width = 125;
            // 
            // COL_EndOrder
            // 
            this.COL_EndOrder.HeaderText = "Действует по";
            this.COL_EndOrder.MinimumWidth = 6;
            this.COL_EndOrder.Name = "COL_EndOrder";
            this.COL_EndOrder.ReadOnly = true;
            this.COL_EndOrder.Width = 125;
            // 
            // COL_ToTime
            // 
            this.COL_ToTime.HeaderText = "Заключен на период";
            this.COL_ToTime.MinimumWidth = 6;
            this.COL_ToTime.Name = "COL_ToTime";
            this.COL_ToTime.ReadOnly = true;
            this.COL_ToTime.Width = 125;
            // 
            // COL_Benefit
            // 
            this.COL_Benefit.HeaderText = "Наличие льготы";
            this.COL_Benefit.MinimumWidth = 6;
            this.COL_Benefit.Name = "COL_Benefit";
            this.COL_Benefit.ReadOnly = true;
            this.COL_Benefit.Width = 125;
            // 
            // BTN_Create_Human
            // 
            this.BTN_Create_Human.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Create_Human.Location = new System.Drawing.Point(13, 36);
            this.BTN_Create_Human.Name = "BTN_Create_Human";
            this.BTN_Create_Human.Size = new System.Drawing.Size(166, 43);
            this.BTN_Create_Human.TabIndex = 2;
            this.BTN_Create_Human.Text = "Добавить жильца";
            this.BTN_Create_Human.UseVisualStyleBackColor = true;
            this.BTN_Create_Human.Click += new System.EventHandler(this.BTN_Create_Human_Click);
            // 
            // BTN_UpdateTable
            // 
            this.BTN_UpdateTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_UpdateTable.Location = new System.Drawing.Point(1369, 36);
            this.BTN_UpdateTable.Name = "BTN_UpdateTable";
            this.BTN_UpdateTable.Size = new System.Drawing.Size(144, 43);
            this.BTN_UpdateTable.TabIndex = 3;
            this.BTN_UpdateTable.Text = "Обновить таблицу";
            this.BTN_UpdateTable.UseVisualStyleBackColor = true;
            this.BTN_UpdateTable.Click += new System.EventHandler(this.BTN_UpdateTable_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1526, 616);
            this.Controls.Add(this.BTN_UpdateTable);
            this.Controls.Add(this.BTN_Create_Human);
            this.Controls.Add(this.DG_View_Peoples);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supply Admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View_Peoples)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортВExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BTN_CreateOrders;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HostelsSettings;
        private System.Windows.Forms.ToolStripMenuItem RoomSettings;
        private System.Windows.Forms.DataGridView DG_View_Peoples;
        private System.Windows.Forms.Button BTN_Create_Human;
        private System.Windows.Forms.Button BTN_UpdateTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_NumberOfOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Surename;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Hostel;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_StartOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EndOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ToTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_Benefit;
    }
}

