using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Deck
    {
        // creating an array called stack that stores cards
        private Card[] stack;
        private int top;
        //deck of cards can't be greater than 52, 4 suits of 13 numbers
        private const int DECKSIZE = 52;

        public Deck()

        {
            stack = new Card[DECKSIZE];
            // as the integer called top is the current highest card in the deck it must equal -1 as the array starts at 0
            top = -1;
            this.AddToStack();
        }

        public Card pop()
        {
            //subroutine to remove the card at postion top, return this card and set top to the poistion below
            Card c;
            c = stack[top];
            top--;
            return c;
        }
      
        public void push(Card c)
        {
            //check if the deck is full, if it is not then add the card c given to the subroutine to the top
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
            //adds 52 cards or different suit number up to 4 and other number up to 13
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
                    //pushes each card to the stack in order giving the three parameters needed
                    Card card = new Card(i, z, a);
                    push(card);
                }
            }
            
        }

        
    }
}
