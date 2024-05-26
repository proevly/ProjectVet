using System.ComponentModel.DataAnnotations;

namespace ProjectVet.Dtos
{
    public class KullaniciDto
    {
        public Guid KullaniciId { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string TelefonNo { get; set; }

        public string Mail { get; set; }

        public string Parola { get; set; }

        //public ICollection<Pet> Petler { get; set; } = new List<Pet>();

        //public ICollection<Randevu> Randevular { get; set; } = new List<Randevu>();
    }

}
