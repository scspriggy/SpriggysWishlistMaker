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
        public string frame;
        public string frameDesc;
        public string ammoType;
        public int season;
        public string element;
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
            this.frame = "";
            this.frameDesc = "";
            this.ammoType = "";
            this.season = 0;
            this.element = "";
            this.id = 0;
            this.perk1Group = "";
            this.perk2Group = "";
            perk1Options = new List<Perk>();
            perk2Options = new List<Perk>();
            perk3Options = new List<Perk>();
            perk4Options = new List<Perk>();
        }

        public string getInfo()
        {
            string s = "";

            if (frame != "")
                s += frame + ": " + frameDesc + Environment.NewLine;

            if (category != "")
                s += "Category: " + category + Environment.NewLine;
            if (ammoType != "")
                s += "Ammo Type: " + ammoType + Environment.NewLine;
            if (element != "")
                s += "Element: " + element + Environment.NewLine;
            if (season != 0)
                s += "Season: " + season + Environment.NewLine;

            return s.TrimEnd(Environment.NewLine.ToCharArray()); ;
        }
    }
}
