using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public class RecordBusiness : IRecordBusiness
    {
        private IRecordRepository recordRepository;
        private ApartmentRepository apartmentRepository;

        public RecordBusiness(IRecordRepository recordRepository)
        {
            this.recordRepository = recordRepository;
            this.apartmentRepository = new ApartmentRepository();
        }

        //logika za unos nove evidencije u bazu
        public bool InsertRecord(Record r)
        {
            int variable = this.recordRepository.InsertRecord(r);
            Record re = new Record();
            re = r;
            re.A_Apartment_Id = r.A_Apartment_Id;

            if (variable > 0)
            {
                if (re.A_Apartment_Id > 0)
                {
                    if (re.Record_Status == "Ulaz")
                    {
                        this.apartmentRepository.UpdateAppartementZauzet(re.A_Apartment_Id);
                        return true;
                    }
                    else if (re.Record_Status == "Izlaz")
                    {
                        this.apartmentRepository.UpdateAppartementSlobodan(re.A_Apartment_Id);
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
            else
            {
                return false;
            }
        }

        //logika za ispis svih podataka iz baze o Evidenciji
        public List<All> GetAllRecords()
        {
            return this.recordRepository.GetAllRecords();
        }

        //logika za azuriranje evidencije u bazi
        public bool UpdateRecord(Record r)
        {
            if (r.Record_Id != 0 && this.recordRepository.UpdateRecord(r) > 0)
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
