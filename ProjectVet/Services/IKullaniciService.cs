using ProjectVet.Dtos;
using ProjectVet.EfCore;

namespace ProjectVet.Services
{
    public interface IKullaniciService
    {
        void KullaniciEkle(EkleGuncelleKullaniciDto input);
        List<KullaniciDto> GetTumKullanicilar();

        void KullaniciGuncelle(EkleGuncelleKullaniciDto input);
        Kullanici GetKullaniciById(Guid id);

        void KullaniciSil(Guid id);
    }

    public class KullaniciService : IKullaniciService
    {

        private readonly KlinikContext _context;

        public KullaniciService(KlinikContext context)
        {
            _context = context;
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
                    Ad=x.Ad,
                    Soyad=x.Soyad,
                    TelefonNo=x.TelefonNo,
                    Mail=x.Mail,
                    Parola=x.Parola,
                }).ToList();

            return kullanicilar;
        }

        public void KullaniciEkle(EkleGuncelleKullaniciDto input)
        {
            _context.Kullanicilar.Add(new Kullanici
            {
                Ad=input.Ad,
                Soyad=input.Soyad,
                TelefonNo=input.TelefonNo,
                Mail=input.Mail,
                Parola=input.Parola,
            });
            _context.SaveChanges();

        }

        public void KullaniciGuncelle(EkleGuncelleKullaniciDto input)
        {
            var mevcutKullanici= _context.Kullanicilar
                .Where(x=> x.KullaniciId==input.KullaniciId)
                .FirstOrDefault();

                if (mevcutKullanici != null)
                {
                    mevcutKullanici.Ad=input.Ad;
                    mevcutKullanici.Soyad=input.Soyad;
                    mevcutKullanici.TelefonNo=input.TelefonNo;
                    mevcutKullanici.Mail=input.Mail;
                    mevcutKullanici.Parola=input.Parola;
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
