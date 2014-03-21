using BoatRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoatRental.Pages.Shared
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Batplats> BåtplListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return Service.GetBåtplatsPageWise(maximumRows, startRowIndex, out totalRowCount);
        }
    }
}