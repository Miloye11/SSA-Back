﻿using BussinesLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/portal/cities")]
    public class CityController : ApiController
    {
        private ICityBusiness cityBusiness;

        public CityController(ICityBusiness cityBusiness)
        {
            this.cityBusiness = cityBusiness;
        }
        
        [Route("getallcities")]
        public List<City> GetAllCities()
        {
            return this.cityBusiness.GetAllCities();
        }
        
        [Route("insertcities")]
        [HttpPost]
        public bool InsertCities([FromBody]City c)
        {
            return this.cityBusiness.InsertCities(c);
        }
        
        [Route("updatecities")]
        [HttpPut]
        public bool UpdateCities([FromBody]City c)
        {
            return this.cityBusiness.UpdateCities(c);
        }
        

    }
}
