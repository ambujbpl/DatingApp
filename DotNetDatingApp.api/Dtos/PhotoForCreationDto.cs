  
using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Dtos
{
    public class PhotoForCreationDto
    {
        public string url { get; set; }
        public IFormFile File { get; set; }
        public string description { get; set; }
        public DateTime dateAdded { get; set; }
        public string publicId { get; set; }
        public PhotoForCreationDto()
        {
            dateAdded = DateTime.Now;
        }
    }
}