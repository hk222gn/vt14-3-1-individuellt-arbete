using BoatRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoatRental.Pages.Shared
{
    public partial class WebForm6 : System.Web.UI.Page
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
            get { return Session["Status"] as string; }
            set { Session["Status"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void KundFormView_UpdateItem(int KundID)
        {
            var kund = Service.GetKund(KundID);

            if (kund == null)
            {
                //Om kunden inte finns, visa ett felmeddelande.
                ModelState.AddModelError("", String.Format("Kunden med ID {0} hittades inte", KundID));
                return;
            }
            
            if (TryUpdateModel(kund))
            {
                //Om kunden går igenom valideringen, spara kunden.
                Service.SaveKund(kund);
                Status = "Kunden updaterades!";
                Response.RedirectToRoute("Kunder", null);
            }
        }
        public BoatRental.Model.Kund KundFormView_GetItem()
        {
            try
            {
                return Service.GetKund(ID);
            }
            catch 
            {
                ModelState.AddModelError(String.Empty, "Fel när kunden skulle hämtas");
                return null;
            }
        }
    }
}