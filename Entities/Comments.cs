using System.ComponentModel.DataAnnotations.Schema;
namespace Blog_site.Entities
{
    public class Comments : BaseEntity
    {
        public int OwnerId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public User Owner {  get; set; }
        [ForeignKey(nameof(PostId))]
        public Posts MainPost { get; set; }
    }
}
