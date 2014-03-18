using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BoatRental.Model.DAL
{
    public class BokningDAL : DALBase
    {
        public void DeleteBokning(int bokningID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    //Skapar ett SQl objekt som används för att exekvera en lagrade procedur.
                    var cmd = new SqlCommand("appSchema.usp_DeleteBooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de parametrar som behövs.
                    cmd.Parameters.Add("@BokningID", SqlDbType.Int, 4).Value = bokningID;

                    //Öppnar anslutningen.
                    conn.Open();

                    //Exekverar den lagrade proceduren. Vi kan använda denna metoden då inga poster returneras.
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ArgumentException("Error in BokningDAL DeleteBokning.");
                }
            }
        }

        public Bokning GetBokning(int bokningID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    //Skapar ett SQl objekt som används för att exekvera en lagrade procedur.
                    var cmd = new SqlCommand("appSchema.usp_GetBokning", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de parametrar som behövs.
                    cmd.Parameters.Add("@BokningID", SqlDbType.Int, 4).Value = bokningID;

                    //Öppnar anslutningen.
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Läser in data
                            var iBokningID = reader.GetOrdinal("BokningID");
                            var iKundID = reader.GetOrdinal("KundID");
                            var iBåtplID = reader.GetOrdinal("BåtplID");
                            var iStart = reader.GetOrdinal("StartDatum");
                            var iSlut = reader.GetOrdinal("SlutDatum");

                            //Lägger till data i ett nytt objekt och returnerar det.
                            return new Bokning
                            {
                                BokningID = reader.GetInt32(iBokningID),
                                KundID = reader.GetInt32(iKundID),
                                BåtplID = reader.GetInt32(iBåtplID),
                                StartDatum = reader.GetDateTime(iStart),
                                SlutDatum = reader.GetDateTime(iSlut)

                            };
                        }
                        throw new ApplicationException("Det gick inte att hitta någon kund!");
                    }
                }
                catch
                {
                    throw new ApplicationException("Error in KundDAL GetKund");
                }

            }
        }

        public IEnumerable<Bokning> GetBokningPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var bokningar = new List<Bokning>(maximumRows);

                    //Skapar ett SQl objekt som används för att exekvera en lagrade procedur.
                    var cmd = new SqlCommand("appSchema.usp_GetBokningarPageWise", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de parametrar som krävs.
                    cmd.Parameters.Add("@PageIndex", SqlDbType.Int, 4).Value = startRowIndex / maximumRows + 1;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int, 4).Value = maximumRows;
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    //Öppnar anslutningen.
                    conn.Open();

                    //Exekverar den lagrade proceduren. Vi kan använda denna metoden då inga poster returneras.
                    cmd.ExecuteNonQuery();

                    //Lägger till parametern som hämtades till kund objektet.
                    totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;

                    using (var reader = cmd.ExecuteReader())
                    {
                        //Läser in data
                        var iBokningID = reader.GetOrdinal("BokningID");
                        var iKundID = reader.GetOrdinal("KundID");
                        var iBåtplID = reader.GetOrdinal("BåtplID");
                        var iStart = reader.GetOrdinal("StartDatum");
                        var iSlut = reader.GetOrdinal("SlutDatum");

                        while (reader.Read())
                        {
                            //Lägger till data i ett nytt objekt.
                            bokningar.Add(new Bokning
                            {
                                BokningID = reader.GetInt32(iBokningID),
                                KundID = reader.GetInt32(iKundID),
                                BåtplID = reader.GetInt32(iBåtplID),
                                StartDatum = reader.GetDateTime(iStart),
                                SlutDatum = reader.GetDateTime(iSlut)
                            });
                        }
                    }
                    //Tar bort onödiga platser i listan, sparar minne
                    bokningar.TrimExcess();

                    return bokningar;
                }
                catch
                {
                    throw new ApplicationException("Error in BokningDAL GetBokningPageWise");
                }
            }
        }

        public void InsertBokning(Bokning bokning, int ID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    //Skapar ett SQl objekt som används för att exekvera en lagrade procedur.
                    var cmd = new SqlCommand("appSchema.usp_AddBooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de parametrar som behövs.
                    cmd.Parameters.Add("@KundID", SqlDbType.Int, 4).Value = ID;
                    cmd.Parameters.Add("@BåtplID", SqlDbType.Int, 4).Value = bokning.BåtplID;
                    cmd.Parameters.Add("@Start", SqlDbType.DateTime).Value = bokning.StartDatum;
                    cmd.Parameters.Add("@Slut", SqlDbType.DateTime).Value = bokning.SlutDatum;

                    //Speciell parameter som hämtas efter proceduren har exekverats.
                    cmd.Parameters.Add("@BokningID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    //Öppnar anslutningen.
                    conn.Open();

                    //Exekverar den lagrade proceduren. Vi kan använda denna metoden då inga poster returneras.
                    cmd.ExecuteNonQuery();

                    //Lägger till parametern som hämtades till kund objektet.
                    bokning.BokningID = (int)cmd.Parameters["@BokningID"].Value;
                }
                catch
                {
                    throw new ArgumentException("Error in BokningDAL InsertBokning.");
                }
            }
        }

        public void UpdateBokning(Bokning bokning)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    //Skapar ett SQl objekt som används för att exekvera en lagrade procedur.
                    var cmd = new SqlCommand("appSchema.usp_UpdateBooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de parametrar som behövs.
                    cmd.Parameters.Add("@BokningID", SqlDbType.Int, 4).Value = bokning.BokningID;
                    cmd.Parameters.Add("@BåtplID", SqlDbType.Int, 4).Value = bokning.BåtplID;
                    cmd.Parameters.Add("@Start", SqlDbType.DateTime).Value = bokning.StartDatum;
                    cmd.Parameters.Add("@Slut", SqlDbType.DateTime).Value = bokning.SlutDatum;

                    //Öppnar anslutningen.
                    conn.Open();

                    //Exekverar den lagrade proceduren. Vi kan använda denna metoden då inga poster returneras.
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ArgumentException("Error in BokningDAL UpdateBokning.");
                }
            }
        }
    }
}