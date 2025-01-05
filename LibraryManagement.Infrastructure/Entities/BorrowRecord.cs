using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Entities
{
    public class BorrowRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime BorrowedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ReturnedAt { get; set; }
    }
}
