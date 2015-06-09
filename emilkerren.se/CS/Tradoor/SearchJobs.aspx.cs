using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchJobs : System.Web.UI.Page
{
    protected string jobTitle;
    protected Job selectedJob;
    protected int selJobId;
    protected Member selectedJobsMember;
    protected int bidersId;
    protected Member currentUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        currentUser = (Member)Session["user"];
        GW_availableJobs.DataSource = DataFactory.RetrieveJobsFromEmployers();
        GW_availableJobs.DataBind();
    }
    protected void GWAvailableJobs_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GW_availableJobs.SelectedRow;
        //string b = row.Cells[6].Text;
        jobTitle = row.Cells[1].Text;
        selJobId = Convert.ToInt32(row.Cells[0].Text);
        //selJobId = (int)GW_availableJobs.DataKeys[0].Value;
        bidersId = currentUser.Id;
        // selectedJobsMember = DataFactory.RetrieveUser(row.Cells[].Text);
    }
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
        AddRowSelectToGridView(GW_availableJobs);

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
        label_selected.Text = "jobID: " + selJobId + ", memId: " + bidersId;
        selectedJob = DataFactory.RetrieveJob(selJobId);
        Session["selectedJob"] = selectedJob;
        //selJobId = selectedJob.Id;

        //Session["user"] = selectedJob;
    }
    protected void BtnSelectedIndex_Click(object sender, EventArgs e)
    {
        string tb_text = TB_commentJob.Text;
        selectedJob = (Job)Session["selectedJob"];
        double sum = Convert.ToDouble(TB_bidSum.Text);
        if (selJobId != 0) { status.Text += " selJob ok "; }
        if (bidersId != 0) { status.Text += " bidersId ok "; }
        if (currentUser != null) { status.Text += " currentUser ok "; }
        if (selectedJob != null) { status.Text += " selectedJob ok "; }
        else
        {
            status.Text = "fel";

        }
        DataFactory.BidOnJob(selJobId, bidersId, sum, currentUser, selectedJob);
        status.Text += "added bid succesfully";
        if (tb_text != "")
        {
            DataFactory.PostCommentOnJob(tb_text, selectedJob, currentUser);
            status.Text += " + added post succesfully";
        }

    }


    protected void GW_availableJobs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }
}