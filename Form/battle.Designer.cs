namespace YuGiOh
{
    partial class battle
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
            pc_Attack = new PictureBox();
            pc_Target = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pc_Attack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pc_Target).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pc_Attack
            // 
            pc_Attack.BackColor = Color.Transparent;
            pc_Attack.BackgroundImageLayout = ImageLayout.None;
            pc_Attack.Location = new Point(20, 123);
            pc_Attack.Name = "pc_Attack";
            pc_Attack.Size = new Size(238, 368);
            pc_Attack.TabIndex = 0;
            pc_Attack.TabStop = false;
            // 
            // pc_Target
            // 
            pc_Target.BackColor = Color.Transparent;
            pc_Target.BackgroundImageLayout = ImageLayout.None;
            pc_Target.Location = new Point(649, 122);
            pc_Target.Name = "pc_Target";
            pc_Target.Size = new Size(238, 368);
            pc_Target.TabIndex = 1;
            pc_Target.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.VS;
            pictureBox1.Location = new Point(296, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(313, 431);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Location = new Point(648, 121);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(238, 368);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Location = new Point(18, 122);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(237, 367);
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(92, 48);
            label1.Name = "label1";
            label1.Size = new Size(98, 37);
            label1.TabIndex = 5;
            label1.Text = "ㅇㅇㅇ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(726, 48);
            label2.Name = "label2";
            label2.Size = new Size(98, 37);
            label2.TabIndex = 5;
            label2.Text = "컴퓨터";
            // 
            // battle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Battle;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(900, 650);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(pc_Target);
            Controls.Add(pc_Attack);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "battle";
            Text = "battle";
            Load += battle_Load;
            ((System.ComponentModel.ISupportInitialize)pc_Attack).EndInit();
            ((System.ComponentModel.ISupportInitialize)pc_Target).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pc_Attack;
        private PictureBox pc_Target;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label1;
        private Label label2;
    }
}