<%@ Page Title="" Language="C#" MasterPageFile="../Tradoor/JobTakerMasterPage.master" AutoEventWireup="true" CodeFile="ProfilePageEmployers.aspx.cs" Inherits="ProfilePageEmployers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="label_jobsCreated" runat="server" Text="Jobs created: "></asp:Label><br />
    <asp:GridView ID="GW_jobsCreated" runat="server"></asp:GridView>
     <asp:Label ID="label_tags" runat="server" Text="tags: "></asp:Label><br />
    <asp:Label ID="label_rating" runat="server" Text="rating: "></asp:Label><br />
</asp:Content>

