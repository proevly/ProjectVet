namespace ProjectVet.Areas.Admin.Dtos
{
    public class RandevuDto
    {
        public Guid Id { get; set; }
        public string KullaniciAd { get; set; }
        public string KullaniciSoyad { get; set; }
        public string PetTur { get; set; }
        public string PetCins { get; set; }
        public DateTime RandevuTarih { get; set; }
        public DateTime RandevuSaat { get; set; }
        public bool AsiMiMuayeneMi { get; set; }
        public bool OnaylandiMi { get; set; }
    }
}
