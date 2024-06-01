using ProjectVet.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Kullanici")]
public class Kullanici
{
    [Key]
    public Guid KullaniciId { get; set; }

    [Required]
    [StringLength(50)]
    public string Ad { get; set; }

    [Required]
    [StringLength(50)]
    public string Soyad { get; set; }

    [Required]
    public string KullaniciName { get; set; }
    [Required]
    [Phone]
    public string TelefonNo { get; set; }

    [Required]
    [EmailAddress]
    public string Mail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Parola { get; set; }

    public ICollection<Pet> Petler { get; set; } = new List<Pet>();

    public ICollection<Randevu> Randevular { get; set; } = new List<Randevu>();
}
