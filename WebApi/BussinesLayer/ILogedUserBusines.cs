using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
   public interface ILogedUserBusiness
    {
        List<LogedUser> GetLogedUser();
        bool InsertUser(Owner o);
        bool TrancadeLogedUser();







    }
}
