namespace YuGiOh
{
    partial class Login
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
            label1 = new Label();
            label2 = new Label();
            tb_id = new TextBox();
            tb_password = new TextBox();
            bt_rg = new Button();
            bt_login = new Button();
            bt_start = new Button();
            bt_exit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(496, 547);
            label1.Name = "label1";
            label1.Size = new Size(80, 21);
            label1.TabIndex = 0;
            label1.Text = "아이디   :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(496, 585);
            label2.Name = "label2";
            label2.Size = new Size(84, 21);
            label2.TabIndex = 2;
            label2.Text = "비밀번호 :";
            // 
            // tb_id
            // 
            tb_id.Location = new Point(598, 549);
            tb_id.Name = "tb_id";
            tb_id.Size = new Size(130, 23);
            tb_id.TabIndex = 1;
            // 
            // tb_password
            // 
            tb_password.Location = new Point(598, 587);
            tb_password.Name = "tb_password";
            tb_password.PasswordChar = '*';
            tb_password.Size = new Size(130, 23);
            tb_password.TabIndex = 3;
            // 
            // bt_rg
            // 
            bt_rg.BackColor = Color.Transparent;
            bt_rg.FlatStyle = FlatStyle.Popup;
            bt_rg.ForeColor = Color.White;
            bt_rg.Location = new Point(495, 627);
            bt_rg.Name = "bt_rg";
            bt_rg.Size = new Size(81, 28);
            bt_rg.TabIndex = 4;
            bt_rg.Text = "회원가입";
            bt_rg.UseVisualStyleBackColor = false;
            bt_rg.Click += bt_rg_Click;
            // 
            // bt_login
            // 
            bt_login.BackColor = Color.Transparent;
            bt_login.FlatStyle = FlatStyle.Popup;
            bt_login.ForeColor = Color.White;
            bt_login.Location = new Point(582, 627);
            bt_login.Name = "bt_login";
            bt_login.Size = new Size(81, 28);
            bt_login.TabIndex = 5;
            bt_login.Text = "로그인";
            bt_login.UseVisualStyleBackColor = false;
            bt_login.Click += bt_login_Click;
            // 
            // bt_start
            // 
            bt_start.BackColor = Color.Transparent;
            bt_start.BackgroundImage = Properties.Resources.card_back;
            bt_start.BackgroundImageLayout = ImageLayout.Stretch;
            bt_start.FlatStyle = FlatStyle.Popup;
            bt_start.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            bt_start.ForeColor = Color.Red;
            bt_start.Location = new Point(758, 531);
            bt_start.Name = "bt_start";
            bt_start.Size = new Size(64, 106);
            bt_start.TabIndex = 7;
            bt_start.Text = "START";
            bt_start.UseVisualStyleBackColor = false;
            bt_start.Click += bt_start_Click;
            // 
            // bt_exit
            // 
            bt_exit.BackColor = Color.Transparent;
            bt_exit.FlatStyle = FlatStyle.Popup;
            bt_exit.ForeColor = Color.White;
            bt_exit.Location = new Point(671, 627);
            bt_exit.Name = "bt_exit";
            bt_exit.Size = new Size(81, 28);
            bt_exit.TabIndex = 6;
            bt_exit.Text = "종료";
            bt_exit.UseVisualStyleBackColor = false;
            bt_exit.Click += bt_exit_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.login_1;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1350, 759);
            Controls.Add(bt_start);
            Controls.Add(bt_exit);
            Controls.Add(bt_login);
            Controls.Add(bt_rg);
            Controls.Add(tb_password);
            Controls.Add(tb_id);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            Text = "login1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tb_id;
        private TextBox tb_password;
        private Button bt_rg;
        private Button bt_login;
        private Button bt_start;
        private Button bt_exit;
    }
}