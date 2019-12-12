using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spriggys_DIM_Wishlist_Maker
{
    class WishlistItem
    {
        enum WeaponTier { S, A, B, C, F}
        enum GameType { PvE, PvP, Both}
        enum Perk1 { Barrel, Blade}
        enum Perk2 { Guard, Magazine}
        enum Masterwork { Range, Reload }

        private long weaponId;
        private string weaponName;
        private GameType gameType1;
        private GameType gameType2;
        private Perk1 perk1Name;
        private Perk2 perk2Name;
        private RollRating[] perk1Rolls;
        private RollRating[] perk2Rolls;
        private RollRating[] perk3Rolls;
        private RollRating[] perk4Rolls;
        private Masterwork pveMasterwork;
        private Masterwork pvpMasterwork;

        //TODO check out the Wishlist generator from the old app, re-use or improve!
    }
}
