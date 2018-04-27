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
    [RoutePrefix("api/portal/owners")]
    public class OwnerController : ApiController
    {
        private IOwnerBusiness ownerBusiness;

        public OwnerController(IOwnerBusiness ownerBusiness)
        {
            this.ownerBusiness = ownerBusiness;
        }

        [Route("getallowners")]
        public List<Owner> GetAllOwners()
        {
            return this.ownerBusiness.GetAllOwners();
        }

        [Route("insertowner")]
        [HttpPost]
        public bool InsertOwner([FromBody]Owner o)
        {
            return this.ownerBusiness.InsertOwner(o);
        }

        [Route("updateowner")]
        [HttpPut]
        public bool UpdateOwner([FromBody]Owner o)
        {
            return this.ownerBusiness.UpdateOwner(o);
        }

    }
}
