using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public interface ICityBusiness
    {
        List<City> GetAllCities();

        bool InsertCities(City c);

        bool UpdateCities(City c);
    }
}
