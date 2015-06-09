using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JobTakerMasterPage : System.Web.UI.MasterPage
{
    protected Member currentUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    
    protected void Btn_logout_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        statusLabel.ForeColor = System.Drawing.Color.Black;
        statusLabel.Text = "not logged in";
        Response.Redirect("Default.aspx");
        /*Btn_login.Visible = true;
        linkBtn_reg.Visible = true;
        Btn_logout.Visible = false;
        Label_register.Visible = true;
        linkBtn_profile.Visible = false;*/
    }
    protected void gotoSearchEmployers(object sender, EventArgs e)
    {
        Response.Redirect("SearchEmployers.aspx");
    }
    protected void gotoProfilePage(object sender, EventArgs e)
    {
        Response.Redirect("ProfilePage.aspx");
    }
    
    protected void gotoJobsPage(object sender, EventArgs e)
    {
        Response.Redirect("SearchJobs.aspx");
    }
}
