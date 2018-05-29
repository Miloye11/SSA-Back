using DataLayer;
using DataLayer.Models;
using System.Collections.Generic;

namespace BussinesLayer
{
    public class ApartmentBusiness : IApartmentBusiness
    {
        private IApartmentRepository apartmentRepository;

        public ApartmentBusiness(IApartmentRepository apartmentRepository)
        {
            // inicijalizacija repozitorijuma "ubrizgavanjem" kroz konstruktor
            this.apartmentRepository = apartmentRepository;
        }

        

        //metoda koja ubacuje podatke u tabelu Apartments
        public bool InsertApartment(Apartment a)
        {
            if (a != null)
            {
                if (this.apartmentRepository.InsertApartment(a) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //metoda koja azurira podatke u tabeli Apartments
        public bool UpdateApartment(Apartment a)
        {
            if (a != null && a.Apartment_Id != 0)
            {
                if (this.apartmentRepository.UpdateApartment(a) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //metoda koja brise jedan stan iz tabele Apartments
       public bool DeleteApartement(int id)
        {
            if (id>0)
            {
                if (this.apartmentRepository.DeleteApartement(id)>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
      public  List<All> GetAllApartmentsJoined()
        {
            List<All> list = this.apartmentRepository.GetAllApartmentsJoined();
            if (list.Count>0)
            {
                return list;
            }
            else
            {
                return null;
            }
        }
    }
}