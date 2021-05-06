using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class AIPlayer : Player
    {
        //returns the card to be played and removes this card from the hand.
      override public Card move()
        {
            bool played = false;
            Card crd = null;
            foreach(Card cr in hand.gethand())
            {
                if(cr != null && !played)
                {
                    played = true;
                    crd = cr;
                    hand.RemoveCard(cr);
                }
            }
            return crd;
        }
        

        

    }
}
