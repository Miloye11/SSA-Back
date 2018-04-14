using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IPersonRepository
    {
        List<Person> GetAllPersons();
        int InsertPersons(Person p);
        int UpdatePersons(Person p);
    }
}
