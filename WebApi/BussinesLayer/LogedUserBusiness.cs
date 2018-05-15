using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
   public class LogedUserBusiness : ILogedUserBusiness
    {
        private ILogedUser userRepository;

        public LogedUserBusiness (ILogedUser userRepository)

        {
            // inicijalizacija repozitorijuma "ubrizgavanjem" kroz konstruktor
            this.userRepository = userRepository;
        }

      
        public List<LogedUser> GetLogedUser()
        {
            List<LogedUser> users = this.userRepository.GetLogedUser();
            if (users.Count > 0)
            {
                return users;
            }
            else
            {
                return null;
            }
        }
        
       

      
        public bool InsertUser(Owner o)
        {
            if (o != null)
            {
                if (this.userRepository.InsertUser(o) > 0)
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

     public   bool TrancadeLogedUser()
        {
            if (this.userRepository.TrancadeLogedUser() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
