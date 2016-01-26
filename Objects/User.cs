using System;

namespace Objects
{
    public class User
    {
        private string _username;
        private string _password;
        private Guid _guid;
        private UserDetails _userDetails;
        
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }
        public UserDetails UserDetails
        {
            get { return _userDetails; }
            set { _userDetails = value; }
        }

        public User()
        {
        }

        public User(string username, string password, Guid guid, UserDetails userdetails)
        {
            Username = username;
            Password = password;
            Guid = guid;
            UserDetails = userdetails;
        }
    }

    public class UserDetails
    {
        private string _email;
        private string _address;
        private City _city;

        public string Email
        {
            get { return _email;}
            set { _email = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public City City
        {
            get { return _city; }
            set { _city = value; }
        }
        public UserDetails(string email, string address, City city)
        {
            Email = email;
            Address = address;
            City = city;
        }
    }

    public class City
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public City(string name)
        {
            Name = name;
        }
    }
}
