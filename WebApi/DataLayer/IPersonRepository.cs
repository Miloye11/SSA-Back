using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IPersonRepository
    {
        List<Person> GetAllPersons();

        int InsertPerson(Person p);

        int UpdatePerson(Person p);
    }
}