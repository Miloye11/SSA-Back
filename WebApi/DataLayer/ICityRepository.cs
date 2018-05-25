using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface ICityRepository
    {
        List<City> GetAllCities();

        int InsertCities(City c);

        int UpdateCities(City c);

        List<City> GetAllCityNames();

        int DeleteCities(int id);
    }
}