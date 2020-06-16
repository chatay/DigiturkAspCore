using System;

namespace Digiturk.data.Dto
{
    public class LanguagesDto
    {
        public Byte LanguagesId { get; set; }
        public string Name { get; set; }
        public string ShortForm { get; set; }
        public string LanguageCode { get; set; }
        public string FolderName { get; set; }
        public string TextDirection { get; set; }
        public Byte Status { get; set; }
        public Byte LanguageOrder { get; set; }
    }
}
