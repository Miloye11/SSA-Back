using BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/portal/types")]
    public class TypeController : ApiController
    {
        private ITypeBusiness typeBusiness;

        public TypeController(ITypeBusiness typeBusiness)
        {
            this.typeBusiness = typeBusiness;
        }

        [Route("getalltypes")]
        public List<DataLayer.Models.Type> GetAllTypes()
        {
            return this.typeBusiness.GetAllTypes();
        }

        [Route("inserttypes")]
        [HttpPost]
        public bool InsertTypes([FromBody]DataLayer.Models.Type t)
        {
            return this.typeBusiness.InsertTypes(t);
        }

        [Route("updatetypes")]
        [HttpPut]
        public bool UpdateTypes([FromBody]DataLayer.Models.Type t)
        {
            return this.typeBusiness.UpdateTypes(t);
        }
    }
}
