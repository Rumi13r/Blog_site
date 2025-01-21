using System.ComponentModel.DataAnnotations;
namespace Blog_site.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id {  get; set; }
    }

}
