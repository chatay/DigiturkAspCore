using System;

namespace Digiturk.data.Dto
{
    public class PostsDto
    {
        public int PostsId { get; set; }
        public Byte LanguagesId { get; set; }
        public string Title { get; set; }
        public string TitleSlug { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Keywords { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string ImageBig { get; set; }
        public string ImageMid { get; set; }
        public string ImageSmall { get; set; }
        public string ImageSlider { get; set; }
        public string ImageMime { get; set; }
        public Byte IsSlider { get; set; }
        public Byte IsPicked { get; set; }
        public int Hit { get; set; }
        public Byte SliderOrder { get; set; }
        public string OptionalUrl { get; set; }
        public string PostType { get; set; }
        public string VideoUrl { get; set; }
        public string VideoEmbedCode { get; set; }
        public string ImageUrl { get; set; }
        public Byte NeedAuth { get; set; }
        public Byte Visibility { get; set; }
        public Byte Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
