using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Digiturk.data.Model
{
    public class Categories
    {
        public Categories()
        {
            Posts = new HashSet<Posts>();
        }

        [Key]
        public int CategoriesId { get; set; }
        public Byte LangId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public Int32? ParentId { get; set; }
        public Int16? CategoryOrder { get; set; }
        public Byte ShowOnMenu { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
        public virtual Languages LanguagesNavigation { get; set; }
    }
}
