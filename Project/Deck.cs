using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Deck
    {
        private Card[] stack;
        private int top;
        private const int DECKSIZE = 52;

        public Deck()

        {
            stack = new Card[DECKSIZE];
            top = -1;
            this.AddToStack();
        }

        public Card pop()
        {
            Card c;
            c = stack[top];
            top--;
            return c;
        }
      
        public void push(Card c)
        {
            if(top < 51)
                top++;
            stack[top] = c;

            
        }
        public Card GetCard1(int pos)
        {
            return stack[pos];
        }
        public void returncard(int pos, Card card)
        {
            stack[pos] = card;
        }
       
        public void AddToStack()
        {
            int a = 0;


            for (int i = 1; i < 5; i++)
            {
                for (int z = 1; z < 14; z++)
                {
                    if (z < 11)
                    {
                        a = z;
                    }
                    else
                    {
                        a = 10;
                    }
                    Card card = new Card(i, z, a);
                    push(card);
                }
            }
            
        }

        
    }
}
