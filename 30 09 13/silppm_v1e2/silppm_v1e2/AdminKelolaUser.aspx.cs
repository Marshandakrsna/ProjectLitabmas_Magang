﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using silppm_v1e2.Entity;
using System.Data;
using System.Windows.Forms;

namespace silppm_v1e2
{
    public partial class WebForm21 : System.Web.UI.Page
    {
        private string tmpusername,tmpNpp;
        private int flag = 0;
        private DataSet dataset = new DataSet();
        private UserDAO user = new UserDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["userdata"] != null)
                {
                    UserEntity ue = Session["userdata"] as UserEntity;

                    tmpusername = ue.Username;
                    if (flag == 0)
                    {
                        panelUbah.Visible = false;
                    }
                    else {
                        panelUbah.Visible = true;
                    }
                    //tmpKantor = datauser.getalam
                    dataset.Clear();
                    dataset = user.getAllDatauser();
                    if (dataset.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = dataset.Tables[0];
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.Visible = false;
                    }

                    


                }
                else
                {
                    Response.Redirect("LoginExpired.aspx");
                }

            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindGridView(); //bindgridview will get the data source and bind it again
        }
        private void bindGridView()
        {
            dataset = user.getAllDatauser();
            if (dataset.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = dataset.Tables[0];
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UbahRole")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);
                hiddenTmpNpp.Value = tmp; flag = 1;
               // tmpNpp = hiddenTmpNpp.Value;
                if (flag == 0)
                {
                    panelUbah.Visible = false;
                }
                else
                {
                    panelUbah.Visible = true;
                }

            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int tampungRole=5;
            if(listRole.Text=="Administrator"){
            tampungRole=1;
            }
            else if (listRole.Text == "Assesor")
            {
                tampungRole = 12;
            }
            else if (listRole.Text == "Dosen")
            {
                tampungRole = 3;
            }
            if(user.UpdateRole(hiddenTmpNpp.Value,tampungRole)){
            //MessageBox.Show("", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Role user berhasil di ubah!');", true);
                bindGridView();
                flag = 0;
                if (flag == 0)
                {
                    panelUbah.Visible = false;
                }
                else
                {
                    panelUbah.Visible = true;
                }
            }
            else{
            //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Terjadi kesalahan!');", true);
            }
        }
    }
}