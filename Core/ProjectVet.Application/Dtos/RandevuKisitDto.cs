using System.ComponentModel.DataAnnotations;

namespace ProjectVet.Areas.Admin.Dtos
{
    public class RandevuKisitDto
    {
        public Guid Id { get; set; }

        public DateTime Tarih { get; set; }
        public bool OgledenOnceMi { get; set; }
    }
}
