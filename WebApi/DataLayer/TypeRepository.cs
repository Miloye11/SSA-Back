using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TypeRepository : ITypeRepository
    {
        //konekcioni string
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        //metoda za vracanje svih gradova
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

        //metoda za ubacivanje u tabelu gradova
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

        //metoda za update gradova
        public int UpdateTypes(DataLayer.Models.Type t)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Students SET"
                    + " Name= '" + t.Type_Name + "'"
                    + "WHERE City_Id=" + t.Type_Id;

                return command.ExecuteNonQuery();
            }
        }
    }
}
