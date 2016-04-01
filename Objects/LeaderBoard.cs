using System.Collections.Generic;

namespace Objects
{
    public class LeaderBoard
    {
        public List<User> Favorites { get; set; }
        public List<User> Users { get; set; }
        public List<Clan> Clans { get; set; }
        public List<Trophy> Trophies { get; set; }

        public LeaderBoard()
        {
            
        }
    }
}
