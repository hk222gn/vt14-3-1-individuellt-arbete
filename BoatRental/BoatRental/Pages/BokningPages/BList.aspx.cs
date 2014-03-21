using BoatRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoatRental.Pages.Shared
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        private string Status
        {
            //Används för att spara ett fel/rätt meddelande
            get { return Session["Status"] as string; }
            set { Session["Status"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Status"] != null)
            {
                Panel1.Visible = true;
                ResultLabel.Text = Status;
                Session.Remove("Status");
            }
        }

        public IEnumerable<Bokning> BokningListView_GetDataPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return Service.GetBokningPageWise(maximumRows, startRowIndex, out totalRowCount);
        }

        public string GetKundNamn(int kundID)
        {
            var kund = Service.GetKund(kundID);
            return kund.Namn;
        }

        public string GetBatplatsnr(int batplID)
        {
            var batplats = Service.GetBatplats(batplID);

            return batplats.Båtplatsnr;
        }
    }
}