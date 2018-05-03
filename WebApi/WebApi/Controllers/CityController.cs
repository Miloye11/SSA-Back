using BussinesLayer;
using DataLayer.Models;
using System.Collections.Generic;
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

        [Route("getallcitynames")]
        public List<City> GetAllCityNames()
        {
            return this.cityBusiness.GetAllCityNames();
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