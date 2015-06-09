using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portfolio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ContentPlaceHolder cpCSharp = (ContentPlaceHolder)this.Page.Master.FindControl("ContentPlaceHolderCSharp");
        cpCSharp.Visible = true;
        ContentPlaceHolder cpFlash = (ContentPlaceHolder)this.Page.Master.FindControl("ContentPlaceHolderFlash");
        cpFlash.Visible = true;
    }

    //protected void OnChanged(object sender, EventArgs e)
    //{
    //    if(DDL_portfolio.SelectedValue == "1"){

    //        ContentPlaceHolder cpCSharp = (ContentPlaceHolder)this.Page.Master.FindControl("ContentPlaceHolderCSharp");
    //        cpCSharp.Visible = true;

    //        ContentPlaceHolder cpFlash = (ContentPlaceHolder)this.Page.Master.FindControl("ContentPlaceHolderFlash");
    //        cpFlash.Visible = false;
    //    }
    //    else if(DDL_portfolio.SelectedValue =="2")
    //    {
    //        ContentPlaceHolder cpCSharp = (ContentPlaceHolder)this.Page.Master.FindControl("ContentPlaceHolderCSharp");
    //        cpCSharp.Visible = false;

    //        ContentPlaceHolder cpFlash = (ContentPlaceHolder)this.Page.Master.FindControl("ContentPlaceHolderFlash");
    //        cpFlash.Visible = true;
    //    }
    //}
}