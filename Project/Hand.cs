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
        private int CountPoints(Card[] hand)
        {

            int count = 0;

            int points = 0;
            addCard(extra);
            //first to check for flush
            for (int b = 1; b < 5; b++)
            {
                count = 0;
                for (int a = 0; a < 5; a++)
                {
                    if (hand[a].suit == b)
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
                    if (hand[d].number == firstnumber)
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
            int tempcount;
            int temp1;
            int temp2;
            int temp3;
            int temp4;
            int runlength = 0;
            bool run;
            count = 0;
            for (int l = 1; l < 11; l++)
            {
                tempcount = 0;
                temp1 = 0;
                temp2 = 0;
                temp3 = 0;
                temp4 = 0;
                int c = l;

                for (int a = 0; a < 5; a++)
                {
                    if (hand[a].number == l)
                    {
                        tempcount = tempcount + 1;
                    }
                }
                if (tempcount > 0)
                {
                    do
                    {
                        run = false;
                        for (int b = 0; b < 5; b++)
                        {
                            if (hand[b].number == c + 1)
                            {
                                temp1++;
                                run = true;
                            }
                            if (run)
                            {
                                runlength++;
                            }
                        }
                        run = false;
                        if (runlength == 2)
                        {
                            for (int b = 0; b < 5; b++)
                            {
                                if (hand[b].number == c + 2)
                                {
                                    temp2++;
                                    run = true;
                                }
                                if (run)
                                {
                                    runlength++;
                                }
                            }
                        }
                        run = false;
                        if (runlength == 3)
                        {
                            for (int b = 0; b < 5; b++)
                            {
                                if (hand[b].number == c + 3)
                                {
                                    temp3++;
                                    run = true;
                                }
                                if (run)
                                {
                                    runlength++;
                                }
                            }
                        }

                        run = false;
                        if (runlength == 4)
                        {
                            for (int b = 0; b < 5; b++)
                            {
                                if (hand[b].number == c + 4)
                                {
                                    temp4++;
                                    run = true;
                                }
                                if (run)
                                {
                                    runlength++;
                                }
                            }
                        }


                    } while (run);
                    if (runlength == 4)
                    {
                        l++;
                    }
                    if (runlength == 3)
                    {
                        points = points + (runlength * tempcount * temp1 * temp2);
                    }
                    if (runlength == 4)
                    {
                        points = points + (runlength * tempcount * temp1 * temp2 * temp3);
                    }
                    if (runlength == 5)
                    {
                        points = points + 5;
                    }
                }


            }

            //next to check for 15s


            count = 0;
            //checking all possibilites of two cards
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1 + i; j < 5; j++)
                {
                    if (hand[i].tempnumber + hand[j].tempnumber == 15)
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
                        if (hand[a1].tempnumber + hand[a2].tempnumber + hand[a3].tempnumber == 15)
                        {
                            points = points = 2;
                        }
                    }
                }
            }
            //then check all possibilities of 4 cards
            for (int g = 0; g < 5; g++)
            {
                if (hand[0].tempnumber + hand[1].tempnumber + hand[2].tempnumber + hand[3].tempnumber + hand[4].tempnumber - hand[g].tempnumber == 15)
                {
                    points = points + 2;
                }
            }
            // finally check if all 5 cards add up to 15

            for (int z = 0; z < 5; z++)
            {
                count = count + hand[z].number;
            }
            if (count == 15)
            {
                points = points + 2;
            }

            //finally to checks for nobs
            for (int n = 0; n < 5; n++)
            {
                if (hand[n].suit == extra.suit)
                {
                    if (hand[n].number == 11)
                    {
                        points++;
                    }

                }
            }
            hand[4] = null;
            counter = 3;
            return points;
        }

    }
}
