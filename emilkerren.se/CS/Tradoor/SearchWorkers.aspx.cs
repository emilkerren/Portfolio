using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
public partial class SearchWorkers : System.Web.UI.Page
{
    protected string workerUserName;
    protected Member selectedWorker;
    private string SearchString = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       GWAvailableWorkers.DataSource = DataFactory.RetrieveAvailableWorkers();
       GWAvailableWorkers.DataBind();
       //Response.Write("<script>alert('login successful'+DataFactory.RetrieveAvailableWorkers());</script>");
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
        GWAvailableWorkers.DataBind();
    }
    protected void GWAvailableWorkers_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GWAvailableWorkers.SelectedRow;
        //string b = row.Cells[6].Text;
        workerUserName = row.Cells[3].Text;
        
    }
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {

        AddRowSelectToGridView(GWAvailableWorkers);

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
        label_selected.Text = "Username " + workerUserName;
        selectedWorker = DataFactory.RetrieveUser(workerUserName);
        Session["profile"] = selectedWorker;
    }
    protected void BtnSelectedIndex_Click(object sender, EventArgs e)
    {

        
        selectedWorker = (Member)Session["profile"];
        //gå in på profilsidan för den tryckta arbetaren
        if (selectedWorker == null)
        {
            status.Text = "error selected worker is null";
            //label_selected.Text = " fel!!! "+selectedWorker;
        }
        else
        {
            Response.Redirect(string.Format("ProfilePageWorkers.aspx?UserName={0}",selectedWorker.UserName.ToString() ));
        }
    }
}