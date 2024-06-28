namespace YuGiOh
{
    partial class register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(register));
            groupBox1 = new GroupBox();
            cb_mail = new ComboBox();
            tb_mail1 = new TextBox();
            tb_phone = new TextBox();
            tb_name1 = new TextBox();
            tb_Id2 = new TextBox();
            tb_Id1 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            bt_enter = new Button();
            rd_noagreed = new RadioButton();
            rd_agreed = new RadioButton();
            groupBox3 = new GroupBox();
            bt_enter2 = new Button();
            rd_noagreed2 = new RadioButton();
            rd_agreed2 = new RadioButton();
            bt_close = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(cb_mail);
            groupBox1.Controls.Add(tb_mail1);
            groupBox1.Controls.Add(tb_phone);
            groupBox1.Controls.Add(tb_name1);
            groupBox1.Controls.Add(tb_Id2);
            groupBox1.Controls.Add(tb_Id1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.WhiteSmoke;
            groupBox1.Location = new Point(12, 244);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(465, 262);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "회원가입";
            // 
            // cb_mail
            // 
            cb_mail.FormattingEnabled = true;
            cb_mail.Items.AddRange(new object[] { "@naver.com", "@gmail.com\t", "@hotmail.com" });
            cb_mail.Location = new Point(227, 205);
            cb_mail.Name = "cb_mail";
            cb_mail.Size = new Size(121, 25);
            cb_mail.TabIndex = 10;
            // 
            // tb_mail1
            // 
            tb_mail1.Location = new Point(105, 205);
            tb_mail1.Name = "tb_mail1";
            tb_mail1.Size = new Size(100, 25);
            tb_mail1.TabIndex = 9;
            // 
            // tb_phone
            // 
            tb_phone.Location = new Point(105, 165);
            tb_phone.Name = "tb_phone";
            tb_phone.Size = new Size(110, 25);
            tb_phone.TabIndex = 7;
            // 
            // tb_name1
            // 
            tb_name1.Location = new Point(105, 127);
            tb_name1.Name = "tb_name1";
            tb_name1.Size = new Size(110, 25);
            tb_name1.TabIndex = 5;
            // 
            // tb_Id2
            // 
            tb_Id2.Location = new Point(105, 85);
            tb_Id2.Name = "tb_Id2";
            tb_Id2.PasswordChar = '*';
            tb_Id2.Size = new Size(110, 25);
            tb_Id2.TabIndex = 3;
            // 
            // tb_Id1
            // 
            tb_Id1.Location = new Point(105, 45);
            tb_Id1.Name = "tb_Id1";
            tb_Id1.Size = new Size(110, 25);
            tb_Id1.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(21, 208);
            label5.Name = "label5";
            label5.Size = new Size(70, 17);
            label5.TabIndex = 8;
            label5.Text = "이메일    :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(21, 168);
            label4.Name = "label4";
            label4.Size = new Size(68, 17);
            label4.TabIndex = 6;
            label4.Text = "전화번호 :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(22, 130);
            label3.Name = "label3";
            label3.Size = new Size(67, 17);
            label3.TabIndex = 4;
            label3.Text = "이름      :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(22, 88);
            label2.Name = "label2";
            label2.Size = new Size(68, 17);
            label2.TabIndex = 2;
            label2.Text = "비밀번호 :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(22, 48);
            label1.Name = "label1";
            label1.Size = new Size(70, 17);
            label1.TabIndex = 0;
            label1.Text = "아이디    :";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(bt_enter);
            groupBox2.Controls.Add(rd_noagreed);
            groupBox2.Controls.Add(rd_agreed);
            groupBox2.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = SystemColors.ControlLightLight;
            groupBox2.Location = new Point(499, 292);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(270, 86);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "회원가입하기";
            // 
            // bt_enter
            // 
            bt_enter.BackColor = Color.Black;
            bt_enter.FlatStyle = FlatStyle.Flat;
            bt_enter.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            bt_enter.Location = new Point(189, 39);
            bt_enter.Name = "bt_enter";
            bt_enter.Size = new Size(75, 23);
            bt_enter.TabIndex = 2;
            bt_enter.Text = "확인";
            bt_enter.UseVisualStyleBackColor = false;
            bt_enter.Click += bt_enter_Click;
            // 
            // rd_noagreed
            // 
            rd_noagreed.AutoSize = true;
            rd_noagreed.Location = new Point(107, 40);
            rd_noagreed.Name = "rd_noagreed";
            rd_noagreed.Size = new Size(73, 19);
            rd_noagreed.TabIndex = 1;
            rd_noagreed.TabStop = true;
            rd_noagreed.Text = "동의안함";
            rd_noagreed.UseVisualStyleBackColor = true;
            // 
            // rd_agreed
            // 
            rd_agreed.AutoSize = true;
            rd_agreed.Location = new Point(31, 40);
            rd_agreed.Name = "rd_agreed";
            rd_agreed.Size = new Size(49, 19);
            rd_agreed.TabIndex = 0;
            rd_agreed.TabStop = true;
            rd_agreed.Text = "동의";
            rd_agreed.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(bt_enter2);
            groupBox3.Controls.Add(rd_noagreed2);
            groupBox3.Controls.Add(rd_agreed2);
            groupBox3.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.ForeColor = SystemColors.ControlLightLight;
            groupBox3.Location = new Point(499, 412);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(270, 94);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "개인정보 동의";
            // 
            // bt_enter2
            // 
            bt_enter2.BackColor = Color.Black;
            bt_enter2.FlatStyle = FlatStyle.Flat;
            bt_enter2.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            bt_enter2.Location = new Point(189, 43);
            bt_enter2.Name = "bt_enter2";
            bt_enter2.Size = new Size(75, 23);
            bt_enter2.TabIndex = 2;
            bt_enter2.Text = "확인";
            bt_enter2.UseVisualStyleBackColor = false;
            bt_enter2.Click += bt_enter2_Click;
            // 
            // rd_noagreed2
            // 
            rd_noagreed2.AutoSize = true;
            rd_noagreed2.Location = new Point(107, 44);
            rd_noagreed2.Name = "rd_noagreed2";
            rd_noagreed2.Size = new Size(78, 21);
            rd_noagreed2.TabIndex = 1;
            rd_noagreed2.TabStop = true;
            rd_noagreed2.Text = "동의안함";
            rd_noagreed2.UseVisualStyleBackColor = true;
            // 
            // rd_agreed2
            // 
            rd_agreed2.AutoSize = true;
            rd_agreed2.Location = new Point(31, 44);
            rd_agreed2.Name = "rd_agreed2";
            rd_agreed2.Size = new Size(52, 21);
            rd_agreed2.TabIndex = 0;
            rd_agreed2.TabStop = true;
            rd_agreed2.Text = "동의";
            rd_agreed2.UseVisualStyleBackColor = true;
            // 
            // bt_close
            // 
            bt_close.BackgroundImage = Properties.Resources.butten;
            bt_close.BackgroundImageLayout = ImageLayout.Stretch;
            bt_close.FlatStyle = FlatStyle.Flat;
            bt_close.Location = new Point(-3, 0);
            bt_close.Name = "bt_close";
            bt_close.Size = new Size(31, 30);
            bt_close.TabIndex = 3;
            bt_close.UseVisualStyleBackColor = true;
            bt_close.Click += bt_close_Click;
            // 
            // register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(781, 521);
            Controls.Add(bt_close);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "register";
            Text = "register";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cb_mail;
        private TextBox tb_mail1;
        private TextBox tb_phone;
        private TextBox tb_name1;
        private TextBox tb_Id2;
        private TextBox tb_Id1;
        private Label label5;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button bt_enter2;
        private RadioButton rd_noagreed2;
        private RadioButton rd_agreed2;
        private Button bt_enter;
        private RadioButton rd_noagreed;
        private RadioButton rd_agreed;
        private Button bt_close;
    }
}