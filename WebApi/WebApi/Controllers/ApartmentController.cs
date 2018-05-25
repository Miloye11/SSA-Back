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
    [RoutePrefix("api/portal/apartments")]
    public class ApartmentController : ApiController
    {

        private IApartmentBusiness apartmentBusiness;

        public ApartmentController(IApartmentBusiness apartmentBusiness)
        {
            this.apartmentBusiness = apartmentBusiness;
        }

        [Route("getallapartments")]
        public List<Apartment> GetAllPersons()
        {
            return this.apartmentBusiness.GetAllApartments();
        }
        [Route("getallapartmentsjoined")]
        [HttpGet]
        public List<All> GetAllApartmentsJoined()
        {
            return this.apartmentBusiness.GetAllApartmentsJoined();
        }

        [Route("insertapartment")]
        [HttpPost]
        public bool InsertApartment([FromBody]Apartment a)
        {
            return this.apartmentBusiness.InsertApartment(a);
        }

        [Route("updateapartment")]
        [HttpPut]
        public bool UpdateApartment([FromBody]Apartment a)
        {
            return this.apartmentBusiness.UpdateApartment(a);
        }
        [Route("deleteapartment/{id}")]
        [HttpGet]
        public bool DeleteApartment(int id)
        {
            return this.apartmentBusiness.DeleteApartement(id);
        }
    }
}
