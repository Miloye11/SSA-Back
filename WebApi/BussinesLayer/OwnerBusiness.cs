using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
   public class OwnerBusiness : IOwnerBusiness
    {
        private IOwnerRepository ownerRepository;

        public OwnerBusiness(IOwnerRepository ownerRepository)
        {
            // inicijalizacija repozitorijuma "ubrizgavanjem" kroz konstruktor
            this.ownerRepository = ownerRepository;
        }

        // metoda koja vraća listu svih vlasnika ako ih uopšte ima u bazi
        public List<Owner> GetAllOwners()
        {
            List<Owner> owners = this.ownerRepository.GetAllOwners();
            if (owners.Count > 0)
            {
                return owners;
            }
            else
            {
                return null;
            }
        }
        
        
        // metoda koja vlasnika na osnovu username i password
        public List<Owner> Login(string username, string password)
        {
            List<Owner> owners = this.ownerRepository.GetAllOwners();
            if (owners.Count > 0)
            {
                return owners.Where(o => o.Username == username && o.Password == password).ToList();
            }
            else
            {
                return null;
            }
        }




        //metoda koja ubacuje podatke u tabelu Owners
        public bool InsertOwner(Owner o)
        {
            if (o != null)
            {
                if (this.ownerRepository.InsertOwner(o) > 0)
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

        //metoda koja azurira podatke u tabeli Owners
        public bool UpdateOwner(Owner o)
        {
            if (o != null && o.Owner_Id != 0)
            {
                if (this.ownerRepository.UpdateOwner(o) > 0)
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
