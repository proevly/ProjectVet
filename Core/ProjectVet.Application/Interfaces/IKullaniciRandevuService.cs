using ProjectVet.Models;

namespace ProjectVet.Interfaces
{
    public interface IKullaniciRandevuService
    {
        void RandevuEkle(Randevu randevu);
        List<Randevu> GetTumRandevular();
        List<string> GetUnavailableTimes(DateTime date);
    }

}
