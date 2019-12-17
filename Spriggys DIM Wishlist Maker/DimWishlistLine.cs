using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spriggys_DIM_Wishlist_Maker
{
    class DimWishlistLine
    {
        public string line;
        public float maxRating;

        public DimWishlistLine(long weaponId, WeaponTier weaponTier, GameType gameType1, GameType gameType2, RollRating p1, RollRating p2, RollRating p3, RollRating p4, string pveMasterwork, string pvpMasterwork, List<Combo> combos)
        {
            line = "dimwishlist:item=" + weaponId.ToString() + "&perks=";

            if (p1 != null)
                line += p1.id + ",";

            if (p2 != null)
                line += p2.id + ",";

            if (p3 != null)
                line += p3.id + ",";

            if (p4 != null)
                line += p4.id + ",";

            line = line.Substring(0, line.Length - 1);

            //Wishlist Notes
            line += "#notes:";

            float pve = getRating(p1, p2, p3, p4, combos, gameType1);
            float pvp = getRating(p1, p2, p3, p4, combos, gameType2);
            maxRating = Math.Max(pve, pvp);

            if (maxRating < Properties.Settings.Default.MinRating)
                line = "";
            else
            {
                if (Properties.Settings.Default.NoteRatings)
                {
                    if (pve >= Properties.Settings.Default.MinRating && pvp >= Properties.Settings.Default.MinRating)
                    {
                        line += weaponTier + "pve" + pve + ", " + weaponTier + "pvp" + pvp;
                    }
                    else if(pve >= Properties.Settings.Default.MinRating && gameType1 == GameType.Both)
                    {
                        line += weaponTier + "pve" + pve + ", " + weaponTier + "pvp" + pve;
                    }
                    else if (pve >= Properties.Settings.Default.MinRating)
                    {
                        line += weaponTier + "pve" + pve;
                    }
                    else if (pvp >= Properties.Settings.Default.MinRating)
                    {
                        line += weaponTier + "pvp" + pvp;
                    }
                }

                if( Properties.Settings.Default.NoteMasterwork)
                {
                    if (pve >= Properties.Settings.Default.MinRating && pvp >= Properties.Settings.Default.MinRating )
                    {
                        if (pveMasterwork != null && pvpMasterwork != null)
                            line += " MWpve " + pveMasterwork + ", MWpvp " + pvpMasterwork;
                        else if (pveMasterwork != null)
                            line += " MWpve " + pveMasterwork;
                        else if (pvpMasterwork != null)
                            line += " MWpvp " + pvpMasterwork;
                    }
                    else if (pve >= Properties.Settings.Default.MinRating && gameType1 == GameType.Both)
                    {
                        if (pveMasterwork != null)
                            line += " MW " + pveMasterwork;
                    }
                    else if (pve >= Properties.Settings.Default.MinRating)
                    {
                        if (pveMasterwork != null)
                            line += " MW " + pveMasterwork;
                    }
                    else if (pvp >= Properties.Settings.Default.MinRating)
                    {
                        if (pvpMasterwork != null)
                            line += " MW " + pvpMasterwork;
                    }
                }

            }
        }

        private float getRating(RollRating p1, RollRating p2, RollRating p3, RollRating p4, List<Combo> combos, GameType type)
        {
            float p1Rating = 0;
            float p2Rating = 0;
            float p3Rating = 0;
            float p4Rating = 0;

            if (p1 != null && type == GameType.PvP)
                p1Rating = p1.pvpRating;
            else if (p1 != null)
                p1Rating = p1.pveRating;

            if (p2 != null && type == GameType.PvP)
                p2Rating = p2.pvpRating;
            else if (p2 != null)
                p2Rating = p2.pveRating;

            if (p3 != null && type == GameType.PvP)
                p3Rating = p3.pvpRating;
            else if (p3 != null)
                p3Rating = p3.pveRating;

            if (p4 != null && type == GameType.PvP)
                p4Rating = p4.pvpRating;
            else if (p4 != null)
                p4Rating = p4.pveRating;

            //Combo
            long p1Id = 0;
            long p2Id = 0;
            long p3Id = 0;
            long p4Id = 0;
            float comboScore = 0;

            if (p1 != null)
                p1Id = p1.id;
            if (p2 != null)
                p2Id = p2.id;
            if (p3 != null)
                p3Id = p3.id;
            if (p4 != null)
                p4Id = p4.id;

            foreach(Combo c in combos)
            {
                comboScore += c.getComboRating(p1Id, p2Id, p3Id, p4Id, type);
            }

            return p1Rating + p2Rating + p3Rating + p4Rating + comboScore;
        }

        
    }
}
