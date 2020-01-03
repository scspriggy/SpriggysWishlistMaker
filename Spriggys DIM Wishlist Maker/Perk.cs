using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spriggys_DIM_Wishlist_Maker
{
    class Perk
    {
        public string name;
        public List<string> perkGroup;
        public long id;
        public string desc;

        public Perk()
        {
            this.name = "";
            this.perkGroup = new List<string>();
            this.id = 0;
            this.desc = "";
        }
    }
}
