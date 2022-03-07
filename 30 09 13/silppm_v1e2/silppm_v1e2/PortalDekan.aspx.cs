using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace silppm_v1e2
{
    public partial class PortalDekan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Text == "Dekan")
            {
                Response.Redirect("DekanHome.aspx");
            }
            else if (DropDownList1.Text == "Dosen")
            {
                Response.Redirect("WebForm1.aspx");
            }
        }
    }
}