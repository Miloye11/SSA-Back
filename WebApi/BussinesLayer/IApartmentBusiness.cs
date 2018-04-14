using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
   public interface IApartmentBusiness
    {
        List<Apartment> GetAllApartments();
        bool InsertApartment(Apartment a);
        bool UpdateApartment(Apartment a);
    }
}
