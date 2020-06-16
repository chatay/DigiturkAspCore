using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Digiturk.data.Model
{
    public class Languages
    {
        public Languages()
        {
            Posts = new HashSet<Posts>();
            Categories = new HashSet<Categories>();
        }

        [Key]
        public Byte LanguagesId { get; set; }
        public string Name { get; set; }
        public string ShortForm { get; set; }
        public string LanguageCode { get; set; }
        public string FolderName { get; set; }
        public string TextDirection { get; set; }
        public Byte Status { get; set; }
        public Byte LanguageOrder { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<Categories> Categories { get; set; }
    }
}
