﻿namespace SCHESS.Infrastructure.Provider.Email.Settings
{
    public class MailSettings
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FromEmail { get; set; }
        public string? FromName { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
    }
}
