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

        public int PredictionsNo { get; set; }

        public int SuccessfulPredictions { get; set; }
        
        public User()
        {
        }

        public User(string username, string inclansince)
        {
            Username = username;
            InClanSince = inclansince;
        }

        public User(string username, int points)
        {
            Username = username;
            Points = points;
        }

        public User(string username, string password, Guid guid, int credit, int clanid, UserDetails userdetails, int points, int predictionsno, int successfulpredictions)
        {
            Username = username;
            Password = password;
            Guid = guid;
            UserDetails = userdetails;
            Credit = credit;
            ClanId = clanid;
            Points = points;
            PredictionsNo = predictionsno;
            SuccessfulPredictions = successfulpredictions;
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
