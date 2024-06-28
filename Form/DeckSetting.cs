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
    public partial class DeckSetting : Form
    {
        BGM bgm;
        MySQLHandler handler;
        List<Card> cardList; //카드 리스트를 담을 리스트로 Card 클래스를 선언해 줍니다.
        public DeckSetting()
        {
            bgm = new BGM();
            handler = new MySQLHandler();
            InitializeComponent();
        }

        private void DeckSetting_Load(object sender, EventArgs e)
        {
            bgm.PlayBGM("BGM03_Decksetting");
            //cardList에 값을 담기 위해 Card클래스에 생성자를 만들어 준다.
            cardList = new List<Card>();
            cardList.Add(new Card("---------------특수 카드---------------"));
            cardList.AddRange(Card.Load_YuGiOh_Card_F()); //유희왕 카드 정보를 담아줍니다.
            cardList.Add(new Card("---------------일반 카드---------------"));
            cardList.AddRange(Card.Load_PocketMon_Card()); //포켓몬 카드 정보를 담아줍니다.
            cardList.AddRange(Card.Load_Digimon_Card()); //디지몬 카드 정보를 담아줍니다.
            cardList.AddRange(Card.Load_YuGiOh_Card());

            foreach (Card card in cardList)
            {
                checkedListBox1.Items.Add(card.Name); //cardList에 들어간 카드 정보중에 이름만을 checkedListBox1에 순차적으로 넣어주게 됩니다.
            }

            checkedListBox1.ItemCheck += CheckedListBox_ItemCheck;
            checkedListBox1.SetItemCheckState(0, CheckState.Indeterminate);   //특수카드 인덱스 번호 비활성화 처리
            checkedListBox1.SetItemCheckState(13, CheckState.Indeterminate);  //일반카드 인덱스 번호 비활성화 처리

            //기존에 저장된 덱이 있으면 체크된 상태로 변경
            if (handler.GetDeck(GameInfo.Member.Id).Count > 0)
            {
                foreach (Card deckCard in handler.GetDeck(GameInfo.Member.Id))
                {
                    int index = cardList.FindIndex(card => card.Name == deckCard.Name);
                    if (index != -1)
                    {
                        checkedListBox1.SetItemChecked(index, true);
                    }
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e) //checkedListBox1의 선택된 인덱스 값들에 따른 이벤트 호출
        {
            int selectedIndex = checkedListBox1.SelectedIndex;

            // 0번 인덱스와 13번 인덱스인 경우에는 아무 작업도 수행하지 않음
            if (selectedIndex == 0 || selectedIndex == 13)
            {
                return;
            }

            if (selectedIndex >= 0 && selectedIndex < cardList.Count)
            {
                Card selectedCard = cardList[selectedIndex];
                pictureBox1.Image = selectedCard.Image;             //pictureBox1.Image에 선택된 카드의 이미지를 출력
                textBox1.Text = selectedCard.Name;                  //textBox1에 선택 카드의 이미지를 출력
                textBox2.Text = $"{selectedCard.Rank}\r\n";         //textBox2에 선택 카드의 Rank값을 출력
                textBox3.Text = $"{selectedCard.Attack}";           //textBox3에 선택 카드의 공격력을 출력
                textBox4.Text = $"{selectedCard.Defense}";          //textBox4에 선택 카드의 방어력을 출력
                richTextBox1.Text = $"{selectedCard.CardInfo}\r\n"; //richTextBox1에 선택 카드의 정보를 출력
            }
        }

        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // 특정 인덱스(0번, 13번 인덱스)에서의 체크를 막습니다.
            if (e.Index == 0)
            {

                e.NewValue = e.CurrentValue; // 체크 불가능하도록 이벤트를 취소합니다.
            }
            if (e.Index == 13)
            {

                e.NewValue = e.CurrentValue;  // 체크 불가능하도록 이벤트를 취소합니다.
            }
        }
        // 특수 카드의 체크된 개수를 반환하는 메서드
        private int FunctionCardCount()
        {
            int count = 0;
            for (int i = 1; i <= 12; i++) // 특수 카드의 인덱스 범위를 확인
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    count++;
                }
            }
            return count;
        }
        // 일반 카드의 체크된 개수를 반환하는 메서드
        private int NormalCardCount()
        {
            int count = 0;
            for (int i = 14; i < checkedListBox1.Items.Count; i++) // 일반 카드의 인덱스 범위를 확인
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    count++;
                }
            }
            return count;
        }

        //checkedListBox1의 인덱스값이 checked 되면 listBox1에 표시
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string itemName = checkedListBox1.Items[e.Index].ToString();

            int checkedSpecialCount = FunctionCardCount(); //특수 카드의 체크된 개수를 가져오는 메서드
            int checkedNormalCount = NormalCardCount();   //일반 카드의 체크된 개수를 가져오는 메서드
            int selectedIndex = e.Index;

            if (selectedIndex == 0 || selectedIndex == 13)
            {
                return;
            }

            if (e.NewValue == CheckState.Checked)
            {
                string selectedFunction = cardList[selectedIndex].Function; //cardList에 유희왕 카드 중에서 기능이 담겨 있는 녀석들을 selectedFuction 변수에 담는다.

                if (!string.IsNullOrEmpty(selectedFunction) && checkedSpecialCount >= 8)   //IsNullOrEmpty 함수를 이용해 selectedFuntion이 비어 있지 않은지 확인 그리고 동시에 checkedItem 횟수에가 8개 이하인지 확인 조건
                {
                    e.NewValue = CheckState.Unchecked;
                    MessageBox.Show("특수카드는 최대 8장까지만 선택할 수 있습니다.");
                    return;
                }
            }
            // 45장 이상 선택되면 listBox1에 아이템 추가하지 않음
            if (checkedListBox1.CheckedItems.Count >= 45 && e.NewValue == CheckState.Checked)
            {
                e.NewValue = CheckState.Unchecked;
                MessageBox.Show("최대 45장까지만 선택할 수 있습니다.");
                return;
            }
            // 체크 상태에 따라 listBox1에 아이템 추가 또는 삭제
            if (e.NewValue == CheckState.Checked)
            {
                if (!listBox1.Items.Contains(itemName))
                {
                    listBox1.Items.Add(itemName);
                }
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                if (listBox1.Items.Contains(itemName))
                {
                    listBox1.Items.Remove(itemName);
                }
            }
        }
        //덱을 저장하고 반환
        private void btSave_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count < 45) // checkedListBox1에 담긴 체크표시들이 45개 미만일 때
            {
                MessageBox.Show("카드의 개수가 45장이 아닙니다."); return;
            }
            else if (checkedListBox1.CheckedItems.Count == 45) //만약 checkedListBox1의 체크표시가 45개라면 조건 실행
            {
                List<Card> selectedCards = new List<Card>();    //selectedCards 인스턴스 생성

                foreach (int selectedIndex in checkedListBox1.CheckedIndices)
                {
                    selectedCards.Add(cardList[selectedIndex]);
                }
                GameInfo.Player.Deck = selectedCards; //선택카드들을 GameInfo.Player.Deck에 저장

                handler.DeleteDeck(GameInfo.Member.Id);
                handler.SaveDeck(GameInfo.Member.Id, selectedCards);

                MessageBox.Show("덱이 저장되었습니다.");
            }
        }
        //나가기 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            bgm.StopBGM(); //기존음악 중지
            bgm.PlayBGM("BGM02_Menu"); //메뉴창의 음악 재생
            this.Close();
        }
        //초기화 하는 버튼 
        private void bt_clear_Click(object sender, EventArgs e)
        {
            //listBox1에 항목들의 개수가 1이상일 때 초기화 진행
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear(); // checkedListBox1의 모든 항목의 체크를 해제

                for (int i = 0; i < checkedListBox1.Items.Count; i++) //checkedListBox1.item들의 체크된 횟수만큼 반복문 진행
                {
                    checkedListBox1.SetItemChecked(i, false);  //i번째의 요소값을 false로 변환
                }
                MessageBox.Show("초기화 되었습니다.");
            }
            else
            {
                MessageBox.Show("더 이상 초기화 할 카드가 없습니다."); return;
            }
        }
    }
}
