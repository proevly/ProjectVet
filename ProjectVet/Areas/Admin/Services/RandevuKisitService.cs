using ProjectVet.Application.Interfaces;
using ProjectVet.Areas.Admin.Dtos;
using ProjectVet.Domain.Entities.Models;
using ProjectVet.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVet.Persistance.Services
{

    public class RandevuKisitService : IRandevuKisitService
    {
        private readonly KlinikContext _context;

        public RandevuKisitService(KlinikContext context)
        {
            _context = context;
        }
        public void RandevuKisitEkle(RandevuKisitDto model)
        {
            _context.RandevuKisitlar.Add(new RandevuKisit
            {
                Id = model.Id,
                Tarih = model.Tarih,
                OgledenOnceMi = model.OgledenOnceMi
            });
            _context.SaveChanges();
        }

        public List<string> GetUnavailableTimes(DateTime date)
        {
            var unavailableTimes = _context.RandevuKisitlar
                .Where(r => r.Tarih.Date == date.Date)
                .Select(r => r.Tarih.ToString("HH:mm"))
                .ToList();

            return unavailableTimes;
        }
    }

}
