using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfilePageEmployers : System.Web.UI.Page
{
    protected string requestedString;
    protected Member requestedMember;
    protected Member currentUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        currentUser = (Member)Session["user"];
        requestedString = Request.QueryString["UserName"];
        requestedMember = DataFactory.RetrieveUser(requestedString);
        //requestedMember.UserName = ClientQueryString;
        if (requestedString != "")
        {
            foreach (var tags in requestedMember.Tag)
            {
                
                label_tags.Text += tags.TagWord;
            }
            //requestedMember = DataFactory.RetrieveUser(requestedString);
        }
        GW_jobsCreated.DataSource = requestedMember.JobsCreated;
        GW_jobsCreated.DataBind();
        
        if (requestedMember.Rating == null)
        {
            label_rating.Text = "no rating yet";

        }
        else
        {
            label_rating.Text += DataFactory.calculateRating(requestedMember, currentUser).ToString();
        }
        
    }
}