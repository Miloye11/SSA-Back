using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class LogedUser
    {
        public int Owner_Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string JMBG { get; set; }
        public int Card_Number { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public LogedUser() { }
    }
}
