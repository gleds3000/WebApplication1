<%@ Page Language="C#"   MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="webx.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>--%>
<%-- <body>
    <form id="form1" runat="server">--%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div><b>DashBoard - Importação de dados</b></div>
    <div>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnUpload" runat="server" Text="Carregar"
            OnClick="btnUpload_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Cabeçalho?" />
    <asp:RadioButtonList ID="rbHDR" runat="server">
    <asp:ListItem Text = "Sim" Value = "Yes" Selected = "True" >
    </asp:ListItem>
    <asp:ListItem Text = "Não" Value = "No"></asp:ListItem>
    </asp:RadioButtonList>
<asp:GridView ID="GridView1" runat="server"
OnPageIndexChanging = "PageIndexChanging" AllowPaging = "True" CellPadding="3" GridLines="Vertical" 
            style="color: #0099FF; text-align: center" PageSize="10" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px">
    <AlternatingRowStyle BackColor="#DCDCDC" />
    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#0000A9" />
    <SortedDescendingCellStyle BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#000065" />
</asp:GridView>
    </div>
    </asp:Content>

 <%--   </form>
</body>
</html>--%>
