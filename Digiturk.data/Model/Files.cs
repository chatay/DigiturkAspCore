using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Digiturk.data.Model
{
    public class Files
    {
        public Files()
        {
            PostFiles = new HashSet<PostFiles>();
        }
        [Key]
        public int FilesId { get; set; }
        public string FileName { get; set; }

        public virtual ICollection<PostFiles> PostFiles { get; set; }
    }
}
