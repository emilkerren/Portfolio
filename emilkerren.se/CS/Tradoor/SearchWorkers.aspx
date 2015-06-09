<%@ Page Title="" Language="C#" MasterPageFile="JobCreaterMasterPage.master" AutoEventWireup="true" CodeFile="SearchWorkers.aspx.cs" Inherits="SearchWorkers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="label_search" runat="server" Text="search username"></asp:Label> 
     <asp:TextBox ID="txtSearch" runat="server" />&nbsp;&nbsp;
    <asp:ImageButton ID="btnSearch" ImageUrl="~/SearchButton.png" runat="server"
        Style="top: 5px; position: relative" onclick="btnSearch_Click" />&nbsp;&nbsp;
        <asp:ImageButton ID="btnClear" ImageUrl="~/Clearbutton.png" runat="server" Style="top: 5px;
        position: relative" onclick="btnClear_Click" /><br />
            <br />
    <asp:GridView ID="GWAvailableWorkers" runat="server" AllowSorting="True" AutoGenerateColumns="False" OnSelectedIndexChanged="GWAvailableWorkers_SelectedIndexChanged" DataKeyNames="Id">
       
         <Columns>
             <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
             <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
             <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
             <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
             <asp:CheckBoxField DataField="Jobcreator" HeaderText="Jobcreator" SortExpression="Jobcreator" />
             <asp:BoundField DataField="Telephone" HeaderText="Telephone" SortExpression="Telephone" />
         </Columns>
       
         <SelectedRowStyle BackColor="#3399FF" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" FilterExpression="UserName LIKE '%{0}%'" ConnectionString="<%$ ConnectionStrings:fuohulnwTradoorDbConnectionString %>" SelectCommand="SELECT [FirstName], [LastName], [Email], [UserName], [Jobcreator], [Telephone] FROM [MemberSet] WHERE ([Jobcreator] = @Jobcreator)">
        <FilterParameters>
        <asp:ControlParameter Name="UserName" ControlID="txtSearch" PropertyName="Text" />
        </FilterParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="False" Name="Jobcreator" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="label_selected" runat="server" Text="Label"></asp:Label><br />
     <asp:Label ID="status" runat="server" Text="status"></asp:Label><br />
    <asp:Button ID="BtnSelectedIndex" runat="server" Text="Visit" OnClick="BtnSelectedIndex_Click" />
    
</asp:Content>

