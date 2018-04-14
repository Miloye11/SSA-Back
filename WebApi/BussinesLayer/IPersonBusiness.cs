using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
   public interface IPersonBusiness
    {

        List<Person> GetAllPersons();
        bool InsertPerson(Person p);
        bool UpdatePerson(Person p);
    }
}
