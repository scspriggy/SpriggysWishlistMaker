namespace Spriggys_DIM_Wishlist_Maker
{
    internal class Combo
    {
        private long id1;
        private long id2;
        private long id3;
        private long id4;
        private float rating;
        private GameType type;

        public Combo(string line, GameType type)
        {
            this.type = type;
            string[] lineArray = line.Split(':');
            rating = float.Parse(lineArray[1]);
            string[] rolls = lineArray[0].Split(',');
            id1 = System.Convert.ToInt64(rolls[0]);
            id2 = System.Convert.ToInt64(rolls[1]);
            id3 = System.Convert.ToInt64(rolls[2]);
            id4 = System.Convert.ToInt64(rolls[3]);
        }

        public float getComboRating(long id1, long id2, long id3, long id4, GameType t)
        {
            if (id1 != 0 && id1 != this.id1)
                return 0;

            if (id2 != 0 && id2 != this.id2)
                return 0;

            if (id3 != 0 && id3 != this.id3)
                return 0;

            if (id4 != 0 && id4 != this.id4)
                return 0;

            return rating;
        }

    }
}