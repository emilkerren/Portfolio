<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CssProfile.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>

        <asp:Label ID="lbl_firstname" runat="server" Text="Firstname"></asp:Label>
        <asp:TextBox ID="TB_firstname" Text="" runat="server" ></asp:TextBox> 
        </p>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="must be under 15 chars and non numeric" ControlToValidate="TB_firstname" ValidationExpression="^[a-zA-Z''-'\s]{1,15}$"></asp:RegularExpressionValidator>
        <p>

        <asp:Label ID="lbl_lastname" runat="server" Text="Lastname"></asp:Label>
        <asp:TextBox ID="TB_lastname" Text="" runat="server"></asp:TextBox>
        </p>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="must be under 25 chars and non numeric" ControlToValidate="TB_lastname" ValidationExpression="^[a-zA-Z''-'\s]{1,25}$"></asp:RegularExpressionValidator> <br />
        <p>

        <asp:Label ID="lbl_username" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="TB_username" Text="" runat="server">
        </asp:TextBox>
        </p>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="must be under 15 chars and non numeric" ControlToValidate="TB_username" ValidationExpression="^[a-zA-Z''-'\s]{1,15}$"></asp:RegularExpressionValidator> <br />
        <p>

        <asp:Label ID="lbl_pw" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TB_pw" Text="" runat="server"></asp:TextBox> <br />
        </p>
        <p>

        <asp:Label ID="lbl_repeat_pw" runat="server" Text="Reapeat password"></asp:Label>
        <asp:TextBox ID="TB_pw2" Text="" runat="server"></asp:TextBox>
        </p>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="password doesn't match" ControlToValidate="TB_pw" ControlToCompare="TB_pw2"></asp:CompareValidator><br />
<p>

        <asp:Label ID="lbl_email" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="TB_email" Text="" runat="server"></asp:TextBox><br />
</p>
<p>

        <asp:Label ID="lbl_telephone" runat="server" Text="Telephone"></asp:Label>
        <asp:TextBox ID="TB_Telephone" Text="" runat="server"> </asp:TextBox>
</p>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="must be 10 chars and numeric" ControlToValidate="TB_Telephone" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator><br />
        <asp:CheckBox ID="CheckBox_jobcreator" runat="server" Text="job creator"/> <br />
        

    <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
