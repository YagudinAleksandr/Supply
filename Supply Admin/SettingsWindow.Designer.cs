
namespace Supply_Admin
{
    partial class SettingsWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.TB_ConnectionString = new System.Windows.Forms.TextBox();
            this.BTN_SaveChanges = new System.Windows.Forms.Button();
            this.TabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BTN_TemplateDir = new System.Windows.Forms.Button();
            this.TB_TempDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTN_OpenFolder = new System.Windows.Forms.Button();
            this.TB_SaveFolderDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BTN_Apply = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.TabControlSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Строка подключения к серверу БД";
            // 
            // TB_ConnectionString
            // 
            this.TB_ConnectionString.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Supply_Admin.Properties.Settings.Default, "ConnectionString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TB_ConnectionString.Location = new System.Drawing.Point(191, 9);
            this.TB_ConnectionString.Margin = new System.Windows.Forms.Padding(2);
            this.TB_ConnectionString.Name = "TB_ConnectionString";
            this.TB_ConnectionString.Size = new System.Drawing.Size(586, 20);
            this.TB_ConnectionString.TabIndex = 1;
            this.TB_ConnectionString.Text = global::Supply_Admin.Properties.Settings.Default.ConnectionString;
            // 
            // BTN_SaveChanges
            // 
            this.BTN_SaveChanges.Location = new System.Drawing.Point(566, 446);
            this.BTN_SaveChanges.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_SaveChanges.Name = "BTN_SaveChanges";
            this.BTN_SaveChanges.Size = new System.Drawing.Size(102, 32);
            this.BTN_SaveChanges.TabIndex = 2;
            this.BTN_SaveChanges.Text = "Сохранить";
            this.BTN_SaveChanges.UseVisualStyleBackColor = true;
            this.BTN_SaveChanges.Click += new System.EventHandler(this.BTN_SaveChanges_Click);
            // 
            // TabControlSettings
            // 
            this.TabControlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlSettings.Controls.Add(this.tabPage1);
            this.TabControlSettings.Controls.Add(this.tabPage2);
            this.TabControlSettings.Controls.Add(this.tabPage3);
            this.TabControlSettings.Location = new System.Drawing.Point(13, 12);
            this.TabControlSettings.Name = "TabControlSettings";
            this.TabControlSettings.SelectedIndex = 0;
            this.TabControlSettings.Size = new System.Drawing.Size(790, 429);
            this.TabControlSettings.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TB_ConnectionString);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Настройки БД";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BTN_TemplateDir);
            this.tabPage2.Controls.Add(this.TB_TempDir);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.BTN_OpenFolder);
            this.tabPage2.Controls.Add(this.TB_SaveFolderDir);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(782, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Настройки сохранения файлов";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BTN_TemplateDir
            // 
            this.BTN_TemplateDir.Location = new System.Drawing.Point(679, 51);
            this.BTN_TemplateDir.Name = "BTN_TemplateDir";
            this.BTN_TemplateDir.Size = new System.Drawing.Size(92, 23);
            this.BTN_TemplateDir.TabIndex = 5;
            this.BTN_TemplateDir.Text = "Обзор";
            this.BTN_TemplateDir.UseVisualStyleBackColor = true;
            this.BTN_TemplateDir.Click += new System.EventHandler(this.BTN_TemplateDir_Click);
            // 
            // TB_TempDir
            // 
            this.TB_TempDir.Location = new System.Drawing.Point(186, 51);
            this.TB_TempDir.Name = "TB_TempDir";
            this.TB_TempDir.Size = new System.Drawing.Size(473, 20);
            this.TB_TempDir.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Директория шаблонов";
            // 
            // BTN_OpenFolder
            // 
            this.BTN_OpenFolder.Location = new System.Drawing.Point(679, 15);
            this.BTN_OpenFolder.Name = "BTN_OpenFolder";
            this.BTN_OpenFolder.Size = new System.Drawing.Size(92, 23);
            this.BTN_OpenFolder.TabIndex = 2;
            this.BTN_OpenFolder.Text = "Обзор";
            this.BTN_OpenFolder.UseVisualStyleBackColor = true;
            this.BTN_OpenFolder.Click += new System.EventHandler(this.BTN_OpenFolder_Click);
            // 
            // TB_SaveFolderDir
            // 
            this.TB_SaveFolderDir.Location = new System.Drawing.Point(186, 16);
            this.TB_SaveFolderDir.Name = "TB_SaveFolderDir";
            this.TB_SaveFolderDir.Size = new System.Drawing.Size(473, 20);
            this.TB_SaveFolderDir.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Директория сохранения файлов";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(782, 403);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Пользователь";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BTN_Apply
            // 
            this.BTN_Apply.Location = new System.Drawing.Point(674, 446);
            this.BTN_Apply.Name = "BTN_Apply";
            this.BTN_Apply.Size = new System.Drawing.Size(109, 32);
            this.BTN_Apply.TabIndex = 4;
            this.BTN_Apply.Text = "Применить";
            this.BTN_Apply.UseVisualStyleBackColor = true;
            this.BTN_Apply.Click += new System.EventHandler(this.BTN_Apply_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Location = new System.Drawing.Point(467, 446);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(94, 32);
            this.BTN_Cancel.TabIndex = 5;
            this.BTN_Cancel.Text = "Отменить";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 489);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.BTN_Apply);
            this.Controls.Add(this.TabControlSettings);
            this.Controls.Add(this.BTN_SaveChanges);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.TabControlSettings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_ConnectionString;
        private System.Windows.Forms.Button BTN_SaveChanges;
        private System.Windows.Forms.TabControl TabControlSettings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button BTN_OpenFolder;
        private System.Windows.Forms.TextBox TB_SaveFolderDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_TemplateDir;
        private System.Windows.Forms.TextBox TB_TempDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTN_Apply;
        private System.Windows.Forms.Button BTN_Cancel;
    }
}