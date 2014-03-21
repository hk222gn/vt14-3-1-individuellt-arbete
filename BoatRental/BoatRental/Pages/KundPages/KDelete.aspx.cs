using BoatRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoatRental.Pages.Shared
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected int ID
        {
            //Hämtar ID från addressen
            get { return int.Parse(RouteData.Values["ID"].ToString()); }
        }

        private string Status
        {
            //Används för att spara ett fel/rätt meddelande
            get { return Session["Status"] as string; }
            set { Session["Status"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    //Ser till att kunden finns, visar annars error.
                    var kund = Service.GetKund(ID);
                    if (kund != null)
                    {
                        return;
                    }
                    ModelState.AddModelError(String.Empty, String.Format("Kunden med id {0} hittades inte.", ID));
                }
                catch
                {
                    ModelState.AddModelError(String.Empty, "Fel vid hämtning av kund.");
                }
            }
        }

        protected void DeleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var ID = int.Parse(e.CommandArgument.ToString());
                Service.DeleteKund(ID);
                Status = "Kunden raderades!";
                Response.RedirectToRoute("Kunder", null);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch 
            {
                ModelState.AddModelError(String.Empty, "Fel vid radering av kund");
            }
        }
    }
}