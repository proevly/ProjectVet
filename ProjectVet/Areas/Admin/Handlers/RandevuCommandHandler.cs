using ProjectVet.EfCore;

namespace ProjectVet.Areas.Admin.Handlers
{
    public class RandevuCommandHandler
    {
        private readonly KlinikContext _context;

        public RandevuCommandHandler(KlinikContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(Commands.OnaylaRandevuCommand command)
        {
            var randevu = await _context.Randevular.FindAsync(command.Id);
            if (randevu == null)
                return false;

            randevu.OnaylandiMi = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Handle(Commands.ReddetRandevuCommand command)
        {
            var randevu = await _context.Randevular.FindAsync(command.Id);
            if (randevu == null)
                return false;

            _context.Randevular.Remove(randevu);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Handle(Commands.DuzenleRandevuCommand command)
        {
            var randevu = await _context.Randevular.FindAsync(command.Id);
            if (randevu == null)
                return false;

            randevu.Pet.Tur= command.PetTur;
            randevu.Pet.Cins = command.PetCins;
            randevu.RandevuTarih = command.RandevuTarih;
            randevu.RandevuSaat = command.RandevuSaat;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
