using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOh.Data;
using YuGiOh.Service;

namespace YuGiOh
{
    public partial class Game : Form
    {
        BGM bgm;
        CardMode mode;
        public Game()
        {
            InitializeComponent();
            bgm = new BGM();
            GameInfo.Game = this;
        }
        List<Button> list;
        private void Game_Load(object sender, EventArgs e)
        {
            bgm.PlayBGM("BGM05_InGame");
            //플레이어와 컴퓨터의 버튼 정보 입력
            GameInfo.Player.PlayerBtn = btnPlayer;
            GameInfo.Player.DeckBtn = btnPlayerDeck;
            GameInfo.Player.HandBtn = new List<Button>() { btnPlayerCard1, btnPlayerCard2, btnPlayerCard3, btnPlayerCard4, btnPlayerCard5 };
            GameInfo.Player.AttackFieldBtn = new List<Button>() { btnPlayerField1, btnPlayerField2, btnPlayerField3, btnPlayerField4, btnPlayerField5 };
            GameInfo.Player.DefenseFieldBtn = new List<Button>() { btnPlayerFieldD1, btnPlayerFieldD2, btnPlayerFieldD3, btnPlayerFieldD4, btnPlayerFieldD5 };

            GameInfo.Computer.PlayerBtn = btnComputer;
            GameInfo.Computer.HandBtn = new List<Button>() { btnComCard1, btnComCard2, btnComCard3, btnComCard4, btnComCard5 };
            GameInfo.Computer.AttackFieldBtn = new List<Button>() { btnComField1, btnComField2, btnComField3, btnComField4, btnComField5 };
            GameInfo.Computer.DefenseFieldBtn = new List<Button>() { btnComFieldD1, btnComFieldD2, btnComFieldD3, btnComFieldD4, btnComFieldD5 };

            GameLogic.LbPlayer = lbPlayerHP;
            GameLogic.LbComputer = lbComputerHP;
            GameLogic.CardToolTip = cardToolTip;

            GameLogic.playerDie = bt_PlayerDie;
            GameLogic.computerDie = bt_ComputerDie;

            list = new List<Button>() { btnComField1, btnComField2, btnComField3, btnComField4, btnComField5, btnComFieldD1, btnComFieldD2, btnComFieldD3, btnComFieldD4, btnComFieldD5 };

            //마우스가 버튼에 올라갔을 때 강조 표시 이벤트 등록
            //foreach (var button in GameInfo.Player.HandBtn)
            //{
            //    button.MouseEnter += MouseEnterColor;
            //    button.MouseLeave += MouseLeaveColor;
            //}
            //foreach (var button in GameInfo.Player.AttackFieldBtn)
            //{
            //    button.MouseEnter += MouseEnterColor;
            //    button.MouseLeave += MouseLeaveColor;
            //}
            //게임 초기화, 컴퓨터/플레이어 덱 및 패 생성
            GameLogic.InitializeGame();

            //위 함수를 통해 생성한 손패를 버튼의 크기에 맞게 조정해서 출력
            int i = 0;
            foreach (Button item in GameInfo.Player.HandBtn)
            {
                item.BackgroundImage = ImageControl.ResizeImage(GameInfo.Player.HandCard[i++].Image, 110, 225);
            }

            //손패 버튼에 이벤트 등록
            foreach (Button item in GameInfo.Player.HandBtn)
            {
                item.Click += HandCardSelect;
            }

            //플레이어 공격 필드 버튼에 이벤트 등록
            foreach (Button item in GameInfo.Player.AttackFieldBtn)
            {
                item.Click += AttackFieldSelect;
            }

            //적 필드 버튼에 이벤트 등록
            foreach (Button item in GameInfo.Computer.AttackFieldBtn)
                item.Click += EnemyAttackFieldSelect;
            foreach (Button item in GameInfo.Computer.DefenseFieldBtn)
                item.Click += EnemyDefenseFieldSelect;
            btnComputer.Click += EnemySelect;

            lbPlayerHP.Text = GameInfo.Player.HP.ToString();
            lbComputerHP.Text = GameInfo.Computer.HP.ToString();

            GameLogic.UpdateCardTooltips();
        }

        //플레이어 소환할 카드 선택 이벤트
        public void HandCardSelect(object sender, EventArgs e)
        {
            GameLogic.HandCardBtn = (Button)sender;
            GameLogic.SummonCard((Button)sender);
        }
        //플레이어 공격형 카드 선택 이벤트
        public void AttackFieldSelect(object sender, EventArgs e)
        {
            GameLogic.AttackFieldBtn = (Button)sender;
            GameLogic.SetEnableAttack();
        }

        //컴퓨터 본체 선택 이벤트
        public void EnemySelect(object sender, EventArgs e)
        {
            GameLogic.EnemyBtn = (Button)sender;
            GameLogic.SetDisableAttack();
            GameLogic.Attack(GameLogic.AttackFieldBtn, (Button)sender);
        }
        //컴퓨터 공격형 카드 선택 이벤트
        public void EnemyAttackFieldSelect(object sender, EventArgs e)
        {
            GameLogic.EnemyAttackFieldBtn = (Button)sender;
            GameLogic.SetDisableAttack();
            GameLogic.Attack(GameLogic.AttackFieldBtn, (Button)sender);
        }
        //컴퓨터 방어형 카드 선택 이벤트
        public void EnemyDefenseFieldSelect(object sender, EventArgs e)
        {
            GameLogic.EnemyDefenceFieldBtn = (Button)sender;
            GameLogic.SetDisableAttack();
            GameLogic.Attack(GameLogic.AttackFieldBtn, (Button)sender);
        }

        //드로우, 패의 개수가 4개 이하이면 하나 추가
        private void btnPlayerDeck_Click(object sender, EventArgs e)
        {
            //플레이어의 덱과, 손패 정보를 통해 드로우 기능 처리
            GameLogic.DrawCard(GameInfo.Player.Deck, GameInfo.Player.HandCard);
        }

        //공격형으로 소환 버튼
        private void btnAttack_Click(object sender, EventArgs e)
        {
            mode = CardMode.Attack;
            GameLogic.SummonTypeBtn = (Button)sender;
        }
        //방어형으로 소환 버튼
        private void btnDefence_Click(object sender, EventArgs e)
        {
            mode = CardMode.Defence;
            GameLogic.SummonTypeBtn = (Button)sender;
        }
        //턴 넘기기 버튼
        private void btnTurnChange_Click(object sender, EventArgs e)
        {
            GameInfo.TurnInfo.SetComputerTurn();
            GameLogic.ComputerAI();
            GameLogic.EnableAttack(GameInfo.Player, GameInfo.TurnInfo.PlayerAttackCount);
            //컴퓨터의 공격 횟수 계산 로직 필요, Turn에 설정해줘야 함
        }
        //마우스 접근 시 버튼 강조
        public void MouseEnterColor(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.Green;
        }
        //마우스 멀어지면 버튼 강조 해제
        public void MouseLeaveColor(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.Transparent;
        }
    }
}
