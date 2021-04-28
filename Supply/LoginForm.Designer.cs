
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
            this.SuspendLayout();
            // 
            // TB_Login
            // 
            this.TB_Login.Location = new System.Drawing.Point(42, 34);
            this.TB_Login.Name = "TB_Login";
            this.TB_Login.Size = new System.Drawing.Size(206, 20);
            this.TB_Login.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль";
            // 
            // TB_Password
            // 
            this.TB_Password.Location = new System.Drawing.Point(42, 88);
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.Size = new System.Drawing.Size(206, 20);
            this.TB_Password.TabIndex = 2;
            this.TB_Password.UseSystemPasswordChar = true;
            // 
            // BT_Enter
            // 
            this.BT_Enter.Location = new System.Drawing.Point(111, 126);
            this.BT_Enter.Name = "BT_Enter";
            this.BT_Enter.Size = new System.Drawing.Size(75, 23);
            this.BT_Enter.TabIndex = 4;
            this.BT_Enter.Text = "Войти";
            this.BT_Enter.UseVisualStyleBackColor = true;
            this.BT_Enter.Click += new System.EventHandler(this.BT_Enter_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 170);
            this.Controls.Add(this.BT_Enter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_Login);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}