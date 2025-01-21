using Blog_site.Entities;

namespace Blog_site.ViewModels.Comment
{
    public class CreateVM
    {
        public int OwnerId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        
    }
}
