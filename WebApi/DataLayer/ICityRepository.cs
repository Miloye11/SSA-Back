using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ICityRepository
    {
        List<City> GetAllCities();

        int InsertCities(City c);

        int UpdateCities(City c);
    }
}
