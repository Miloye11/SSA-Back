using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IApartmentRepository
    {
        List<Apartment> GetAllApartments();

        int InsertApartment(Apartment a);

        int UpdateApartment(Apartment a);


        //--------------- DEO KOJI RADI DJUSIC -----------------
        int UpdateAppartementSlobodan(int Apartment_Id);
        int UpdateAppartementZauzet(int Apartment_Id);
        //--------------- DEO KOJI RADI DJUSIC -----------------
    }
}