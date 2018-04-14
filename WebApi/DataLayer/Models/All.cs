using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class All
    {

        //klasa Person
        public int Person_Id { get; set; }
        public string Person_Name { get; set; }
        public string Person_Surname { get; set; }
        public string JMBG { get; set; }
        public int Card_Number { get; set; }

        //Klasa Type
        public int Type_Id { get; set; }
        public string Type_Name { get; set; }

        //Klasa City
        public int City_Id { get; set; }
        public int Ppt { get; set; }
        public string City_Name { get; set; }

        //Klasa Apartment
        public int Apartment_Id { get; set; }
        public string Address { get; set; }
        public int Apartment_Number { get; set; }
        public string Owner_Name { get; set; }
        public string Owner_Surname { get; set; }
        public string Appartment_Status { get; set; }
        public int T_Type_Id { get; set; }
        public int C_City_Id { get; set; }

        //klasa Record
        public int Record_Id { get; set; }
        public DateTime Date_Time { get; set; }
        public string Record_Status { get; set; }
        public int P_Person_Id { get; set; }
        public int A_Appartement_Id { get; set; }

        public All() { }
    }
}
