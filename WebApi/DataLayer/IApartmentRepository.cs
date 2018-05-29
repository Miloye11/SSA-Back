using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IApartmentRepository
    {
      

        int InsertApartment(Apartment a);

        int UpdateApartment(Apartment a);

        int DeleteApartement(int id);

        List<All> GetAllApartmentsJoined();

        //--------------- DEO KOJI RADI DJUSIC -----------------
        int UpdateAppartementSlobodan(int Apartment_Id);
        int UpdateAppartementZauzet(int Apartment_Id);
        //--------------- DEO KOJI RADI DJUSIC -----------------
    }
}