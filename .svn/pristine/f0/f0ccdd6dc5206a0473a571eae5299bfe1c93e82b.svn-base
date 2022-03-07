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
    public partial class Homev3_vertical_menu : System.Web.UI.MasterPage
    {
        private UserDAO user = new UserDAO();
        private UserEntity userdata;
        DataTable dt = new DataTable();

        int ID_SISTEM_INFORMASI = 8;
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
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("userdata");
            Response.Redirect("LandingPage.aspx");
            
        }
         
        private void getMenu()
        {
            DataTable dt = new DataTable();
            UserEntity userEntity = (UserEntity) Session["userdata"];
            string npp = userEntity.NPP;
            dt = user.getAllMenu(npp, ID_SISTEM_INFORMASI);
            DataRow[] drowpar = dt.Select("ParentID=" + 0);
            MenuItem mnu=null;
            MenuItem miHome = new MenuItem("Home");
            miHome.NavigateUrl = "WebForm1.aspx";
            menuBar.Items.Add(miHome);
            foreach (DataRow dr in drowpar)
            {
                menuBar.Items.Add(new MenuItem(dr["MenuName"].ToString(), dr["MenuID"].ToString(),
                "", "WebForm1.aspx"));
            }
            foreach (DataRow dr in dt.Select("ParentID >" + 0))
            {

                if (dr["MenuName"].ToString() == "Internal Perorangan")
                {
                    mnu = new MenuItem(dr["MenuName"].ToString(), dr["MenuID"].ToString(),
                    "", dr["MenuLocation"].ToString() + ".aspx");
                }
                else if (dr["MenuName"].ToString() == "Pengabdian Perorangan")
                {
                    mnu = new MenuItem(dr["MenuName"].ToString(), dr["MenuID"].ToString(),
                    "", dr["MenuLocation"].ToString() + ".aspx?Type=Perorangan");
                }
                else if (dr["MenuName"].ToString() == "Pengabdian Kelompok")
                {
                    mnu = new MenuItem(dr["MenuName"].ToString(), dr["MenuID"].ToString(),
                    "", dr["MenuLocation"].ToString() + ".aspx?Type=Kelompok");
                }
                else {
                    mnu = new MenuItem(dr["MenuName"].ToString(), dr["MenuID"].ToString(),
                    "",dr["MenuLocation"].ToString() + ".aspx");
                }
                
                menuBar.FindItem(dr["ParentID"].ToString()).ChildItems.Add(mnu);
            }
            MenuItem miLogOut = new MenuItem("Log Out");
            miLogOut.NavigateUrl = "LandingPage.aspx";
            menuBar.Items.Add(miLogOut);
        } 

    }
}