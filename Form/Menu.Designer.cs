namespace YuGiOh
{
    partial class Menu
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
            btDeckSetting = new Button();
            btCardShop = new Button();
            btExit = new Button();
            btStart = new Button();
            lb_name = new Label();
            lb_cash = new Label();
            SuspendLayout();
            // 
            // btDeckSetting
            // 
            btDeckSetting.BackColor = Color.Transparent;
            btDeckSetting.BackgroundImage = Properties.Resources.deck1;
            btDeckSetting.BackgroundImageLayout = ImageLayout.Stretch;
            btDeckSetting.FlatStyle = FlatStyle.Flat;
            btDeckSetting.ForeColor = SystemColors.ControlLightLight;
            btDeckSetting.Location = new Point(93, 207);
            btDeckSetting.Name = "btDeckSetting";
            btDeckSetting.Size = new Size(101, 31);
            btDeckSetting.TabIndex = 0;
            btDeckSetting.Text = "\r\n\r\n";
            btDeckSetting.UseVisualStyleBackColor = false;
            btDeckSetting.Click += btDeckSetting_Click;
            // 
            // btCardShop
            // 
            btCardShop.BackColor = Color.Transparent;
            btCardShop.BackgroundImage = Properties.Resources.shop;
            btCardShop.BackgroundImageLayout = ImageLayout.Stretch;
            btCardShop.FlatStyle = FlatStyle.Flat;
            btCardShop.ForeColor = SystemColors.ControlLightLight;
            btCardShop.Location = new Point(93, 262);
            btCardShop.Name = "btCardShop";
            btCardShop.Size = new Size(101, 31);
            btCardShop.TabIndex = 0;
            btCardShop.UseVisualStyleBackColor = false;
            btCardShop.Click += btCardShop_Click;
            // 
            // btExit
            // 
            btExit.BackColor = Color.Transparent;
            btExit.BackgroundImageLayout = ImageLayout.None;
            btExit.FlatStyle = FlatStyle.Popup;
            btExit.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btExit.ForeColor = Color.White;
            btExit.Location = new Point(117, 59);
            btExit.Name = "btExit";
            btExit.Size = new Size(105, 31);
            btExit.TabIndex = 0;
            btExit.Text = "로그아웃";
            btExit.UseVisualStyleBackColor = false;
            btExit.Click += btExit_Click;
            // 
            // btStart
            // 
            btStart.BackColor = Color.Transparent;
            btStart.BackgroundImage = Properties.Resources.duel;
            btStart.BackgroundImageLayout = ImageLayout.Stretch;
            btStart.FlatStyle = FlatStyle.Flat;
            btStart.ForeColor = SystemColors.ControlLightLight;
            btStart.Location = new Point(91, 134);
            btStart.Name = "btStart";
            btStart.Size = new Size(159, 45);
            btStart.TabIndex = 1;
            btStart.UseVisualStyleBackColor = false;
            btStart.Click += btStart_Click_1;
            // 
            // lb_name
            // 
            lb_name.AutoSize = true;
            lb_name.BackColor = Color.Transparent;
            lb_name.FlatStyle = FlatStyle.Popup;
            lb_name.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_name.Location = new Point(147, 27);
            lb_name.Name = "lb_name";
            lb_name.Size = new Size(0, 25);
            lb_name.TabIndex = 2;
            // 
            // lb_cash
            // 
            lb_cash.AutoSize = true;
            lb_cash.BackColor = Color.Transparent;
            lb_cash.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_cash.Location = new Point(682, 39);
            lb_cash.Name = "lb_cash";
            lb_cash.Size = new Size(54, 20);
            lb_cash.TabIndex = 3;
            lb_cash.Text = "99999";
            lb_cash.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            BackgroundImage = Properties.Resources.main_store;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1350, 800);
            Controls.Add(lb_cash);
            Controls.Add(lb_name);
            Controls.Add(btStart);
            Controls.Add(btExit);
            Controls.Add(btCardShop);
            Controls.Add(btDeckSetting);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Menu";
            Text = "MenuBtn";
            Load += Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btDeckSetting;
        private Button btCardShop;
        private Button btExit;
        private Button btStart;
        private Label lb_name;
        private Label lb_cash;
    }
}