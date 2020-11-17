using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
     abstract class Player
    {
        private Hand hand;
        private int points;
        public Player()
        {
            hand = new Hand();
            
        }
        abstract public int move();


        public Boolean addCard(Card c)
        {
            bool t = false;

            return t;
        }
        

        
    }
}
