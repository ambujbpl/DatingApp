using System;

namespace DotNetDatingApp.api.Dtos
{
    public class PhotoForReturnDto
    {
        public int id { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public DateTime dateAdded { get; set; }
        public bool ismain { get; set; }
        public string publicId { get; set; }
    }
}