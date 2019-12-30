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
    public partial class showcrf1 : System.Web.UI.Page
    {
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "showcrf1";
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
                cmd = new MySqlCommand("select * from view_crf1 where dssid like '%" + txtdssid.Text + "%'  order by form_crf_1_id", con);
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
                TableCell cell = e.Row.Cells[8];
                if (e.Row.Cells[8].Text != "&nbsp;")
                {
                    cell.BackColor = System.Drawing.Color.FromName("#feca57");
                    cell.ForeColor = System.Drawing.Color.FromName("#ffffff");
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
                    e.Row.Cells[6].Text = "Wrong Information";
                }
                else if (e.Row.Cells[6].Text == "5")
                {
                    e.Row.Cells[6].Text = "Wrong Info. DSS";
                }
                else if (e.Row.Cells[6].Text == "6")
                {
                    e.Row.Cells[6].Text = "Woman was never found Pregnant";
                }
                else if (e.Row.Cells[6].Text == "7")
                {
                    e.Row.Cells[6].Text = "Woman was preg. but recently delivered";
                }
                else if (e.Row.Cells[6].Text == "8")
                {
                    e.Row.Cells[6].Text = "Shifted out of DSS";
                }
                else if (e.Row.Cells[6].Text == "9")
                {
                    e.Row.Cells[6].Text = "PW died";
                }
                else if (e.Row.Cells[6].Text == "10")
                {
                    e.Row.Cells[6].Text = "Visitor";
                }
            }
        }













        protected void btnExport_Click(object sender, EventArgs e)
        {

            ExcelExport();

            txtdssid.Focus();
        }



        public void ExcelExportMessage()
        {
            if (txtdssid.Text != "")
            {
                GridView2.Caption = "DSSID, Search by: " + txtdssid.Text;
            }
        }

     

        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(LiveServer);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT a.*,bb.code_of_reader_1 as code1,bb.code_of_reader_2 as code2, bb.reading_1  as LW_MUAC_R1,	bb.reading_2  as LW_MUAC_R2 		 from view_crf1 as a                		left join(select * from muac_assessment  where id in ( select max(id) from muac_assessment group by form_crf_1_id)) as bb on bb.form_crf_1_id=a.form_crf_1_id                    inner join (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  a.assis_id = b.assis_id AND str_to_date(a.lw_crf1_02, '%d-%m-%Y') = b.TopDate  and a.dssid like '%" + txtdssid.Text + "%'", con);

                //cmd = new MySqlCommand("SELECT * from view_crf1 where dssid like '%" + txtdssid.Text + "%' order by form_crf_1_id", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
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
                Response.AddHeader("content-disposition", "attachment;filename=SCREENING (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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


    }
}