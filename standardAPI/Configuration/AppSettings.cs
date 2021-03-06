namespace standardAPI.Configuration
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public Jwt Jwt { get; set; }
    }

    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
