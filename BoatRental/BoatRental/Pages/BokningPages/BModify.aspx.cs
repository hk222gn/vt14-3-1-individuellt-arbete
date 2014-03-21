using BoatRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoatRental.Pages.Master
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected int ID
        {
            //Hämtar ID ifrån addressen.
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

        public Bokning BokningFormView_GetItem()
        {
            try
            {
                return Service.GetBokning(ID);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Fel när bokningen skulle hämtas");
                return null;
            }
        }

        public void BokningFormView_UpdateItem(int BokningID)
        {
            var bokning = Service.GetBokning(BokningID);

            if (bokning == null)
            {
                //Om bokningen inte finns, visa ett felmeddelande.
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", BokningID));
                return;
            }

            if (TryUpdateModel(bokning))
            {
                //Om bokningen går igenom valideringen, spara bokningen.
                try
                {
                    Service.SaveBokning(bokning, ID);
                    Status = "Bokningen har ändrats!";
                    Response.RedirectToRoute("Bokningar", null);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch
                {
                    ModelState.AddModelError(String.Empty, "Fel när bokningen skulle updateras. Klicka på Bokningar och se till att det inte är en dubbelbokning!");
                }
                
            }
        }

        public IEnumerable<Batplats> DropDown_GetBatplatser()
        {
            return Service.GetBatplatser();
        }
    }
}