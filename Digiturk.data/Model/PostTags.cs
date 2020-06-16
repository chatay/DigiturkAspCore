using System.ComponentModel.DataAnnotations;

namespace Digiturk.data.Model
{
    public class PostTags
    {
        [Key]
        public int PostId { get; set; }
        public string Tag { get; set; }
        public string TagSlug { get; set; }

        public virtual Posts PostsNavigation { get; set; }
    }
}
