using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CityRepository : ICityRepository
    {
        //konekcioni string
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        //metoda za vracanje svih gradova
        public List<City> GetAllCities()
        {
            List<City> listToReturn = new List<City>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM Cities";
                
                SqlDataReader dataReader = command.ExecuteReader();
                
                while (dataReader.Read())
                {
                    City c = new City();
                    c.City_Id = dataReader.GetInt32(0);
                    c.City_Name = dataReader.GetString(1);
                    c.Ppt = dataReader.GetInt32(2);
                    listToReturn.Add(c);
                }
            }
            return listToReturn;
        }

        //metoda za ubacivanje u tabelu gradova
        public int InsertCities(City c)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Cities VALUES ('" +
                    c.City_Name + "', '" +
                    c.Ppt +"')";
                
                return command.ExecuteNonQuery();
            }
        }

        //metoda za update gradova
        public int UpdateCities(City c)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Students SET"
                    + " Name= '" + c.City_Name + "'"
                    + ", Ppt= '" + c.Ppt + "'"
                    + "WHERE City_Id=" + c.City_Id;
                
                return command.ExecuteNonQuery();
            }
        }



    }
}
