using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using silppm_v1e2.Entity;

namespace silppm_v1e2
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;
                Label1.Text = ue.NAMA;
                

            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
        }
    }
}