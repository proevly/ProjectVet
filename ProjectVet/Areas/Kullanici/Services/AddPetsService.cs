using ProjectVet.EfCore;

namespace ProjectVet.Areas.Kullanici.Services
{
    public class AddPetsService
    {
        private readonly KlinikContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddPetsService(KlinikContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddPets(string petType, string petBreed, int petAge)
        {
            // Mevcut kullanıcıya ait bir pet oluştur
            var pet = new Pet
            {
                Id = Guid.NewGuid(),
                Tur = petType,
                Cins = petBreed,
                Yas = petAge,
                KullaniciId = GetUserIdFromSession() // Kullanıcı kimliği
            };

            // Pet'i veritabanına ekle
            _context.Petler.Add(pet);
            _context.SaveChanges();

        }

        private Guid GetUserIdFromSession()
        {
            var userIdString = _httpContextAccessor.HttpContext?.Session.GetString("UserId");
            if (Guid.TryParse(userIdString, out var userIdGuid))
            {
                return userIdGuid;
            }
            // Hata durumunda varsayılan bir kullanıcı kimliği döndürülebilir
            return Guid.Empty;
        }
    }
}

