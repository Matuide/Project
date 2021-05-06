using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Card
    {
        //each card has a suit and two numbers, as different numbers may be used when counting points
        public int suit;
        public int number;
        public int tempnumber;

        public Card(int suit, int number, int tempnumber)
        {
            this.suit = suit;
            this.number = number;
            this.tempnumber = tempnumber;
            
        }
        //from the file of cards, assign each card an integer representation of the suit to be easier to use.
        private char ConvertSuit(int s)
        {
            char a = 'x';
            if (s == 1)
            {
                a = 'D';
            }
            if (s == 2)
            {
                a = 'C';
            }
            if (s == 3)
            {
                a = 'H';
            }
            if (s == 4)
            {
                a = 'S';
            }

            return a;
        }
        public string getName()
        {
            return Convert.ToString(number) + ConvertSuit(suit);
        }

        public string getUIName()
        {
            return Convert.ToString(number) + Convert.ToString(suit);
        }
    }
}