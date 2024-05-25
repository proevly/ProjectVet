using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectVet.Models
{
    [Table("Admin")]
    public class Admin
    {
        public Guid Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

    }
}
