namespace DAL.Entities
{
    public class Tag : BaseEntity
    {
        public required string Name { get; set; }

        // Many-to-Many
        public virtual ICollection<Post> Post { get; set; } = [];
    }
}
