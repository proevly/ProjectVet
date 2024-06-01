using ProjectVet.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Pet")]
public class Pet
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Tur { get; set; }

    [Required]
    [StringLength(50)]
    public string Cins { get; set; }

    [Required]
    public int Yas { get; set; }

    [ForeignKey("Kullanici")]
    public Guid KullaniciId { get; set; }

    public virtual Kullanici Kullanici { get; set; }
    public virtual ICollection<Randevu> Randevular { get; set; }

}
