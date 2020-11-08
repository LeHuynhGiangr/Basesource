using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ApplicationSettings
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public int RefreshTokenTTL { get; set; }

        public string SmtpHost { get; set; }

        public string SmtpPort { get; set; }
    }
}
