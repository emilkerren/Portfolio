using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

public partial class ProfilePage : System.Web.UI.Page
{
    protected Member currentUser;
    protected Member selectedBider;
    protected Job selectedJob;
    private int selJobId;
    private int bidersId;
    private int biderPrice;
    protected CommaDelimitedStringCollection _collectionOfTags;
    protected void Page_Load(object sender, EventArgs e)
    {
        currentUser = (Member)Session["user"];
        if (currentUser == null)
        {
            return;
        }
        else
        {
            firstname_label.Text = currentUser.FirstName;
            lastname_label.Text = currentUser.LastName;
            email_label.Text = currentUser.Email;
            telephone_label.Text = currentUser.Telephone;

            
            if(currentUser.Jobcreator==true)
            {
                linkBtn_addJob.Visible = true;
                GW_JobsCreated.Visible = true;
                bids_label.Visible = true;
                GW_UsersWhoHasBidOnYourJobs.Visible = true;
                GW_posts.Visible = true;
                label_posts.Visible = true;
                createdJobs_label.Visible = true;
                label_selected.Visible = true;
                status.Visible = true;
                label_selected_final.Visible = true;
                BtnSelectedIndex.Visible = true;
                foreach (var tags in currentUser.Tag)
                {

                    label_tags.Text += tags.TagWord+", ";
                }
                using (ModelContext context = new ModelContext())
                {
                    GW_JobsCreated.DataSource = context.JobSet.Where(x => x.MemberId == currentUser.Id).ToList();
                    GW_UsersWhoHasBidOnYourJobs.DataSource = context.BidSet.Where(y => y.Job.UserWhoCreatedJob.Id == currentUser.Id).ToList();
                    GW_posts.DataSource = context.PostSet.Where(z => z.Job.UserWhoCreatedJob.Id == currentUser.Id).ToList();
                    GW_JobsCreated.DataBind();
                    GW_UsersWhoHasBidOnYourJobs.DataBind();
                    GW_posts.DataBind();
                    //var jobs = context.JobSet.Where(x => x.MemberId == currentUser.Id);
                    //Profile.jobs = jobs;
                }
            }
            else if(currentUser.Jobcreator == false)
            {
                    createdJobs_label.Text = "Given Jobs";
                    createdJobs_label.Visible = true;
                    GW_JobsCreated.Visible = true;
                    status.Visible = true;
                    foreach (var tags in currentUser.Tag)
                    {

                        label_tags.Text += tags.TagWord+", ";
                    }
                using (ModelContext context = new ModelContext())
                {
                    GW_JobsCreated.DataSource = context.JobSet.Where(x => x.MemberId == currentUser.Id).ToList();
                    GW_JobsCreated.DataBind();

                    //______-------------------__________________________-------------
                    //var jobs = context.JobSet.Where(x => x.MemberId == currentUser.Id);
                    //Profile.jobs = jobs;
                   
                }
            }
        }
    }
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {

        AddRowSelectToGridView(GW_UsersWhoHasBidOnYourJobs);

        base.Render(writer);

    }

    private void AddRowSelectToGridView(GridView gv)
    {

        foreach (GridViewRow row in gv.Rows)
        {

            row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";

            row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + row.RowIndex.ToString(), true));

        }
        label_selected.Text = "jobID: " + selJobId + ", biderId: " + bidersId+", Bider price: "+biderPrice;
        selectedBider = DataFactory.RetrieveUserById(bidersId);
        selectedJob = DataFactory.RetrieveJobById(selJobId);
        
        Session["selectedJob"] = selectedJob;
        Session["selectedBider"] = selectedBider;
    }
    protected void GW_UsersWhoHasBidOnYourJobs_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GW_UsersWhoHasBidOnYourJobs.SelectedRow;
       
        biderPrice = Convert.ToInt32(row.Cells[1].Text);
        selJobId = Convert.ToInt32(row.Cells[2].Text);
        bidersId = Convert.ToInt32(row.Cells[3].Text);
       
    }
    protected void BtnSelectedIndex_Click(object sender, EventArgs e)
    {
       selectedJob = (Job)Session["selectedJob"];
       selectedBider = (Member)Session["selectedBider"];
        
        if(selectedJob != null & selectedBider != null){

            label_selected_final.Text = "Bider name: "+selectedBider.FirstName+" will be given the job: "+selectedJob.Title + " selectedbider.bid: "+selectedJob.Bid.ElementAtOrDefault(0).Price;
            //selectedBider.Job.Add(selectedJob);
            DataFactory.AddJobToBider(selectedJob, selectedBider.Id);

            status.Text += "added succesfully";
        }
    }
    protected void linkBtn_addJob_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddJobPage.aspx");
    }
    protected void BtnAddTag_Click(object sender, EventArgs e)
    {
        string tag = TBTag.Text;
        if(tag != ""){

            DataFactory.AddTagToUser(currentUser, tag);
        }
        TBTag.Text = "";
        label_tags.Text = "";
        foreach (var tags in currentUser.Tag)
        {

            label_tags.Text += tags.TagWord + ", ";
        }
    }
}