﻿using System;
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
            //hand is a simple array of card elements of max length 6
            const int MAXLENGTH = 6;
            hand = new Card[MAXLENGTH];
            counter = 0;
        }
        

        public Card remove()
        {
            //returns the top card of the hand, this is only used when replacing the cards at the end of each round, 
            //otherwise an input parameter position would be needed
            counter = counter - 1;
            Card c = hand[counter];
            hand[counter] = null;
            return c;

        }


        public void RemoveCard(Card c)
        {
            //deletes the card c if it is in the hand
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
            //counts the number of cards remaining in the hand so UI knows if to ask for another one to be thrown away
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
            //adding the extra card to the hand so it can be counted
            addCard(extra);
        }

        private Card getCard()
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
            return mergeSort(handtosort);
        }


        public int CountPoints(Card[] hnd)
        {
            //get the hand in order to make it easier to count
            hnd = SortHand(hnd);
            int count = 0;
            bool running;
            int points = 0;
           
            //first to check for flush
            //by iterating through the hand and counting the number of cards from each suit
            //if there are 4 or more of one suit, points are awarded
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
                    points = points +  4;
                }
                else if (count == 5)
                {
                    points = points + 5;
                }

            }
            // next to check for pairs
            // by counting the number of each card number and awarding points accordingly if there are 2 or more
            for (int b = 1; b < 14; b++)
            {
                count = 0;
                for (int place = 0; place < 5; place++)
                {
                    if (hnd[place].number == b)
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    points = points +(count*(count -1));
                }
                
            }
            //next to check for runs
            //as the hand is in order, this algorithm just checks to see if the next card along is the same or one number above
            int exponent = 1;
            for (int i = 0; i < hnd.Length; i++)
            {
                running = true;
                counter = 1;
                
                for (int j = 1; j < hnd.Length+1; j++)
                {
                    if (i + j <= hnd.Length - 1 && hnd[i].number == hnd[1 + i].number && hnd[i] != null && hnd[i + j] != null && running)
                    {
                        exponent++;
                        running = true;
                    }
                    if (i + j <= hnd.Length - 1 && hnd[i] != null && hnd[i + j] != null && hnd[i].number == hnd[i + j].number - j && running)
                    {
                        counter++;
                       
                    }else
                    {
                        running = false;
                    }
                    


                }
                if(counter > 2)
                {
                    i = 4;
                    
                }
                if (counter > 2)
                {
                    points += counter * Convert.ToInt32(Math.Pow(Convert.ToDouble(2),Convert.ToDouble(exponent-1)));
                }

            }
            
                


            //next to check for 15s
            //using nested for loops to check all possible combination of cards that could add up to 15

            count = 0;
            //checking all possibilites of two cards
            for (int i = 0; i < hnd.Length-1; i++)
            {
                for (int j = 1 + i; j < hnd.Length-1; j++)
                {
                    if (hnd[j] != null && hnd[i] != null && hnd[i].tempnumber + hnd[j].tempnumber == 15)
                    {
                        points = points + 2;
                    }
                }
            }
            //then check all possibilities of 3 cards
            for (int a1 = 0; a1 < hnd.Length-2; a1++)
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
            count = 0;
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
            //simply checks if the player has the jack of the same suit as the extracard
            for (int n = 0; n < 4; n++)
            {
                if (hnd[4] != null && hnd[n] != null && hnd[n].suit == hnd[4].suit)
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
        public static Card[] mergeSort(Card[] array)
        {
            Card[] left;
            Card[] right;
            Card[] result = new Card[array.Length];
            int temp = 0;
            //split the cards up first
            if (array.Length <= 1)
                return array;
            int centre = array.Length / 2;
            left = new Card[centre];

            if (array.Length % 2 == 0)
                right = new Card[centre];
            else
                right = new Card[centre + 1];
            for (int i = 0; i < centre; i++)
                left[i] = array[i];
            for (int i = centre; i < array.Length; i++)
            {
                right[temp] = array[i];
                temp++;
            }
          //use recursion to split and eventually merge the sub-lists of cards on each side of centre
            left = mergeSort(left);
            
            right = mergeSort(right);
           //then merge each pair into a sub-list putting them in order.
            result = merge(left, right);
            return result;
        }

        public static Card[] merge(Card[] left, Card[] right)
        {
            int resultLength = right.Length + left.Length;
            Card[] result = new Card[resultLength];
        
            int indL = 0, indR = 0, indD = 0;
            
            while (indL < left.Length || indR < right.Length)
            {
                if (indL < left.Length && indR < right.Length)
                { 
                    if (left[indL].number <= right[indR].number)
                    {
                        result[indD] = left[indL];
                        indL++;
                        indD++;
                    }
                    else
                    {
                        result[indD] = right[indR];
                        indR++;
                        indD++;
                    }
                }
                else if (indL < left.Length)
                {
                    result[indD] = left[indL];
                    indL++;
                    indD++;
                }
                else if (indR < right.Length)
                {
                    result[indD] = right[indR];
                    indR++;
                    indD++;
                }
            }
            return result;
        }

    }
}
