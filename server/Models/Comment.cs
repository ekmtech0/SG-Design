using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public sealed class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        // Relação com o autor do comentário
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        // Relação com likes
        public ICollection<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
