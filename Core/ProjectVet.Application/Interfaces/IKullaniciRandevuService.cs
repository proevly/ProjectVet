using ProjectVet.Models;

namespace ProjectVet.Interfaces
{
    public interface IKullaniciRandevuService
    {
        string RandevuEkle(Randevu randevu);
        List<Randevu> GetTumRandevular();
        List<string> GetUnavailableTimes(DateTime date);
        List<Pet> GetKullaniciPets(Guid kullaniciId);
    }

}
