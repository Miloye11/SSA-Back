using DataLayer.Models;
using System.Collections.Generic;

namespace BussinesLayer
{
    public interface IApartmentBusiness
    {
        List<Apartment> GetAllApartments();

        bool InsertApartment(Apartment a);

        bool UpdateApartment(Apartment a);
    }
}