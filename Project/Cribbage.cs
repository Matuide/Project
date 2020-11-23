using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Cribbage
    {
        private Deck deck;
        private Player[]  players  = new Player[2];

        public Cribbage()
        {
            deck = new Deck();
            players[0] = new HumanPlayer();
            players[1] = new AIPlayer();


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
                    stack1.push(deck.pop());
                }
                for (int n = 0; n < 52 - randomnumber; n++)
                {
                    stack2.push(deck.pop());
                }
                for (int n = 0; n < randomnumber; n++)
                {
                    deck.push(stack1.pop());
                }
                for (int n = 0; n < 52 - randomnumber; n++)
                {
                    deck.push(stack2.pop());
                }
            }

        }
        public void playround()
        {
            Deal();

        }

        public void Deal()
        {
            deck.Deal();
            for (int a = 0; a<6;a++)
            {

            }
        }

        public Deck getDeck()
        {
            return deck;
        }




    }
}
