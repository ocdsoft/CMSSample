using System;

namespace Benefits.Shared.Models.Repository
{
    public class Publication
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
    }
}