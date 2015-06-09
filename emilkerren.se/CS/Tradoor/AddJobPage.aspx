<%@ Page Title="" Language="C#" MasterPageFile="../Tradoor/JobCreaterMasterPage.master" AutoEventWireup="true" CodeFile="AddJobPage.aspx.cs" Inherits="AddJobPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>
        <asp:Label ID="title_label" runat="server" Text="title"></asp:Label><asp:TextBox ID="TB_Title" runat="server"></asp:TextBox><br />
        <asp:Label ID="description_label" runat="server" Text="description"></asp:Label><asp:TextBox ID="TB_Description" runat="server" TabIndex="1"></asp:TextBox><br />
        <asp:Label ID="category_label" runat="server" Text="category"></asp:Label><asp:TextBox ID="TB_Category" runat="server" TabIndex="2"></asp:TextBox><br />
        <asp:Label ID="location_label" runat="server" Text="location"></asp:Label><asp:TextBox ID="TB_Location" runat="server" TabIndex="3"></asp:TextBox><br />
        <asp:Label ID="startingprice_label" runat="server" Text="startingprice"></asp:Label><asp:TextBox ID="TB_StartingPrice" runat="server" TabIndex="4"></asp:TextBox><br />
        
        <asp:Button ID="Button1" runat="server" Text="Add Job" OnClick="btn_click_addJob" />
        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
        <br />
         <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataKeyNames="Id" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="false" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:LinkButton ID="linkBtn_profile" runat="server" Visible="false" OnClick="linkBtn_profile_Click">ProfilePage</asp:LinkButton>
    </div>
</asp:Content>

