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
            
            output += getWishlistItems();
        }

        private void populateWishlistItems()
        {

            while (lineNum < input.Length)
            {
                List<string> weaponRating = new List<string>();

                skipWhitespaces();

                while (lineNum < input.Length && input[lineNum].StartsWith("//"))
                {
                    weaponRating.Add(input[lineNum]);
                    lineNum++;
                }

                long weaponId = getWeaponId(input[lineNum]);
                items.Add(new WishlistItem(weaponRating.ToArray(), weaponId));

                while (lineNum < input.Length && input[lineNum].StartsWith("dimwishlist"))
                {
                    lineNum++;
                }

                skipWhitespaces();

            }

        }

        private void skipWhitespaces()
        {
            while ((lineNum < input.Length && String.IsNullOrWhiteSpace(input[lineNum])) || (lineNum < input.Length && input[lineNum].StartsWith("//////")) || (lineNum < input.Length && input[lineNum].StartsWith("//=======================================================================")))
            {
                lineNum++;
            }
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

        private string getWishlistItems()
        {
            string output = "";
            foreach(WishlistItem item in items)
            {
                //TODO: Check for Letter separators, maybe sort?
                output += item.toString() + Environment.NewLine + Environment.NewLine;
            }
            return output;
        }

       

        

        internal string getOutput()
        {
            return output;
        }
    }
}
