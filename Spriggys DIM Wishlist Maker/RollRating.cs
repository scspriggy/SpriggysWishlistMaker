using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spriggys_DIM_Wishlist_Maker
{
    class RollRating
    {
        private long id;
        private string name;
        private float pveRating;
        private float pvpRating;

        public RollRating(long myID, string myName)
        {
            id = myID;
            name = myName;
        }
    }
}
