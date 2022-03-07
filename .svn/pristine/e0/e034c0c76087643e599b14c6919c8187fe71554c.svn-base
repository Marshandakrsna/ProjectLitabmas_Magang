using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace silppm_v1e2
{
    public partial class WebForm91 : System.Web.UI.Page
    {
        private string tmpid, subid;
        protected void Page_Load(object sender, EventArgs e)
        {
            tmpid = Request.QueryString["id"];
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LaporanPengabdianTahap1.aspx?id=" + tmpid);
        }
    }
}