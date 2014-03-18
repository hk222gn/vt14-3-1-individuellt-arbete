using BoatRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoatRental.Pages.Master
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected int ID
        {
            //Hämtar ut ID från addressen.
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
                    var bokning = Service.GetBokning(ID);
                    if (bokning != null)
                    {
                        return;
                    }
                    ModelState.AddModelError(String.Empty, String.Format("Bokningen med ID {0} hittades ej.", ID));
                }
                catch
                {
                    ModelState.AddModelError(String.Empty, "Fel vid hämtning av bokning.");
                }
            }
        }

        protected void DeleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var ID = int.Parse(e.CommandArgument.ToString());
                Service.DeleteBokning(ID);
                Status = "Bokningen har raderats!";
                Response.RedirectToRoute("Bokningar", null);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Fel vid radering av bokning");
            }
        }
    }
}