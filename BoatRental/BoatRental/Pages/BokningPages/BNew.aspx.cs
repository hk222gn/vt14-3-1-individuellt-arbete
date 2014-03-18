using BoatRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoatRental.Pages.Master
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected int ID
        {
            //Hämtar ut ID ifrån addressen.
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

        }

        public void BokningFormView_InsertItem(Bokning bokning)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveBokning(bokning, ID);
                    Status = "Bokningen skapades!";
                    Response.RedirectToRoute("Bokningar", null);
                }
                catch
                {
                    ModelState.AddModelError(String.Empty, "Fel när bokningen skulle updateras. Klicka på Bokningar och se till att det inte är en dubbelbokning!");
                }

            }
        }
    }
}