<%@ Page Title="" Language="C#" MasterPageFile="JobTakerMasterPage.master" AutoEventWireup="true" CodeFile="SearchJobs.aspx.cs" Inherits="SearchJobs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GW_availableJobs" runat="server" OnRowDataBound="GW_availableJobs_RowDataBound" OnSelectedIndexChanged="GWAvailableJobs_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="Id">
        <Columns>
           <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="false" SortExpression="Id" Visible="true" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
            <asp:BoundField DataField="AskingPrice" HeaderText="AskingPrice" SortExpression="AskingPrice" />
            <asp:BoundField DataField="MemberId" HeaderText="MemberId" SortExpression="MemberId" />
        </Columns>
        <SelectedRowStyle BackColor="#3399FF" />
    </asp:GridView>
   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=91.189.42.44;Initial Catalog=fuohulnwTradoorDb;User ID=fuohulnwTradoruser;Password=124578;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [JobSet]"></asp:SqlDataSource>
   
    <asp:Label ID="label_selected" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="status" runat="server" Text="status"></asp:Label><br />
    <asp:Label ID="label_bid" runat="server" Text="Bid"></asp:Label>
    <br />
    
    <asp:TextBox ID="TB_bidSum" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TB_bidSum" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
   
    <br />
    <asp:Label ID="label_post" runat="server" Text="post comment on job"></asp:Label>
    <br />
    <asp:TextBox ID="TB_commentJob" runat="server"></asp:TextBox>
     <asp:Button ID="BtnSelectedIndex" runat="server" Text="Bid" OnClick="BtnSelectedIndex_Click" />
</asp:Content>

