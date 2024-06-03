using ProjectVet.Dtos;
using ProjectVet.EfCore;
using ProjectVet.Interfaces;

namespace ProjectVet.Services
{
    public class KullaniciService : IKullaniciService
    {

        private readonly KlinikContext _context;

        public KullaniciService(KlinikContext context)
        {
            _context = context;
        }

        public Kullanici Authenticate(string username, string password)
        {
            // Kullanıcıyı e-posta ve şifreye göre doğrulayın
            return _context.Kullanicilar.FirstOrDefault(k => k.KullaniciName == username && k.Parola == password);
        }

        public Kullanici GetKullaniciById(Guid id)
        {
            return _context.Kullanicilar
                .Where(x => x.KullaniciId == id)
                .FirstOrDefault();
        }

        public List<KullaniciDto> GetTumKullanicilar()
        {
            var kullanicilar = _context.Kullanicilar
                .Select(x => new KullaniciDto
                {
                    Ad = x.Ad,
                    Soyad = x.Soyad,
                    TelefonNo = x.TelefonNo,
                    KullaniciName = x.KullaniciName,
                    Mail = x.Mail,
                    Parola = x.Parola,
                }).ToList();

            return kullanicilar;
        }

        public void KullaniciEkle(EkleGuncelleKullaniciDto input)
        {
            _context.Kullanicilar.Add(new Kullanici
            {
                Ad = input.Ad,
                Soyad = input.Soyad,
                KullaniciName = input.KullaniciName,
                TelefonNo = input.TelefonNo,
                Mail = input.Mail,
                Parola = input.Parola,
            });
            _context.SaveChanges();

        }

        public void KullaniciGuncelle(EkleGuncelleKullaniciDto input)
        {
            var mevcutKullanici = _context.Kullanicilar
                .Where(x => x.KullaniciId == input.KullaniciId)
                .FirstOrDefault();

            if (mevcutKullanici != null)
            {
                mevcutKullanici.Ad = input.Ad;
                mevcutKullanici.Soyad = input.Soyad;
                mevcutKullanici.TelefonNo = input.TelefonNo;
                mevcutKullanici.KullaniciName = input.KullaniciName;
                mevcutKullanici.Mail = input.Mail;
                mevcutKullanici.Parola = input.Parola;
                _context.Kullanicilar.Update(mevcutKullanici);
                _context.SaveChanges();
            }
        }

        public void KullaniciSil(Guid id)
        {
            var kullanici = _context.Kullanicilar.Find(id);
            if (kullanici != null)
            {
                _context.Kullanicilar.Remove(kullanici);
                _context.SaveChanges();
            }
        }



    }
}
