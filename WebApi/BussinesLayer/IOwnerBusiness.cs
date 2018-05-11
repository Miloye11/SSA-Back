using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
   public interface IOwnerBusiness
    {
        List<Owner> GetAllOwners();

        bool InsertOwner(Owner o);

        bool UpdateOwner(Owner o);

        List<Owner> Login(string username, string password);


    }
}
