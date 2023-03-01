namespace RestFull.DataConnec
{
    public class Connection
    {
        private static IConfiguration configuration;

        public Connection(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public static string urlConn = "Server=localhost;Database=databasetraining; Uid=root;Pwd=admin;";


    }
}
