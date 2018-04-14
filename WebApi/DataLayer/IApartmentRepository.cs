using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IApartmentRepository
    {
        List<Apartment> GetAllApartments();
        int InsertApartment(Apartment a);
        int UpdateApartment(Apartment a);
    }
}
