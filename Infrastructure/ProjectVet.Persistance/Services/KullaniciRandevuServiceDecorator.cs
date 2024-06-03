using ProjectVet.Interfaces;
using ProjectVet.Models;

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

        public void RandevuEkle(Randevu randevu)
        {
            _decoratedService.RandevuEkle(randevu);
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
    }
}