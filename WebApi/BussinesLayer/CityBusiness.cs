using DataLayer;
using DataLayer.Models;
using System.Collections.Generic;

namespace BussinesLayer
{
    public class CityBusiness : ICityBusiness
    {
        private ICityRepository cityRepository;

        public CityBusiness(CityRepository cityRepository)
        {
            // inicijalizacija repozitorijuma "ubrizgavanjem" kroz konstruktor
            this.cityRepository = cityRepository;
        }

        // metoda koja vraća listu svih gradova ako ih uopšte ima u bazi
        public List<City> GetAllCities()
        {
            List<City> cities = this.cityRepository.GetAllCities();
            if (cities.Count > 0)
            {
                return cities;
            }
            else
            {
                return null;
            }
        }

        // metoda koja vraća listu imena svih gradova ako ih uopšte ima u bazi
        public List<City> GetAllCityNames()
        {
            List<City> cities = this.cityRepository.GetAllCityNames();
            if (cities.Count > 0)
            {
                return cities;
            }
            else
            {
                return null;
            }
        }

        //metoda koja ubacuje podatke u tabelu gradova
        public bool InsertCities(City c)
        {
            if (this.cityRepository.InsertCities(c) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //metoda koja vrsi update tabele gradova
        public bool UpdateCities(City c)
        {
            bool result = false;
            if (c.City_Id != 0 && this.cityRepository.UpdateCities(c) > 0)
            {
                result = true;
            }
            return result;
        }
        //metoda koja brise jedan grad iz table Cities
        public bool DeleteCities (int id)
        {
           if (id>0)
            {
                if (this.cityRepository.DeleteCities(id) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
             }
                else
                {
                    return false;
                }
        }
    }
}