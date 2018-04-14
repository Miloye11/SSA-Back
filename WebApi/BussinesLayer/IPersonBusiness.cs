using DataLayer.Models;
using System.Collections.Generic;

namespace BussinesLayer
{
    public interface IPersonBusiness
    {
        List<Person> GetAllPersons();

        bool InsertPerson(Person p);

        bool UpdatePerson(Person p);
    }
}