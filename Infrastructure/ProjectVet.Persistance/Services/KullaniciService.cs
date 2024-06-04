using ProjectVet.Dtos;
using ProjectVet.EfCore;
using ProjectVet.Interfaces;
using ProjectVet.Services;

public class KullaniciService : IKullaniciService
{
    private readonly KlinikContext _context;

    public KullaniciService(KlinikContext context)
    {
        _context = context;
    }

    public void KullaniciEkle(EkleGuncelleKullaniciDto input)
    {
        var validateHandler = new ValidateKullaniciHandler();
        var addHandler = new AddKullaniciHandler(_context);

        validateHandler.SetNext(addHandler);

        validateHandler.Handle(input);
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

    public Kullanici GetKullaniciById(Guid id)
    {
        return _context.Kullanicilar.FirstOrDefault(x => x.KullaniciId == id);
    }

    public Kullanici Authenticate(string username, string password)
    {
        return _context.Kullanicilar.FirstOrDefault(k => k.KullaniciName == username && k.Parola == password);
    }

}

