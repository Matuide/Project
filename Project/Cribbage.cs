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
        private Player[]  players  = new Player[2];
        private Crib c;

        public Cribbage()
        {
            deck = new Deck();
            players[0] = new HumanPlayer();
            players[1] = new AIPlayer();

            c = new Crib();

        }

        public Deck getDeck()
        {
            return deck;
        } 

        public Player getPlayer(int number)
        {
            return players[number];
        }



      

        

        public void Shuffle()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            int r=0;
            int g=0;

            for (int i = 0; i < 1000; i++)
            {

                
                    r = rand.Next(0, 51);
                    g = rand.Next(0, 52);
                // Random for remaining positions. 
                

                //swapping the elements 
                Card temp = deck.GetCard1(r);
                deck.returncard(r,deck.GetCard1(g));
                deck.returncard(g, temp);
                

            } 


        }

        public void startround()
        {
            Shuffle();
            Deal();
            //players[0].SortHand();
            //players[1].SortHand();

        }


        public void playerClickCard()
        {
            // Manages throwing cards
            Console.WriteLine("Click ");
        }
        public void playround()
        {
            
            returntodeck();
            
        }
        public void returntodeck()
        {
            for (int h = 0; h<6;h++)
            {
                deck.push(players[0].removecard());
                deck.push(players[1].removecard());
            }
            
         
        }
        

        public void Deal()
        {
            
            for (int a = 0; a<6;a++)
            {
                players[0].addCard(deck.pop());
                players[1].addCard(deck.pop());
            }
            extracard = deck.pop();
        }
        

        

       




    }
}
