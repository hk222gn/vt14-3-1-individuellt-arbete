using BoatRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoatRental.Pages.Shared
{
    public partial class WebForm2 : System.Web.UI.Page
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

        public IEnumerable<Kund> KundListView_GetDataPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return Service.GetKundPageWise(maximumRows, startRowIndex, out totalRowCount);
        }
        
    }
}