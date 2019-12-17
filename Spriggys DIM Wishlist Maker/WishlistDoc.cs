using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spriggys_DIM_Wishlist_Maker
{
    class WishlistDoc
    {
        private string[] input;
        private string output;
        private List<WishlistItem> items = new List<WishlistItem>();
        private int lineNum = 0;

        public WishlistDoc(string[] input)
        {
            this.input = input;
            populateWishlistItems();
            List<string> list = new List<string>();
            output = "";
            
            output += getIntro();
            output += getWishlistItems();
        }

        private void populateWishlistItems()
        {
            List<string> weaponRating = new List<string>();

            //clear out whitespace
            while( lineNum < input.Length && String.IsNullOrWhiteSpace(input[lineNum]))
            {
                lineNum++;
            }

            while (lineNum < input.Length && input[lineNum].StartsWith("//"))
            {
                weaponRating.Add(input[lineNum]);
                lineNum++;
            }

            long weaponId = getWeaponId(input[lineNum]);
            items.Add(new WishlistItem(weaponRating.ToArray(), weaponId));
        }

        private long getWeaponId(string line)
        {
            long weaponId;
            if(System.Char.IsDigit(line[0]))
            {
                weaponId = Convert.ToInt64(line);
            }
            else
            {
                line = line.Replace("dimwishlist:item=", "");
                line = line.Replace("dimwishlist:", "");
                line = line.Replace("item=", "");
                string[] lineArray = line.Split('&');
                weaponId = Convert.ToInt64(lineArray[0]);
            }

            return weaponId;
        }

        private string getIntro()
        {
            //TODO: Intro
            return "//Intro stuffs" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
        }

        private string getWishlistItems()
        {
            string output = "";
            foreach(WishlistItem item in items)
            {
                output += item.toString() + Environment.NewLine; ;
            }
            return output;
        }

       

        

        internal string getOutput()
        {
            return output;
        }
    }
}
