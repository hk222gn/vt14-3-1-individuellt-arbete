using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BoatRental.Model.DAL
{
    public class BatplatsDAL : DALBase
    {
        public IEnumerable<Batplats> GetBåtplatsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var båtplats = new List<Batplats>(maximumRows);

                    //Skapar ett SQl objekt som används för att exekvera en lagrade procedur.
                    var cmd = new SqlCommand("appSchema.usp_GetBåtplatsPageWise", conn);
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
                        var iBåtplID = reader.GetOrdinal("BåtplID");
                        var iDjupID = reader.GetOrdinal("DjupID");
                        var iBåtplatsnr = reader.GetOrdinal("Båtplatsnr");

                        while (reader.Read())
                        {
                            //Lägger till data i ett nytt objekt.
                            båtplats.Add(new Batplats
                            {
                                BåtplID = reader.GetInt32(iBåtplID),
                                DjupID = reader.GetInt32(iDjupID),
                                Båtplatsnr = reader.GetString(iBåtplatsnr)
                            });
                        }
                    }
                    //Tar bort onödiga platser i listan, sparar minne
                    båtplats.TrimExcess();

                    return båtplats;
                }
                catch
                {
                    throw new ApplicationException("Error in BåtplatsDAL GetBåtplatsPageWise");
                }
            }
        }

        public IEnumerable<Batplats> GetBatplatser()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var batplats = new List<Batplats>(40);

                    var cmd = new SqlCommand("appSchema.usp_GetBatplatser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {

                        var iBatplatsID = reader.GetOrdinal("BåtplID");
                        var iDjupID = reader.GetOrdinal("DjupID");
                        var iBatplatsnr = reader.GetOrdinal("Båtplatsnr");

                        while (reader.Read())
                        {
                            batplats.Add(new Batplats
                            {
                                BåtplID = reader.GetInt32(iBatplatsID),
                                DjupID = reader.GetInt32(iDjupID),
                                Båtplatsnr = reader.GetString(iBatplatsnr)
                            });
                        }
                    }
                    batplats.TrimExcess();

                    return batplats;
                }
                catch
                {
                    throw new ApplicationException("Error in BatplatsDAL GetBatplatser");
                }
            }
        }

        public Batplats GetBatplats(int batplID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    //Skapar ett SQl objekt som används för att exekvera en lagrade procedur.
                    var cmd = new SqlCommand("appSchema.usp_GetBåtplats", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Lägger till de parametrar som behövs.
                    cmd.Parameters.Add("@BåtplID", SqlDbType.Int, 4).Value = batplID;

                    //Öppnar anslutningen.
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Läser in data
                            var iBatplatsID = reader.GetOrdinal("BåtplID");
                            var iDjupID = reader.GetOrdinal("DjupID");
                            var iBatplatsnr = reader.GetOrdinal("Båtplatsnr");

                            //Lägger till data i ett nytt objekt och returnerar det.
                            return new Batplats
                            {
                                BåtplID = reader.GetInt32(iBatplatsID),
                                DjupID = reader.GetInt32(iDjupID),
                                Båtplatsnr = reader.GetString(iBatplatsnr)
                            };
                        }
                        throw new ApplicationException("Det gick inte att hitta någon båtplats!");
                    }
                }
                catch
                {
                    throw new ApplicationException("Error in BatplatsDAL GetBatplats");
                }

            }
        }
    }
}