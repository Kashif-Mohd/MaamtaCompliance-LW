using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ComplianceMaamtaLW
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbeUserName.Text = Convert.ToString(Session["ComplianceMaamtaLW"]);

            string vall = Convert.ToString(Session["Role"]);
           

            // Only for Maamta-LW Admin User: 
            if (Convert.ToString(Session["Role"]) != "admin_maamtaLW" && Convert.ToString(Session["Role"]) != "super_admin")
            {                
                Compliance.Visible = false;
                EntryForms.Visible = false;
            }


            if (Convert.ToString(Session["Role"]) == "field")
            {
                // Main Menu
                FieldWorker.Visible = true;
                // Sub Menu
                Register_CoreDSS.Visible = false;
                Update_CoreDSS.Visible = false;

                // Main Menu
                Dashboard.Visible = false;
            }
            if (Convert.ToString(Session["Role"]) == "admin_maamtaLW")
            {
                // Main Menu

                FieldWorker.Visible = true;
                // Sub Menu             
                Register_CoreDSS.Visible = false;
            }
            if (Convert.ToString(Session["Role"]) == "admin_core_dss")
            {
                // Main Menu
                FieldWorker.Visible = true;
                // Sub Menu
                showcrf6.Visible = false;
                showcrf2.Visible = false;
                chWeight.Visible = false;
                Dashboard.Visible = false;
            }
            if (Convert.ToString(Session["Role"]) == "super_admin")
            {
                FieldWorker.Visible = true;          
            }




            if (Session["ComplianceMaamtaLW"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Convert.ToString(Session["WebForm"]) == "dashEmptySachet")
                {
                    Dashboard.Attributes.Add("class", "active");
                    dashEmptySachet.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "dashCrf11")
                {
                    Dashboard.Attributes.Add("class", "active");
                    dashCrf11.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "dashCrf8")
                {
                    Dashboard.Attributes.Add("class", "active");
                    dashCrf8.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "ReportCRF8")
                {
                    Dashboard.Attributes.Add("class", "active");
                    ReportCRF8.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }

                else if (Convert.ToString(Session["WebForm"]) == "showcrf1")
                {
                    FieldWorker.Attributes.Add("class", "active");
                    showcrf1.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf2")
                {
                    FieldWorker.Attributes.Add("class", "active");
                    showcrf2.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "coredss")
                {
                    FieldWorker.Attributes.Add("class", "active");
                    coredss.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "Register_CoreDSS")
                {
                    FieldWorker.Attributes.Add("class", "active");
                    Register_CoreDSS.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "Update_CoreDSS")
                {
                    FieldWorker.Attributes.Add("class", "active");
                    Update_CoreDSS.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "chWeight")
                {
                    FieldWorker.Attributes.Add("class", "active");
                    chWeight.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "entryEmptySachet")
                {
                    Compliance.Attributes.Add("class", "active");
                    entryEmptySachet.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "searchDssid")
                {
                    Compliance.Attributes.Add("class", "active");
                    searchdss.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "searchFollowups")
                {
                    Compliance.Attributes.Add("class", "active");
                    searchfollowups.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "crf11")
                {
                    EntryForms.Attributes.Add("class", "active");
                    crf11.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "crf8")
                {
                    EntryForms.Attributes.Add("class", "active");
                    crf8.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
            }

        }



    }
}