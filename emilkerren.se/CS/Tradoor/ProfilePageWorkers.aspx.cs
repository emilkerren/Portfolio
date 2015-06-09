using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
public partial class ProfilePageWorkers : System.Web.UI.Page
{
    protected string requestedString;
    protected Member requestedMember;
    protected Member currentUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        MouseEvents();

        currentUser = (Member)Session["user"];
        requestedString = Request.QueryString["UserName"];
        requestedMember = DataFactory.RetrieveUser(requestedString);
        if(requestedString != ""){
            foreach (var tags in requestedMember.Tag)
            {

                label_tags.Text += tags.TagWord;
            }
            requestedMember = DataFactory.RetrieveUser(requestedString);
        }
        GW_jobsGiven.DataSource = requestedMember.JobsCreated;
        GW_jobsGiven.DataBind();

        if(requestedMember.Rating == null){
              label_rating.Text = "no rating yet";

        }else{    
            label_rating.Text = DataFactory.calculateRating(requestedMember, currentUser).ToString();
        }
        
    }
    protected void Rating1_Click(object sender, ImageClickEventArgs e)
    {
            DataFactory.AddRating(requestedMember, 1);
            label_rating.Text = DataFactory.calculateRating(requestedMember, currentUser).ToString();
    }
    protected void Rating2_Click(object sender, ImageClickEventArgs e)
    {
            DataFactory.AddRating(requestedMember, 2);
            label_rating.Text = DataFactory.calculateRating(requestedMember, currentUser).ToString();
    }
    protected void Rating3_Click(object sender, ImageClickEventArgs e)
    {
            DataFactory.AddRating(requestedMember, 3);
            label_rating.Text = DataFactory.calculateRating(requestedMember, currentUser).ToString();
    }
    protected void Rating4_Click(object sender, ImageClickEventArgs e)
    {
            DataFactory.AddRating(requestedMember, 4);
            label_rating.Text = DataFactory.calculateRating(requestedMember, currentUser).ToString();
    }
    protected void Rating5_Click(object sender, ImageClickEventArgs e)
    {
            DataFactory.AddRating(requestedMember, 5);
            label_rating.Text = DataFactory.calculateRating(requestedMember, currentUser).ToString();
    }
    private void MouseEvents()
    {
        Rating1.Attributes.Add("onmouseover", "this.src='Images/Filled.gif'");
        Rating1.Attributes.Add("onmouseout", "this.src='Images/Unfilled.gif'");
        
        Rating2.Attributes.Add("onmouseover", "this.src='Images/Filled.gif'");
        Rating2.Attributes.Add("onmouseout", "this.src='Images/Unfilled.gif'");
        
        Rating3.Attributes.Add("onmouseover", "this.src='Images/Filled.gif'");
        Rating3.Attributes.Add("onmouseout", "this.src='Images/Unfilled.gif'");
        
        Rating4.Attributes.Add("onmouseover", "this.src='Images/Filled.gif'");
        Rating4.Attributes.Add("onmouseout", "this.src='Images/Unfilled.gif'");
        
        Rating5.Attributes.Add("onmouseover", "this.src='Images/Filled.gif'");
        Rating5.Attributes.Add("onmouseout", "this.src='Images/Unfilled.gif'");
    }
}