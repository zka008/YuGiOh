using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh.Data
{
    public class GameInfo
    {
        static Turn turnInfo;
        static Player player;
        static Player computer;
        static Member member;
        public static Form Game {  get; set; }

        public static Member Member
        {
            get
            {
                if (member == null)
                {
                    member = new Member();
                }
                return member;
            }
        }

        public static Turn TurnInfo
        {
            get
            {
                if (turnInfo == null)
                    turnInfo = new Turn();
                return turnInfo;
            }
        }
        public static Player Player
        {
            get
            {
                if (player == null)
                    player = new Player();
                return player;
            }
        }
        public static Player Computer
        {
            get
            {
                if (computer == null)
                    computer = new Player();
                return computer;
            }
        }
    }
}
