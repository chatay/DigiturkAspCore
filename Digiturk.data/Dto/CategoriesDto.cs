using System;

namespace Digiturk.data.Dto
{
    public class CategoriesDto
    {
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
    }
}
