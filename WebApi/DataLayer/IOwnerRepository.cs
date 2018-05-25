using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
  public interface IOwnerRepository
    {
        List<Owner> GetAllOwners();

        int InsertOwner(Owner o);

        int UpdateOwner(Owner o);

        int DeleteOwner(int id);
    }
}
