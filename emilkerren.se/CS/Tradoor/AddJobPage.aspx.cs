using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddJobPage : System.Web.UI.Page
{
    protected Member currentUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        //User currentUser = User;
        //userId = Convert.ToInt32(currentUser.Id);
    }
    protected void btn_click_addJob(object sender, EventArgs e)
    {
        if (TB_Title.Text == "" || TB_Category.Text == "" || TB_Description.Text == "" || TB_Location.Text == "" || TB_StartingPrice.Text == "")
        {
            return;
        }
        currentUser = (Member)Session["user"];
        using (ModelContext context = new ModelContext())
        {
            var newJob = new Job
            {
                Title = TB_Title.Text,
                Category = TB_Category.Text,
                Description = TB_Description.Text,
                Location = TB_Location.Text,
                AskingPrice = TB_StartingPrice.Text,
                MemberId = currentUser.Id,


            };

            context.JobSet.Add(newJob);
            context.SaveChanges();

            GridView1.DataSource = context.JobSet.Where(x => x.MemberId == currentUser.Id).ToList();
            GridView1.DataBind();
            //DataFactory.AddJob(TB_Title.Text, TB_Description.Text, TB_Category.Text, TB_Location.Text, TB_AskingPrice.Text, sessionUserID);

        }
        linkBtn_profile.Visible = true;
    }

    protected void linkBtn_profile_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProfilePage.aspx");
    }
}