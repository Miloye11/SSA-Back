using DataLayer.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

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
                    if (c.City_Name != "izbrisan grad")
                    { listToReturn.Add(c); }
                   
                }
            }
            return listToReturn;
        }

        //metoda za vracanje svih imena gradova
        public List<City> GetAllCityNames()
        {
            List<City> listToReturn = new List<City>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT Name FROM Cities";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    City c = new City();
                    c.City_Name = dataReader.GetString(0);
                    if (c.City_Name != "izbrisan grad")
                    { listToReturn.Add(c); }
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
                    c.Ppt + "')";

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
                command.CommandText = "UPDATE Cities SET"
                    + " Name= '" + c.City_Name + "'"
                    + ", Ppt= '" + c.Ppt + "'"
                    + "WHERE City_Id=" + c.City_Id;

                return command.ExecuteNonQuery();
            }
        }

       public int DeleteCities(int id)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Cities set Name='izbrisan grad', Ppt=0 where City_Id=" + id;

                return command.ExecuteNonQuery();
            }
        }
    }
}