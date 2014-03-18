using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace BoatRental.Model.DAL
{
    public class KundDAL : DALBase
    {
        public void DeleteKund(int kundID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    //Skapar ett SQl objekt som används för att exekvera en lagrade procedur.
                    var cmd = new SqlCommand("appSchema.usp_DeleteKund", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de parametrar som behövs.
                    cmd.Parameters.Add("@KundID", SqlDbType.Int, 4).Value = kundID;

                    //Öppnar anslutningen.
                    conn.Open();

                    //Exekverar den lagrade proceduren. Vi kan använda denna metoden då inga poster returneras.
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Error in KundDAL DeleteKund.");
                }
            }
        }

        public Kund GetKund(int kundID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    //Skapar ett SQl objekt som används för att exekvera en lagrade procedur.
                    var cmd = new SqlCommand("appSchema.usp_GetKund", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de parametrar som behövs.
                    cmd.Parameters.Add("@KundID", SqlDbType.Int, 4).Value = kundID;

                    //Öppnar anslutningen.
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Läser in data
                            var iKundID = reader.GetOrdinal("KundID");
                            var iNamn = reader.GetOrdinal("Namn");
                            var iTelefonnummer = reader.GetOrdinal("Telefonnummer");
                            var iAddress = reader.GetOrdinal("Address");
                            var iMail = reader.GetOrdinal("E-Mail");
                            var iMedlemskapID = reader.GetOrdinal("MedlemskapID");

                            //Lägger till data i ett nytt objekt och returnerar det.
                            return new Kund
                            {
                                KundID = reader.GetInt32(iKundID),
                                Namn = reader.GetString(iNamn),
                                Telefonnummer = reader.GetString(iTelefonnummer),
                                Address = reader.GetString(iAddress),
                                E_Mail = reader.GetString(iMail),
                                MedlemskapID = reader.GetInt32(iMedlemskapID)
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

        public IEnumerable<Kund> GetKundPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var kunder = new List<Kund>(maximumRows);

                    //Skapar ett SQl objekt som används för att exekvera en lagrade procedur.
                    var cmd = new SqlCommand("appSchema.usp_GetKundPageWise", conn);
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
                        var iKundID = reader.GetOrdinal("KundID");
                        var iNamn = reader.GetOrdinal("Namn");
                        var iTelefonnummer = reader.GetOrdinal("Telefonnummer");
                        var iAddress = reader.GetOrdinal("Address");
                        var iMail = reader.GetOrdinal("E-Mail");
                        var iMedlemskapID = reader.GetOrdinal("MedlemskapID");

                        while (reader.Read())
                        {
                            //Lägger till data i ett nytt objekt.
                            kunder.Add(new Kund
                            {
                                KundID = reader.GetInt32(iKundID),
                                Namn = reader.GetString(iNamn),
                                Telefonnummer = reader.GetString(iTelefonnummer),
                                Address = reader.GetString(iAddress),
                                E_Mail = reader.GetString(iMail),
                                MedlemskapID = reader.GetInt32(iMedlemskapID)
                            });
                        }
                    }
                    //Tar bort onödiga platser i listan, sparar minne
                    kunder.TrimExcess();

                    return kunder;
                }
                catch
                {
                    throw new ApplicationException("Error in KundDAL GetKunder");
                }
            }
        }

        public IEnumerable<Kund> GetKunder()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var kunder = new List<Kund>(60);

                    var cmd = new SqlCommand("appSchema.usp_GetKunder", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {

                        var iKundID = reader.GetOrdinal("KundID");
                        var iNamn = reader.GetOrdinal("Namn");
                        var iTelefonnummer = reader.GetOrdinal("Telefonnummer");
                        var iAddress = reader.GetOrdinal("Address");
                        var iMail = reader.GetOrdinal("E-Mail");
                        var iMedlemskapID = reader.GetOrdinal("MedlemskapID");

                        while (reader.Read())
                        {
                            kunder.Add(new Kund
                            {
                                KundID = reader.GetInt32(iKundID),
                                Namn = reader.GetString(iNamn),
                                Telefonnummer = reader.GetString(iTelefonnummer),
                                Address = reader.GetString(iAddress),
                                E_Mail = reader.GetString(iMail),
                                MedlemskapID = reader.GetInt32(iMedlemskapID)
                            });
                        }
                    }
                    kunder.TrimExcess();

                    return kunder;
                }
                catch 
                {
                    throw new ApplicationException("Error in KundDAL GetKunder");
                }
            }
        }

        public void InsertKund(Kund kund)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    //Skapar ett SQl objekt som används för att exekvera en lagrade procedur.
                    var cmd = new SqlCommand("appSchema.usp_AddKund", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de parametrar som krävs.
                    cmd.Parameters.Add("@Namn", SqlDbType.VarChar, 30).Value = kund.Namn;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar, 20).Value = kund.Address;
                    cmd.Parameters.Add("@Telefonnummer", SqlDbType.VarChar, 16).Value = kund.Telefonnummer;
                    cmd.Parameters.Add("@Mail", SqlDbType.VarChar, 50).Value = kund.E_Mail;
                    cmd.Parameters.Add("MedlemskapID", SqlDbType.Int, 4).Value = 1;

                    //Speciell parameter som hämtas efter proceduren har exekverats.
                    cmd.Parameters.Add("@KundID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    //Öppnar anslutningen.
                    conn.Open();

                    //Exekverar den lagrade proceduren. Vi kan använda denna metoden då inga poster returneras.
                    cmd.ExecuteNonQuery();

                    //Lägger till parametern som hämtades till kund objektet.
                    kund.KundID = (int)cmd.Parameters["@KundID"].Value;
                }
                catch
                {
                    throw new ApplicationException("Error in KundDAL InsertKund.");
                }
            }
        }

        public void UpdateKund(Kund kund)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    //Skapar ett SQl objekt som används för att exekvera en lagrade procedur.
                    var cmd = new SqlCommand("appSchema.usp_UpdateKund", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de parametrar som krävs.
                    cmd.Parameters.Add("@KundID", SqlDbType.Int, 4).Value = kund.KundID;
                    cmd.Parameters.Add("@Namn", SqlDbType.VarChar, 30).Value = kund.Namn;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar, 20).Value = kund.Address;
                    cmd.Parameters.Add("@Telefonnummer", SqlDbType.VarChar, 16).Value = kund.Telefonnummer;
                    cmd.Parameters.Add("@Mail", SqlDbType.VarChar, 50).Value = kund.E_Mail;
                    cmd.Parameters.Add("@MedlemskapID", SqlDbType.Int, 4).Value = kund.MedlemskapID;

                    //Öppnar anslutningen.
                    conn.Open();

                    //Exekverar den lagrade proceduren. Vi kan använda denna metoden då inga poster returneras.
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Error in KundDAL UpdateKund");
                }
            }
        }
    }
}