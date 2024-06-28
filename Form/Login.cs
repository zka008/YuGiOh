using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using YuGiOh.Service;
using YuGiOh.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace YuGiOh
{
    public partial class Login : Form
    {
        private bool bt_login_click = false;
        MySQLHandler handler;
        public Login()
        {
            InitializeComponent();
            handler = new MySQLHandler();
        }

        private void bt_rg_Click(object sender, EventArgs e)
        {
            register registerForm = new register();
            registerForm.StartPosition = FormStartPosition.CenterScreen;
            registerForm.ShowDialog();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            string inputId = tb_id.Text;
            string inputPassword = tb_password.Text;

            if (handler.LoginMember(inputId, inputPassword))
            {
                handler.GetMemberInfo(inputId);
                List<Card> db = handler.GetDeck(inputId);
                if(db.Count > 0)
                {
                    List<Card> allCards = new List<Card>();
                    allCards.AddRange(Card.Load_YuGiOh_Card());
                    allCards.AddRange(Card.Load_PocketMon_Card());
                    allCards.AddRange(Card.Load_Digimon_Card());
                    List<Card> matchedCards = new List<Card>();

                    foreach (var savedCard in db)
                    {
                        Card matchingCard = allCards.Find(card => card.Name == savedCard.Name);
                        if (matchingCard != null)
                        {
                            matchedCards.Add(matchingCard);
                        }
                    }
                    GameInfo.Player.Deck = matchedCards;
                }
                MessageBox.Show("로그인 완료");
                bt_login_click = true;
                return;
            }
            else
            {
                MessageBox.Show("아이디 및 비밀번호가 틀렸습니다.");
            }
        }

        private async void bt_start_Click(object sender, EventArgs e)
        {

            if (bt_login_click)
            {
                MessageBox.Show("시작합니다.");
                Loading loadingForm = new Loading();
                loadingForm.StartPosition = FormStartPosition.CenterScreen;
                loadingForm.Show();

                await Task.Delay(3000);

                Menu menu = new Menu();
                menu.StartPosition = FormStartPosition.CenterScreen;
                menu.Show();

                loadingForm.Close();
            }
            else
            {
                MessageBox.Show("로그인을 먼저 해주세요.");
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
