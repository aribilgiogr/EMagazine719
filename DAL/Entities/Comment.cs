namespace DAL.Entities
{
    public class Comment : BaseEntity
    {
        public required string Content { get; set; }
        public bool Approved { get; set; } = false;

        public int PostId { get; set; }
        public virtual Post Post { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        // İçiçe hiyerarşisi için (Yoruma yapılan yorumlar)
        public int? ParentCommentId { get; set; }
        public virtual Comment? ParentComment { get; set; }
        public virtual ICollection<Comment> Replies { get; set; } = [];

    }
}
