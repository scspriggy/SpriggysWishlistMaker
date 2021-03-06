﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spriggys_DIM_Wishlist_Maker
{
    enum WeaponTier { U, S, A, B, C, F }
    enum GameType { Empty, PvE, PvP, Both }
    enum ItemType { None, Separator, Simple, Normal}

    class WishlistItem
    {
        private long weaponId;
        private string weaponName;
        public string weaponNameSort;
        private GameType gameType1;
        private GameType gameType2;
        private string perk1Name;
        private string perk2Name;
        private List<RollRating> perk1Rolls = new List<RollRating>();
        private List<RollRating> perk2Rolls = new List<RollRating>();
        private List<RollRating> perk3Rolls = new List<RollRating>();
        private List<RollRating> perk4Rolls = new List<RollRating>();
        private string pveMasterwork;
        private string pvpMasterwork;
        private WeaponTier weaponTier;
        private string weaponTierString;
        private List<Combo> combos = new List<Combo>();
        private string output = "";

        public WishlistItem(string[] wishlistText, long weaponId)
        {
            this.weaponId = weaponId;
            parseWishlistText(wishlistText);
            populateWishlistOutput();
        }

      

        public WishlistItem(string[] wishlistText, ItemType type)
        {
            if(type == ItemType.Separator)
            {
                output = wishlistText[0] + Environment.NewLine;
                string temp = wishlistText[1].Replace("//","");
                temp = temp.Replace("=", "");
                weaponNameSort = temp;
                output += wishlistText[1] + Environment.NewLine;
                output += wishlistText[2] + Environment.NewLine;
            }

            if (type == ItemType.Simple)
            {
                weaponName = getWeaponName(wishlistText[0]).Trim();
                weaponNameSort = Regex.Replace(weaponName, "^the ", "", RegexOptions.IgnoreCase);
                weaponNameSort = Regex.Replace(weaponNameSort, "^a ", "", RegexOptions.IgnoreCase);

                for(int i=0; i < wishlistText.Length; i++)
                {
                    output += wishlistText[i] + Environment.NewLine;
                }
            }
        }

        private void parseWishlistText(string[] text)
        {
            int lineNum = 0;
            weaponTier = getWeaponTier(text[lineNum]);
            weaponName = getWeaponName(text[lineNum]).Trim();
            weaponNameSort = Regex.Replace(weaponName, "^the ", "", RegexOptions.IgnoreCase);
            weaponNameSort = Regex.Replace(weaponNameSort, "^a ", "", RegexOptions.IgnoreCase);
            lineNum++;

            if (text[lineNum].Contains("============"))
            {
                gameType1 = getGameType(text[lineNum]);
                lineNum++;
            }

            lineNum = checkRolls(text, lineNum, gameType1);
            lineNum = checkCombo(text, lineNum, gameType1);
            lineNum = checkMasterwork(text, lineNum, gameType1);

            //Check for 2nd listing
            //lineNum++;
            if (lineNum < text.Length && text[lineNum].Contains("============") && !text[lineNum].ToLower().Contains("wishlist"))
            {
                gameType2 = getGameType(text[lineNum]);
                lineNum++;
                lineNum = checkRolls(text, lineNum, gameType2);
                lineNum = checkCombo(text, lineNum, gameType2);
                lineNum = checkMasterwork(text, lineNum, gameType2);
            }
        }

        private WeaponTier getWeaponTier(string line)
        {
            WeaponTier t = WeaponTier.U;

            string[] titleString = line.Split('-');

            if (titleString.Length > 1 && line.Contains(" - "))
            {
                weaponTierString = titleString[titleString.Length - 1];
                char tier = char.Parse(titleString[titleString.Length - 1].Substring(1, 1));

                if (tier == 'S' || tier == 's')
                    t = WeaponTier.S;
                else if (tier == 'A' || tier == 'a')
                    t = WeaponTier.A;
                else if (tier == 'B' || tier == 'b')
                    t = WeaponTier.B;
                else if (tier == 'C' || tier == 'c')
                    t = WeaponTier.C;
                else if (tier == 'F' || tier == 'f')
                    t = WeaponTier.F;
                else
                    t = WeaponTier.U;
            }
            else
            {
                t = WeaponTier.U;
            }

            return t;
        }

        private string getWeaponName(string line)
        {
            string name = "";

            string[] titleString = line.Split('-');

            if (titleString.Length > 1 && line.Contains(" - "))
            {
                for (int i = 0; i < titleString.Length - 1; i++)
                {
                    string lineUncommented = titleString[i].Replace("//", "");
                    name += lineUncommented;

                    if (i + 1 < titleString.Length - 1)
                        name += "-";
                }
            }
            else
            {
                name = line.Replace("//", "");
            }

            return name;
        }

        private GameType getGameType(string line)
        {
            if (line.ToLower().Contains("pve") && line.ToLower().Contains("pvp"))
                return GameType.Both;

            if (line.ToLower().Contains("pve"))
                return GameType.PvE;

            if (line.ToLower().Contains("pvp"))
                return GameType.PvP;

            return GameType.Both;
        }

        private int checkRolls(string[] text, int lineNum, GameType gameType)
        {
            perk1Name = text[lineNum].Replace("//", "");
            lineNum++;
            while (lineNum < text.Length && System.Char.IsDigit(text[lineNum].Replace("//", "")[0]))
            {
                bool isSame = false;
                foreach(RollRating r in perk1Rolls)
                {
                    if (r.isSame(text[lineNum]))
                        isSame = true;
                }

                if( !isSame)
                    perk1Rolls.Add(new RollRating(text[lineNum], gameType));
                lineNum++;
            }

            perk2Name = text[lineNum].Replace("//", "");
            lineNum++;
            while (lineNum < text.Length && System.Char.IsDigit(text[lineNum].Replace("//", "")[0]))
            {
                bool isSame = false;
                foreach (RollRating r in perk2Rolls)
                {
                    if (r.isSame(text[lineNum]))
                        isSame = true;
                }

                if (!isSame)
                    perk2Rolls.Add(new RollRating(text[lineNum], gameType));
                lineNum++;
            }

            lineNum++;  //Perk 1
            while (lineNum < text.Length && System.Char.IsDigit(text[lineNum].Replace("//", "")[0]))
            {
                bool isSame = false;
                foreach (RollRating r in perk3Rolls)
                {
                    if (r.isSame(text[lineNum]))
                        isSame = true;
                }

                if (!isSame)
                    perk3Rolls.Add(new RollRating(text[lineNum], gameType));
                lineNum++;
            }

            lineNum++;  //Perk 2
            while (lineNum < text.Length && System.Char.IsDigit(text[lineNum].Replace("//", "")[0]))
            {
                bool isSame = false;
                foreach (RollRating r in perk4Rolls)
                {
                    if (r.isSame(text[lineNum]))
                        isSame = true;
                }

                if (!isSame)
                    perk4Rolls.Add(new RollRating(text[lineNum], gameType));
                lineNum++;
            }

            return lineNum;
        }

        private int checkCombo(string[] text, int lineNum, GameType gameType)
        {
            if (lineNum < text.Length && text[lineNum].ToLower().Contains("combo"))
            {
                lineNum++;
                while (lineNum < text.Length && System.Char.IsDigit(text[lineNum].Replace("//", "")[0]))
                {
                    combos.Add(new Combo(text[lineNum].Replace("//", ""), gameType));
                    lineNum++;
                }
            }
            return lineNum;
        }

        private int checkMasterwork(string[] text, int lineNum, GameType gameType)
        {
            if (lineNum < text.Length && text[lineNum].Replace("//", "").ToLower().StartsWith("mw"))
            {
                string mw = text[lineNum].Replace("//", "").Remove(0, 3);

                if (gameType.Equals(GameType.PvE))
                {
                    pveMasterwork = mw;
                }
                else if (gameType.Equals(GameType.PvP))
                {
                    pvpMasterwork = mw;
                }
                else
                {
                    pveMasterwork = mw;
                    pvpMasterwork = mw;
                }
                lineNum++;
            }
            return lineNum;
        }

        public string toString()
        {
            return output;
        }

        private string getRollInfo(GameType t)
        {
            string output = "";

            //Game Type
            if (t == GameType.PvP)
            {
                output += "//=================PvP=================" + Environment.NewLine;
                perk1Rolls = perk1Rolls.OrderByDescending(o => o.pvpRating).ToList();
                perk2Rolls = perk2Rolls.OrderByDescending(o => o.pvpRating).ToList();
                perk3Rolls = perk3Rolls.OrderByDescending(o => o.pvpRating).ToList();
                perk4Rolls = perk4Rolls.OrderByDescending(o => o.pvpRating).ToList();
            }
            else if (t == GameType.PvE)
            {
                output += "//=================PvE=================" + Environment.NewLine;
                perk1Rolls = perk1Rolls.OrderByDescending(o => o.pveRating).ToList();
                perk2Rolls = perk2Rolls.OrderByDescending(o => o.pveRating).ToList();
                perk3Rolls = perk3Rolls.OrderByDescending(o => o.pveRating).ToList();
                perk4Rolls = perk4Rolls.OrderByDescending(o => o.pveRating).ToList();
            }
            else
            {
                output += "//=================PvE/PvP=================" + Environment.NewLine;
                perk1Rolls = perk1Rolls.OrderByDescending(o => o.pveRating).ToList();
                perk2Rolls = perk2Rolls.OrderByDescending(o => o.pveRating).ToList();
                perk3Rolls = perk3Rolls.OrderByDescending(o => o.pveRating).ToList();
                perk4Rolls = perk4Rolls.OrderByDescending(o => o.pveRating).ToList();
            }


            output += "//" + perk1Name + Environment.NewLine;
            foreach (RollRating r in perk1Rolls)
            {
                output += r.toString(t);
            }

            output += "//" + perk2Name + Environment.NewLine;
            foreach (RollRating r in perk2Rolls)
            {
                output += r.toString(t);
            }

            output += "//Perk 1" + Environment.NewLine;
            foreach (RollRating r in perk3Rolls)
            {
                output += r.toString(t);
            }

            output += "//Perk 2" + Environment.NewLine;
            foreach (RollRating r in perk4Rolls)
            {
                output += r.toString(t);
            }

            //Combo Logic
            string comboString = "";
            foreach (Combo c in combos)
            {
                if (t == c.type)
                    comboString += c.toString() + Environment.NewLine;
            }

            if(comboString != "")
            {
                output += "//Combos" + Environment.NewLine;
                output += comboString;
            }

            //Masterwork Logic
            if (t == GameType.PvP && pvpMasterwork != null)
                output += "//MW " + pvpMasterwork + Environment.NewLine;
            else if(pveMasterwork != null)
                output += "//MW " + pveMasterwork + Environment.NewLine;


            return output;
        }

        private string getWishlistItems()
        {
            string output = "//=================Wishlist=================" + Environment.NewLine;
            List<DimWishlistLine> rolls = new List<DimWishlistLine>();

            perk1Rolls.Add(null);
            perk2Rolls.Add(null);
            perk3Rolls.Add(null);
            perk4Rolls.Add(null);

            foreach(RollRating p1 in perk1Rolls)
            {
                foreach (RollRating p2 in perk2Rolls)
                {
                    foreach (RollRating p3 in perk3Rolls)
                    {
                        foreach (RollRating p4 in perk4Rolls)
                        {
                            rolls.Add(new DimWishlistLine(weaponId, weaponTier, gameType1, gameType2, p1, p2, p3, p4, pveMasterwork, pvpMasterwork, combos));
                        }
                    }
                }
            }

            List<DimWishlistLine> sorted = rolls.OrderByDescending(o => o.maxRating).ToList();

            foreach(DimWishlistLine dim in sorted)
            {
                if (dim.maxRating >= Properties.Settings.Default.MinRating)
                    output += dim.line + Environment.NewLine;
            }
            

            return output;
        }

        private void populateWishlistOutput()
        {
            output = "";

            if (Properties.Settings.Default.NameRating)
                output += "//" + weaponName + " - " + weaponTier + Environment.NewLine;
            else
                output += "//" + weaponName + Environment.NewLine;

            if (Properties.Settings.Default.CommentedRollInfo)
            {
                output += getRollInfo(gameType1);

                if(gameType2 != GameType.Empty)
                    output += getRollInfo(gameType2);
            }

            output += getWishlistItems();
        }

    }
}
