using System;

namespace Objects
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid Guid { get; set; }
        public UserDetails UserDetails { get; set; }
        public int Credit { get; set; }
        public int Points { get; set; }
        public int ClanId { get; set; }
        public string InClanSince { get; set; }
        public int TotalPredictions { get; set; }
        public int SuccessfulPredictions { get; set; }
        public int LastPredictions { get; set; }
        public int LastSuccessfulPredictions { get; set; }
        public int AvatarId { get; set; }
        public bool isApproved { get; set; }
        public int Rank { get; set; }
        
        public User()
        {
        }

        public User(string username, string inclansince, bool isapproved, int points)
        {
            Username = username;
            InClanSince = inclansince;
            isApproved = isapproved;
            Points = points;
        }

        public User(string username, int points)
        {
            Username = username;
            Points = points;
        }

        public User(string username, Guid guid, int credit, int clanid, 
            UserDetails userdetails, int points, int predictionsno, int successfulpredictions,
            int lastpredictions, int lastsuccessfulpredictions, int avatarid, int rank)
        {
            Username = username;
            Guid = guid;
            UserDetails = userdetails;
            Credit = credit;
            ClanId = clanid;
            Points = points;
            TotalPredictions = predictionsno;
            SuccessfulPredictions = successfulpredictions;
            LastPredictions = lastpredictions;
            LastSuccessfulPredictions = lastsuccessfulpredictions;
            AvatarId = avatarid;
            Rank = rank;
        }
    }

    public class UserDetails
    {
        public string Email { get; set; }

        public string Address { get; set; }

        public City City { get; set; }

        public UserDetails(string email, string address, City city)
        {
            Email = email;
            Address = address;
            City = city;
        }
    }

    public class City
    {
        public string Name { get; set; }

        public City(string name)
        {
            Name = name;
        }
    }
}
