using System;

namespace Post_Surfer.Options
{
    public class JwtSettings
    {
            public  string Secret { get; set; }
            public TimeSpan TokenLifetime { get; set; }
    }
}
