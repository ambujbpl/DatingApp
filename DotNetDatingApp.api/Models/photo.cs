using System;

namespace DotNetDatingApp.api.Models
{
    public class Photo
    {
        public int id { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public DateTime dateadded { get; set; }
        public bool ismain { get; set; }
        public string publicId { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}