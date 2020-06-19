using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace ComplianceMaamtaLW
{
    public partial class crf8b : System.Web.UI.Page
    {
        static string AD_Start_Date;
        static string AD_Stop_Date;
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "crf8";
                FieldFill();
                txtq26.Focus();
            }
        }





        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }


        protected void next_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(LiveServer);
            cn.Open();
            try
            {
                //q30a1
                if (txtq30a1dt.Text != "" && txtq30a1dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a1dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a1dt.Focus();
                }
                else if (txtq30a1dt.Text != "" && txtq30a1dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a1dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a1dt.Focus();
                }

                //q30a2
                else if (txtq30a2dt.Text != "" && txtq30a2dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a2dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a2dt.Focus();
                }
                else if (txtq30a2dt.Text != "" && txtq30a2dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a2dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a2dt.Focus();
                }

                //q30a3
                else if (txtq30a3dt.Text != "" && txtq30a3dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a3dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a3dt.Focus();
                }
                else if (txtq30a3dt.Text != "" && txtq30a3dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a3dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a3dt.Focus();
                }

                //q30a4
                else if (txtq30a4dt.Text != "" && txtq30a4dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a4dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a4dt.Focus();
                }
                else if (txtq30a4dt.Text != "" && txtq30a4dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a4dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a4dt.Focus();
                }

                //q30a5
                else if (txtq30a5dt.Text != "" && txtq30a5dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a5dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a5dt.Focus();
                }
                else if (txtq30a5dt.Text != "" && txtq30a5dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a5dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a5dt.Focus();
                }

                //q30a6
                else if (txtq30a6dt.Text != "" && txtq30a6dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a6dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a6dt.Focus();
                }
                else if (txtq30a6dt.Text != "" && txtq30a6dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a6dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a6dt.Focus();
                }

                //q30a7
                else if (txtq30a7dt.Text != "" && txtq30a7dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a7dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a7dt.Focus();
                }
                else if (txtq30a7dt.Text != "" && txtq30a7dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a7dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a7dt.Focus();
                }

                //q30a8
                else if (txtq30a8dt.Text != "" && txtq30a8dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a8dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a8dt.Focus();
                }
                else if (txtq30a8dt.Text != "" && txtq30a8dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a8dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a8dt.Focus();
                }

                //q30a9
                else if (txtq30a9dt.Text != "" && txtq30a9dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a9dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a9dt.Focus();
                }
                else if (txtq30a9dt.Text != "" && txtq30a9dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a9dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a9dt.Focus();
                }

                //q30a10
                else if (txtq30a10dt.Text != "" && txtq30a10dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a10dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a10dt.Focus();
                }
                else if (txtq30a10dt.Text != "" && txtq30a10dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a10dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a10dt.Focus();
                }
                //q30a11
                else if (txtq30a11dt.Text != "" && txtq30a11dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a11dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a11dt.Focus();
                }
                else if (txtq30a11dt.Text != "" && txtq30a11dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a11dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a11dt.Focus();
                }
                //q30a12
                else if (txtq30a12dt.Text != "" && txtq30a12dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a12dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a12dt.Focus();
                }
                else if (txtq30a12dt.Text != "" && txtq30a12dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a12dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a12dt.Focus();
                }
                //q30a13
                else if (txtq30a13dt.Text != "" && txtq30a13dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a13dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a13dt.Focus();
                }
                else if (txtq30a13dt.Text != "" && txtq30a13dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a13dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a13dt.Focus();
                }
                //q30a14
                else if (txtq30a14dt.Text != "" && txtq30a14dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a14dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a14dt.Focus();
                }
                else if (txtq30a14dt.Text != "" && txtq30a14dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a14dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a14dt.Focus();
                }
                //q30a15
                else if (txtq30a15dt.Text != "" && txtq30a15dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30a15dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30a15dt.Focus();
                }
                else if (txtq30a15dt.Text != "" && txtq30a15dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30a15dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30a15dt.Focus();
                }







                //q30b1
                else if (txtq30b1dt.Text != "" && txtq30b1dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b1dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b1dt.Focus();
                }
                else if (txtq30b1dt.Text != "" && txtq30b1dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b1dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b1dt.Focus();
                }

                //q30b2
                else if (txtq30b2dt.Text != "" && txtq30b2dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b2dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b2dt.Focus();
                }
                else if (txtq30b2dt.Text != "" && txtq30b2dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b2dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b2dt.Focus();
                }

                //q30b3
                else if (txtq30b3dt.Text != "" && txtq30b3dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b3dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b3dt.Focus();
                }
                else if (txtq30b3dt.Text != "" && txtq30b3dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b3dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b3dt.Focus();
                }

                //q30b4
                else if (txtq30b4dt.Text != "" && txtq30b4dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b4dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b4dt.Focus();
                }
                else if (txtq30b4dt.Text != "" && txtq30b4dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b4dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b4dt.Focus();
                }

                //q30b5
                else if (txtq30b5dt.Text != "" && txtq30b5dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b5dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b5dt.Focus();
                }
                else if (txtq30b5dt.Text != "" && txtq30b5dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b5dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b5dt.Focus();
                }

                //q30b6
                else if (txtq30b6dt.Text != "" && txtq30b6dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b6dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b6dt.Focus();
                }
                else if (txtq30b6dt.Text != "" && txtq30b6dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b6dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b6dt.Focus();
                }

                //q30b7
                else if (txtq30b7dt.Text != "" && txtq30b7dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b7dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b7dt.Focus();
                }
                else if (txtq30b7dt.Text != "" && txtq30b7dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b7dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b7dt.Focus();
                }

                //q30b8
                else if (txtq30b8dt.Text != "" && txtq30b8dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b8dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b8dt.Focus();
                }
                else if (txtq30b8dt.Text != "" && txtq30b8dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b8dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b8dt.Focus();
                }

                //q30b9
                else if (txtq30b9dt.Text != "" && txtq30b9dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b9dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b9dt.Focus();
                }
                else if (txtq30b9dt.Text != "" && txtq30b9dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b9dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b9dt.Focus();
                }

                //q30b10
                else if (txtq30b10dt.Text != "" && txtq30b10dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b10dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b10dt.Focus();
                }
                else if (txtq30b10dt.Text != "" && txtq30b10dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b10dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b10dt.Focus();
                }
                //q30b11
                else if (txtq30b11dt.Text != "" && txtq30b11dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b11dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b11dt.Focus();
                }
                else if (txtq30b11dt.Text != "" && txtq30b11dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b11dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b11dt.Focus();
                }
                //q30b12
                else if (txtq30b12dt.Text != "" && txtq30b12dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b12dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b12dt.Focus();
                }
                else if (txtq30b12dt.Text != "" && txtq30b12dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b12dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b12dt.Focus();
                }
                //q30b13
                else if (txtq30b13dt.Text != "" && txtq30b13dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b13dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b13dt.Focus();
                }
                else if (txtq30b13dt.Text != "" && txtq30b13dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b13dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b13dt.Focus();
                }
                //q30b14
                else if (txtq30b14dt.Text != "" && txtq30b14dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b14dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b14dt.Focus();
                }
                else if (txtq30b14dt.Text != "" && txtq30b14dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b14dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b14dt.Focus();
                }
                //q30b15
                else if (txtq30b15dt.Text != "" && txtq30b15dt.Text != "__-__-____" && (DateTime.ParseExact(txtq30b15dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq30b15dt.Focus();
                }
                else if (txtq30b15dt.Text != "" && txtq30b15dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq30b15dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq30b15dt.Focus();
                }


                else
                {

                    //   MySqlCommand cmd = new MySqlCommand("update crf8 set q26='" + txtq26.Text + "',q27='" + txtq27.Text + "',q27_other='" + txtq27_other.Text + "',q28='" + txtq28.Text + "'	,q29_minutes='" + txtq29_min.Text + "'	,q29_hours='" + txtq29_hr.Text + "', q29_days='" + txtq29_day.Text + "', q30a_1='" + txtq30a1.InnerText + "', q30a_2='" + txtq30a2.InnerText + "', q30a_3='" + txtq30a3.InnerText + "', q30a_4='" + txtq30a4.InnerText + "', q30a_5='" + txtq30a5.InnerText + "', q30a_6='" + txtq30a6.InnerText + "', q30a_7='" + txtq30a7.InnerText + "', q30a_8='" + txtq30a8.InnerText + "', q30a_9='" + txtq30a9.InnerText + "', q30a_10='" + txtq30a10.InnerText + "',      q30b_1='" + txtq30b1.InnerText + "', q30b_2='" + txtq30b2.InnerText + "', q30b_3='" + txtq30b3.InnerText + "', q30b_4='" + txtq30b4.InnerText + "', q30b_5='" + txtq30b5.InnerText + "', q30b_6='" + txtq30b6.InnerText + "', q30b_7='" + txtq30b7.InnerText + "', q30b_8='" + txtq30b8.InnerText + "', q30b_9='" + txtq30b9.InnerText + "', q30b_10='" + txtq30b10.InnerText + "'          where  id='" + Request.QueryString["FormID"] + "' and status=0", cn);
                    MySqlCommand cmd = new MySqlCommand("update crf8 set q26='" + txtq26.Text + "',q27='" + txtq27.Text + "',q27_other='" + txtq27_other.Text + "',q28='" + txtq28.Text + "'	,q29_minutes='" + txtq29_min.Text + "'	,q29_hours='" + txtq29_hr.Text + "', q29_days='" + txtq29_day.Text + "', q30a_1='" + txtq30a1.InnerText + "', q30a_2='" + txtq30a2.InnerText + "', q30a_3='" + txtq30a3.InnerText + "', q30a_4='" + txtq30a4.InnerText + "', q30a_5='" + txtq30a5.InnerText + "', q30a_6='" + txtq30a6.InnerText + "', q30a_7='" + txtq30a7.InnerText + "', q30a_8='" + txtq30a8.InnerText + "', q30a_9='" + txtq30a9.InnerText + "', q30a_10='" + txtq30a10.InnerText + "',q30a_11='" + txtq30a11.InnerText + "',q30a_12='" + txtq30a12.InnerText + "',q30a_13='" + txtq30a13.InnerText + "',q30a_14='" + txtq30a14.InnerText + "',q30a_15='" + txtq30a15.InnerText + "',      q30b_1='" + txtq30b1.InnerText + "', q30b_2='" + txtq30b2.InnerText + "', q30b_3='" + txtq30b3.InnerText + "', q30b_4='" + txtq30b4.InnerText + "', q30b_5='" + txtq30b5.InnerText + "', q30b_6='" + txtq30b6.InnerText + "', q30b_7='" + txtq30b7.InnerText + "', q30b_8='" + txtq30b8.InnerText + "', q30b_9='" + txtq30b9.InnerText + "', q30b_10='" + txtq30b10.InnerText + "',q30b_11='" + txtq30b11.InnerText + "',q30b_12='" + txtq30b12.InnerText + "',q30b_13='" + txtq30b13.InnerText + "',q30b_14='" + txtq30b14.InnerText + "',q30b_15='" + txtq30b15.InnerText + "',                       q30a_1dt='" + txtq30a1dt.Text + "', q30a_2dt='" + txtq30a2dt.Text + "', q30a_3dt='" + txtq30a3dt.Text + "', q30a_4dt='" + txtq30a4dt.Text + "', q30a_5dt='" + txtq30a5dt.Text + "', q30a_6dt='" + txtq30a6dt.Text + "', q30a_7dt='" + txtq30a7dt.Text + "', q30a_8dt='" + txtq30a8dt.Text + "', q30a_9dt='" + txtq30a9dt.Text + "', q30a_10dt='" + txtq30a10dt.Text + "',q30a_11dt='" + txtq30a11dt.Text + "',q30a_12dt='" + txtq30a12dt.Text + "',q30a_13dt='" + txtq30a13dt.Text + "',q30a_14dt='" + txtq30a14dt.Text + "',q30a_15dt='" + txtq30a15dt.Text + "',                           q30b_1dt='" + txtq30b1dt.Text + "', q30b_2dt='" + txtq30b2dt.Text + "', q30b_3dt='" + txtq30b3dt.Text + "', q30b_4dt='" + txtq30b4dt.Text + "', q30b_5dt='" + txtq30b5dt.Text + "', q30b_6dt='" + txtq30b6dt.Text + "', q30b_7dt='" + txtq30b7dt.Text + "', q30b_8dt='" + txtq30b8dt.Text + "', q30b_9dt='" + txtq30b9dt.Text + "', q30b_10dt='" + txtq30b10dt.Text + "', q30b_11dt='" + txtq30b11dt.Text + "', q30b_12dt='" + txtq30b12dt.Text + "', q30b_13dt='" + txtq30b13dt.Text + "', q30b_14dt='" + txtq30b14dt.Text + "', q30b_15dt='" + txtq30b15dt.Text + "'          where  id='" + Request.QueryString["FormID"] + "' and status=0", cn);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("crf8c.aspx?&FormID=" + Request.QueryString["FormID"] + "&Study_ID=" + Request.QueryString["Study_ID"]);
                }
            }
            catch (Exception ex)
            {
                showalert(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }





        public void FieldFill()
        {
            MySqlConnection con = new MySqlConnection(LiveServer);
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from crf8 where  id='" + Request.QueryString["FormID"] + "' and status=0", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    AD_Start_Date = dr["q16"].ToString();
                    AD_Stop_Date = dr["q18"].ToString();

                    txtq26.SelectedValue = dr["q26"].ToString();
                    txtq27.SelectedValue = dr["q27"].ToString();
                    txtq27_other.Text = dr["q27_other"].ToString();
                    txtq28.SelectedValue = dr["q28"].ToString();

                    txtq29_min.Text = dr["q29_minutes"].ToString();
                    txtq29_hr.Text = dr["q29_hours"].ToString();
                    txtq29_day.Text = dr["q29_days"].ToString();



                    txtq30a1.InnerText = dr["q30a_1"].ToString();
                    txtq30a2.InnerText = dr["q30a_2"].ToString();
                    txtq30a3.InnerText = dr["q30a_3"].ToString();
                    txtq30a4.InnerText = dr["q30a_4"].ToString();
                    txtq30a5.InnerText = dr["q30a_5"].ToString();
                    txtq30a6.InnerText = dr["q30a_6"].ToString();
                    txtq30a7.InnerText = dr["q30a_7"].ToString();
                    txtq30a8.InnerText = dr["q30a_8"].ToString();
                    txtq30a9.InnerText = dr["q30a_9"].ToString();
                    txtq30a10.InnerText = dr["q30a_10"].ToString();
                    txtq30a11.InnerText = dr["q30a_11"].ToString();
                    txtq30a12.InnerText = dr["q30a_12"].ToString();
                    txtq30a13.InnerText = dr["q30a_13"].ToString();
                    txtq30a14.InnerText = dr["q30a_14"].ToString();
                    txtq30a15.InnerText = dr["q30a_15"].ToString();

                    txtq30b1.InnerText = dr["q30b_1"].ToString();
                    txtq30b2.InnerText = dr["q30b_2"].ToString();
                    txtq30b3.InnerText = dr["q30b_3"].ToString();
                    txtq30b4.InnerText = dr["q30b_4"].ToString();
                    txtq30b5.InnerText = dr["q30b_5"].ToString();
                    txtq30b6.InnerText = dr["q30b_6"].ToString();
                    txtq30b7.InnerText = dr["q30b_7"].ToString();
                    txtq30b8.InnerText = dr["q30b_8"].ToString();
                    txtq30b9.InnerText = dr["q30b_9"].ToString();
                    txtq30b10.InnerText = dr["q30b_10"].ToString();
                    txtq30b11.InnerText = dr["q30b_11"].ToString();
                    txtq30b12.InnerText = dr["q30b_12"].ToString();
                    txtq30b13.InnerText = dr["q30b_13"].ToString();
                    txtq30b14.InnerText = dr["q30b_14"].ToString();
                    txtq30b15.InnerText = dr["q30b_15"].ToString();



                    txtq30a1dt.Text = dr["q30a_1dt"].ToString();
                    txtq30a2dt.Text = dr["q30a_2dt"].ToString();
                    txtq30a3dt.Text = dr["q30a_3dt"].ToString();
                    txtq30a4dt.Text = dr["q30a_4dt"].ToString();
                    txtq30a5dt.Text = dr["q30a_5dt"].ToString();
                    txtq30a6dt.Text = dr["q30a_6dt"].ToString();
                    txtq30a7dt.Text = dr["q30a_7dt"].ToString();
                    txtq30a8dt.Text = dr["q30a_8dt"].ToString();
                    txtq30a9dt.Text = dr["q30a_9dt"].ToString();
                    txtq30a10dt.Text = dr["q30a_10dt"].ToString();
                    txtq30a11dt.Text = dr["q30a_11dt"].ToString();
                    txtq30a12dt.Text = dr["q30a_12dt"].ToString();
                    txtq30a13dt.Text = dr["q30a_13dt"].ToString();
                    txtq30a14dt.Text = dr["q30a_14dt"].ToString();
                    txtq30a15dt.Text = dr["q30a_15dt"].ToString();

                    txtq30b1dt.Text = dr["q30b_1dt"].ToString();
                    txtq30b2dt.Text = dr["q30b_2dt"].ToString();
                    txtq30b3dt.Text = dr["q30b_3dt"].ToString();
                    txtq30b4dt.Text = dr["q30b_4dt"].ToString();
                    txtq30b5dt.Text = dr["q30b_5dt"].ToString();
                    txtq30b6dt.Text = dr["q30b_6dt"].ToString();
                    txtq30b7dt.Text = dr["q30b_7dt"].ToString();
                    txtq30b8dt.Text = dr["q30b_8dt"].ToString();
                    txtq30b9dt.Text = dr["q30b_9dt"].ToString();
                    txtq30b10dt.Text = dr["q30b_10dt"].ToString();
                    txtq30b11dt.Text = dr["q30b_11dt"].ToString();
                    txtq30b12dt.Text = dr["q30b_12dt"].ToString();
                    txtq30b13dt.Text = dr["q30b_13dt"].ToString();
                    txtq30b14dt.Text = dr["q30b_14dt"].ToString();
                    txtq30b15dt.Text = dr["q30b_15dt"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }

    }
}