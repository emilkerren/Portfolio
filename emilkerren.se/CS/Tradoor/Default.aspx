<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tradoor</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <h1>Tradoor.se</h1>
         <asp:Label ID="Label_username" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="TextBox_username" runat="server"></asp:TextBox>
        <asp:Label ID="Label_password" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TextBox_password" runat="server"></asp:TextBox>
        <asp:Button ID="Btn_login" runat="server" Text="Login" OnClick="Btn_login_Click" />
        <asp:Button ID="Btn_logout" runat="server" Text="Logout" Visible="false" OnClick="Btn_logout_Click" />
        <asp:Label ID="Label_register" runat="server" Text="Not a member?"></asp:Label>
        <asp:LinkButton ID="linkBtn_reg" Text="register now" runat="server" OnClick="gotoReg"></asp:LinkButton><br />
        <asp:Label ID="statusLabel" runat="server" ForeColor="Red"></asp:Label><br />

       <br /> <p>
           Hello and welcome to Tradoor!<br />
           Here you can create a profile as a "jobcreator" or "worker". <br />
           When you are logged in you either bid on jobs or create them, depending on what your account status is.<br />
           You can also check out the jobcreators profile if you are a worker and vice versa. <br />
           If you don't wanna create a profile you can use "emketradoor" with password "emkepw1" as jobcreator.<br />
           And "moketradoor" with password "mokepw1" as worker.
           Enjoy! <br />
           Below is some jobs currently not taken.
              </p>
       <asp:GridView ID="GW_jobsWithBids" runat="server" AutoGenerateColumns="False" OnRowDataBound="GW_jobsWithBids_RowDataBound">
           <Columns>
               <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
               <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
               <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
               <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
               <asp:BoundField DataField="AskingPrice" HeaderText="AskingPrice" SortExpression="AskingPrice" />
           </Columns>
         </asp:GridView>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:fuohulnwTradoorDbConnectionString %>" SelectCommand="SELECT [Title], [Description], [Category], [Location], [AskingPrice] FROM [JobSet]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
