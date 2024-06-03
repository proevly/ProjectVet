using ProjectVet.Dtos;
using ProjectVet.Interfaces;
using ProjectVet.Models;

namespace ProjectVet.Services
{
    public class ProjectVetFacade : IProjectVetFacade
    {
        private readonly IKullaniciService _kullaniciService;
        private readonly IKullaniciRandevuService _kullaniciRandevuService;
        private readonly IAdminService _adminService;

        //Alt Kısımda Tüm Servicesleri Birleştirerek Tek Kısımdan Hepsine Erişme Kolaylıgı Saglıyoruz Facade Design Pattern.
        public ProjectVetFacade(IKullaniciService kullaniciService, IKullaniciRandevuService kullaniciRandevuService, IAdminService adminService)
        {
            _kullaniciService = kullaniciService;
            _kullaniciRandevuService = kullaniciRandevuService;
            _adminService = adminService;
        }

        public void KullaniciEkle(EkleGuncelleKullaniciDto input)
        {
            _kullaniciService.KullaniciEkle(input);
        }

        public List<KullaniciDto> GetTumKullanicilar()
        {
            return _kullaniciService.GetTumKullanicilar();
        }

        public void RandevuEkle(Randevu randevu)
        {
            _kullaniciRandevuService.RandevuEkle(randevu);
        }

        public List<Randevu> GetTumRandevular()
        {
            return _kullaniciRandevuService.GetTumRandevular();
        }

        // Admin service methods
        public void AdminKullaniciEkle(Kullanici input)
        {
            _adminService.KullaniciEkle(input);
        }

        public List<Kullanici> AdminGetKullaniciList()
        {
            return _adminService.GetKullaniciList();
        }

        public Kullanici AdminGetKullaniciById(Guid id)
        {
            return _adminService.GetKullaniciById(id);
        }

        public Kullanici AdminGetKullaniciByName(string name)
        {
            return _adminService.GetKullaniciByName(name);
        }
    }

}
