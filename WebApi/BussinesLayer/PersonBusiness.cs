using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
   public class PersonBusiness : IPersonBusiness
    {
        private IPersonRepository personRepository;

        public PersonBusiness(IPersonRepository personRepository)
        {
            // inicijalizacija repozitorijuma "ubrizgavanjem" kroz konstruktor
            this.personRepository = personRepository;
        }

        // metoda koja vraća listu svih osoba ako ih uopšte ima u bazi
        public List<Person> GetAllPersons()
        {
            List<Person> persons = this.personRepository.GetAllPersons();
            if (persons.Count > 0)
            {
                return persons;
            }
            else
            {
                return null;
            }
        }

        //metoda koja ubacuje podatke u tabelu Persons
        public bool InsertPerson(Person p)
        {
            if( p != null)
            {
                if (this.personRepository.InsertPersons(p) > 0)
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


        //metoda koja azurira podatke u tabeli Persons
        public bool UpdatePerson(Person p)
        {
            if (p != null && p.Person_Id != 0)
            {
                if (this.personRepository.UpdatePersons(p) > 0)
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
