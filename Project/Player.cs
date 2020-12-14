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
       // private Card extra;
        public Player()
        {
            hand = new Hand();

            
        }
        abstract public int move();
        public Card removecard()
        {
            return hand.remove();
        }
        
        public Card[] ReturnHand()
        {
            return hand.gethand();
        }

        public void addCard(Card c)
        {
            
            hand.addCard(c);
            
        }

        public Hand getHand()
        {

            return hand;
        }
        

        
    }
}
