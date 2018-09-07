using Benefits.Shared.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Benefits.Shared.Models.Repository
{
    public class Resource
    {
        private const string ImageUrl = "/images/document-dots-{0}.png";

        //private List<string> FileTypes = new List<string> {
        //        FileType.DOC,
        //        FileType.DVD,
        //        FileType.PDF,
        //        FileType.PPT,
        //        FileType.XLS,
        //        FileType.GENERIC,
        //        FileType.HTM,
        //        FileType.LRN,
        //        FileType.BLOG
        //    };

        public string ID { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
        public string FullFileName { get; set; }
        public string FileExt { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string HtmlContent { get; set; }
        
        public string IconUrl
        {
            get
            {
                return $"{ImageUrl}-{FileExt.Substring(0, 3)}.png";
            }
        }
    }
}