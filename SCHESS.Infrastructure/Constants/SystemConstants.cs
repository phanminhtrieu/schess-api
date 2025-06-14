namespace SCHESS.Infrastructure.Constants
{
    public class SystemConstants
    {
        public class AppConstants 
        {
            public const string TOKENS_KEY = "Tokens:key";
            public const string TOKENS_ISSUER = "Tokens:Issuer";
        }

        public class ConnectionStringConstants
        {
            public const string MAIN_CONNECTION_STRING = "SCHESS";
        }

        public class DatabaseConfigConstants
        {
            public const string DATABASE_MAX_POOL = "Database:Pool:Max";
        }

        public class ErrorMessage
        {
            public const string WRONG_EMAIL = "Wrong email";
            public const string WRONG_PASSWORD = "Wrong password";
            public const string LOGIN_SUCCESSFULLY = "Login successfully";
            public const string INTERNAL_SERVER_ERROR = "Internal Server Error";
        }
    }
}
