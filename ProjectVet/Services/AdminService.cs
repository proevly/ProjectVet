
//SİNGLETON  BURADA

using ProjectVet.Areas.Admin.Dtos;
using ProjectVet.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectVet.Services
{
    public class AdminService : IAdminService
    {
        private readonly KlinikContext _context;
        private static AdminService _instance;
        private static readonly object _lock = new object();

        // Dışarıdan örneklemeyi kapattık SİNGLETON
        private AdminService(KlinikContext context)
        {
            _context = context;
        }

        //  Singleton için Public static method 
        public static AdminService GetInstance(KlinikContext context)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AdminService(context);
                    }
                }
            }
            return _instance;
        }

        public void KullaniciEkle(Kullanici input)
        {
            _context.Kullanicilar.Add(new Kullanici
            {
                Ad = input.Ad,
                Soyad = input.Soyad,
                TelefonNo = input.TelefonNo,
                Mail = input.Mail,
                Parola = input.Parola,
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
            return _context.Kullanicilar.FirstOrDefault(d => d.Ad == name);
        }

        void IAdminService.KullaniciListele(Kullanici input)
        {
            throw new NotImplementedException();
        }
    }
}

