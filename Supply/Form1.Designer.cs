
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
            this.Managers = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddressesInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.менеджерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseApp = new System.Windows.Forms.ToolStripMenuItem();
            this.AppSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.общежитияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Hostels = new System.Windows.Forms.ToolStripMenuItem();
            this.Rooms = new System.Windows.Forms.ToolStripMenuItem();
            this.оснащениеКомнатToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тарифныеПланыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.электроэнергияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Managers,
            this.AppSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(832, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Managers
            // 
            this.Managers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчетToolStripMenuItem,
            this.AddressesInformation,
            this.менеджерыToolStripMenuItem,
            this.общежитияToolStripMenuItem,
            this.CloseApp});
            this.Managers.Name = "Managers";
            this.Managers.Size = new System.Drawing.Size(48, 20);
            this.Managers.Text = "Файл";
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            this.отчетToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.отчетToolStripMenuItem.Text = "Отчет";
            // 
            // AddressesInformation
            // 
            this.AddressesInformation.Name = "AddressesInformation";
            this.AddressesInformation.Size = new System.Drawing.Size(180, 22);
            this.AddressesInformation.Text = "Адреса";
            this.AddressesInformation.Click += new System.EventHandler(this.AddressesInformation_Click);
            // 
            // менеджерыToolStripMenuItem
            // 
            this.менеджерыToolStripMenuItem.Name = "менеджерыToolStripMenuItem";
            this.менеджерыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.менеджерыToolStripMenuItem.Text = "Менеджеры";
            this.менеджерыToolStripMenuItem.Click += new System.EventHandler(this.менеджерыToolStripMenuItem_Click);
            // 
            // CloseApp
            // 
            this.CloseApp.Name = "CloseApp";
            this.CloseApp.Size = new System.Drawing.Size(180, 22);
            this.CloseApp.Text = "Выход";
            this.CloseApp.Click += new System.EventHandler(this.CloseApp_Click);
            // 
            // AppSettings
            // 
            this.AppSettings.Name = "AppSettings";
            this.AppSettings.Size = new System.Drawing.Size(78, 20);
            this.AppSettings.Text = "Настройка";
            this.AppSettings.Click += new System.EventHandler(this.AppSettings_Click);
            // 
            // общежитияToolStripMenuItem
            // 
            this.общежитияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Hostels,
            this.Rooms,
            this.оснащениеКомнатToolStripMenuItem,
            this.тарифныеПланыToolStripMenuItem,
            this.электроэнергияToolStripMenuItem});
            this.общежитияToolStripMenuItem.Name = "общежитияToolStripMenuItem";
            this.общежитияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.общежитияToolStripMenuItem.Text = "Общежития";
            // 
            // Hostels
            // 
            this.Hostels.Name = "Hostels";
            this.Hostels.Size = new System.Drawing.Size(182, 22);
            this.Hostels.Text = "Общежития";
            this.Hostels.Click += new System.EventHandler(this.Hostels_Click);
            // 
            // Rooms
            // 
            this.Rooms.Name = "Rooms";
            this.Rooms.Size = new System.Drawing.Size(182, 22);
            this.Rooms.Text = "Комнаты";
            // 
            // оснащениеКомнатToolStripMenuItem
            // 
            this.оснащениеКомнатToolStripMenuItem.Name = "оснащениеКомнатToolStripMenuItem";
            this.оснащениеКомнатToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.оснащениеКомнатToolStripMenuItem.Text = "Оснащение комнат";
            // 
            // тарифныеПланыToolStripMenuItem
            // 
            this.тарифныеПланыToolStripMenuItem.Name = "тарифныеПланыToolStripMenuItem";
            this.тарифныеПланыToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.тарифныеПланыToolStripMenuItem.Text = "Тарифные планы";
            // 
            // электроэнергияToolStripMenuItem
            // 
            this.электроэнергияToolStripMenuItem.Name = "электроэнергияToolStripMenuItem";
            this.электроэнергияToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.электроэнергияToolStripMenuItem.Text = "Электроэнергия";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 485);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер общежитий";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Managers;
        private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseApp;
        private System.Windows.Forms.ToolStripMenuItem AppSettings;
        private System.Windows.Forms.ToolStripMenuItem AddressesInformation;
        private System.Windows.Forms.ToolStripMenuItem менеджерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem общежитияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Hostels;
        private System.Windows.Forms.ToolStripMenuItem Rooms;
        private System.Windows.Forms.ToolStripMenuItem оснащениеКомнатToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тарифныеПланыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem электроэнергияToolStripMenuItem;
    }
}

