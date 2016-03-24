using System;
using System.Collections.Generic;
using System.Security.Permissions;

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
        public string NameOfClan { get; set; }
        public string InClanSince { get; set; }
        public int TotalPredictions { get; set; }
        public int SuccessfulPredictions { get; set; }
        public int LastPredictions { get; set; }
        public int LastSuccessfulPredictions { get; set; }
        public int AvatarId { get; set; }
        public bool isApproved { get; set; }
        public Guid SessionId { get; set; }
        public int Rank { get; set; }
        public int PreviousLeagueRank { get; set; }
        private DateTime _birthday;
        public string Birthday => _birthday.ToString("dd/MM/yyyy");
        public IList<Chatroom> Chatrooms { get; set; }

        
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

        public User(string username, int points, int previousleaguerank)
        {
            Username = username;
            Points = points;
            PreviousLeagueRank = previousleaguerank;
        }

        public User(string username, Guid guid, int credit, int clanid, 
            UserDetails userdetails, int points, int predictionsno, int successfulpredictions,
            int lastpredictions, int lastsuccessfulpredictions, int avatarid, int rank, 
            string nameofclan, Guid sessionid, DateTime birthday)
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
            NameOfClan = nameofclan;
            SessionId = sessionid;
            _birthday = birthday;
            Chatrooms = new List<Chatroom>();
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
