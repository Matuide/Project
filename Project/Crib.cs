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
        public Crib()
        {
            crib = new Hand();
        }
        public void addtocrib(Card card)
        {
            crib.addCard(card);
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
                toreturn = crib.remove();
                end = end - 1;
            }

            return toreturn;
        }
        public int Count()
        {
            return crib.gethand().Length;
        }
    }
}
