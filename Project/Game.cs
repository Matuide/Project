using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    
    class Game
    {
        private Deck deck;
        private Player[] players;
        private Pile centrepile;
        public Game()
        {
            deck = new Deck();
            players = new Player[2];
            players[0] = new AIPlayer();
            players[1] = new HumanPlayer();
            centrepile = new Pile();
        }

    }
    
}
