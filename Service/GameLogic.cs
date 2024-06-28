using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOh.Data;


namespace YuGiOh.Service
{
    internal class GameLogic
    {
        public static Button? HandCardBtn = null; //손에 들고 있는 소환할 카드
        public static Button? AttackFieldBtn = null; //공격 할 카드

        public static Button? EnemyBtn = null; //공격할 플레이어(직접 공격)
        public static Button? EnemyAttackFieldBtn = null; //공격할 카드(공격형)
        public static Button? EnemyDefenceFieldBtn = null; //공격할 카드(방어형)

        public static Button? SummonTypeBtn = null;

        public static Label LbPlayer, LbComputer;
        public static ToolTip CardToolTip;
        
        public static Button playerDie, computerDie;

        //게임 시작 시 덱, 패 생성
        static public void InitializeGame()
        {
            ////전체 카드 로드
            //List<Card> cards = new List<Card>();
            //cards.AddRange(Card.Load_YuGiOh_Card());
            //cards.AddRange(Card.Load_PocketMon_Card());
            //cards.AddRange(Card.Load_Digimon_Card());

            ////컴퓨터, 전체 카드 중 45장 랜덤으로 선택
            //GameInfo.Computer.Deck = GetRandomCard(cards, 45);
            ////그 중 5장은 초기 패로 사용
            //GameInfo.Computer.HandCard = GameInfo.Computer.Deck.GetRange(0, 5);
            ////초기 패 5장을 덱에서 제외
            //GameInfo.Computer.Deck.RemoveRange(0, 5);

            ////플레이어, 선택한 45장의 카드를 랜덤하게 섞고 초기 패 생성
            //if (GameInfo.Player.Deck.Count > 0)
            //    GameInfo.Player.Deck = GetRandomCard(GameInfo.Player.Deck, 45);
            //else
            //{
            //    MessageBox.Show("구성된 덱이 없으므로 랜덤한 카드가 등장합니다");
            //    GameInfo.Player.Deck = GetRandomCard(cards, 45);
            //}

            //GameInfo.Player.HandCard = GameInfo.Player.Deck.GetRange(0, 5);
            //GameInfo.Player.Deck.RemoveRange(0, 5);
            //GameInfo.Player.HP = 5000;

            //전체 카드 로드
            List<Card> cards = new List<Card>();
            cards.AddRange(Card.Load_PocketMon_Card());
            cards.AddRange(Card.Load_Digimon_Card());
            cards.AddRange(Card.Load_YuGiOh_Card());
            cards.AddRange(Card.Load_YuGiOh_Card_F());

            List<Card> com = new List<Card>();
            com.AddRange(Card.Load_YuGiOh_Card_F());
            com.AddRange(Card.Load_YuGiOh_Card());
            cards.AddRange(GetRandomCard(Card.Load_Digimon_Card(), 22));

            //컴퓨터, 전체 카드 중 45장 랜덤으로 선택
            GameInfo.Computer.Deck = GetRandomCard(com, 45);

            //그 중 5장은 초기 패로 사용
            GameInfo.Computer.HandCard = GameInfo.Computer.Deck.GetRange(0, 5);
            //초기 패 5장을 덱에서 제외
            GameInfo.Computer.Deck.RemoveRange(0, 5);

            //플레이어, 선택한 45장의 카드를 랜덤하게 섞고 초기 패 생성
            if (GameInfo.Player.Deck.Count > 0)
                GameInfo.Player.Deck = GetRandomCard(GameInfo.Player.Deck, 45);
            else
            {
                MessageBox.Show("구성된 덱이 없으므로 랜덤한 카드가 등장합니다");
                GameInfo.Player.Deck = GetRandomCard(cards, 45);
            }

            GameInfo.Player.HandCard = GameInfo.Player.Deck.GetRange(0, 5);
            GameInfo.Player.Deck.RemoveRange(0, 5);
            GameInfo.Player.HP = 5000;
        }

        //컴퓨터 알고리즘
        async public static void ComputerAI()
        {
            for(int i = 0; i < GameInfo.TurnInfo.ComputerAttackCount.Count; i++)
            {
                GameInfo.TurnInfo.ComputerAttackCount[i] = false;
            }
            Random rnd = new Random();
            //소환
            if (GameInfo.TurnInfo.Summon == true)
            {
                int select = rnd.Next(2);
                //카드 소환 0 일때 공격형, 1일때 방어형
                if (select == 0)
                {
                    Button summon = GetNoBackgroundImageButton(GameInfo.Computer.AttackFieldBtn);
                    if (summon != null)
                    {
                        summon.BackgroundImage = ImageControl.ResizeImage(GameInfo.Computer.HandCard[0].Image, 77, 110);
                        GameInfo.Computer.AttackFieldCard.Add(GameInfo.Computer.HandCard[0]);
                        GameInfo.Computer.HandCard.RemoveAt(0);

                        EnableAttack(GameInfo.Computer, GameInfo.TurnInfo.ComputerAttackCount);
                        GameInfo.TurnInfo.ComputerAttackCount.Add(true);
                    }
                    else
                    {
                        select++;
                    }
                }
                else if (select == 1)
                {
                    Button summon = GetNoBackgroundImageButton(GameInfo.Computer.DefenseFieldBtn);
                    if (summon != null)
                    {
                        summon.BackgroundImage = ImageControl.RotateImage(ImageControl.ResizeImage(GameInfo.Computer.HandCard[0].Image, 77, 110));
                        GameInfo.Computer.DefenseFieldCard.Add(GameInfo.Computer.HandCard[0]);
                        GameInfo.Computer.HandCard.RemoveAt(0);
                        //SetBackgroundImageButton(GameInfo.Computer.HandBtn, GameInfo.Computer.HandCard, 77, 110, 0);
                    }
                    
                }
                GameInfo.TurnInfo.Summon = false;
                //SummonSpecialCard(GameInfo.Computer.HandCard[0], GameInfo.Computer, GameInfo.Player, GameInfo.TurnInfo.PlayerAttackCount);

                //카드 소환 후 HP 정보 업데이트(특수 카드 효과)
                UpdateHPInfo();
                UpdateCardTooltips();
            }

            //카드 드로우
            if (GameInfo.TurnInfo.Draw == true)
            {
                //손에 든 카드가 5장 보다 적고 덱이 남아있으면 드로우
                if (GameInfo.Computer.HandCard.Count < 5 && GameInfo.Computer.Deck.Count > 0)
                {
                    GameInfo.Computer.HandCard.Add(GameInfo.Computer.Deck[0]);
                    GameInfo.Computer.Deck.RemoveAt(0);
                    //SetBackgroundImageButton(GameInfo.Computer.HandBtn, GameInfo.Computer.HandCard, 77, 110, 0);
                    GameInfo.TurnInfo.Draw = false;
                }
            }

            //공격
            if (GameInfo.TurnInfo.Attack == true)
            {
                for (int i = 0; i < GameInfo.Computer.AttackFieldCard.Count; i++)
                {
                    if (GameInfo.Computer.AttackFieldCard.Count > 0)
                    {
                        int attack = i;
                        //첫 소환된 카드는 공격 불가능 및 턴당 한 번 공격 가능
                        if (GameInfo.TurnInfo.ComputerAttackCount[attack] == true) 
                        {
                            continue;
                        }
                        int attackTarget = -1;
                        if (GameInfo.Player.AttackFieldCard.Count > 0)
                            attackTarget = rnd.Next(GameInfo.Player.AttackFieldCard.Count);
                        int defenseTarget = -1;
                        if (GameInfo.Player.DefenseFieldCard.Count > 0)
                            defenseTarget = rnd.Next(GameInfo.Player.DefenseFieldCard.Count);

                        if (attack > -1 && attackTarget > -1)
                        {
                            //공격하는 카드가 공격받는 카드보다 공격력이 높을 때
                            if (GameInfo.Computer.AttackFieldCard[attack].Attack > GameInfo.Player.AttackFieldCard[attackTarget].Attack)
                            {
                                //전투 화면 폼 호출
                                //battle battle = new(GameInfo.Computer.AttackFieldBtn[attack], GameInfo.Player.AttackFieldBtn[attackTarget], GameInfo.Computer.AttackFieldBtn[attack]);
                                battle battle = new(GameInfo.Player.AttackFieldBtn[attackTarget], GameInfo.Computer.AttackFieldBtn[attack], GameInfo.Computer.AttackFieldBtn[attack]);
                                battle.StartPosition = FormStartPosition.CenterScreen;
                                battle.Show();

                                //공격한 카드 체크
                                DisableAttack(attack, GameInfo.Computer, GameInfo.TurnInfo.ComputerAttackCount);

                                //대미지 계산
                                int damage = GameInfo.Player.AttackFieldCard[attackTarget].Attack - GameInfo.Computer.AttackFieldCard[attack].Attack;

                                //패배 한 카드 제거
                                playerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Player.AttackFieldCard[attackTarget].Image, 77, 110);
                                GameInfo.Player.AttackFieldBtn[attackTarget].BackgroundImage = null;
                                GameInfo.Player.AttackFieldCard.RemoveAt(attackTarget);
                                GameInfo.TurnInfo.PlayerAttackCount.RemoveAt(attackTarget);
                                SetBackgroundImageButton(GameInfo.Player.AttackFieldBtn, GameInfo.Player.AttackFieldCard, 77, 110, 0);

                                //대미지 적용
                                GameInfo.Player.HP += damage;
                                goto Attacked;
                            }

                            //공격하는 카드가 공격받는 카드보다 공격력이 낮을 때
                            else if (GameInfo.Computer.AttackFieldCard[attack].Attack < GameInfo.Player.AttackFieldCard[attackTarget].Attack)
                            {
                                //전투 화면 폼 호출
                                //battle battle = new(GameInfo.Computer.AttackFieldBtn[attack], GameInfo.Player.AttackFieldBtn[attackTarget], GameInfo.Player.AttackFieldBtn[attackTarget]);
                                battle battle = new(GameInfo.Player.AttackFieldBtn[attackTarget], GameInfo.Computer.AttackFieldBtn[attack], GameInfo.Player.AttackFieldBtn[attackTarget]);
                                battle.StartPosition = FormStartPosition.CenterScreen;
                                battle.Show();

                                //대미지 계산
                                int damage = GameInfo.Player.AttackFieldCard[attackTarget].Attack - GameInfo.Computer.AttackFieldCard[attack].Attack;

                                //패배 한 카드 제거
                                computerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Computer.AttackFieldCard[attack].Image, 77, 110);
                                GameInfo.Computer.AttackFieldBtn[attack].BackgroundImage = null;
                                GameInfo.Computer.AttackFieldCard.RemoveAt(attack);
                                GameInfo.TurnInfo.ComputerAttackCount.RemoveAt(attack);
                                SetBackgroundImageButton(GameInfo.Computer.AttackFieldBtn, GameInfo.Computer.AttackFieldCard, 77, 110, 0);

                                //대미지 적용
                                GameInfo.Computer.HP -= damage;
                                goto Attacked;
                            }

                            //공격하는 카드와 공격받는 카드의 공격력이 같을 때
                            else
                            {
                                //전투 화면 폼 호출
                                battle battle = new(GameInfo.Player.AttackFieldBtn[attackTarget], GameInfo.Computer.AttackFieldBtn[attack], null);
                                battle.StartPosition = FormStartPosition.CenterScreen;
                                battle.Show();

                                //패배 한 카드 제거
                                playerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Player.AttackFieldCard[attackTarget].Image, 77, 110);
                                GameInfo.Player.AttackFieldBtn[attackTarget].BackgroundImage = null;
                                GameInfo.Player.AttackFieldCard.RemoveAt(attackTarget);
                                GameInfo.TurnInfo.PlayerAttackCount.RemoveAt(attackTarget);
                                SetBackgroundImageButton(GameInfo.Player.AttackFieldBtn, GameInfo.Player.AttackFieldCard, 77, 110, 0);

                                //패배 한 카드 제거
                                computerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Computer.AttackFieldCard[attack].Image, 77, 110);
                                GameInfo.Computer.AttackFieldBtn[attack].BackgroundImage = null;
                                GameInfo.Computer.AttackFieldCard.RemoveAt(attack);
                                GameInfo.TurnInfo.ComputerAttackCount.RemoveAt(attack);
                                SetBackgroundImageButton(GameInfo.Computer.AttackFieldBtn, GameInfo.Computer.AttackFieldCard, 77, 110, 0);
                                goto Attacked;
                            }
                        }

                        //공격형이 방어형 공격
                        else if (attack > -1 && defenseTarget > -1)
                        {
                            //공격하는 카드가 공격받는 카드보다 공격력이 높을 때
                            if (GameInfo.Computer.AttackFieldCard[attack].Attack > GameInfo.Player.DefenseFieldCard[defenseTarget].Defense)
                            {
                                //전투 화면 폼 호출
                                //battle battle = new(GameInfo.Computer.AttackFieldBtn[attack], GameInfo.Player.DefenseFieldBtn[defenseTarget], GameInfo.Computer.AttackFieldBtn[attack]);
                                battle battle = new(GameInfo.Player.DefenseFieldBtn[defenseTarget], GameInfo.Computer.AttackFieldBtn[attack], GameInfo.Computer.AttackFieldBtn[attack]);
                                battle.StartPosition = FormStartPosition.CenterScreen;
                                battle.Show();

                                //공격한 카드 체크
                                DisableAttack(attack, GameInfo.Computer, GameInfo.TurnInfo.ComputerAttackCount);


                                //대미지 계산
                                int damage = GameInfo.Player.DefenseFieldCard[defenseTarget].Defense - GameInfo.Computer.AttackFieldCard[attack].Attack;

                                //패배 한 카드 제거
                                playerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Player.DefenseFieldCard[defenseTarget].Image, 77, 110);
                                GameInfo.Player.DefenseFieldBtn[defenseTarget].BackgroundImage = null;
                                GameInfo.Player.DefenseFieldCard.RemoveAt(defenseTarget);
                                SetBackgroundImageButton(GameInfo.Player.DefenseFieldBtn, GameInfo.Player.DefenseFieldCard, 77, 110, 90);

                                //대미지 적용
                                GameInfo.Player.HP += damage;
                                goto Attacked;
                            }

                            //공격하는 카드가 공격받는 카드보다 공격력이 낮을 때
                            else if (GameInfo.Computer.AttackFieldCard[attack].Attack < GameInfo.Player.DefenseFieldCard[defenseTarget].Defense)
                            {
                                //전투 화면 폼 호출
                                //battle battle = new(GameInfo.Computer.AttackFieldBtn[attack], GameInfo.Player.DefenseFieldBtn[defenseTarget], GameInfo.Player.DefenseFieldBtn[defenseTarget]);
                                battle battle = new(GameInfo.Player.DefenseFieldBtn[defenseTarget], GameInfo.Computer.AttackFieldBtn[attack], GameInfo.Player.DefenseFieldBtn[defenseTarget]);
                                battle.StartPosition = FormStartPosition.CenterScreen;
                                battle.Show();

                                //대미지 계산
                                int damage = GameInfo.Player.DefenseFieldCard[defenseTarget].Defense - GameInfo.Computer.AttackFieldCard[attack].Attack;

                                //패배 한 카드 제거
                                computerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Computer.AttackFieldCard[attack].Image, 77, 110);
                                GameInfo.Computer.AttackFieldBtn[attack].BackgroundImage = null;
                                GameInfo.Computer.AttackFieldCard.RemoveAt(attack);
                                GameInfo.TurnInfo.ComputerAttackCount.RemoveAt(attack);
                                SetBackgroundImageButton(GameInfo.Computer.AttackFieldBtn, GameInfo.Computer.AttackFieldCard, 77, 110, 0);

                                //대미지 적용
                                GameInfo.Computer.HP -= damage;
                                goto Attacked;
                            }

                            //공격하는 카드와 공격받는 카드의 공격력이 같을 때
                            else
                            {
                                //전투 화면 폼 호출
                                //battle battle = new(GameInfo.Computer.AttackFieldBtn[attack], GameInfo.Player.DefenseFieldBtn[defenseTarget], null);
                                battle battle = new(GameInfo.Player.DefenseFieldBtn[defenseTarget], GameInfo.Computer.AttackFieldBtn[attack], null);
                                battle.StartPosition = FormStartPosition.CenterScreen;
                                battle.Show();

                                //패배 한 카드 제거
                                playerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Player.DefenseFieldCard[defenseTarget].Image, 77, 110);
                                GameInfo.Player.DefenseFieldBtn[defenseTarget].BackgroundImage = null;
                                GameInfo.Player.DefenseFieldCard.RemoveAt(defenseTarget);
                                SetBackgroundImageButton(GameInfo.Player.DefenseFieldBtn, GameInfo.Player.DefenseFieldCard, 77, 110, 90);

                                //패배 한 카드 제거
                                computerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Computer.AttackFieldCard[attack].Image, 77, 110);
                                GameInfo.Computer.AttackFieldBtn[attack].BackgroundImage = null;
                                GameInfo.Computer.AttackFieldCard.RemoveAt(attack);
                                GameInfo.TurnInfo.ComputerAttackCount.RemoveAt(attack);
                                SetBackgroundImageButton(GameInfo.Computer.AttackFieldBtn, GameInfo.Computer.AttackFieldCard, 77, 110, 0);
                                goto Attacked;
                            }
                        }
                        else
                        {
                            if (GetTotalCountSummonedCard(GameInfo.Player.AttackFieldBtn, GameInfo.Player.DefenseFieldBtn) > 0)
                            {
                                MessageBox.Show("필드에 소환된 카드가 있으면 플레이어를 직접 공격할 수 없습니다.");
                                return;
                            }
                            //니니니니니니 이미지 띄우는 기능 추가
                            Direct_Attack direct = new Direct_Attack();
                            direct.StartPosition = FormStartPosition.CenterScreen;
                            direct.Show();
                            GameInfo.Player.HP -= GameInfo.Computer.AttackFieldCard[attack].Attack;
                        }
                        //공격 후 HP 정보 업데이트
                        Attacked:
                        UpdateHPInfo();
                        UpdateCardTooltips();
                    }
                    await Task.Delay(4000);
                }
            }
            GameInfo.TurnInfo.SetPlayerTurn();
        }

        //카드 뽑기, 최대 5장까지 보유 가능, 한 턴에 한 번 가능
        public static void DrawCard(List<Card> deck, List<Card> hand)
        {
            //이미 드로우 했다면 드로우 불가
            if (GameInfo.TurnInfo.Draw)
            {
                MessageBox.Show("이미 드로우 하셨습니다");
                return;
            }

            //덱에 남은 카드가 없으면 드로우 불가
            if (deck.Count == 0)
            {
                MessageBox.Show("남은 카드가 존재하지 않습니다.");
                GameInfo.Player.DeckBtn.Enabled = false;
                GameInfo.Player.DeckBtn.BackgroundImage = null;
            }
            if (hand.Count < 5) //손에 든 카드가 5장 보다 적으면 드로우
            {
                hand.Add(deck[0]);
                deck.RemoveAt(0);
                SetBackgroundImageButton(GameInfo.Player.HandBtn, GameInfo.Player.HandCard, 110, 225, 0);
                GameInfo.TurnInfo.Draw = true;
            }
            else //손에 든 카드가 5장 이상일때 드로우 불가
                MessageBox.Show("소지 가능한 패는 최대 5장입니다");

            SetEnableButtonByImage(GameInfo.Player.HandBtn); //카드가 추가된 버튼은 클릭 가능
            UpdateCardTooltips();
        }

        //카드 소환, 한 턴에 한 번 가능
        public static void SummonCard(Button button)
        {
            //한 턴에 한번 소환
            if (GameInfo.TurnInfo.Summon)
            {
                MessageBox.Show("카드는 한 턴에 한 번만 소환할 수 있습니다.");
                return;
            }

            if (HandCardBtn != null && SummonTypeBtn != null) //카드와 필드를 다 선택했다면
            {
                //어떤 카드를 선택했는지?
                Card selectedCard = GameInfo.Player.HandCard[GameInfo.Player.HandBtn.IndexOf(button)];
                int idx = GameInfo.Player.HandBtn.IndexOf(button);

                //공격 모드를 선택했다면
                if (SummonTypeBtn.Name == "btnAttack")
                {
                    Button summon = GetNoBackgroundImageButton(GameInfo.Player.AttackFieldBtn);
                    if (summon == null)
                    {
                        MessageBox.Show("더 이상 소환할 수 없습니다.");
                        return;
                    }
                    else
                    {
                        summon.BackgroundImage = ImageControl.ResizeImage(GameInfo.Player.HandCard[idx].Image, 77, 110);
                        GameInfo.Player.AttackFieldCard.Add(GameInfo.Player.HandCard[idx]);
                        GameInfo.Player.HandCard.RemoveAt(idx);
                        SetBackgroundImageButton(GameInfo.Player.HandBtn, GameInfo.Player.HandCard, 77, 110, 0);
                        EnableAttack(GameInfo.Player, GameInfo.TurnInfo.PlayerAttackCount);
                        GameInfo.TurnInfo.PlayerAttackCount.Add(true);
                        EnableBtn(GameInfo.Player, GameInfo.TurnInfo.PlayerAttackCount);
                    }
                }
                //방어 모드를 선택했다면
                else if (SummonTypeBtn.Name == "btnDefence")
                {
                    Button summon = GetNoBackgroundImageButton(GameInfo.Player.DefenseFieldBtn);
                    if (summon == null)
                    {
                        MessageBox.Show("더 이상 소환할 수 없습니다.");
                        return;
                    }
                    else
                    {
                        summon.BackgroundImage = ImageControl.RotateImage(ImageControl.ResizeImage(GameInfo.Player.HandCard[idx].Image, 77, 110));
                        GameInfo.Player.DefenseFieldCard.Add(GameInfo.Player.HandCard[idx]);
                        GameInfo.Player.HandCard.RemoveAt(idx);
                        SetBackgroundImageButton(GameInfo.Player.HandBtn, GameInfo.Player.HandCard, 77, 110, 0);
                    }
                }

                //카드를 소환 했음
                GameInfo.TurnInfo.Summon = true;

                //카드가 빈 버튼은 클릭 불가능 설정
                SetEnableButtonByImage(GameInfo.Player.HandBtn);

                //소환할 카드와 소환 모드 초기화
                HandCardBtn = null;
                SummonTypeBtn = null;

                SummonSpecialCard(selectedCard, GameInfo.Player, GameInfo.Computer, GameInfo.TurnInfo.ComputerAttackCount);

                //카드 소환 후 HP 정보 업데이트(특수 카드 효과)
                UpdateHPInfo();
                UpdateCardTooltips();
            }
        }

        //특수 효과 카드 소환 시 로직
        static void SummonSpecialCard(Card selectedCard, Player player, Player target, List<bool?> attackCount)
        {
            //YuGiOh_Card 중에서 기능을 가진 녀석들에 대한 기능 구현
            switch (selectedCard.Function)
            {
                case "destroy":
                    if (player == GameInfo.Player)
                    {
                        //적 필드에 카드가 있는지 확인
                        if (target.AttackFieldCard.Count > 0 || target.DefenseFieldCard.Count > 0)
                        {
                            Random random = new Random();

                            //적 공격 필드에서 카드 제거
                            if (target.AttackFieldCard.Count > 0)
                            {
                                int randomIndex = random.Next(0, target.AttackFieldCard.Count);
                                target.AttackFieldCard.RemoveAt(randomIndex);
                                target.AttackFieldBtn[randomIndex].BackgroundImage = null;
                                attackCount.RemoveAt(randomIndex);
                                MessageBox.Show("카드 한 장이 파괴되었습니다.");
                                return; //파괴가 성공했으므로 더 이상 진행X
                            }

                            //적 방어 필드에서 카드를 제거
                            if (target.DefenseFieldCard.Count > 0)
                            {
                                int randomIndex = random.Next(0, target.DefenseFieldCard.Count);
                                target.DefenseFieldCard.RemoveAt(randomIndex);
                                MessageBox.Show("카드 한 장이 파괴되었습니다.");
                                target.DefenseFieldBtn[randomIndex].BackgroundImage = null;
                                return;
                            }
                        }
                        MessageBox.Show("파괴할 카드가 없습니다.");
                    }
                    else
                    {
                        //적 필드에 카드가 있는지 확인
                        if (target.AttackFieldCard.Count > 0 || target.DefenseFieldCard.Count > 0)
                        {
                            Random random = new Random();

                            //적 공격 필드에서 카드 제거
                            if (target.AttackFieldCard.Count > 0)
                            {
                                int randomIndex = random.Next(0, target.AttackFieldCard.Count);
                                target.AttackFieldCard.RemoveAt(randomIndex);
                                target.AttackFieldBtn[randomIndex].BackgroundImage = null;
                                attackCount.RemoveAt(randomIndex);
                                return; //파괴가 성공했으므로 더 이상 진행X
                            }

                            //적 방어 필드에서 카드를 제거
                            if (target.DefenseFieldCard.Count > 0)
                            {
                                int randomIndex = random.Next(0, target.DefenseFieldCard.Count);
                                target.DefenseFieldCard.RemoveAt(randomIndex);
                                target.DefenseFieldBtn[randomIndex].BackgroundImage = null;
                                return;
                            }
                        }
                    }
                    break;
                case "draw":
                    if (player == GameInfo.Player)
                    {
                        MessageBox.Show("카드 한 장이 드로우 됩니다.");
                        GameLogic.DrawCard(player.Deck, player.HandCard);
                    }
                    break;
                case "heal":
                    if (player == GameInfo.Player)
                    {
                        player.HP += 500;
                        MessageBox.Show("나의 생명력 500 회복");
                    }
                    else
                    {
                        player.HP += 500;
                    }
                    break;
                case "summon":
                    if (player == GameInfo.Player)
                    {
                        MessageBox.Show("카드 한 장을 더 소환할 수 있습니다.");
                        GameInfo.TurnInfo.Summon = false;
                        SummonCard(HandCardBtn);
                    }
                    else
                    {
                        GameInfo.TurnInfo.Summon = true;
                        Random rnd = new Random();
                        //컴퓨터의 턴(소환)이라면
                        if (GameInfo.TurnInfo.Summon == true)
                        {
                            int select = rnd.Next(2);
                            //카드 소환 0 일때 공격형, 1일때 방어형
                            if (select == 0)
                            {
                                Button summon = GetNoBackgroundImageButton(GameInfo.Computer.AttackFieldBtn);
                                if (summon != null)
                                {
                                    summon.BackgroundImage = ImageControl.ResizeImage(GameInfo.Computer.HandCard[0].Image, 77, 110);
                                    GameInfo.Computer.AttackFieldCard.Add(GameInfo.Computer.HandCard[0]);
                                    GameInfo.Computer.HandCard.RemoveAt(0);
                                    EnableAttack(GameInfo.Computer, GameInfo.TurnInfo.ComputerAttackCount);
                                    GameInfo.TurnInfo.ComputerAttackCount.Add(true);
                                }
                                else
                                {
                                    select++;
                                }
                                GameInfo.TurnInfo.Summon = false;
                            }
                            else if (select == 1)
                            {
                                Button summon = GetNoBackgroundImageButton(GameInfo.Computer.DefenseFieldBtn);
                                if (summon != null)
                                {
                                    summon.BackgroundImage = ImageControl.RotateImage(ImageControl.ResizeImage(GameInfo.Computer.HandCard[0].Image, 77, 110));
                                    GameInfo.Computer.DefenseFieldCard.Add(GameInfo.Computer.HandCard[0]);
                                    GameInfo.Computer.HandCard.RemoveAt(0);
                                    SetBackgroundImageButton(GameInfo.Computer.HandBtn, GameInfo.Computer.HandCard, 77, 110, 0);
                                }
                                GameInfo.TurnInfo.Summon = false;
                            }
                            SummonSpecialCard(GameInfo.Computer.HandCard[0], GameInfo.Computer, GameInfo.Player, GameInfo.TurnInfo.PlayerAttackCount);

                            //카드 소환 후 HP 정보 업데이트(특수 카드 효과)
                            UpdateHPInfo();
                            UpdateCardTooltips();
                        }
                    }
                    break;
                case "attack":
                    if (player == GameInfo.Player)
                    {
                        target.HP -= 500;
                        MessageBox.Show("상대방의 생명력 500 차감");
                    }
                    else
                    {
                        target.HP -= 500;
                    }
                    break;
                //skip은 내 턴을 한 번 더 가질 수 있음
                case "skip":
                    if (target == GameInfo.Computer)
                    {
                        MessageBox.Show("드로우, 소환, 공격을 다시 할 수 있습니다.");
                        for (int i = 0; i < GameInfo.TurnInfo.PlayerAttackCount.Count; i++)
                        {
                            GameInfo.TurnInfo.PlayerAttackCount[i] = false;
                        }
                        GameInfo.TurnInfo.SetPlayerTurn(); // 내 턴으로 설정합니다.
                    }
                    else
                    {
                        for (int i = 0; i < GameInfo.TurnInfo.ComputerAttackCount.Count; i++)
                        {
                            GameInfo.TurnInfo.ComputerAttackCount[i] = false;
                        }
                        GameInfo.TurnInfo.SetComputerTurn();
                        ComputerAI();
                    }
                    break;
            }
        }

        //플레이어용 공격
        public static void Attack(Button a, Button b)
        {
            //공격하는 카드의 인덱스
            int idxAttack = GameInfo.Player.AttackFieldBtn.IndexOf(a);
            int idxTarget;

            //공격하는 카드를 정상적으로 선택했는가?
            if (idxAttack == -1)
            {
                MessageBox.Show("공격을 수행할 카드를 선택해주세요");
                return;
            }

            //첫 소환된 카드는 공격 불가능 및 턴당 한 번 공격 가능
            if (GameInfo.TurnInfo.PlayerAttackCount[idxAttack] == true)
            {
                MessageBox.Show("이미 공격한 카드입니다");
                return;
            }

            //공격형 -> 공격형 타격 시
            if (GameInfo.Computer.AttackFieldBtn.IndexOf(b) >= 0)
            {
                //공격 받는 카드 인덱스
                idxTarget = GameInfo.Computer.AttackFieldBtn.IndexOf(b);

                //공격하는 카드가 공격받는 카드보다 공격력이 높을 때
                if (GameInfo.Player.AttackFieldCard[idxAttack].Attack > GameInfo.Computer.AttackFieldCard[idxTarget].Attack)
                {
                    //전투 화면 폼 호출
                    battle battle = new(a, b, a);
                    battle.StartPosition = FormStartPosition.CenterScreen;
                    battle.Show();

                    //공격한 카드 체크
                    DisableAttack(idxAttack, GameInfo.Player, GameInfo.TurnInfo.PlayerAttackCount);


                    //대미지 계산
                    int damage = GameInfo.Computer.AttackFieldCard[idxTarget].Attack - GameInfo.Player.AttackFieldCard[idxAttack].Attack;

                    //패배 한 카드 제거
                    computerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Computer.AttackFieldCard[idxTarget].Image, 77, 110);
                    GameInfo.Computer.AttackFieldBtn[idxTarget].BackgroundImage = null;
                    GameInfo.Computer.AttackFieldCard.RemoveAt(idxTarget);
                    GameInfo.TurnInfo.ComputerAttackCount.RemoveAt(idxTarget);
                    SetBackgroundImageButton(GameInfo.Computer.AttackFieldBtn, GameInfo.Computer.AttackFieldCard, 77, 110, 0);

                    //대미지 적용
                    GameInfo.Computer.HP += damage;
                }

                //공격하는 카드가 공격받는 카드보다 공격력이 낮을 때
                else if (GameInfo.Player.AttackFieldCard[idxAttack].Attack < GameInfo.Computer.AttackFieldCard[idxTarget].Attack)
                {
                    //전투 화면 폼 호출
                    battle battle = new(a, b, b);
                    battle.StartPosition = FormStartPosition.CenterScreen;
                    battle.Show();

                    //대미지 계산
                    int damage = GameInfo.Computer.AttackFieldCard[idxTarget].Attack - GameInfo.Player.AttackFieldCard[idxAttack].Attack;

                    //패배 한 카드 제거
                    playerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Player.AttackFieldCard[idxAttack].Image, 77, 110);
                    GameInfo.Player.AttackFieldBtn[idxAttack].BackgroundImage = null;
                    GameInfo.Player.AttackFieldCard.RemoveAt(idxAttack);
                    GameInfo.TurnInfo.PlayerAttackCount.RemoveAt(idxAttack);
                    SetBackgroundImageButton(GameInfo.Player.AttackFieldBtn, GameInfo.Player.AttackFieldCard, 77, 110, 0);

                    //대미지 적용
                    GameInfo.Player.HP -= damage;
                }

                //공격하는 카드와 공격받는 카드의 공격력이 같을 때
                else
                {
                    //전투 화면 폼 호출
                    battle battle = new(a, b, null);
                    battle.StartPosition = FormStartPosition.CenterScreen;
                    battle.Show();

                    //패배 한 카드 제거
                    playerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Player.AttackFieldCard[idxAttack].Image, 77, 110);
                    GameInfo.Player.AttackFieldBtn[idxAttack].BackgroundImage = null;
                    GameInfo.Player.AttackFieldCard.RemoveAt(idxAttack);
                    GameInfo.TurnInfo.PlayerAttackCount.RemoveAt(idxAttack);
                    SetBackgroundImageButton(GameInfo.Player.AttackFieldBtn, GameInfo.Player.AttackFieldCard, 77, 110, 0);

                    //패배 한 카드 제거
                    computerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Computer.AttackFieldCard[idxTarget].Image, 77, 110);
                    GameInfo.Computer.AttackFieldBtn[idxTarget].BackgroundImage = null;
                    GameInfo.Computer.AttackFieldCard.RemoveAt(idxTarget);
                    GameInfo.TurnInfo.ComputerAttackCount.RemoveAt(idxTarget);
                    SetBackgroundImageButton(GameInfo.Computer.AttackFieldBtn, GameInfo.Computer.AttackFieldCard, 77, 110, 0);
                }
            }

            //공격형 -> 방어형 타격 시
            else if (GameInfo.Computer.DefenseFieldBtn.IndexOf(b) >= 0)
            {
                //공격 받는 카드 인덱스
                idxTarget = GameInfo.Computer.DefenseFieldBtn.IndexOf(b);

                //공격하는 카드가 공격받는 카드보다 공격력이 높을 때
                if (GameInfo.Player.AttackFieldCard[idxAttack].Attack > GameInfo.Computer.DefenseFieldCard[idxTarget].Defense)
                {
                    //전투 화면 폼 호출
                    battle battle = new(a, b, a);
                    battle.StartPosition = FormStartPosition.CenterScreen;
                    battle.Show();

                    DisableAttack(idxAttack, GameInfo.Player, GameInfo.TurnInfo.PlayerAttackCount);

                    //대미지 계산
                    int damage = GameInfo.Computer.DefenseFieldCard[idxTarget].Defense - GameInfo.Player.AttackFieldCard[idxAttack].Attack;

                    //패배 한 카드 제거
                    computerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Computer.DefenseFieldCard[idxTarget].Image, 77, 110);
                    GameInfo.Computer.DefenseFieldBtn[idxTarget].BackgroundImage = null;
                    GameInfo.Computer.DefenseFieldCard.RemoveAt(idxTarget);
                    SetBackgroundImageButton(GameInfo.Computer.DefenseFieldBtn, GameInfo.Computer.DefenseFieldCard, 77, 110, 90);

                    //대미지 적용
                    GameInfo.Computer.HP += damage;
                }

                //공격하는 카드가 공격받는 카드보다 공격력이 낮을 때
                else if (GameInfo.Player.AttackFieldCard[idxAttack].Attack < GameInfo.Computer.DefenseFieldCard[idxTarget].Defense)
                {
                    //전투 화면 폼 호출
                    battle battle = new(a, b, b);
                    battle.StartPosition = FormStartPosition.CenterScreen;
                    battle.Show();

                    //대미지 계산
                    int damage = GameInfo.Computer.DefenseFieldCard[idxTarget].Defense - GameInfo.Player.AttackFieldCard[idxAttack].Attack;

                    //패배 한 카드 제거
                    playerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Player.AttackFieldCard[idxAttack].Image, 77, 110);
                    GameInfo.Player.AttackFieldBtn[idxAttack].BackgroundImage = null;
                    GameInfo.Player.AttackFieldCard.RemoveAt(idxTarget);
                    SetBackgroundImageButton(GameInfo.Player.AttackFieldBtn, GameInfo.Player.AttackFieldCard, 77, 110, 0);

                    //대미지 적용
                    GameInfo.Player.HP -= damage;
                }

                //공격하는 카드와 공격받는 카드의 공격력이 같을 때
                else
                {
                    //전투 화면 폼 호출
                    battle battle = new(a, b, null);
                    battle.StartPosition = FormStartPosition.CenterScreen;
                    battle.Show();

                    //패배 한 카드 제거
                    playerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Player.AttackFieldCard[idxAttack].Image, 77, 110);
                    GameInfo.Player.AttackFieldBtn[idxAttack].BackgroundImage = null;
                    GameInfo.Player.AttackFieldCard.RemoveAt(idxAttack);
                    GameInfo.TurnInfo.PlayerAttackCount.RemoveAt(idxAttack);
                    SetBackgroundImageButton(GameInfo.Player.AttackFieldBtn, GameInfo.Player.AttackFieldCard, 77, 110, 0);

                    //패배 한 카드 제거
                    computerDie.BackgroundImage = ImageControl.ResizeImage(GameInfo.Computer.DefenseFieldCard[idxTarget].Image, 77, 110);
                    GameInfo.Computer.DefenseFieldBtn[idxTarget].BackgroundImage = null;
                    GameInfo.Computer.DefenseFieldCard.RemoveAt(idxTarget);
                    SetBackgroundImageButton(GameInfo.Computer.DefenseFieldBtn, GameInfo.Computer.DefenseFieldCard, 77, 110, 90);
                }
            }

            //플레이어 직접 공격 시
            else if (GameInfo.Computer.PlayerBtn == b)
            {
                if (GetTotalCountSummonedCard(GameInfo.Computer.AttackFieldBtn, GameInfo.Computer.DefenseFieldBtn) > 0)
                {
                    MessageBox.Show("필드에 소환된 카드가 있으면 플레이어를 직접 공격할 수 없습니다.");
                    return;
                }
                //니니니니니니 이미지 띄우는 기능 추가
                Direct_Attack direct = new Direct_Attack();
                direct.StartPosition = FormStartPosition.CenterScreen;
                direct.Show();
                GameInfo.Computer.HP -= GameInfo.Player.AttackFieldCard[idxAttack].Attack;
            }

            //공격 후 HP 정보 업데이트
            UpdateHPInfo();
            UpdateCardTooltips();
        }

        //공격할 카드 선택 후 컴퓨터의 카드 및 본체 버튼 활성화/비활성화
        public static void SetEnableAttack()
        {
            if (GetTotalCountSummonedCard(GameInfo.Computer.AttackFieldBtn, GameInfo.Computer.DefenseFieldBtn) == 0)
                GameInfo.Computer.PlayerBtn.Enabled = true;
            else
                GameInfo.Computer.PlayerBtn.Enabled = false;

            SetEnableButtonByImage(GameInfo.Computer.AttackFieldBtn);
            SetEnableButtonByImage(GameInfo.Computer.DefenseFieldBtn);
        }

        //공격 후 컴퓨터 버튼들 비활성화
        public static void SetDisableAttack()
        {
            GameInfo.Computer.PlayerBtn.Enabled = false;
            foreach (Button item in GameInfo.Computer.AttackFieldBtn)
                item.Enabled = false;
            foreach (Button item in GameInfo.Computer.DefenseFieldBtn)
                item.Enabled = false;
        }

        //공격 가능한 상태에 따라 버튼 활성화/비활성화
        public static void EnableBtn(Player player, List<bool?> attack)
        {
            for (int i = 0; i < attack.Count; i++)
            {
                if (attack[i] != null)
                {
                    if (attack[i] == false)
                        player.AttackFieldBtn[i].Enabled = true;
                    else
                        player.AttackFieldBtn[i].Enabled = false;
                }
            }
        }

        //턴 변경시 소환된 카드를 공격 가능한 상태로 변경
        public static void EnableAttack(Player player, List<bool?> attack)
        {
            for (int i = 0; i < attack.Count; i++)
            {
                if (attack[i] != null)
                {
                    attack[i] = false;
                    if (player == GameInfo.Player)
                        player.AttackFieldBtn[i].Enabled = true;
                }
            }
        }

        //공격한 카드는 비활성화(공격은 한번만, 선택 불가능으로 변경)
        static void DisableAttack(int idx, Player player, List<bool?> attack)
        {
            attack[idx] = true;
            player.AttackFieldBtn[idx].Enabled = false;
        }

        //컴퓨터, 플레이어 HP 정보 업데이트
        static void UpdateHPInfo()
        {
            LbPlayer.Text = GameInfo.Player.HP.ToString();
            LbComputer.Text = GameInfo.Computer.HP.ToString();
            if (GameInfo.Player.HP <= 0)
            {
                MessageBox.Show("패배");
                GameInfo.Game.Close();
                Initialize();
            }
            if (GameInfo.Computer.HP <= 0)
            {
                MySQLHandler handler = new MySQLHandler();
                MessageBox.Show("승리\n포인트 500 획득");
                handler.UpdateMemberInfo(GameInfo.Member.Id, GameInfo.Member.Cash + 500);

                GameInfo.Game.Close();
                Initialize();
            }
        }

        //새 게임 시작 시 기존 정보 초기화
        static void Initialize()
        {
            HandCardBtn = null; //손에 들고 있는 소환할 카드
            AttackFieldBtn = null; //공격 할 카드

            EnemyBtn = null; //공격할 플레이어(직접 공격)
            EnemyAttackFieldBtn = null; //공격할 카드(공격형)
            EnemyDefenceFieldBtn = null; //공격할 카드(방어형)

            SummonTypeBtn = null;

            GameInfo.Player.Clear();
            GameInfo.Computer.Clear();
            GameInfo.TurnInfo.Clear();
        }

        //리스트에서 백그라운드 이미지가 없는 가장 빠른 인덱스의 버튼 반환
        static Button GetNoBackgroundImageButton(List<Button> buttonList)
        {
            Button resultButton = null;
            int minIndex = int.MaxValue;

            for (int i = 0; i < buttonList.Count; i++)
            {
                if (buttonList[i].BackgroundImage == null && i < minIndex)
                {
                    minIndex = i;
                    resultButton = buttonList[i];
                }
            }

            return resultButton;
        }

        //이미지 없는 버튼 비활성화, 이미지 있는 버튼 활성화
        static void SetEnableButtonByImage(List<Button> buttons)
        {
            foreach (var button in buttons)
            {
                if (button.BackgroundImage != null)
                {
                    button.Enabled = true;
                }
                else
                {
                    button.Enabled = false;
                }
            }
        }

        //카드 셔플 및 특정 개수 가져오기
        static List<Card> GetRandomCard(List<Card> cardList, int cardNum)
        {
            Random random = new Random();

            List<Card> shuffledCards = cardList.OrderBy(x => random.Next()).ToList();

            List<Card> selectedCards = shuffledCards.Take(cardNum).ToList();

            return selectedCards;
        }

        //소환, 파괴 등 변동 사항 버튼 백그라운드 이미지로 반영
        static void SetBackgroundImageButton(List<Button> buttons, List<Card> imageList, int width, int height, int degree)
        {
            if (degree == 0)
            {
                // 이미지 리스트와 버튼 배열의 인덱스가 일치하면 해당 이미지 설정
                for (int i = 0; i < buttons.Count && i < imageList.Count; i++)
                {
                    buttons[i].BackgroundImage = ImageControl.ResizeImage(imageList[i].Image, width, height);
                }

                if (imageList.Count > 0)
                {
                    // 이미지가 부족한 경우 배열 앞쪽 버튼에 대해서는 리스트에서 이미지 설정
                    for (int i = imageList.Count; i < buttons.Count; i++)
                    {
                        buttons[i].BackgroundImage = ImageControl.ResizeImage(imageList[i % imageList.Count].Image, width, height);
                    }
                }
            }
            if (degree == 90)
            {
                for (int i = 0; i < buttons.Count && i < imageList.Count; i++)
                {
                    buttons[i].BackgroundImage = ImageControl.RotateImage(ImageControl.ResizeImage(imageList[i].Image, width, height));
                }

                if (imageList.Count > 0)
                {
                    // 이미지가 부족한 경우 배열 앞쪽 버튼에 대해서는 리스트에서 이미지 설정
                    for (int i = imageList.Count; i < buttons.Count; i++)
                    {
                        buttons[i].BackgroundImage = ImageControl.RotateImage(ImageControl.ResizeImage(imageList[i % imageList.Count].Image, width, height));
                    }
                }
            }

            // 이미지가 부족한 경우 나머지 버튼은 이미지 제거
            for (int i = imageList.Count; i < buttons.Count; i++)
            {
                buttons[i].BackgroundImage = null;
            }
        }

        //필드에 소환되어 있는 모든 카드의 수 반환
        static int GetTotalCountSummonedCard(List<Button> AttackList, List<Button> Defenselist)
        {
            int count = 0;
            foreach (Button item in AttackList)
            {
                if (item.BackgroundImage != null)
                {
                    count++;
                }
            }
            foreach (Button item in Defenselist)
            {
                if (item.BackgroundImage != null)
                {
                    count++;
                }
            }
            return count;
        }

        //각 필드에 생성된 툴팁 적용
        public static void UpdateCardTooltips()
        {
            try
            {
                // 모든 툴팁 제거
                CardToolTip.RemoveAll();

                // 플레이어 및 상대방의 필드에 대한 툴팁 설정
                SetTooltipsForField(GameInfo.Player.HandBtn, GameInfo.Player.HandCard);
                SetTooltipsForField(GameInfo.Player.AttackFieldBtn, GameInfo.Player.AttackFieldCard);
                SetTooltipsForField(GameInfo.Player.DefenseFieldBtn, GameInfo.Player.DefenseFieldCard);
                SetTooltipsForField(GameInfo.Computer.AttackFieldBtn, GameInfo.Computer.AttackFieldCard);
                SetTooltipsForField(GameInfo.Computer.DefenseFieldBtn, GameInfo.Computer.DefenseFieldCard);
            }
            catch (Exception ex)
            {
                // 예외가 발생한 경우 처리
                Console.WriteLine("예외 발생: " + ex.Message);
            }
        }

        //툴팁 생성 메소드
        static void SetTooltipsForField(List<Button> fieldButtons, List<Card> fieldCards)
        {
            foreach (var button in fieldButtons)
            {
                int index = fieldButtons.IndexOf(button);

                // 인덱스가 올바른 범위 내에 있는지 확인
                if (index >= 0 && index < fieldCards.Count)
                {
                    Card card = fieldCards[index];

                    // 기존에 등록된 툴팁 제거
                    CardToolTip.SetToolTip(button, null);

                    // 새로운 툴팁 설정
                    CardToolTip.SetToolTip(button, card.TooltipInfo());
                }
                else
                {
                    // 예외가 발생한 경우 처리
                    Console.WriteLine("예외: 올바르지 않은 인덱스");
                }
            }
        }
    }
}