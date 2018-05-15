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
   public class LogedUserRepository : ILogedUser
    {
        //konekcioni string
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        //metoda za prikaz svih osoba iz tabele Owners
        public List<LogedUser> GetLogedUser()
        {
            List<LogedUser> listToReturn = new List<LogedUser>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM LogedUsers";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    LogedUser o = new LogedUser();
                    o.Owner_Id = dataReader.GetInt32(0);
                    o.Name = dataReader.GetString(1);
                    o.Surname = dataReader.GetString(2);
                    o.JMBG = dataReader.GetString(3);
                    o.Card_Number = dataReader.GetInt32(4);
                    o.Username = dataReader.GetString(5);
                    o.Password = dataReader.GetString(6);
                    listToReturn.Add(o);
                }
            }
            return listToReturn;
        }


        //metoda za ubacivanje nove osobe u tabelu Owners
        public int InsertUser (Owner o)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO LogedUsers VALUES ("+ o.Owner_Id+ ",'" + o.Name + "', '" + o.Surname + "', '" + o.JMBG + "'," + o.Card_Number + ",'" + o.Username + "', '" + o.Password + "')";

                return command.ExecuteNonQuery();
            }
        }

        public int TrancadeLogedUser ()
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "DELETE FROM LogedUsers";

                return command.ExecuteNonQuery();
            }
        }
    }
}
