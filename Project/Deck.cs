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
            top = DECKSIZE;
            this.AddToStack();
        }

        public Card pop()
        {
            top--;
            Card c;
            c = stack[top];
            return c;
        }
        public void Deal()
        {

        }
        public void push(Card c)
        {
            stack[top] = c;
            top++;
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

        public void Shuffle()
        {
            Deck stack1 = new Deck();
            Deck stack2 = new Deck();
            Random random = new Random();
            int randomnumber = random.Next(52);
            for (int i = 0; i < 12000; i++)
            {
                for (int n = 0; n < randomnumber; n++)
                {
                    stack1.push(pop());
                }
                for (int n = 0; n < 52 - randomnumber; n++)
                {
                    stack2.push(pop());
                }
                for (int n = 0; n < randomnumber; n++)
                {
                    push(stack1.pop());
                }
                for (int n = 0; n < 52 - randomnumber; n++)
                {
                    push(stack2.pop());
                }
            }

        }
    }
}
