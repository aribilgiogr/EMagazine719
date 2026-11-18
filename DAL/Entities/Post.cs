using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Post : BaseEntity
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string? CoverImageUrl { get; set; }
        public int ViewCount { get; set; } = 0;
        public DateTime? PublishedAt { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual User Author { get; set; } = null!;

        public virtual ICollection<Tag> Tags { get; set; } = [];
        public virtual ICollection<Comment> Comments { get; set; } = [];
        public virtual ICollection<Reaction> Reactions { get; set; } = [];
    }
}
