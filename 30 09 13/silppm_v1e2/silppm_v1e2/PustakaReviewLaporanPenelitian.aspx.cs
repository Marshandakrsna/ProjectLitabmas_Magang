﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using silppm_v1e2.Entity;

namespace silppm_v1e2
{
    public partial class WebForm39 : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private ProposalDAO prop = new ProposalDAO();
        private string tmpNppPustakawan;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;

                
                tmpNppPustakawan = ue.NPP;

                //ddlDana.DataSource = prop.getSbrDana();
                //ddlDana.DataBind();
                dataset.Clear();
                dataset = prop.getListLaporanPustaka();

                if (dataset.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = dataset.Tables[0];
                    GridView1.DataBind();


                }
            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "review")
            {

                int index = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);

                //dataset = rev.getAdminDataPerkembangan(HiddenField1.Value);
                Response.Redirect("PustakaApproval.aspx?id=" + tmp);
                
                }
            }
        }
    
}