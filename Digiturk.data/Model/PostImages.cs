using System.ComponentModel.DataAnnotations;

namespace Digiturk.data.Model
{
    public class PostImages
    {
        [Key]
        public int PostId { get; set; }
        public string ImagePath { get; set; }

        public virtual Posts PostsNavigation { get; set; }
    }
}
