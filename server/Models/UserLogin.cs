namespace server.Models
{
    public class UserLogin
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public DateTime ExpiresAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

        public bool IsRevoked { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

    }
}
