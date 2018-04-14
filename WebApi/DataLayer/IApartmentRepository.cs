using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IApartmentRepository
    {
        List<Apartment> GetAllApartments();

        int InsertApartment(Apartment a);

        int UpdateApartment(Apartment a);
    }
}