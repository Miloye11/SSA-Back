using DataLayer.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ApartmentRepository : IApartmentRepository
    {
        //konekcioni string
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        //metoda za prikaz svih stanova iz tabele Apartmant
        public List<Apartment> GetAllApartments()
        {
            List<Apartment> listToReturn = new List<Apartment>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM Apartments";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Apartment a = new Apartment();
                    a.Apartment_Id = dataReader.GetInt32(0);
                    a.Address = dataReader.GetString(1);
                    a.Apartment_Number = dataReader.GetInt32(2);
                    a.Owner_Name = dataReader.GetString(3);
                    a.Owner_Surname = dataReader.GetString(4);
                    a.Status = dataReader.GetString(5);
                    a.Type_Id = dataReader.GetInt32(6);
                    a.City_Id = dataReader.GetInt32(7);
                    listToReturn.Add(a);
                }
            }
            return listToReturn;
        }

        //metoda za ubacivanje novog stana u tabelu Apartments
        public int InsertApartment(Apartment a)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Apartments VALUES ('" + a.Address + "', " + a.Apartment_Number + ", '" + a.Owner_Name + "','" + a.Owner_Surname + "', '" + a.Status + "', " + a.Type_Id + ", " + a.City_Id + ")";

                return command.ExecuteNonQuery();
            }
        }

        //metoda za update/azuriranje stana u tabeli Apartments
        public int UpdateApartment(Apartment a)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Apartments SET Address ='" + a.Address + "', Apartment_Number=" + a.Apartment_Number + ", Owner_Name = '" + a.Owner_Name + "', Owner_Surname = '" + a.Owner_Surname + "', Status = '" + a.Status + "', Type_Id = " + a.Type_Id + ", City_Id=" + a.City_Id + " WHERE Apartment_Id  = " + a.Apartment_Id + " ";

                return command.ExecuteNonQuery();
            }
        }

        //----------------  DEO KOJI RADI DJUSIC!  --------------------------------------------------------------

        //metoda za update statusa stana na SLOBODAN kada se izvrsi insert u RECORD
        public int UpdateAppartementSlobodan(int Apartment_Id)
        {
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand(); // kreiranje SQL komande
                command.Connection = dataConnection;// ------------------PITATI I PROVERITI KAKO SE RADI UPDATE, DAL SE OVDE PISE ULAZ/IZLAZ ILI U POSTMANU!?
                command.CommandText = "UPDATE Apartments SET Status = 'Slobodan' WHERE Apartment_Id = " + Apartment_Id + "";

                // SQL data reader dobija vrednost virtuelne tabele koja je vraćena iz baze
                return command.ExecuteNonQuery();
            }
        }

        //metoda za update statusa stana na Zauzeto kada se izvrsi insert u records za istu osobu
        public int UpdateAppartementZauzet(int Apartment_Id)
        {
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand(); // kreiranje SQL komande
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Apartments SET Status = 'Zauzet' WHERE Apartment_Id = " + Apartment_Id + "";

                // SQL data reader dobija vrednost virtuelne tabele koja je vraćena iz baze
                return command.ExecuteNonQuery();
            }
        }

        //----------------  DEO KOJI RADI DJUSIC!  --------------------------------------------------------------

    }
}