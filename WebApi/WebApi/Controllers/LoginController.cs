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
    [RoutePrefix("api/portal/login")]
    public class LoginController : ApiController
    {

        private IOwnerBusiness ownerBusiness;

        public LoginController(IOwnerBusiness ownerBusiness)
        {
            this.ownerBusiness = ownerBusiness;
        }

        [Route("{username}/{password}")]
        public List<Owner> GetOwner(string username, string password)
        {
            return this.ownerBusiness.Login(username, password);
        }
    }
}
