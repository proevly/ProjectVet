using ProjectVet.Interfaces;
using ProjectVet.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectVet.Services
{
    public class LoggingKullaniciRandevuServiceDecorator : IKullaniciRandevuService
    {
        //Not : Decartor Desgin pattern kullandım internetten araştırarak ancak mantıgını anlayamadım
        private readonly IKullaniciRandevuService _decoratedService;

        public LoggingKullaniciRandevuServiceDecorator(IKullaniciRandevuService decoratedService)
        {
            _decoratedService = decoratedService;
        }

        public string RandevuEkle(Randevu randevu)
        {
            var result = _decoratedService.RandevuEkle(randevu);
            return result;
        }

        public List<Randevu> GetTumRandevular()
        {
            var result = _decoratedService.GetTumRandevular();
            return result;
        }

        public List<string> GetUnavailableTimes(DateTime date)
        {
            var result = _decoratedService.GetUnavailableTimes(date);
            return result;
        }

        public List<Pet> GetKullaniciPets(Guid kullaniciId)
        {
            var result = _decoratedService.GetKullaniciPets(kullaniciId);
            return result;
        }
    }
}