<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="Label1" runat="server" Text="All books in store"></asp:Label>
    <br />
    <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="1px" CellPadding="2" CellSpacing="2" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableCell ID="Num" runat="server">Num</asp:TableCell>
                <asp:TableCell ID="ID" runat="server">ID</asp:TableCell>
                <asp:TableCell ID="Name" runat="server">Name</asp:TableCell>
                <asp:TableCell ID="Author" runat="server">Author</asp:TableCell>
                <asp:TableCell ID="Year" runat="server">Year</asp:TableCell>
                <asp:TableCell ID="Price" runat="server">Price</asp:TableCell>
                <asp:TableCell ID="Stock" runat="server">Stock</asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    <br />
    <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
&nbsp;
    <asp:Label ID="Label2" runat="server" Text="ID"></asp:Label>
&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
    <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
&nbsp;
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;
    <asp:Label ID="Label4" runat="server" Text="Author"></asp:Label>
&nbsp;
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;
    <asp:Label ID="Label5" runat="server" Text="Year"></asp:Label>
&nbsp;
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
&nbsp;
    <asp:Label ID="Label6" runat="server" Text="Prices"></asp:Label>
&nbsp;
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
&nbsp; Stock&nbsp;
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" />
&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>Num</asp:ListItem>
        <asp:ListItem>Year</asp:ListItem>
        <asp:ListItem>ID</asp:ListItem>
    </asp:DropDownList>
&nbsp;
    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button3" runat="server" Text="Search" OnClick="Button3_Click" />
&nbsp;
    <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem>ID</asp:ListItem>
        <asp:ListItem>Name</asp:ListItem>
        <asp:ListItem>Author</asp:ListItem>
        <asp:ListItem>Year</asp:ListItem>
    </asp:DropDownList>
&nbsp;
    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>

    <br />
    <asp:Table ID="Table2" runat="server" BorderColor="Black" BorderWidth="1px" CellPadding="2" CellSpacing="2" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell1" runat="server">Num</asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server">ID</asp:TableCell>
                <asp:TableCell ID="TableCell3" runat="server">Name</asp:TableCell>
                <asp:TableCell ID="TableCell4" runat="server">Author</asp:TableCell>
                <asp:TableCell ID="TableCell5" runat="server">Year</asp:TableCell>
                <asp:TableCell ID="TableCell6" runat="server">Price</asp:TableCell>
                <asp:TableCell ID="TableCell7" runat="server">Stock</asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    <br />
    <br />
    <asp:Label ID="Label7" runat="server" Text="Purchase books"></asp:Label>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Total budget"></asp:Label>
&nbsp;
    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
    <br />

    <asp:Panel ID = "Panel1" runat="server">
        </asp:Panel>
    <br />
    <asp:Button ID="Button4" runat="server" Text="More" OnClick="Button4_Click" />
    <br />
    
    <asp:Button ID="Button5" runat="server" Text="Purchase" OnClick="Button5_Click" />
&nbsp;
    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
&nbsp;&nbsp; 

    <br />
    <br />
    <asp:Label ID="Label9" runat="server" Text="Error Message Display"></asp:Label>
&nbsp;
    <asp:TextBox ID="TextBox13" runat="server" ></asp:TextBox>

</asp:Content>
