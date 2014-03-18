using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BoatRental.Model.DAL
{
    public class BåtplatsDAL : DALBase
    {
        public IEnumerable<Båtplats> GetBåtplatsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var båtplats = new List<Båtplats>(maximumRows);

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

                        while (reader.Read())
                        {
                            //Lägger till data i ett nytt objekt.
                            båtplats.Add(new Båtplats
                            {
                                BåtplID = reader.GetInt32(iBåtplID),
                                DjupID = reader.GetInt32(iDjupID)
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
    }
}