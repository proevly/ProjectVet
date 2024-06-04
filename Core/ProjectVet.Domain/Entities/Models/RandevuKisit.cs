using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVet.Domain.Entities.Models
{
    [Table("RandevuKisit")]
    public class RandevuKisit
    {
        public Guid Id { get; set; }

        [DataType(DataType.Time)]
        public DateTime Tarih { get; set; }
        public bool OgledenOnceMi { get; set; }
    }

}
