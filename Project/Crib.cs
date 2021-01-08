using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Crib
    {

        private Hand crib;
        private int end = 0;
        public void addtocrib(Card card)
        {
            crib[end] = card;
            end++;
        }
        public Card returnfromcrib()
        {
            Card toreturn;
            if (end == 0)
            {
                return null;
            }
            else
            {
                toreturn = crib[end - 1];
                end = end - 1;
            }

            return toreturn;
        }
    }
}
