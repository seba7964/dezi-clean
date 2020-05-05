using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dezi_clean.Controllers;

namespace dezi_clean
{
    public partial class Dezinsekcija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList values = new ArrayList();
            values = GetDataFromDB.GetDataForBind("dezinsekcija");


            myCustomRepeater.DataSource = values;
            myCustomRepeater.DataBind();
        }
    }
}