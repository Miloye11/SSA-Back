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
    [RoutePrefix("api/portal/logeduser")]
    public class LogedUserController : ApiController
    {
        private ILogedUserBusiness LogedUserBusines;

        public LogedUserController(ILogedUserBusiness logedUserBusiness)
        {
            this.LogedUserBusines = logedUserBusiness;
        }

        [Route("getuser")]
        public List<LogedUser> GetUser()
        {
            return this.LogedUserBusines.GetLogedUser();
        }


        [Route("insertlogeduser")]
        [HttpPost]
        public bool InsertLogedUser([FromBody] Owner o)
        {
            return this.LogedUserBusines.InsertUser(o);
        }

        [Route("trancatelogeduser")]
        [HttpGet]
        public bool TrancateLogedUser()
        {
            return this.LogedUserBusines.TrancadeLogedUser();
        }

    }
}
