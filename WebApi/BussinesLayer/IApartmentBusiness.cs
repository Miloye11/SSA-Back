using DataLayer.Models;
using System.Collections.Generic;

namespace BussinesLayer
{
    public interface IApartmentBusiness
    {
      

        bool InsertApartment(Apartment a);

        bool UpdateApartment(Apartment a);

        bool DeleteApartement(int id);

        List<All> GetAllApartmentsJoined();
    }
}