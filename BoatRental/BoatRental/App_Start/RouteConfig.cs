using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace BoatRental
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection rout)
        {
            rout.MapPageRoute("Default", "Index", "~/Default.aspx");

            rout.MapPageRoute("Kunder", "Kunder", "~/Pages/KundPages/KList.aspx");
            rout.MapPageRoute("KunderNy", "Kunder/Ny", "~/Pages/KundPages/KNew.aspx");
            rout.MapPageRoute("KunderRadera", "Kund/{ID}/Radera", "~/Pages/KundPages/KDelete.aspx");
            rout.MapPageRoute("KunderÄndra", "Kund/{ID}/Ändra", "~/Pages/KundPages/KModify.aspx");

            rout.MapPageRoute("Bokningar", "Bokningar", "~/Pages/BokningPages/BList.aspx");
            rout.MapPageRoute("BokningarNy", "Bokningar/{ID}/ny", "~/Pages/BokningPages/BNew.aspx");
            rout.MapPageRoute("BokningarRadera", "Bokningar/{ID}/Radera", "~/Pages/BokningPages/BDelete.aspx");
            rout.MapPageRoute("BokningarÄndra", "Bokningar/{ID}/Ändra", "~/Pages/BokningPages/BModify.aspx");

            rout.MapPageRoute("Båtplatser", "Båtplatser", "~/Pages/BåtplatsPages/BåList.aspx");
        }

    }
}