using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        // metoda koja vraća listu svih stanova ako ih uopšte ima u bazi
        public List<Apartment> GetAllApartments()
        {
            List<Apartment> apartments = this.apartmentRepository.GetAllApartments();
            if (apartments.Count > 0)
            {
                return apartments;
            }
            else
            {
                return null;
            }
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
    }
}
