using System.ComponentModel.DataAnnotations;

namespace Digiturk.data.Model
{
    public class PostFiles
    {
        [Key]
        public int PostId { get; set; }
        public int FileId { get; set; }


        public virtual Posts PostsNavigation { get; set; }
        public virtual Files FilesNavigation { get; set; }
    }
}
