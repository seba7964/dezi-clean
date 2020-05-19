using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dezi_clean.Controllers;

namespace dezi_clean
{
    public partial class Dezinfekcija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ArrayList values = new ArrayList();
            values = GetDataFromDB.GetDataForBind("='dezinfekcija'");


            myCustomRepeater.DataSource = values;
            myCustomRepeater.DataBind();
        }
    }
}