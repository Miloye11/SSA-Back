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
                    a.Status = dataReader.GetString(3);
                    object temp0 = dataReader.GetValue(4);
                    if (temp0.ToString().Equals(""))
                    {
                        a.Type_Id = -1;

                    }
                    else
                    {
                        a.Type_Id = dataReader.GetInt32(4);
                    }
                    object tem = dataReader.GetValue(5);
                    
                    if (tem.ToString().Equals("") )
                   {
                        a.City_Id = -1;

                 }
                   else
                   {
                     a.City_Id = dataReader.GetInt32(5);
                  }
                    object temp1 = dataReader.GetValue(6);
                    if (temp1.ToString().Equals(""))
                    {
                        a.Owner_Id = -1;
                    }
                    else
                    {
                        a.Owner_Id = dataReader.GetInt32(6);
                    }


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
                command.CommandText = "INSERT INTO Apartments VALUES ('" + a.Address + "', " + a.Apartment_Number + ", '" + a.Status + "', " + a.Type_Id + ", " + a.City_Id + ", " + a.Owner_Id + ")";

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
                command.CommandText = "UPDATE Apartments SET Address ='" + a.Address + "', Apartment_Number=" + a.Apartment_Number + ", Status = '" + a.Status + "', Type_Id = " + a.Type_Id + ", City_Id=" + a.City_Id + ", Owner_Id=" + a.Owner_Id + " WHERE Apartment_Id  = " + a.Apartment_Id + " ";

                return command.ExecuteNonQuery();
            }
        }
        // metoda za delte jednog stana prema ID-u u tabeli Apartements
        public int DeleteApartement (int id)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "DELETE FROM Apartments WHERE Apartment_Id=" + id;
             return    command.ExecuteNonQuery();
               

            }
        }


        //----------------  DEO ZA UPDATE RECORDS!  --------------------------------------------------------------

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

        //----------------  DEO ZA UPDATE RECORDS!  --------------------------------------------------------------

        //Vraca stan i sve informacije o njemu (o gradu i o vlasniku)
        public List<All> GetAllApartmentsJoined()
        {
            List<All> list = new List<All>();

            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand(); // kreiranje SQL komande
                command.Connection = dataConnection;
                command.CommandText = "SELECT Apartments.Apartment_Id, Apartments.Address, Apartments.Apartment_Number, Apartments.City_Id, Cities.Name, Apartments.Owner_Id, Owners.Name, Owners.Surname, Types.Type_Id, Types.Name FROM Apartments, Owners, Cities, Types WHERE Apartments.City_Id = Cities.City_Id AND Apartments.Owner_Id = Owners.Owner_Id";

                // SQL data reader dobija vrednost virtuelne tabele koja je vraćena iz baze
                SqlDataReader dataReader = command.ExecuteReader();

                // za svaki red koji je dobijen na osnovu SQL SELECT upita
                // kreirati klasu Student, dodeliti joj vrednosti i ubaciti je u listu
                while (dataReader.Read())
                {
                    All a = new All();

                    a.Apartment_Id = dataReader.GetInt32(0);
                    a.Address = dataReader.GetString(1);
                    a.Apartment_Number = dataReader.GetInt32(2);
                    a.City_Id = dataReader.GetInt32(3);
                    a.City_Name = dataReader.GetString(4);
                    a.Owner_Id = dataReader.GetInt32(5);
                    a.Owner_Name = dataReader.GetString(6);
                    a.Owner_Surname = dataReader.GetString(7);
                    a.Type_Id = dataReader.GetInt32(8);
                    a.Type_Name = dataReader.GetString(9);
                  
                   
                    list.Add(a);
                }
            }
            return list;
        }

    }
}