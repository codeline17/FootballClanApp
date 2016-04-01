namespace Objects
{
    public class Trophy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int No { get; set; }

        public Trophy(int no, string name, string color)
        {
            No = no;
            Name = name;
            Color = color;
        }
    }
}
