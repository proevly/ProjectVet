using ProjectVet.Dtos;

namespace ProjectVet.Services
{
    public interface ICommand
    {
        void Execute();
    }

    public class UpdateKullaniciCommand : ICommand
    {
        private readonly KullaniciService _kullaniciService;
        private readonly EkleGuncelleKullaniciDto _input;

        public UpdateKullaniciCommand(KullaniciService kullaniciService, EkleGuncelleKullaniciDto input)
        {
            _kullaniciService = kullaniciService;
            _input = input;
        }

        public void Execute()
        {
            _kullaniciService.KullaniciGuncelle(_input);
        }
    }

    public class DeleteKullaniciCommand : ICommand
    {
        private readonly KullaniciService _kullaniciService;
        private readonly Guid _kullaniciId;

        public DeleteKullaniciCommand(KullaniciService kullaniciService, Guid kullaniciId)
        {
            _kullaniciService = kullaniciService;
            _kullaniciId = kullaniciId;
        }

        public void Execute()
        {
            _kullaniciService.KullaniciSil(_kullaniciId);
        }
    }

}
