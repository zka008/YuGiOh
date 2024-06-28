using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh.Data
{
    public class Player
    {
        public List<Card> Deck { get; set; } //덱에 있는 카드 리스트
        public Button DeckBtn { get; set; }
        public List<Card> HandCard { get; set; } //손에 들고 있는 카드 리스트
        public List<Button> HandBtn { get; set; }
        public List<Card> AttackFieldCard { get; set; } //공격형으로 소환된 카드 리스트
        public List<Button> AttackFieldBtn { get; set; }
        public List<Card> DefenseFieldCard { get; set; } //방어형으로 소환된 카드 리스트
        
        public List<Button> DefenseFieldBtn { get; set; }
        public Button PlayerBtn { get; set; } //플레이어 버튼
        
        public int HP { get; set; }

        public Player()
        {
            Deck = new List<Card>();
            HandCard = new List<Card>();
            AttackFieldCard = new List<Card>();
            DefenseFieldCard = new List<Card>();
            HandBtn = new List<Button>();
            AttackFieldBtn = new List<Button>();
            DefenseFieldBtn = new List<Button>();
            HP = 10000;
        }

        public void Clear()
        {
            HandCard.Clear();
            AttackFieldCard.Clear();
            DefenseFieldCard.Clear();
            HandBtn.Clear();
            AttackFieldBtn.Clear();
            DefenseFieldBtn.Clear();
            HP = 10000;
        }
    }
}
