using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOh.Data;
using YuGiOh.Properties;
using YuGiOh.Service;
using System.Text.Json; // 추가

namespace YuGiOh
{
    public partial class CardShop : Form
    {
        Menu menu;
        BGM bgm;
        List<Card> cardList;
        List<int> purchasedCardIndices = new List<int>();


        public CardShop()
        {
            bgm = new BGM();
            menu = new Menu();
            InitializeComponent();
            LoadPurchasedCards();
        }
        private void CardShop_Load(object sender, EventArgs e)
        {
            bgm.PlayBGM("BGM04_Shop");

            cardList = new List<Card>();
            cardList = Card.Load_YuGiOh_SpecialCard();
            tb_cash.Text = GameInfo.Member.Cash.ToString();

            for (int i = 1; i <= 10; i++)
            {
                string checkBoxName = "ckb_pb" + i;
                CheckBox checkBox = Controls.Find(checkBoxName, true)[0] as CheckBox;

                if (checkBox != null)
                {
                    checkBox.Text = cardList[i - 1].Name;
                    checkBox.CheckedChanged += CheckBox_CheckedChanged;
                }
            }
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox.Checked)
            {
                int index = int.Parse(checkBox.Name.Replace("ckb_pb", "")) - 1;
                Card selectedCard = cardList[index];

                // PictureBox에 이미지 표시
                pictureBox1.Image = selectedCard.Image;

                // ListBox에 체크된 카드 이름 추가
                string cardName = selectedCard.Name;
                listBox1.Items.Add(cardName);

                // 추가: 가격을 합산하여 텍스트 박스에 표시
                int totalPrice = listBox1.Items.Cast<string>().Sum(name => ExtractPriceFromCardName(name));
                tbResult.Text = $"총:{totalPrice}";


            }
            else
            {
                // 체크 해제된 경우
                int index = int.Parse(checkBox.Name.Replace("ckb_pb", "")) - 1;
                Card deselectedCard = cardList[index];

                // ListBox에서 해당 카드 이름 찾아서 제거
                listBox1.Items.Remove(deselectedCard.Name);

                // PictureBox 초기화
                pictureBox1.Image = null;

                // 추가: 가격을 합산하여 텍스트 박스에 표시
                int totalPrice = listBox1.Items.Cast<string>().Sum(name => ExtractPriceFromCardName(name));
                tbResult.Text = $"총:{totalPrice}";
            }
        }
        private int ExtractPriceFromCardName(string cardName)
        {
            // "3000POINT"와 같은 문자열에서 숫자 부분을 추출하고 int로 변환
            string priceString = new string(cardName.Where(char.IsDigit).ToArray());
            int price = int.Parse(priceString);
            return price;
        }
        private void btn_Buy_Click(object sender, EventArgs e)
        {
            // 카드가 선택되었는지 확인
            if (listBox1.Items.Count > 0)
            {
                // 선택한 카드의 총 가격 계산
                int totalPrice = listBox1.Items.Cast<string>().Sum(name => ExtractPriceFromCardName(name));

                // 플레이어가 구매에 필요한 포인트를 가지고 있는지 확인
                if (totalPrice <= GameInfo.Member.Cash)
                {
                    // 확인 대화상자 표시
                    DialogResult result = MessageBox.Show($"구매하시겠습니까? 총 가격: {totalPrice} POINT", "구매 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // 구매 성공 메시지 표시
                        MessageBox.Show("구매되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MySQLHandler handler = new MySQLHandler();
                        handler.UpdateMemberInfo(GameInfo.Member.Id, GameInfo.Member.Cash - totalPrice);
                        UpdatePointsLabel();

                        // 구매된 카드의 인덱스를 저장
                        SavePurchasedCardIndices();

                        DisablePurchasedCardCheckboxes();
                        // ListBox 초기화
                        listBox1.Items.Clear();
                        ckb_Clear();
                    }
                }
                else
                {
                    // 포인트 부족 에러 메시지 표시
                    MessageBox.Show("포인트가 부족합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // 카드를 선택하라는 메시지 표시
                MessageBox.Show("구매할 카드를 체크해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            bgm.StopBGM(); //기존음악 중지
            bgm.PlayBGM("BGM02_Menu"); //메뉴창의 음악 재생
            this.Close();
        }
        // 사용자 포인트 업데이트 메서드
        public void UpdatePointsLabel()
        {
            //cash 보유 현황 업데이트
            tb_cash.Text = GameInfo.Member.Cash.ToString();
            //menu.lb_cash.Text = GameInfo.Member.Cash.ToString();
        }
        public void ckb_Clear()
        {
            ckb_pb1.Checked = false;
            ckb_pb2.Checked = false;
            ckb_pb3.Checked = false;
            ckb_pb4.Checked = false;
            ckb_pb5.Checked = false;
            ckb_pb6.Checked = false;
            ckb_pb7.Checked = false;
            ckb_pb8.Checked = false;
            ckb_pb9.Checked = false;
            ckb_pb10.Checked = false;
        }
        public void DisablePurchasedCardCheckboxes()
        {
            // ListBox에 있는 카드들에 대응하는 체크박스 비활성화
            foreach (string cardName in listBox1.Items)
            {
                int index = cardList.FindIndex(card => card.Name == cardName);

                if (index >= 0)
                {
                    string checkBoxName = "ckb_pb" + (index + 1);
                    CheckBox checkBox = Controls.Find(checkBoxName, true)[0] as CheckBox;

                    if (checkBox != null)
                    {
                        checkBox.Enabled = false;
                    }
                }
            }
        }
        public void SavePurchasedCardIndices()
        {
            // 체크된 카드의 인덱스 저장
            for (int i = 1; i <= 10; i++)
            {
                string checkBoxName = "ckb_pb" + i;
                CheckBox checkBox = Controls.Find(checkBoxName, true)[0] as CheckBox;

                if (checkBox != null && checkBox.Checked)
                {
                    purchasedCardIndices.Add(i - 1);
                }
            }

            // 저장된 정보를 JSON 파일에 저장
            File.WriteAllText("purchasedCards.json", JsonSerializer.Serialize(purchasedCardIndices));

            // 추가: 비활성화된 체크박스 정보를 저장
            List<string> disabledCheckboxes = new List<string>();
            foreach (int index in purchasedCardIndices)
            {
                string checkBoxName = "ckb_pb" + (index + 1);
                disabledCheckboxes.Add(checkBoxName);
            }
            File.WriteAllText("disabledCheckboxes.json", JsonSerializer.Serialize(disabledCheckboxes));
        }
        public void LoadPurchasedCards()
        {
            // 저장된 정보를 JSON 파일에서 읽어옴
            if (File.Exists("purchasedCards.json"))
            {
                try
                {
                    string json = File.ReadAllText("purchasedCards.json");
                    purchasedCardIndices = JsonSerializer.Deserialize<List<int>>(json);
                }
                catch (JsonException ex)
                {
                    // JSON 파싱 오류 처리
                    Console.WriteLine($"Error while deserializing JSON: {ex.Message}");
                }

                // 추가: 비활성화된 체크박스 정보 로드
                if (File.Exists("disabledCheckboxes.json"))
                {
                    string disabledCheckboxesJson = File.ReadAllText("disabledCheckboxes.json");
                    List<string> disabledCheckboxes = JsonSerializer.Deserialize<List<string>>(disabledCheckboxesJson);

                    // 비활성화된 체크박스 찾아서 비활성화
                    foreach (string checkBoxName in disabledCheckboxes)
                    {
                        CheckBox checkBox = Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                        if (checkBox != null)
                        {
                            checkBox.Enabled = false;
                        }
                    }
                }
            }
        }
    }
}
