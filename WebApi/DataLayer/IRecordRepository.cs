/*-------------------------------- RADIO STEFAN DJUSIC ------------------------------------*/
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IRecordRepository
    {
        List<All> GetAllRecords();
        int InsertRecord(Record r);
        int UpdateRecord(Record r);
    }
}
