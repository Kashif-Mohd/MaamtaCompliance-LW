using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComplianceMaamtaLW
{
    public partial class showcrf6 : System.Web.UI.Page
    {
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "showcrf6";
                txtdssid.Focus();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }




        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }



        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }





        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtdssid.Text == "" || txtdssid.Text.Length < 5)
            {
                showalert("Enter DSSID, minimun length should be 5");
            }
            else
            {
                ShowData();
            }

            txtdssid.Focus();
        }




        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(LiveServer);
            try
            {

                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select * from view_crf6 where dssid like '%" + txtdssid.Text + "%'  order by study_code,followup_no", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell = e.Row.Cells[7];
               
                if (e.Row.Cells[7].Text == "1")
                {
                    e.Row.Cells[7].Text = "Complete";
                }
               
                else if (e.Row.Cells[7].Text == "2")
                {
                    e.Row.Cells[7].Text = "Refused";
                }
                else if (e.Row.Cells[7].Text == "3")
                {
                    e.Row.Cells[7].Text = "Household Locked";
                }
                else if (e.Row.Cells[7].Text == "4")
                {
                    e.Row.Cells[7].Text = "Permanent Migrated";
                }
            }
        }



    }
}