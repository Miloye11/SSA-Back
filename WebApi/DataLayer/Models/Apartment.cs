using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
   public class Apartment
    {
        public int  Apartment_Id { get; set; }
        public string Address  { get; set; }
        public int Apartment_Number { get; set; }
        public string Owner_Name { get; set; }     
        public string Owner_Surname { get; set; }     
        public string Status     { get; set; }     
        public int Type_Id     { get; set; }      
        public int City_Id { get; set; }     
    }
}
