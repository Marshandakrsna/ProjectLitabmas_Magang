using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using silppm_v1e2.Entity;

namespace silppm_v1e2
{
    public partial class PortalProdi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Text == "Prodi")
            {
                UserEntity userEntity = (UserEntity)Session["userdata"];
                userEntity.Role = "Prodi";

                Session["userdata"] = userEntity;
                Response.Redirect("ProdiHome.aspx");
            }
            else if (DropDownList1.Text == "Dosen")
            {
                UserEntity userEntity = (UserEntity)Session["userdata"];
                userEntity.Role = "Dosen";
                Session["userdata"] = userEntity;
                Response.Redirect("WebForm1.aspx");
            }
        }
    }
}