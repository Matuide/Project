using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    
    class Pile
    {
        private Card[] pile;
        private const int size = 9;
        private int top;
        public Pile()
        {
            pile = new Card[size];
            top = -1;
        }
        public void Push(Card c)
        {
            top++;
            pile[top] = c;
        }
        public Card[] GetArray()
        {
            return pile;
        }
        public Card peek()
        {
            return pile[top];
        }
        public Card Pop()
        {
            top--;
            return pile[top+1];
        }
    }
}
