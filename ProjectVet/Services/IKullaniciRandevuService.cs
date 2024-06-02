using Microsoft.AspNetCore.Http;
using ProjectVet.EfCore;
using ProjectVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectVet.Services
{
    public interface IKullaniciRandevuService
    {
        void RandevuEkle(Randevu randevu);
        List<Randevu> GetTumRandevular();
        List<string> GetUnavailableTimes(DateTime date);
    }

    public class KullaniciRandevuService : IKullaniciRandevuService
    {
        private readonly KlinikContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public KullaniciRandevuService(KlinikContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public void RandevuEkle(Randevu randevu)
        {
            // Oturum değişkeninden kullanıcı kimliğini alma kısmı burası 
            var userId = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            if (!string.IsNullOrEmpty(userId))
            {
                randevu.KullaniciId = Guid.Parse(userId);

                _context.Randevular.Add(new Randevu
                {
                    Id = randevu.Id,
                    Aciklama = randevu.Aciklama,
                    HayvanId = randevu.HayvanId,
                    OnaylandiMi = false,
                    KullaniciId = randevu.KullaniciId,
                    Pet = randevu.Pet,
                    AsiMiMuayeneMi = randevu.AsiMiMuayeneMi,
                    RandevuSaat = randevu.RandevuSaat,
                    RandevuTarih = randevu.RandevuTarih
                });
                _context.SaveChanges();
            }
            else
            {

            }
        }

        public List<Randevu> GetTumRandevular()
        {
            return _context.Randevular.ToList();
        }

        public List<string> GetUnavailableTimes(DateTime date)
        {
            var unavailableTimes = _context.Randevular
                .Where(r => r.RandevuTarih.Date == date.Date)
                .Select(r => r.RandevuTarih.ToString("HH:mm"))
                .ToList();

            return unavailableTimes;
        }
    }
}
