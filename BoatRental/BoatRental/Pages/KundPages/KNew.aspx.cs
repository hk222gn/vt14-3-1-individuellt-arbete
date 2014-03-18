using BoatRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoatRental.Pages.Master
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        private string Status
        {
            get { return Session["Status"] as string; }
            set { Session["Status"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void KundFormView_InsertItem(Kund kund)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveKund(kund);
                    Session["Status"] = "Kunden lades till!";
                    Response.RedirectToRoute("Kunder", null);
                }
                catch
                {
                    ModelState.AddModelError(String.Empty, "Något gick fel när kunden skulle läggas till");
                }
                
            }
        }
    }
}