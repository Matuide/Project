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

            deck.Shuffle();

        }

        public void Deal()
        {
            deck.Deal();

        }

        public Deck getDeck()
        {
            return deck;
        }




    }
}
