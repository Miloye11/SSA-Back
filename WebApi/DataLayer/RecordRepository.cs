﻿/*-------------------------------- RADIO STEFAN DJUSIC ------------------------------------*/
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
    public class RecordRepository : IRecordRepository
    {
        private string ConnectionString;

        public RecordRepository()
        {
            this.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        //kreiranje sql upita za vracanje svih potrebnih podataka iz baze za RECORD 
        public List<All> GetAllRecords()
        {
            List<All> list = new List<All>();

            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand(); // kreiranje SQL komande
                command.Connection = dataConnection;
                command.CommandText = "SELECT Records.Status, Records.Date_Time, Cities.Ppt, Cities.Name, Apartments.Address, Apartments.Apartment_Number, Apartments.Status, Types.Name, Persons.Name, Persons.Surname, Persons.Card_Number, Persons.JMBG, Apartments.Owner_Name, Apartments.Owner_Surname FROM Records JOIN Persons ON Records.Person_Id = Persons.Person_Id JOIN Apartments ON Records.Apartment_Id = Apartments.Apartment_Id JOIN Cities ON Apartments.City_Id = Cities.City_Id JOIN Types ON Apartments.Type_Id = Types.Type_Id";

                // SQL data reader dobija vrednost virtuelne tabele koja je vraćena iz baze
                SqlDataReader dataReader = command.ExecuteReader();

                // za svaki red koji je dobijen na osnovu SQL SELECT upita
                // kreirati klasu Student, dodeliti joj vrednosti i ubaciti je u listu
                while (dataReader.Read())
                {
                    All a = new All();

                    a.Record_Status = dataReader.GetString(0);
                    a.Date_Time = dataReader.GetDateTime(1);
                    a.Ppt = dataReader.GetInt32(2);
                    a.City_Name = dataReader.GetString(3);
                    a.Address = dataReader.GetString(4);
                    a.Apartment_Number = dataReader.GetInt32(5);
                    a.Appartment_Status = dataReader.GetString(6);
                    a.Type_Name = dataReader.GetString(7);
                    a.Person_Name = dataReader.GetString(8);
                    a.Person_Surname = dataReader.GetString(9);
                    a.Card_Number = dataReader.GetInt32(10);
                    a.JMBG = dataReader.GetString(11);
                    a.Owner_Name = dataReader.GetString(12);
                    a.Owner_Surname = dataReader.GetString(13);

                    list.Add(a);
                }
            }
            return list;
        }

        //METODA KOJU JE RADILA DJINA ZA INSERT!!!
        public List<Record> GetMaxRecords(int ID)
        {
            List<Record> list = new List<Record>();

            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand(); // kreiranje SQL komande
                command.Connection = dataConnection;
                command.CommandText = "SELECT status, MAX (date_time) FROM Records WHERE Person_Id =" + ID + "GROUP BY status";

                // SQL data reader dobija vrednost virtuelne tabele koja je vraćena iz baze
                SqlDataReader dataReader = command.ExecuteReader();

                // za svaki red koji je dobijen na osnovu SQL SELECT upita
                // kreirati klasu Student, dodeliti joj vrednosti i ubaciti je u listu
                while (dataReader.Read())
                {
                    Record a = new Record();
                    a.Record_Status = dataReader.GetString(0);
                    a.Date_Time = dataReader.GetDateTime(1);
                    list.Add(a);
                }
            }
            return list;
        }
        
        //kreiranje metode za unos novog RECORD-A u bazu - * * - DJINA IZMENILA OVU METODU
        public int InsertRecord(Record r)
        {
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                //DJINA DODALA OVE LINIJE KODA
                List<Record> list = new List<Record>();
                list = GetMaxRecords(r.P_Person_Id);
                if (list.Count > 0)
                {
                    Record r1 = new Record();
                    Record r2 = new Record();
                    r1 = list.First();
                    r2 = list.Last();
                    string stat;

                    if (r1.Date_Time > r2.Date_Time)
                        stat = r1.Record_Status;
                    else
                        stat = r2.Record_Status;

                    if (r.Record_Status == stat)
                        return 0;
                }

                dataConnection.Open();

                SqlCommand command = new SqlCommand(); // kreiranje SQL komande
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Records VALUES('" + DateTime.Now + "', '" + r.Record_Status + "', " + r.P_Person_Id + ", " + r.A_Apartment_Id + ")";

                // SQL data reader dobija vrednost virtuelne tabele koja je vraćena iz baze
                return command.ExecuteNonQuery();
            }
        }

        //kreiranje metode za azuriranje evidencije u bazi. Menja se status evidencije kao i vreme izmene evidencije po njenom ID-ju!!
        public int UpdateRecord(Record r)
        {
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand(); // kreiranje SQL komande
                command.Connection = dataConnection;// ------------------PITATI I PROVERITI KAKO SE RADI UPDATE, DAL SE OVDE PISE ULAZ/IZLAZ ILI U POSTMANU!?
                command.CommandText = "UPDATE Records SET Date_Time = '" + DateTime.Now + "', Status = '" + r.Record_Status + "' WHERE Record_Id = " + r.Record_Id + "";

                // SQL data reader dobija vrednost virtuelne tabele koja je vraćena iz baze
                return command.ExecuteNonQuery();
            }
        }
    }
}
