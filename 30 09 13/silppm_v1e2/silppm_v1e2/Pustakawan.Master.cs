using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using silppm_v1e2.Entity;
using System.Data;

namespace silppm_v1e2
{
    public partial class Pustakawan : System.Web.UI.MasterPage
    {
        private UserDAO user = new UserDAO();
        private UserEntity userdata;
        DataTable dt = new DataTable();

        static DataSet static_dataset = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Userdata"] != null)
                {
                    getMenu();
                    static_dataset = user.getMenu("Admin");
                    dt = static_dataset.Tables[0].Copy();
                    dt.Clear();
                    // FillMenu();
                    userdata = Session["Userdata"] as UserEntity;
                }
                else
                {
                    Response.Redirect("LoginExpired.aspx");
                }
            }
        }
        private void getMenu()
        {
            DataTable dt = new DataTable();
            dt = user.getAllMenu("Pustakawan");
            DataRow[] drowpar = dt.Select("ParentID=" + 0);

            MenuItem miHome = new MenuItem("Home");
            miHome.NavigateUrl = "PustakaHome.aspx";
            menuBar.Items.Add(miHome);
            foreach (DataRow dr in drowpar)
            {
                menuBar.Items.Add(new MenuItem(dr["MenuName"].ToString(), dr["MenuID"].ToString(),
                "", "PustakaHome.aspx"));
            }
            foreach (DataRow dr in dt.Select("ParentID >" + 0))
            {
                MenuItem mnu = new MenuItem(dr["MenuName"].ToString(), dr["MenuID"].ToString(),
                "", dr["MenuLocation"].ToString() + ".aspx");
                menuBar.FindItem(dr["ParentID"].ToString()).ChildItems.Add(mnu);
            }
            MenuItem miLogOut = new MenuItem("Log Out");
            miLogOut.NavigateUrl = "LandingPage.aspx";
            menuBar.Items.Add(miLogOut);
        } 

    }
}