using ProjectVet.Dtos;
using ProjectVet.Models;

namespace ProjectVet.Interfaces
{
    public interface IProjectVetFacade
    {
        void KullaniciEkle(EkleGuncelleKullaniciDto input);
        List<KullaniciDto> GetTumKullanicilar();
        void RandevuEkle(Randevu randevu);
        List<Randevu> GetTumRandevular();
    }


}
