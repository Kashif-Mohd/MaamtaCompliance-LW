using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ComplianceMaamtaLW
{
    public partial class dashEmptySachet : System.Web.UI.Page
    {
        string ConDataBase = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLink"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["editDetails_Id"] = null;
            Session["editDetails_RandId"] = null;
            Session["WebForm"] = "dashEmptySachet";
            // ShowData();
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

                cmd = new SqlCommand("select b.id,a.random_id,a.study_id,a.dssid,a.woman_nm,a.dob,DATEDIFF(DAY, CONVERT(datetime,a.dob,103),CONVERT(datetime,b.date_of_attempt,103)) as age,b.date_of_attempt,	 DATEDIFF(DAY,   CONVERT(datetime,b.last_date_of_attempt,103) ,CONVERT(datetime,b.date_of_attempt,103)) as days_diff,	(DATEDIFF(DAY,   CONVERT(datetime,b.last_date_of_attempt,103) ,CONVERT(datetime,b.date_of_attempt,103))*2) as required_sachet,  b.empty_sachet,  b.actual_empty_sachet, b.remarks from LW_info as a left join compliance_sachet as b on a.random_id=b.random_id where a.dssid like '%" + txtdssid.Text.ToUpper() + "%' order by a.random_id,CONVERT(datetime,b.date_of_attempt,103)", con);
                // cmd = new SqlCommand("select b.id,a.random_id,a.study_id,a.dssid,a.woman_nm,a.dob,DATEDIFF(DAY, CONVERT(datetime,a.dob,103),CONVERT(datetime,b.date_of_attempt,103)) as age,b.date_of_attempt,	CAST(case  when	 (b.last_date_of_attempt!='')	then (DATEDIFF(DAY,   CONVERT(datetime,b.last_date_of_attempt,103) ,CONVERT(datetime,b.date_of_attempt,103) )) else 	(DATEDIFF(DAY, CONVERT(datetime,a.dob,103),CONVERT(datetime,b.date_of_attempt,103))) end as nvarchar) as days_diff			,b.empty_sachet from LW_info as a left join compliance_sachet as b on a.random_id=b.random_id where a.dssid like '" + txtdssid.Text.ToUpper() + "%' order by a.random_id,CONVERT(datetime,b.date_of_attempt,103)", con);

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





        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
            txtdssid.Focus();
        }



        public void ExcelExportMessage()
        {
            if (txtdssid.Text != "")
            {
                GridView2.Caption = "DSSID, Search by: " + txtdssid.Text;
            }
        }




        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }





        private void Exportdata()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            try
            {
                con.Open();
                SqlCommand cmd;

                cmd = new SqlCommand("select b.id,a.random_id,a.study_id,a.dssid,a.woman_nm,a.dob,DATEDIFF(DAY, CONVERT(datetime,a.dob,103),CONVERT(datetime,b.date_of_attempt,103)) as age,b.date_of_attempt,	 DATEDIFF(DAY,   CONVERT(datetime,b.last_date_of_attempt,103) ,CONVERT(datetime,b.date_of_attempt,103)) as days_diff,	(DATEDIFF(DAY,   CONVERT(datetime,b.last_date_of_attempt,103) ,CONVERT(datetime,b.date_of_attempt,103))*2) as required_sachet,b.empty_sachet,  b.actual_empty_sachet, b.remarks  from LW_info as a left join compliance_sachet as b on a.random_id=b.random_id where a.dssid like '%" + txtdssid.Text.ToUpper() + "%' order by a.random_id,CONVERT(datetime,b.date_of_attempt,103)", con);
                // cmd = new SqlCommand("select b.id,a.random_id,a.study_id,a.dssid,a.woman_nm,a.dob,DATEDIFF(DAY, CONVERT(datetime,a.dob,103),CONVERT(datetime,b.date_of_attempt,103)) as age,b.date_of_attempt,	CAST(case  when	 (b.last_date_of_attempt!='')	then (DATEDIFF(DAY,   CONVERT(datetime,b.last_date_of_attempt,103) ,CONVERT(datetime,b.date_of_attempt,103) )) else 	(DATEDIFF(DAY, CONVERT(datetime,a.dob,103),CONVERT(datetime,b.date_of_attempt,103))) end as nvarchar) as days_diff			,b.empty_sachet from LW_info as a left join compliance_sachet as b on a.random_id=b.random_id where a.dssid like '" + txtdssid.Text.ToUpper() + "%' order by a.random_id,CONVERT(datetime,b.date_of_attempt,103)", con);

                SqlDataAdapter sda = new SqlDataAdapter();
                {
                    cmd.Connection = con;
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
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }




        public void ExcelExport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Empty Sachet (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2.AllowPaging = false;
                ExcelExportMessage();
                GridView2.CaptionAlign = TableCaptionAlign.Top;

                Exportdata();
                for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
                {
                    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridView2.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView2.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");

            }
        }




        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
            txtdssid.Focus();
        }



  

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.Cells[16].Text == "1")
            //    {
            //        e.Row.Cells[16].Text = "Complete";
            //    }
            //    else if (e.Row.Cells[16].Text == "2")
            //    {
            //        e.Row.Cells[16].Text = "Refused";
            //    }
            //    else if (e.Row.Cells[16].Text == "3")
            //    {
            //        e.Row.Cells[16].Text = "House Lock";
            //    }
            //    else if (e.Row.Cells[16].Text == "4")
            //    {
            //        e.Row.Cells[16].Text = "Permanent Migrated";
            //    }
            //}
        }

        protected void LinkDetail_id(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Role"]) == "admin_maamtaLW" ||  Convert.ToString(Session["Role"]) == "super_admin")
            {
                string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
                Session["editDetails_Id"] = commandArgs[0];
                Session["editDetails_RandId"] = commandArgs[1];
                Response.Redirect("editDetails.aspx");
            }
            else
            {
                showalert("Only Admin has right to update details");
            }
        }



    }
}