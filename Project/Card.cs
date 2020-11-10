using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Card
    {
        public int suit;
        public int number;
        
        public int tempnumber;

        public Card(int suit, int number, int tempnumber)
        {
            this.suit = suit;
            this.number = number;
            this.tempnumber = tempnumber;
            
        }
    }
}