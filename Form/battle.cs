//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using YuGiOh.Data;
//using YuGiOh.Service;

//namespace YuGiOh
//{
//    public partial class battle : Form
//    {
//        Button attackBtn;
//        Button targetBtn;
//        Button? Win;

//        public battle(Button attackBtn, Button targetBtn, Button? win)
//        {
//            InitializeComponent();
//            this.attackBtn = attackBtn;
//            this.targetBtn = targetBtn;
//            this.Win = win;
//        }

//        private void battle_Load(object sender, EventArgs e)
//        {
//            LoadCardImages();
//        }

//        // Winner 열거형 정의
//        public enum BattleWinner
//        {
//            Player,
//            Computer
//        }

//        // Winner 속성 추가
//        public BattleWinner Winner { get; private set; }

//        async private void LoadCardImages()
//        {
//            int idxAttack, idxTarget;
//            Card Attack, Target;

//            //공격하는 카드가 어떤 것인지 확인
//            if (GameInfo.Player.AttackFieldBtn.IndexOf(attackBtn) > -1)
//            {
//                idxAttack = GameInfo.Player.AttackFieldBtn.IndexOf(attackBtn);
//                Attack = GameInfo.Player.AttackFieldCard[idxAttack];
//            }
//            else
//            {
//                idxAttack = GameInfo.Computer.AttackFieldBtn.IndexOf(attackBtn);
//                Attack = GameInfo.Computer.AttackFieldCard[idxAttack];
//            }

//            //공격형 필드인지?
//            if (GameInfo.Player.AttackFieldBtn.IndexOf(targetBtn) > -1)
//            {
//                idxTarget = GameInfo.Player.AttackFieldBtn.IndexOf(targetBtn);
//                Target = GameInfo.Player.AttackFieldCard[idxTarget];
//            }
//            else if (GameInfo.Computer.AttackFieldBtn.IndexOf(targetBtn) > -1)
//            {
//                idxTarget = GameInfo.Computer.AttackFieldBtn.IndexOf(targetBtn);
//                Target = GameInfo.Computer.AttackFieldCard[idxTarget];
//            }
//            //방어형 필드인지?
//            else if (GameInfo.Player.DefenseFieldBtn.IndexOf(targetBtn) > -1)
//            {
//                idxTarget = GameInfo.Player.DefenseFieldBtn.IndexOf(targetBtn);
//                Target = GameInfo.Player.DefenseFieldCard[idxTarget];
//            }
//            else
//            {
//                idxTarget = GameInfo.Computer.DefenseFieldBtn.IndexOf(targetBtn);
//                Target = GameInfo.Computer.DefenseFieldCard[idxTarget];
//            }

//            pc_Attack.BackgroundImage = ImageControl.ResizeImage(Attack.Image, 238, 368);
//            pc_Target.BackgroundImage = ImageControl.ResizeImage(Target.Image, 238, 368);

//            pictureBox2.Visible = false;
//            pictureBox3.Visible = false;
//            await Task.Delay(2500);


//            if (Win == null)
//            {
//                pictureBox2.Image = Properties.Resources.explosion;
//                pictureBox3.Image = Properties.Resources.explosion;
//                pictureBox2.Visible = true;
//                pictureBox3.Visible = true;
//            }
//            else if (Win == attackBtn)
//            {
//                pictureBox2.Visible = true;
//                pictureBox2.Image = Properties.Resources.explosion;
//            }
//            else
//            {
//                pictureBox3.Visible = true;
//                pictureBox3.Image = Properties.Resources.explosion;
//            }
//            await Task.Delay(2000);
//            this.Close();

//        }
//    }
//}



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOh.Data;
using YuGiOh.Service;

namespace YuGiOh
{
    public partial class battle : Form
    {
        Button playerBtn;
        Button computerBtn;
        Button? Win;

        public battle(Button playerBtn, Button computerBtn, Button? win)
        {
            InitializeComponent();
            this.playerBtn = playerBtn;
            this.computerBtn = computerBtn;
            this.Win = win;
        }

        private void battle_Load(object sender, EventArgs e)
        {
            label1.Text = GameInfo.Member.Name;
            LoadCardImages();
        }

        async private void LoadCardImages()
        {
            int idxPlayer, idxComputer;
            Card player, computer;

            //플레이어의 공격형 카드인가?
            if (GameInfo.Player.AttackFieldBtn.IndexOf(playerBtn) > -1)
            {
                idxPlayer = GameInfo.Player.AttackFieldBtn.IndexOf(playerBtn);
                player = GameInfo.Player.AttackFieldCard[idxPlayer];
            }
            else
            {
                idxPlayer = GameInfo.Player.DefenseFieldBtn.IndexOf(playerBtn);
                player = GameInfo.Player.DefenseFieldCard[idxPlayer];
            }

            //컴퓨터의 공격형 카드인가?
            if (GameInfo.Computer.AttackFieldBtn.IndexOf(computerBtn) > -1)
            {
                idxComputer = GameInfo.Computer.AttackFieldBtn.IndexOf(computerBtn);
                computer = GameInfo.Computer.AttackFieldCard[idxComputer];
            }
            else
            {
                idxComputer = GameInfo.Computer.DefenseFieldBtn.IndexOf(computerBtn);
                computer = GameInfo.Computer.DefenseFieldCard[idxComputer];
            }


            pc_Attack.BackgroundImage = ImageControl.ResizeImage(player.Image, 238, 368);
            pc_Target.BackgroundImage = ImageControl.ResizeImage(computer.Image, 238, 368);

            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            await Task.Delay(2500);

            if (Win == null)
            {
                pictureBox2.Image = Properties.Resources.explosion;
                pictureBox3.Image = Properties.Resources.explosion;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
            }
            else if (Win == playerBtn)
            {
                pictureBox2.Visible = true;
                pictureBox2.Image = Properties.Resources.explosion;
            }
            else
            {
                pictureBox3.Visible = true;
                pictureBox3.Image = Properties.Resources.explosion;
            }
            await Task.Delay(2000);
            this.Close();
        }
    }
}

