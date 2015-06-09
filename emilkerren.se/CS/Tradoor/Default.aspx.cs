using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected Member currentUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        Btn_login.Visible = true;
        Btn_logout.Visible = false;
        linkBtn_reg.Visible = true;
        Label_register.Visible = true;

        GW_jobsWithBids.DataSource = DataFactory.RetrieveJobsFromEmployers();
        GW_jobsWithBids.DataBind();
    }
    protected void Btn_login_Click(object sender, EventArgs e)
    {
        string userName = TextBox_username.Text;
        string password = TextBox_password.Text;


        currentUser = DataFactory.RetrieveUser(userName);


        if (currentUser == null)
        {
            statusLabel.ForeColor = System.Drawing.Color.Red;
            statusLabel.Text = "failed to login";
            return;
        }
        if (currentUser.Password == password)
        {
            Session["user"] = currentUser;

            TextBox_username.Text = "";
            TextBox_password.Text = "";
            Btn_login.Visible = false;
            Btn_logout.Visible = true;
            
            linkBtn_reg.Visible = false;
            Label_register.Visible = false;
           
            if (currentUser.Jobcreator == true)
            {
                Response.Redirect("DefaultEmployer.aspx");
            }
            else
            {
                Response.Redirect("DefaultWorker.aspx");
            }
        }
        else
        {
            statusLabel.Text = "failed to login password";
        }
    }
    protected void Btn_logout_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        TextBox_username.Text = "";
        TextBox_password.Text = "";
        statusLabel.ForeColor = System.Drawing.Color.Black;
        statusLabel.Text = "not logged in";
        Btn_login.Visible = true;
        linkBtn_reg.Visible = true;
        Btn_logout.Visible = false;
        Label_register.Visible = true;
        
    }
    protected void gotoReg(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
   protected void GW_jobsWithBids_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = true;
    }
}