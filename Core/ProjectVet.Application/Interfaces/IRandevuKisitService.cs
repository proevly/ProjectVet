using ProjectVet.Areas.Admin.Dtos;
using ProjectVet.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVet.Application.Interfaces
{
    public interface IRandevuKisitService
    {
        void RandevuKisitEkle(RandevuKisitDto model);
    }

}
