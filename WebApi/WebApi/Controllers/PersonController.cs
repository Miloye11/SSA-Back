using BussinesLayer;
using DataLayer.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/portal/persons")]
    public class PersonController : ApiController
    {
        private IPersonBusiness personBusiness;

        public PersonController(IPersonBusiness personBusiness)
        {
            this.personBusiness = personBusiness;
        }

        [Route("getallpersons")]
        public List<Person> GetAllPersons()
        {
            return this.personBusiness.GetAllPersons();
        }

        [Route("insertperson")]
        [HttpPost]
        public bool InsertPerson([FromBody]Person p)
        {
            return this.personBusiness.InsertPerson(p);
        }

        [Route("updateperson")]
        [HttpPut]
        public bool UpdatePerson([FromBody]Person p)
        {
            return this.personBusiness.UpdatePerson(p);
        }
    }
}