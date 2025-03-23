using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        public int Year { get; set; }

        public string? CoverImagePath { get; set; } // Kapak resmi dosya yolu

        [StringLength(500)]
        public string? Description { get; set; }

        [NotMapped] // Bu alan veritabanına kaydedilmeyecek
        public IFormFile? CoverImage { get; set; } // Resim yükleme için
    }
}
