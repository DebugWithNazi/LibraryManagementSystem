using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public string Author { get; set; }

        [AllowNull]
        [MaxLength(50)]
        public string Edition { get; set; }

        [AllowNull]
        [MaxLength(255)]
        public string Publisher { get; set; }

        [Required]
        [MaxLength(13)]
        public string ISBN { get; set; }
        [AllowNull]
        [MaxLength(50)]
        public string Genre { get; set; }
        [AllowNull]
        [Range(1, int.MaxValue)]
        public int PageCount { get; set; }
        [AllowNull]
        [MaxLength(50)]
        public string Language { get; set; }
        [AllowNull]
        [Range(1000, 9999)]
        public int PublicationYear { get; set; }
        //[Required]
        [AllowNull]
        public bool IsDeleted { get; set; } = false;
        [AllowNull]
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
        [AllowNull]
        public DateTime? UpdatedAt { get; set; }
    }
}
