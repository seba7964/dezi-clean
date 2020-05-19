using dezi_clean.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dezi_clean
{
    public partial class Deratizacija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList values = new ArrayList();
            values = GetDataFromDB.GetDataForBind("='deratizacija'");


            myCustomRepeater.DataSource = values;
            myCustomRepeater.DataBind();
        }
    }
}