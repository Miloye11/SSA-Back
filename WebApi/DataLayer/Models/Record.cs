using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Record
    {
        public int Record_Id { get; set; }
        public DateTime Date_Time { get; set; }
        public string Record_Status { get; set; }
        public int P_Person_Id { get; set; }
        public int A_Apartment_Id { get; set; }

        public Record() { }

        public Record(int record_Id, DateTime date_Time, string record_Status, int p_Person_Id, int a_Apartment_Id)
        {
            Record_Id = record_Id;
            Date_Time = date_Time;
            Record_Status = record_Status;
            P_Person_Id = p_Person_Id;
            A_Apartment_Id = a_Apartment_Id;
        }
    }
}
