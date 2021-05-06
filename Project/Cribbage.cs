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
        private Card extracard;
        private Player[] players = new Player[2];
        private Crib crib;
        private Pile pile;

        public Cribbage()
        {
            //where the deck of cards is made at the beginning of the game 
            deck = new Deck();
            //an array of players stores the two players for easy access
            players[0] = new HumanPlayer();
            players[1] = new AIPlayer();

            crib = new Crib();

            pile = new Pile();

        }

        public Deck getDeck()
        {
            return deck;
        }

        public Crib GetCrib()
        {
            return crib;
        }

        public Pile GetPile()
        {
            return pile;
        }

        public Player getPlayer(int number)
        {
            return players[number];
        }







        public void Shuffle()
        {
            //generate a completely random number every time
            Random rand = new Random((int)DateTime.Now.Ticks);
            int r = 0;
            int g = 0;

            for (int i = 0; i < 1000; i++)
            {
                //swapping two random numbers 1000 times 

                r = rand.Next(0, 51);
                g = rand.Next(0, 52);
                // r Random for remaining positions. 


                //swapping the elements 
                Card temp = deck.GetCard1(r);
                deck.returncard(r, deck.GetCard1(g));
                deck.returncard(g, temp);


            }


        }

        public void startround()
        {
            Shuffle();
            Deal();


        }


        public void playerClickCard(Card cr)
        {
            //moves the card the player clicked on from their hand to the crib
            players[0].getHand().RemoveCard(cr);
            crib.addtocrib(cr);
        }
        public void playround()
        {

            returntodeck();

        }
        public void returntodeck()
        {
            //after each round all cards must be returned to the deck to start again, this subroutine pushes all cards back to the deck
            for (int h = 0; h < 6; h++)
            {
                deck.push(players[0].removecard());
                deck.push(players[1].removecard());
            }


        }


        public void Deal()
        {

            for (int a = 0; a < 6; a++)
            {
                //each player in the player array, ie both players just get the top card for the deck which is popped.
                players[0].addCard(deck.pop());
                players[1].addCard(deck.pop());
            }
            extracard = deck.pop();
        }
        public void ThrowOne()
        {
            //this subroutine removes a card from the AI hand and moves it to the crib
            //it doesn't take an input as no card is being clicked on to remove. this is automatic after the player throws a card away
            Card returncard = null;
            int counter = 0;
            Card[] temphand = players[1].getHand().gethand();
            for (int b = 0; b < 6; b++)
            {

                if (temphand[b] != null)
                {
                    //just throwing cards that are not a multiple of 5 as these are less likely to be valuable
                    //this is not throwing the best possible card only one that is likely to get the AI less points
                    if (temphand[b].tempnumber % 5 != 0)
                    {
                        if (counter < 1)
                        {
                            returncard = temphand[b];
                            counter++;
                            players[1].getHand().RemoveCard(returncard);
                            crib.addtocrib(returncard);
                        }

                    }
                }


            }




        }








    }
}
