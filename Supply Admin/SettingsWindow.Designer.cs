
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Строка подключения к серверу БД";
            // 
            // TB_ConnectionString
            // 
            this.TB_ConnectionString.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Supply_Admin.Properties.Settings.Default, "ConnectionString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TB_ConnectionString.Location = new System.Drawing.Point(260, 13);
            this.TB_ConnectionString.Name = "TB_ConnectionString";
            this.TB_ConnectionString.Size = new System.Drawing.Size(814, 22);
            this.TB_ConnectionString.TabIndex = 1;
            this.TB_ConnectionString.Text = global::Supply_Admin.Properties.Settings.Default.ConnectionString;
            // 
            // BTN_SaveChanges
            // 
            this.BTN_SaveChanges.Location = new System.Drawing.Point(938, 163);
            this.BTN_SaveChanges.Name = "BTN_SaveChanges";
            this.BTN_SaveChanges.Size = new System.Drawing.Size(136, 40);
            this.BTN_SaveChanges.TabIndex = 2;
            this.BTN_SaveChanges.Text = "Сохранить";
            this.BTN_SaveChanges.UseVisualStyleBackColor = true;
            this.BTN_SaveChanges.Click += new System.EventHandler(this.BTN_SaveChanges_Click);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 215);
            this.Controls.Add(this.BTN_SaveChanges);
            this.Controls.Add(this.TB_ConnectionString);
            this.Controls.Add(this.label1);
            this.Name = "SettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_ConnectionString;
        private System.Windows.Forms.Button BTN_SaveChanges;
    }
}