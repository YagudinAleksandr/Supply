
namespace Supply
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.TB_Login = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Password = new System.Windows.Forms.TextBox();
            this.BT_Enter = new System.Windows.Forms.Button();
            this.LL_OpenSettingsWindow = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // TB_Login
            // 
            this.TB_Login.Location = new System.Drawing.Point(56, 42);
            this.TB_Login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Login.Name = "TB_Login";
            this.TB_Login.Size = new System.Drawing.Size(273, 22);
            this.TB_Login.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль";
            // 
            // TB_Password
            // 
            this.TB_Password.Location = new System.Drawing.Point(56, 108);
            this.TB_Password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.Size = new System.Drawing.Size(273, 22);
            this.TB_Password.TabIndex = 2;
            this.TB_Password.UseSystemPasswordChar = true;
            // 
            // BT_Enter
            // 
            this.BT_Enter.Location = new System.Drawing.Point(148, 155);
            this.BT_Enter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BT_Enter.Name = "BT_Enter";
            this.BT_Enter.Size = new System.Drawing.Size(100, 28);
            this.BT_Enter.TabIndex = 4;
            this.BT_Enter.Text = "Войти";
            this.BT_Enter.UseVisualStyleBackColor = true;
            this.BT_Enter.Click += new System.EventHandler(this.BT_Enter_Click);
            // 
            // LL_OpenSettingsWindow
            // 
            this.LL_OpenSettingsWindow.AutoSize = true;
            this.LL_OpenSettingsWindow.Location = new System.Drawing.Point(13, 212);
            this.LL_OpenSettingsWindow.Name = "LL_OpenSettingsWindow";
            this.LL_OpenSettingsWindow.Size = new System.Drawing.Size(138, 17);
            this.LL_OpenSettingsWindow.TabIndex = 5;
            this.LL_OpenSettingsWindow.TabStop = true;
            this.LL_OpenSettingsWindow.Text = "Открыть настройки";
            this.LL_OpenSettingsWindow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_OpenSettingsWindow_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 241);
            this.Controls.Add(this.LL_OpenSettingsWindow);
            this.Controls.Add(this.BT_Enter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_Login);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Password;
        private System.Windows.Forms.Button BT_Enter;
        private System.Windows.Forms.LinkLabel LL_OpenSettingsWindow;
    }
}