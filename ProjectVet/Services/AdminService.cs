using ProjectVet.EfCore;

namespace ProjectVet.Services
{
    public class AdminService : IAdminService
    {
        private readonly KlinikContext _context;
        public AdminService(KlinikContext context)
        {
            _context = context;
        }


        public void KullaniciEkle(Kullanici input)
        {
            _context.Kullanicilar.Add(new Kullanici
            {
                Ad = input.Ad,
                Soyad = input.Soyad,
                TelefonNo = input.TelefonNo,
                Mail = input.Mail,
                Parola= input.Parola,
                KullaniciId = Guid.NewGuid(),
            });

            _context.SaveChanges();
        }

        public List<Kullanici> KullaniciListele(Kullanici input)
        {
            var kullaniciList = _context.Kullanicilar.ToList();
            return kullaniciList;
        }

        public List<Kullanici> GetKullaniciList()
        {
            var info = _context.Kullanicilar.ToList();
            return info;
             
              
        }       

        public Kullanici GetKullaniciById(Guid id)
        {
            return _context.Kullanicilar.FirstOrDefault(d => d.KullaniciId == id);
          
        }

        public Kullanici GetKullaniciByName(string name)
        {
            return _context.Kullanicilar.FirstOrDefault(d=>d.Ad == name);
        }

        void IAdminService.KullaniciListele(Kullanici input)
        {
            throw new NotImplementedException();
        }
    }
}
