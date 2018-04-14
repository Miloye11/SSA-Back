using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
   public class Person
    {
      public int  Person_Id { get; set; }
      public string Name { get; set; }
      public string Surname { get; set; }
      public string JMBG { get; set; }
      public int Card_Number { get; set; }
    }
}
