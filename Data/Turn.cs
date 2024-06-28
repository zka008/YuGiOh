using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh.Data
{
    public class Turn
    {
        bool attack; //false일때 플레이어 턴
        bool summon; //true일때 컴퓨터 턴
        bool draw;
        bool playerTurn;
        List<bool?> playerAttackCount; //플레이어의 공격 가능한 카드 수와 공격 유무
        List<bool?> computerAttackCount; //컴퓨터의 공격 가능한 카드 수와 공격 유무

        public Turn()
        {
            Attack = false;
            Summon = false;
            Draw = false;
            PlayerTurn = true;
            PlayerAttackCount = new List<bool?>();
            ComputerAttackCount = new List<bool?>();
        }

        public void Clear()
        {
            Attack = false;
            Summon = false;
            Draw = false;
            PlayerTurn = true;
            PlayerAttackCount.Clear();
            ComputerAttackCount.Clear();
        }

        public bool Attack
        {
            get => attack;
            set
            {
                attack = value;
                UpdatePlayerTurn();
            }
        }

        public bool Summon
        {
            get => summon;
            set
            {
                summon = value;
                UpdatePlayerTurn();
            }
        }

        public bool Draw
        {
            get => draw;
            set
            {
                draw = value;
                UpdatePlayerTurn();
            }
        }

        public bool PlayerTurn
        {
            get => playerTurn;
            private set => playerTurn = value;
        }
        public List<bool?> PlayerAttackCount { get => playerAttackCount; set => playerAttackCount = value; }
        public List<bool?> ComputerAttackCount { get => computerAttackCount; set => computerAttackCount = value; }

        private void UpdatePlayerTurn()
        {
            PlayerTurn = !Attack && !Summon && !Draw;
        }

        public void SetPlayerTurn()
        {
            Attack = false;
            Summon = false;
            Draw = false;
        }

        public void SetComputerTurn()
        {
            Attack = true;
            Summon = true;
            Draw = true;
        }
    }
}