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
   public class PersonRepository : IPersonRepository
    {
        //konekcioni string
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        //metoda za prikaz svih osoba iz tabele Persons
        public List<Person> GetAllPersons()
        {
            List<Person> listToReturn = new List<Person>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM Persons";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Person p = new Person();
                    p.Person_Id = dataReader.GetInt32(0);
                    p.Name = dataReader.GetString(1);
                    p.Surname = dataReader.GetString(2);
                    p.JMBG = dataReader.GetString(3);
                    p.Card_Number = dataReader.GetInt32(4);
                    listToReturn.Add(p);
                }
            }
            return listToReturn;
        }


        //metoda za ubacivanje nove osobe u tabelu Persons
        public int InsertPerson(Person p)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Persons VALUES ('" + p.Name + "', '" + p.Surname + "', '" + p.JMBG + "'," + p.Card_Number + ")";

                return command.ExecuteNonQuery();
            }
        }


        //metoda za update/azuriranje osoba u tabeli Persons
        public int UpdatePerson(Person p)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Persons SET Name ='" + p.Name + "', Surname='" + p.Surname + "', JMBG = '" + p.JMBG + "', Card_Number = " + p.Card_Number + " WHERE Person_Id = " + p.Person_Id + " ";

                return command.ExecuteNonQuery();
            }
        }

    }
}
