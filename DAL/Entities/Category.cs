namespace DAL.Entities
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

        // One-to-Many
        public virtual ICollection<Post> Posts { get; set; } = [];
    }
}
