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
   public class OwnerRepository : IOwnerRepository
    {
        //konekcioni string
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        //metoda za prikaz svih osoba iz tabele Owners
        public List<Owner> GetAllOwners()
        {
            List<Owner> listToReturn = new List<Owner>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM Owners";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Owner o = new Owner();
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
        public int InsertOwner(Owner o)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Owners VALUES ('" + o.Name + "', '" + o.Surname + "', '" + o.JMBG + "'," + o.Card_Number + ",'" + o.Username + "', '" + o.Password + "')";

                return command.ExecuteNonQuery();
            }
        }

        //metoda za update/azuriranje osoba u tabeli Owners
        public int UpdateOwner(Owner o)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Owners SET Name ='" + o.Name + "', Surname='" + o.Surname + "', JMBG = '" + o.JMBG + "', Card_Number = " + o.Card_Number + ", Username = '" + o.Username + "', Password = '" + o.Password + "' WHERE Owner_Id = " + o.Owner_Id + " ";

                return command.ExecuteNonQuery();
            }
        }
    }
}
