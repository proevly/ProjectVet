using ProjectVet.Areas.Admin.Dtos;

namespace ProjectVet.Services
{
    public interface IAdminService
    {
        List<Kullanici> GetKullaniciList();
        void KullaniciListele(Kullanici input);
        Kullanici GetKullaniciById(Guid id);
        Kullanici GetKullaniciByName(string id);
        void KullaniciEkle(Kullanici input);
    }
}
