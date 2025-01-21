namespace Blog_site.ViewModels.Comment
{
    public class IndexVM
    {
        public List<Blog_site.Entities.Posts> Posts { get; set; }
        public List<Blog_site.Entities.Comments> Comments { get; set; }

        public int Id { get; set; }
    }
}
