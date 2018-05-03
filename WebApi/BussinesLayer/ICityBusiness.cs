using DataLayer.Models;
using System.Collections.Generic;

namespace BussinesLayer
{
    public interface ICityBusiness
    {
        List<City> GetAllCities();

        bool InsertCities(City c);

        bool UpdateCities(City c);

        List<City> GetAllCityNames();
    }
}