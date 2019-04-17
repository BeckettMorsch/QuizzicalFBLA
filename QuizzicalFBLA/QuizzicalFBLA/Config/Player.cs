using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzicalFBLA.Config
{
    public class Player
    {
        private static Player player;

        private Player ()
        {
        }

        public string Nickname { get; set; } = "Player";
        public string Name { get; set; } = "Player";
        public string Sub { get; set; } = "na|1234567890";
        public string AutoUsername { get; set; } = "na1234567890";
        public string AutoPassword { get; set; } = "NDFknf2lakdsjf823jLDSo4indsfDKJie3749fmDklkdskqwIPOjlkdsVCNL4870jhmnsaz";

        public static Player Current
        {
            get {

                if (player == null)
                {
                    player = new Player();
                }

                return player;
            }
        }
    }
}
