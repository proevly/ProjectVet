using ProjectVet.Dtos;

namespace ProjectVet.Interfaces
{
    public interface IKullaniciService
    {
        void KullaniciEkle(EkleGuncelleKullaniciDto input);
        List<KullaniciDto> GetTumKullanicilar();

        void KullaniciGuncelle(EkleGuncelleKullaniciDto input);
        Kullanici GetKullaniciById(Guid id);

        void KullaniciSil(Guid id);
        public Kullanici Authenticate(string username, string password);

    }



}
