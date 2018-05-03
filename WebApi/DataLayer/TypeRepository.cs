using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class TypeRepository : ITypeRepository
    {
        //konekcioni string
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        //metoda za vracanje svih tipova
        public List<DataLayer.Models.Type> GetAllTypes()
        {
            List<DataLayer.Models.Type> listToReturn = new List<DataLayer.Models.Type>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM Types";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    DataLayer.Models.Type t = new DataLayer.Models.Type();
                    t.Type_Id = dataReader.GetInt32(0);
                    t.Type_Name = dataReader.GetString(1);
                    listToReturn.Add(t);
                }
            }
            return listToReturn;
        }

        //metoda za vracanje imena tipova
        public List<DataLayer.Models.Type> GetAllTypeNames()
        {
            List<DataLayer.Models.Type> listToReturn = new List<DataLayer.Models.Type>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT Name FROM Types";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    DataLayer.Models.Type t = new DataLayer.Models.Type();
                    t.Type_Name = dataReader.GetString(0);
                    listToReturn.Add(t);
                }
            }
            return listToReturn;
        }

        //metoda za ubacivanje u tabelu tipovi
        public int InsertTypes(DataLayer.Models.Type t)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Types VALUES ('" +
                    t.Type_Name + "')";

                return command.ExecuteNonQuery();
            }
        }

        //metoda za update tipova
        public int UpdateTypes(DataLayer.Models.Type t)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Types SET"
                    + " Name= '" + t.Type_Name + "'"
                    + "WHERE Type_Id=" + t.Type_Id;

                return command.ExecuteNonQuery();
            }
        }
    }
}