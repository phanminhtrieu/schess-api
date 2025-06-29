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

        public class EmailConstants
        {
            public const string MAIL_SETTINGS_SERVER = "MailSettings:Server";
            public const string MAIL_SETTINGS_PORT = "MailSettings:Port";
            public const string MAIL_SETTINGS_ENABLED_SSL = "MailSettings:EnableSsl";
            public const string MAIL_SETTINGS_USERNAME = "MailSettings:UserName";
            public const string MAIL_SETTINGS_PASSWORD = "MailSettings:Password";
            public const string MAIL_SETTINGS_FROM_EMAIL = "MailSettings:FromEmail";
            public const string MAIL_SETTINGS_FROM_NAME = "MailSettings:FromName";
        }

        public class PageLinks
        {
            public const string CONFIRMATION_EMAIL_SUCCESS = "PageLinks:ConfirmationEmailSuccess";
            //public const string CONFIRMATION_EMAIL_FAILED = "PageLinks:ConfirmationEmailFailed";
        }

        public class MarkupReplacements
        {
            public const string CODE = "{{code}}";
            public const string CONFIRMATION_LINK = "{{confirmationLink}}";
        }

        public class ErrorMessage
        {
            public const string WRONG_EMAIL = "Wrong email";
            public const string WRONG_PASSWORD = "Wrong password";
            public const string LOGIN_SUCCESSFULLY = "Login successfully";
            public const string INTERNAL_SERVER_ERROR = "Internal Server Error";
            public const string USER_CREATED = "User've been created";
            public const string CREATE_USER_FAILED = "Create user failed";
            public const string USER_DONT_HAVE_EMAIL = "User don't have email";

            public static string NOT_FOUND_DATA(string objectName, string additionalData = null)
            {
                return $"{objectName} not found data. {additionalData ?? ""}";
            }
        }
    }
}
