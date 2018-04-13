﻿using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
