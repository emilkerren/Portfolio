using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

public partial class Register : System.Web.UI.Page
{
    private bool successful = false;
    protected void Page_Load(object sender, EventArgs e)
    {

        successful = false;
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        using (var myEntity = new ModelContext())
        {
            var newUser = new Member
            {
                FirstName = TB_firstname.Text,
                LastName = TB_lastname.Text,
                Email = TB_email.Text,
                Password = TB_pw2.Text,
                UserName = TB_username.Text,
                Telephone = TB_Telephone.Text,
                Jobcreator = CheckBox_jobcreator.Checked,
                Admin = false,
                JobsCreated=null
                
            };
            myEntity.MemberSet.Add(newUser);
            myEntity.SaveChanges();
            successful = true;
        }
        
       
        if(successful == true){
            Response.Redirect("Default.aspx");
        }
    }
}