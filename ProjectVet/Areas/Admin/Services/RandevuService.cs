using System;
using System.Threading.Tasks;
using ProjectVet.EfCore;

namespace ProjectVet.Areas.Admin.Services
{
    public interface IRandevuService
    {
        Task<bool> OnaylaRandevu(Guid id);
        Task<bool> ReddetRandevu(Guid id);
    }

    public class RandevuService : IRandevuService
    {
        private readonly KlinikContext _context;

        public RandevuService(KlinikContext context)
        {
            _context = context;
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
