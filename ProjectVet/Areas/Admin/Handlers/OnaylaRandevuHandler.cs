using ProjectVet.Areas.Admin.Handlers;
using ProjectVet.EfCore;

public class OnaylaRandevuHandler
{
    private readonly KlinikContext _context;

    public OnaylaRandevuHandler(KlinikContext context)
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
}

public class ReddetRandevuHandler
{
    private readonly KlinikContext _context;

    public ReddetRandevuHandler(KlinikContext context)
    {
        _context = context;
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
}
