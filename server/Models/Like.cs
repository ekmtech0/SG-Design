using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public sealed class CommentLike
    {
        [Key]
        public int Id { get; set; }

        // Usuário que curtiu o comentário
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        // Comentário curtido
        public Guid CommentId { get; set; }
        public Comment Comment { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
