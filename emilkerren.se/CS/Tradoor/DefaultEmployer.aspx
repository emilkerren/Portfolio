<%@ Page Title="" Language="C#" MasterPageFile="../Tradoor/JobCreaterMasterPage.master" AutoEventWireup="true" CodeFile="DefaultEmployer.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="GWJobsAdded" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True" SortExpression="Description" />
             <asp:BoundField DataField="Category" HeaderText="Category" ReadOnly="True" SortExpression="Category" />
             <asp:BoundField DataField="Location" HeaderText="Location" ReadOnly="True" SortExpression="Location" />
             <asp:BoundField DataField="AskingPrice" HeaderText="AskingPrice" ReadOnly="True" SortExpression="AskingPrice" />
         
        </Columns>
</asp:GridView>
</asp:Content>




