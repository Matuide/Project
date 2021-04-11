using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Hand
    {
        private Card[] hand;
        private int counter;
        private Card extra;
        public Hand()
        {
            hand = new Card[6];
            counter = 0;
        }
        

        public Card remove()
        {
            counter = counter - 1;
            Card c = hand[counter];
            hand[counter] = null;
            return c;

        }


        public void RemoveCard(Card c)
        {
            for(int i = 0; i < hand.Length; i++)
            {
                if(hand[i] != null && c.getName() == hand[i].getName())
                {
                    hand[i] = null;
                }
            }
        }
        
        public void addCard(Card c)
        {
            hand[counter] = c;
            
            if (counter <5)
            {
                counter++;
            }
                
            
        
            
        }

        public int Count()
        {
            int counter = 0;
            foreach (Card crd in hand)
            {
                if(crd != null)
                {
                    counter++;
                }
            }
            return counter;
        }
        public Card[] gethand()
        {
            Card[] returnhand = hand;
     
            return returnhand;
        }
        public Card getextra()
        {
            return extra;
        }
        public void addextra()
        {
            
            addCard(extra);
        }

        private Card getCard(int index)
        {
            if (counter>0)
            {
                return hand[counter-1];
            }
            else
            {
                return null;
            }
            

        }

        private void setCard(Card c, int index)
        {
            hand[index] = c;

        }
        private Card[] SortHand(Card [] handtosort)
        {

            return handtosort;
        }
        public int CountPoints(Card[] hnd)
        {
            hnd = SortHand(hnd);
            int count = 0;

            int points = 0;
            //extra = hnd[0];
            //first to check for flush
            for (int b = 1; b < 5; b++)
            {
                count = 0;
                for (int a = 0; a < 5; a++)
                {
                    if (hnd[a] != null && hnd[a].suit == b)
                    {
                        count++;
                    }
                }
                if (count == 4)
                {
                    points = points + 4;
                }
                else if (count == 5)
                {
                    points = points + 5;
                }

            }
            // next to check for pairs

            int firstnumber;
            for (int c = 0; c < 13; c++)
            {
                count = 0;
                firstnumber = c;
                for (int d = 0; d < 5; d++)
                {
                    if (hnd[d] != null && hnd[d].number == firstnumber)
                    {
                        count++;
                    }
                }
                if (count == 2)
                {
                    points = points + 2;
                }
                if (count == 3)
                {
                    points = points + 6;
                }
                if (count == 4)
                {
                    points = points + 12;
                }
            }
            //next to check for runs
            

            //next to check for 15s


            count = 0;
            //checking all possibilites of two cards
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1 + i; j < 5; j++)
                {
                    if (hnd[j] != null && hnd[i] != null && hnd[i].tempnumber + hnd[j].tempnumber == 15)
                    {
                        points = points + 2;
                    }
                }
            }
            //then check all possibilities of 3 cards
            for (int a1 = 0; a1 < 3; a1++)
            {
                for (int a2 = 1 + a1; a2 < 4; a2++)
                {
                    for (int a3 = 1 + a2; a3 < 5; a3++)
                    {
                        if (hnd[a2] != null && hnd[a3] != null && hnd[a1] != null && hnd[a1].tempnumber + hnd[a2].tempnumber + hnd[a3].tempnumber == 15)
                        {
                            points = points = 2;
                        }
                    }
                }
            }
            //then check all possibilities of 4 cards
            for (int g = 0; g < 5; g++)
            {
                if (hnd[g] != null && hnd[0] != null && hnd[1] != null && hnd[2] != null && hnd[3] != null && hnd[4] != null && hnd[0].tempnumber + hnd[1].tempnumber + hnd[2].tempnumber + hnd[3].tempnumber + hnd[4].tempnumber - hnd[g].tempnumber == 15)
                {
                    points = points + 2;
                }
            }
            // finally check if all 5 cards add up to 15

            for (int z = 0; z < 5; z++)
            {
                if(hnd[z] != null)
                    count = count + hnd[z].number;
            }
            if (count == 15)
            {
                points = points + 2;
            }

            //finally to checks for nobs
            for (int n = 0; n < 5; n++)
            {
                if (extra != null && hnd[n] != null && hnd[n].suit == extra.suit)
                {
                    if (hnd[n].number == 11)
                    {
                        points++;
                    }

                }
            }
            hnd[4] = null;
            counter = 3;
            return points;
        }

    }
}
