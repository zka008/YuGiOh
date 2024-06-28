using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using YuGiOh.Data;
using YuGiOh.Service;

namespace YuGiOh
{
    public partial class Menu : Form
    {
        BGM bgm;
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            bgm = new BGM();
            bgm.PlayBGM("BGM02_Menu");
            lb_name.Text = GameInfo.Member.Name;
            lb_cash.Text = GameInfo.Member.Cash.ToString();
        }

        private async void btDeckSetting_Click(object sender, EventArgs e)
        {
            MessageBox.Show("덱구성을 진입합니다.");

            Loading loadingForm = new Loading();
            loadingForm.StartPosition = FormStartPosition.CenterScreen;
            loadingForm.Show();

            await Task.Delay(2500);

            DeckSetting deckSettingForm = new DeckSetting();
            deckSettingForm.Show();

            loadingForm.Close();
        }

        private async void btCardShop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("상점에 진입합니다.");

            Loading loadingForm = new Loading();
            loadingForm.StartPosition = FormStartPosition.CenterScreen;
            loadingForm.Show();

            await Task.Delay(2500);

            CardShop cardshop = new CardShop();
            cardshop.StartPosition = FormStartPosition.CenterScreen;
            cardshop.Show();

            loadingForm.Close();
        }

        private async void btExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("종료합니다.");

            Loading loadingForm = new Loading();
            loadingForm.StartPosition = FormStartPosition.CenterScreen;
            loadingForm.Show();

            await Task.Delay(2500);
            loadingForm.Close();

            this.Close();
            
        }
        private async void btStart_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("게임을 시작합니다.");

            Loading loadingForm = new Loading();
            loadingForm.StartPosition = FormStartPosition.CenterScreen;
            loadingForm.Show();

            bgm.PlayEffect("BGM06_DuelEnter");

            await Task.Delay(5000);
            loadingForm.Close();

            Battle_loading bt_loading = new Battle_loading();   
            bt_loading.StartPosition = FormStartPosition.CenterScreen;
            bt_loading.Show();

            await Task.Delay(3000);

            Game game = new Game();
            game.StartPosition = FormStartPosition.CenterScreen;
            game.Show();

            loadingForm.Close();
            bt_loading.Close();
        }
    }
}
