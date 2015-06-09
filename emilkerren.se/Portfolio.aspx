<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Portfolio.aspx.cs" Inherits="Portfolio" %>



<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <h1>
        Här finns några av mina projekt
    </h1>
    <%-- <asp:DropDownList ID="DDL_portfolio" runat="server" AutoPostBack="false" Height="19px" OnSelectedIndexChanged="OnChanged" Width="208px">
                <asp:ListItem Enabled="False" Value="0" Selected="True">Portfolio</asp:ListItem>
                <asp:ListItem Value="1">C# Projects</asp:ListItem>
                <asp:ListItem Value="2">Flash Projects</asp:ListItem>
            </asp:DropDownList>--%>
         
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderCSharp" runat="server" Visible="true">
    <div id="Tradoor" runat="server" style="padding-top: 10px">
    <h3>Tradoor.se</h3>
     <p>
        Tradoor är en hemsida där man kan lägga upp "mikro-jobb" som arbetsgivare och sedan ska arbetstagare kunna buda på jobben. Man loggar in antingen som arbetsgivare eller arbetstagare. Man ska även kunna söka på arbetsgivare/arbetstagare, gå in på deras profil, "rejta" och skriva kommentar på jobben man blivit tilldelad.
        Detta var en hemtenta för ASP.NET kurs.
    </p>
    <asp:HyperLink ID="HL_Tradoor" runat="server" CssClass="Hyperlinks" NavigateUrl="~/CS/Tradoor/Default.aspx">Gå till Tradoor.se!</asp:HyperLink>
    </div>
</asp:Content>

<asp:Content ID="Content7" runat="server" ContentPlaceHolderID="ContentPlaceHolderFlash">
    <div id="Copter" runat="server" style="padding-top: 10px">
        <p class="p2">
            Copter är ett spel där man ska undvika hindren så länge som möjligt. Man styr med piltangenterna. (kräver flash)
        </p>
        <asp:Image ID="Copter_img" CssClass="Images" src="Images/copter.jpg" runat="server" />
        <asp:HyperLink ID="HyperLink_Copter" CssClass="Hyperlinks" runat="server" NavigateUrl="~/Flash/Copter/Main.html">Gå till spelet!</asp:HyperLink>
    </div>
    <div id="Coloseum" runat="server" style="margin-top:10px">
        <p class="p2">
            Coloseum är en variant av ett gammalt arkad spel. Du är den vita fyrkanten som kan skjuta obegränsat med skott. Fienderna har olika egenskaper. (tar en liten stund innan fienderna dyker upp första gången). Du styr med piltangenterna och skjuter med vänster musknapp och roterar med musen. (kräver flash)
        </p>
        <asp:Image ID="Coloseum_img" src="Images/coloseum.jpg" runat="server" />
        <asp:HyperLink ID="HyperLink_Coloseum" CssClass="Hyperlinks" runat="server" NavigateUrl="~/Flash/Coloseum/Main.html">Gå till spelet!</asp:HyperLink>
    </div>
    <div id="Superdraw" runat="server" style="margin-top:10px">
        <p class="p2">
            Med denna applikation kan du importera bilder från din dator och rita på den med färg som du justerar med de 3 kontrollerna längst ner (röd, grön. blå). Sen kan du spara ner bilden till din hårddisk. (kräver flash)
        </p>
        <asp:Image ID="Superdraw_img" src="Images/superdraw.jpg" runat="server" />
        <asp:HyperLink ID="HyperLink_Superdraw" CssClass="Hyperlinks" runat="server" NavigateUrl="~/Flash/Superdraw/superDraw.html">Gå till applikationen!</asp:HyperLink>
    </div>
    <div id="BSE" runat="server" style="margin-top:10px">
        <p class="p2">
            BSE "Basketball shootout expert" var mitt projekt arbete år 2011. Gjort med 3D-motor och fysik-motor. När jag skapade detta var allt väldigt nytt och är lite extra stolt för de. Instruktioner hur man spelar när du startar. (kräver flash)
        </p>
        <asp:Image ID="BSE_img" src="Images/BSE.jpg" runat="server" />
        <asp:HyperLink ID="HyperLink_BSE" CssClass="Hyperlinks" NavigateUrl="~/Flash/BSE/BSE.html" runat="server">Gå till spelet!</asp:HyperLink>
    </div>
    
</asp:Content>



