using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
public partial class SearchEmployers : System.Web.UI.Page
{
    protected string employerUserName;
    protected Member selectedEmployer;
    private string SearchString = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        GW_jobCreators.DataSource = DataFactory.RetrieveEmployers();
        GW_jobCreators.DataBind();
        //Response.Write("<script>alert('login successful');</script>");
    }
    public string HighlightText(string InputTxt)
    {
        string Search_Str = txtSearch.Text;
        // Setup the regular expression and add the Or operator.
        Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
        // Highlight keywords by calling the
        //delegate each time a keyword is found.
        return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
    }

    public string ReplaceKeyWords(Match m)
    {
        return ("<span class=highlight>" + m.Value + "</span>");
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        //  Set the value of the SearchString so it gets
        SearchString = txtSearch.Text;
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        //  Simple clean up text to return the Gridview to it's default state
        txtSearch.Text = "";
        SearchString = "";
        GW_jobCreators.DataBind();
    }
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {

        AddRowSelectToGridView(GW_jobCreators);

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
        label_selected.Text = "Username " + employerUserName;
        selectedEmployer = DataFactory.RetrieveUser(employerUserName);
        Session["profile"] = selectedEmployer;
    }
    protected void BtnSelectedIndex_Click(object sender, EventArgs e)
    {


        selectedEmployer = (Member)Session["profile"];
        //gå in på profilsidan för den tryckta arbetaren
        if (selectedEmployer == null)
        {
            status.Text = "error selected worker is null";
            //label_selected.Text = " fel!!! "+selectedWorker;
        }
        else
        {
            Response.Redirect(string.Format("ProfilePageEmployers.aspx?UserName={0}", selectedEmployer.UserName.ToString()));
        }
    }
    protected void GW_jobCreators_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GW_jobCreators.SelectedRow;
        //string b = row.Cells[6].Text;
        employerUserName = row.Cells[3].Text;
    }
}
