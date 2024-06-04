using ProjectVet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVet.Application.ViewModels
{
    public class AppointmentViewModel
    {
        public Randevu Randevu { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
