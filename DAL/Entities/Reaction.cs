namespace DAL.Entities
{
    public class Reaction : BaseEntity
    {
        public ReactionType Type { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; } = null!;

        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
