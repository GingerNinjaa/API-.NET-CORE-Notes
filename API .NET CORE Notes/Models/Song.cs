using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace API_.NET_CORE_Notes.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "tITLE CANOT BE NULL")]
        public string Title { get; set; }
        [Required]
        public string Duration { get; set; }

        public DateTime UploadDate { get; set; }
        public bool IsFeatured { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        [NotMapped]
        public IFormFile AudioFile { get; set; }
        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }
        public int ArtistId { get; set; }
        public int? AlbumId { get; set; }
    }
}
