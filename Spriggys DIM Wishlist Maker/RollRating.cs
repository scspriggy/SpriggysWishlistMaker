using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spriggys_DIM_Wishlist_Maker
{
    class RollRating
    {
        public long id;
        private string name;
        public float pveRating;
        public float pvpRating;

        public RollRating(string line, GameType type)
        {
            line = line.Replace("//", "");
            string[] lineFields = line.Split(':');
            
            for(int i=0; i < lineFields.Length; i++)
            {
                if(i == 0)
                {
                    float value = float.Parse(lineFields[i]);
                    if (type.Equals(GameType.PvE))
                        pveRating = value;
                    else if (type.Equals(GameType.PvP))
                        pvpRating = value;
                    else
                    {
                        pveRating = value;
                        pvpRating = value;
                    }
                }
                else if(i == 1)
                {
                    id = Convert.ToInt64(lineFields[i]);
                }
                else if(i == 2)
                {
                    name = lineFields[i];
                }
            }
        }

        public bool isSame(string line)
        {
            line = line.Replace("//", "");
            string[] lineFields = line.Split(':');
            float tempRating = 0;

            for (int i = 0; i < lineFields.Length; i++)
            {
                if (i == 0)
                {
                    tempRating = float.Parse(lineFields[i]);
                }
                else if (i == 1)
                {
                    if( Convert.ToInt64(lineFields[i]) == id)
                    {
                        pvpRating = tempRating;
                        return true;
                    }  
                }
            }
            return false;
        }

        public string toString(GameType type)
        {
            //Don't return lines for empty values
            if (type == GameType.PvP && pvpRating == 0)
                return "";
            if ((type == GameType.PvE || type == GameType.Both) && pveRating == 0)
                return "";

            string rating = pveRating.ToString("0.0");

            if (type == GameType.PvP)
                rating = pvpRating.ToString("0.0");

            return "//" + rating + ":" + id.ToString() + ":" + name + Environment.NewLine; ;
        }
    }
}
