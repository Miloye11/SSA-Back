using BussinesLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/portal/records")]

    public class RecordController : ApiController
    {
        private IRecordBusiness recordBusiness;

        public RecordController(IRecordBusiness recordBusiness)
        {
            this.recordBusiness = recordBusiness;
        }

        //pozivanje preko rute za unos nove evidencije u bazu
        [HttpPost]
        [Route("insertrecord")]
        public bool InsertRecord([FromBody] Record r)
        {
            return this.recordBusiness.InsertRecord(r);
        }

        //pozivanje preko rute za ispis svih podataka iz baze o Evidencijama
        [HttpGet]
        [Route("getallrecords")]
        public List<All> GetAllRecords()
        {
            return this.recordBusiness.GetAllRecords();
        }

        //pozivanje preko rute za izmenu evidencije u bazi - Ovo nam nece trebati ali neka je
        [HttpPut]
        [Route("updaterecord")]
        public bool UpdateRecord(Record r)
        {
            return this.recordBusiness.UpdateRecord(r);
        }
    }
}
