<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfilePage.aspx.cs" Inherits="ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:Label ID="firstname_label" runat="server" Text="" BorderStyle="Solid"></asp:Label> <br />
        <asp:Label ID="lastname_label" runat="server" Text="" BorderStyle="Solid"></asp:Label> <br />
        <asp:Label ID="email_label" runat="server" Text="" BorderStyle="Solid"></asp:Label> <br />
        <asp:Label ID="telephone_label" runat="server" Text="" BorderStyle="Solid"></asp:Label> <br />
        <br />
        <asp:Label ID="label_tags" runat="server" Text="tags: "> </asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnAddTag" runat="server" Text="Add tag" OnClick="BtnAddTag_Click"/> <asp:TextBox ID="TBTag" runat="server"></asp:TextBox><br /><br />
        <asp:Label ID="createdJobs_label" runat="server" Text="created jobs" BorderStyle="Solid" Visible="false"></asp:Label> <br />
        <asp:GridView ID="GW_JobsCreated" runat="server" Visible="false"></asp:GridView><br />
        <asp:Label ID="bids_label" runat="server" Text="bids on your jobs" BorderStyle="Solid" Visible="false"></asp:Label> <br />
        <asp:GridView ID="GW_UsersWhoHasBidOnYourJobs" runat="server" OnSelectedIndexChanged="GW_UsersWhoHasBidOnYourJobs_SelectedIndexChanged" Visible="False">
             <SelectedRowStyle BackColor="#3399FF" />
        </asp:GridView><br />
        <asp:Label ID="label_posts" runat="server" Text="Posts" Visible="false"></asp:Label><br />
         <asp:GridView ID="GW_posts" runat="server" Visible="false">
         </asp:GridView>
        <asp:Label ID="label_selected" runat="server" Text="" Visible="false"></asp:Label><br />
        <asp:Label ID="status" runat="server" Text="" Visible="false"></asp:Label><br />
        <asp:Label ID="label_selected_final" runat="server" Text="" Visible="false"></asp:Label><br />
         <asp:Button ID="BtnSelectedIndex" runat="server" Text="Give bider the job" OnClick="BtnSelectedIndex_Click" Visible="false" /><br />
        <asp:LinkButton ID="linkBtn_addJob" onClick="linkBtn_addJob_Click" runat="server" Visible="false" >add new job</asp:LinkButton>
    </div>
    </form>
</body>
</html>
