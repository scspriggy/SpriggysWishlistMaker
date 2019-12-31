using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spriggys_DIM_Wishlist_Maker
{
    class Weapon
    {
        public string name;
        public string category;
        public long id;
        public string perk1Group;
        public string perk2Group;
        public List<Perk> perk1Options;
        public List<Perk> perk2Options;
        public List<Perk> perk3Options;
        public List<Perk> perk4Options;

        public Weapon()
        {
            this.name = "";
            this.category = "";
            this.id = 0;
            this.perk1Group = "";
            this.perk2Group = "";
            perk1Options = new List<Perk>();
            perk2Options = new List<Perk>();
            perk3Options = new List<Perk>();
            perk4Options = new List<Perk>();
        }
    }
}
