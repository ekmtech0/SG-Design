namespace server.Services
{
    public class CookieGenerateService : ICookieGenerate
    {
        public CookieOptions GenerateCookie()
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            return cookieOptions;
        }
    }
}
