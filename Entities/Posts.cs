using System.ComponentModel.DataAnnotations.Schema;
//using System.Security.Cryptography.X509Certificates;

namespace Blog_site.Entities
{
    public class Posts : BaseEntity
    {
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public string Type { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public virtual User Owner { get; set; }
    }
}
