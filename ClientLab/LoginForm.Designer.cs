namespace ClientLab
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelLogin = new Label();
            labelPassword = new Label();
            labelStatus = new Label();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            btnConnect = new Button();
            SuspendLayout();
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Location = new Point(208, 198);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(41, 15);
            labelLogin.TabIndex = 1;
            labelLogin.Text = "Логин";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(200, 257);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(49, 15);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Пароль";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 20F);
            labelStatus.Location = new Point(200, 120);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(214, 37);
            labelStatus.TabIndex = 3;
            labelStatus.Text = "Не подключено";
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(276, 195);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(100, 23);
            txtLogin.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(276, 254);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(254, 316);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(136, 23);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Подключитсься";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 481);
            Controls.Add(btnConnect);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(labelStatus);
            Controls.Add(labelPassword);
            Controls.Add(labelLogin);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "абоба";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelLogin;
        private Label labelPassword;
        private Label labelStatus;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button btnConnect;
    }
}
