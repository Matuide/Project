using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
     abstract class Player
    {
        private Hand hand;
        public Player()
        {
            hand = new Hand();
            
        }
        abstract public int move();
        

        
    }
}
