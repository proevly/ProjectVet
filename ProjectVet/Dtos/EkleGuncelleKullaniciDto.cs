using System.ComponentModel.DataAnnotations;

namespace ProjectVet.Dtos
{
    public class EkleGuncelleKullaniciDto
    {
        [Key]
        public Guid KullaniciId { get; set; }

        [Required(ErrorMessage = "Ad boş olamaz!")]
        [StringLength(50)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad boş olamaz!")]
        [StringLength(50)]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "TelefonNo boş olamaz!")]
        [Phone]
        public string TelefonNo { get; set; }

        [Required(ErrorMessage = "Mail boş olamaz!")]
        [EmailAddress]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Parola boş olamaz!")]
        [DataType(DataType.Password)]
        public string Parola { get; set; }

        [Required(ErrorMessage = "Parola boş olamaz!")]
        [DataType(DataType.Password)]
        [Compare("Parola")]
        public string ParolaTekrar { get; set; }

    }

}
