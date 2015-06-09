using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JobCreaterMasterPage : System.Web.UI.MasterPage
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
       
    }
    protected void gotoAddJobPage(object sender, EventArgs e)
    {
        currentUser = (Member)Session["user"];
        if (currentUser == null)
        {
            statusLabel.ForeColor = System.Drawing.Color.Red;
            statusLabel.Text = currentUser.Id.ToString();
            return;
        }
        else
        {
            Response.Redirect(string.Format("AddJobPage.aspx?UserName={0}", currentUser.UserName.ToString()));
        }

    }
    protected void gotoProfilePage(object sender, EventArgs e)
    {
        currentUser = (Member)Session["user"];
        Response.Redirect(string.Format("ProfilePage.aspx?UserName={0}", currentUser.UserName.ToString()));
    }
   
    protected void gotoSearchWorkers(object sender, EventArgs e)
    {
        Response.Redirect("SearchWorkers.aspx");
    }
}
