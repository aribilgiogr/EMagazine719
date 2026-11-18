namespace DAL.Entities
{
    public class User : BaseEntity
    {
        public string? Name { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Bio { get; set; }

        public virtual ICollection<Post> Posts { get; set; } = [];
        public virtual ICollection<Comment> Comments { get; set; } = [];
        public virtual ICollection<Reaction> Reactions { get; set; } = [];
    }
}
