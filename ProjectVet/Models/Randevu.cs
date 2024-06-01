using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectVet.Models
{
[Table("Randevu")]
public class Randevu
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("Kullanici")]
    public Guid KullaniciId { get; set; }

    [ForeignKey("Pet")]
    public Guid HayvanId { get; set; }

    [Required]
    public DateTime RandevuTarih { get; set; }

    [Required]
    [DataType(DataType.Time)]
    public DateTime RandevuSaat { get; set; }

    [Required]
    public bool AsiMiMuayeneMi { get; set; }

    [StringLength(500)]
    public string Aciklama { get; set; }

    [Required]
    public bool OnaylandiMi { get; set; }

    public  Kullanici Kullanici { get; set; }

    public  Pet Pet { get; set; }

}
}