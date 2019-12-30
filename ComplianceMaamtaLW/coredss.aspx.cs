using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace ComplianceMaamtaLW
{
    public partial class coredss : System.Web.UI.Page
    {
        string ConDataBase = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLinkCoreDSS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "coredss";
            txtdssid.Focus();
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


        private void ShowData()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            try
            {
                con.Open();
                SqlCommand cmd;

                cmd = new SqlCommand("select * from core_dss where dssid like '" + DropDownList1.SelectedValue + "%' and dssid like '%" + txtdssid.Text + "%'", con);

                SqlDataAdapter sda = new SqlDataAdapter();
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


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "0000000")
            {
                showalert("Please select Site");
                DropDownList1.Focus();
            }
            else if (txtdssid.Text.Length < 5)
            {
                showalert("Minimum 5 digit and char required!");
                txtdssid.Focus();
            }  
            else
            {
                ShowData();
                txtdssid.Focus();
            }
        }







        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }



        protected void btnExport_Click(object sender, EventArgs e)
        {
            ShowData();
            if (GridView1.Rows.Count != 0 && DropDownList1.SelectedValue != "0")
            {
                ExcelExport();
            }
            txtdssid.Focus();
        }





        // Export to CSV
        public void ExcelExport()
        {
            try
            {
                Exportdata();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=CoreDSS-" + DropDownList1.SelectedItem.Text + " (" + DateTime.Today.ToString("dd-MM-yyyy") + ").csv");
                Response.Charset = "";
                Response.ContentType = "application/text";
                StringBuilder sb = new StringBuilder();

                for (int k = 0; k < GridView2.Columns.Count; k++)
                {
                    //add separator
                    sb.Append(GridView2.Columns[k].HeaderText + ',');
                }
                //append new line
                sb.Append("\r\n");
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    for (int k = 0; k < GridView2.Columns.Count; k++)
                    {
                        if (GridView2.Rows[i].Cells[k].Text == "&nbsp;")
                        {
                            GridView2.Rows[i].Cells[k].Text = "";
                        }
                        //add separator
                        sb.Append(GridView2.Rows[i].Cells[k].Text + ',');
                    }
                    //append new line
                    sb.Append("\r\n");
                }
                Response.Write(sb.ToString());
                Response.Flush();
                Response.End();
            }
            catch
            {
                //  Response.Redirect("exportcrf2.aspx");
            }
        }




        private void Exportdata()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from core_dss where dssid like '" + DropDownList1.SelectedValue + "%' and dssid like '%" + txtdssid.Text + "%' ", con);
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 999999;
                        cmd.CommandType = CommandType.Text;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                            con.Close();
                        }
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



        public void ExcelExportMessage()
        {
            GridView2.Caption = "<h3>Core DSS List (" + DropDownList1.SelectedItem.Text + ")";
        }


    }
}