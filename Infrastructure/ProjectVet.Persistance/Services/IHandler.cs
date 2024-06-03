using ProjectVet.Dtos;
using ProjectVet.EfCore;

namespace ProjectVet.Services
{
    public interface IHandler<T>
    {
        void SetNext(IHandler<T> handler);
        void Handle(T request);
    }

    public abstract class Handler<T> : IHandler<T>
    {
        private IHandler<T> _nextHandler;

        public void SetNext(IHandler<T> handler)
        {
            _nextHandler = handler;
        }

        public virtual void Handle(T request)
        {
            _nextHandler?.Handle(request);
        }
    }

    public class ValidateKullaniciHandler : Handler<EkleGuncelleKullaniciDto>
    {
        public override void Handle(EkleGuncelleKullaniciDto request)
        {
            // Kullanıcı verilerini doğrula
            if (string.IsNullOrEmpty(request.Ad) || string.IsNullOrEmpty(request.KullaniciName))
            {
                throw new ArgumentException("Kullanıcı adı veya ad boş olamaz.");
            }

            base.Handle(request);
        }
    }

    public class AddKullaniciHandler : Handler<EkleGuncelleKullaniciDto>
    {
        private readonly KlinikContext _context;

        public AddKullaniciHandler(KlinikContext context)
        {
            _context = context;
        }

        public override void Handle(EkleGuncelleKullaniciDto request)
        {
            var kullanici = new Kullanici
            {
                Ad = request.Ad,
                Soyad = request.Soyad,
                KullaniciName = request.KullaniciName,
                TelefonNo = request.TelefonNo,
                Mail = request.Mail,
                Parola = request.Parola,
            };

            _context.Kullanicilar.Add(kullanici);
            _context.SaveChanges();

            base.Handle(request);
        }
    }

    //KULLANICI GÜNCELLEME
    public class UpdateKullaniciHandler : Handler<EkleGuncelleKullaniciDto>
    {
        private readonly KlinikContext _context;

        public UpdateKullaniciHandler(KlinikContext context)
        {
            _context = context;
        }

        public override void Handle(EkleGuncelleKullaniciDto request)
        {
            var mevcutKullanici = _context.Kullanicilar
                .FirstOrDefault(x => x.KullaniciId == request.KullaniciId);

            if (mevcutKullanici == null)
            {
                throw new KeyNotFoundException("Kullanıcı bulunamadı.");
            }

            mevcutKullanici.Ad = request.Ad;
            mevcutKullanici.Soyad = request.Soyad;
            mevcutKullanici.KullaniciName = request.KullaniciName;
            mevcutKullanici.TelefonNo = request.TelefonNo;
            mevcutKullanici.Mail = request.Mail;
            mevcutKullanici.Parola = request.Parola;

            _context.Kullanicilar.Update(mevcutKullanici);
            _context.SaveChanges();

            base.Handle(request);
        }
    }


    //KULLANICI SİLME
    public class DeleteKullaniciHandler : Handler<Guid>
    {
        private readonly KlinikContext _context;

        public DeleteKullaniciHandler(KlinikContext context)
        {
            _context = context;
        }

        public override void Handle(Guid id)
        {
            var kullanici = _context.Kullanicilar.Find(id);
            if (kullanici != null)
            {
                _context.Kullanicilar.Remove(kullanici);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Kullanıcı bulunamadı.");
            }

            base.Handle(id);
        }
    }


}
