using Microsoft.EntityFrameworkCore;
using ProjectVet.Dtos;
using ProjectVet.EfCore;
using ProjectVet.Interfaces;
using ProjectVet.Models;

namespace ProjectVet.Services
{
    public class ProjectVetFacade : IProjectVetFacade
    {
        private readonly IKullaniciService _kullaniciService;
        private readonly IKullaniciRandevuService _kullaniciRandevuService;
        private readonly IAdminService _adminService;
        private readonly KlinikContext _context;


        //Alt Kısımda Tüm Servicesleri Birleştirerek Tek Kısımdan Hepsine Erişme Kolaylıgı Saglıyoruz Facade Design Pattern.
        public ProjectVetFacade(IKullaniciService kullaniciService, IKullaniciRandevuService kullaniciRandevuService, IAdminService adminService, KlinikContext context)
        {
            _kullaniciService = kullaniciService;
            _kullaniciRandevuService = kullaniciRandevuService;
            _adminService = adminService;
            _context = context;
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
        public async Task<bool> OnaylaRandevu(Guid id)
        {
            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu == null)
                return false;

            randevu.OnaylandiMi = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ReddetRandevu(Guid id)
        {
            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu == null)
                return false;

            await _context.SaveChangesAsync();
            return true;
        }
    }

}
