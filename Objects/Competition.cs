namespace Objects
{
    public class Competition
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public Competition(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }
}
