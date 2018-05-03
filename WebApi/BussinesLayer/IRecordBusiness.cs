/*-------------------------------- RADIO STEFAN DJUSIC ------------------------------------*/
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public interface IRecordBusiness
    {
        bool InsertRecord(Record r);
        List<All> GetAllRecords();
        bool UpdateRecord(Record r);
        List<All> GetAllRecordsToday();
        List<All> GetAllRecordsWeek();
        List<All> GetAllRecordsMonth();
    }
}
