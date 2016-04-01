namespace Objects
{
    public static class Vars
    {
        public static string ConnectionString;

        public static void Init(string connectionstring)
        {
            ConnectionString = connectionstring;
        }
    }
}
