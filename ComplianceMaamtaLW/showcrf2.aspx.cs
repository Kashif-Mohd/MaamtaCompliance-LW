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
    public partial class showcrf2 : System.Web.UI.Page
    {
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "showcrf2";
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
                cmd = new MySqlCommand("select * from view_crf2 where dssid like '%" + txtdssid.Text + "%'  order by form_crf_2", con);
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
                    e.Row.Cells[7].Text = "Enrolled";
                    cell.BackColor = System.Drawing.Color.FromName("#aec62c");
                    cell.ForeColor = System.Drawing.Color.FromName("#ffffff");
                }
                else if (e.Row.Cells[6].Text == "1" && e.Row.Cells[7].Text != "1")
                {
                    e.Row.Cells[7].Text = "Excluded";
                    cell.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }


                if (e.Row.Cells[6].Text == "1")
                {
                    e.Row.Cells[6].Text = "Complete";
                }
                else if (e.Row.Cells[6].Text == "2")
                {
                    e.Row.Cells[6].Text = "Not at home";
                }
                else if (e.Row.Cells[6].Text == "3")
                {
                    e.Row.Cells[6].Text = "Refused";
                }
                else if (e.Row.Cells[6].Text == "4")
                {
                    e.Row.Cells[6].Text = "False Pregnancy";
                }
                else if (e.Row.Cells[6].Text == "5")
                {
                    e.Row.Cells[6].Text = "Shifted out of DSS";
                }
                else if (e.Row.Cells[6].Text == "6")
                {
                    e.Row.Cells[6].Text = "Adopted Child from outside DSS";
                }
                else if (e.Row.Cells[6].Text == "7")
                {
                    e.Row.Cells[6].Text = "PW died before visit";
                }
            }

        }

    }
}