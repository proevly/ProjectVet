using ProjectVet.Areas.Admin.Dtos;
using ProjectVet.EfCore;
using static ProjectVet.Areas.Admin.Handlers.Queries;

namespace ProjectVet.Areas.Admin.Handlers
{
    public class RandevuQueryHandler
    {
        private readonly KlinikContext _context;

        public RandevuQueryHandler(KlinikContext context)
        {
            _context = context;
        }

        public async Task<RandevuDto> Handle(GetRandevuByIdQuery query)
        {
            var randevu = await _context.Randevular.FindAsync(query.Id);
            if (randevu == null)
                return null;

            return new RandevuDto
            {
                Id = randevu.Id,
              
                PetTur = randevu.Pet?.Tur ?? string.Empty, // Null kontrolü ve varsayılan değer
                PetCins = randevu.Pet?.Cins ?? string.Empty, // Null kontrolü ve varsayılan değer
                RandevuTarih = randevu.RandevuTarih,
                RandevuSaat = randevu.RandevuSaat,
            };

        }
    }
}
