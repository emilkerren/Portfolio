<%@ Page Title="" Language="C#" MasterPageFile="../Tradoor/JobCreaterMasterPage.master" AutoEventWireup="true" CodeFile="ProfilePageWorkers.aspx.cs" Inherits="ProfilePageWorkers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="label_jobsTaken" runat="server" Text="Jobs given: "></asp:Label><br />
    <asp:GridView ID="GW_jobsGiven" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
            <asp:BoundField DataField="AskingPrice" HeaderText="AskingPrice" SortExpression="AskingPrice" />
        </Columns>
    </asp:GridView>
     <asp:Label ID="label_tags" runat="server" Text="tags: "></asp:Label><br />
    <asp:Label ID="label_rating" runat="server" Text="rating: "></asp:Label><br />
    <asp:ImageButton BorderStyle="None" ID="Rating1"
       
       OnClientClick="" ImageUrl="~/Images/Unfilled.gif"
        Height="20px" Width="20px" CssClass="CssProfile.css" runat="server" OnClick="Rating1_Click" />
    <asp:ImageButton BorderStyle="None" ID="Rating2" 
       OnClientClick="" ImageUrl="~/Images/Unfilled.gif"
      Height="20px" Width="20px" CssClass="CssProfile.css" runat="server" />
    <asp:ImageButton BorderStyle="None" ID="Rating3"
       OnClientClick="" ImageUrl="~/Images/Unfilled.gif"
       Height="20px" Width="20px" CssClass="CssProfile.css" runat="server"/>
    <asp:ImageButton BorderStyle="None" ID="Rating4" 
       OnClientClick="" ImageUrl="~/Images/Unfilled.gif"
      Height="20px" Width="20px" CssClass="CssProfile.css" runat="server" />
    <asp:ImageButton BorderStyle="None" ID="Rating5" 
      OnClientClick="" ImageUrl="~/Images/Unfilled.gif"
      Height="20px" Width="20px" CssClass="CssProfile.css" runat="server" />
</asp:Content>

