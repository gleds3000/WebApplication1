<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
OnPageIndexChanging = "PageIndexChanging" AllowPaging = "True" CellPadding="4" 
            ForeColor="#333333" GridLines="None" style="color: #0099FF; text-align: center" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
        <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
        <asp:BoundField DataField="Ticket " HeaderText="Ticket " SortExpression="Ticket " />
        <asp:BoundField DataField="Resumo " HeaderText="Resumo " SortExpression="Resumo " />
        <asp:BoundField DataField="Status " HeaderText="Status " SortExpression="Status " />
        <asp:BoundField DataField="Produto " HeaderText="Produto " SortExpression="Produto " />
        <asp:BoundField DataField="Responsável da Demanda" HeaderText="Responsável da Demanda" SortExpression="Responsável da Demanda" />
        <asp:BoundField DataField="Abertura" HeaderText="Abertura" SortExpression="Abertura" />
        <asp:BoundField DataField="Solucionada " HeaderText="Solucionada " SortExpression="Solucionada " />
        <asp:BoundField DataField="Fechada " HeaderText="Fechada " SortExpression="Fechada " />
        <asp:BoundField DataField="Limite SLA" HeaderText="Limite SLA" SortExpression="Limite SLA" />
        <asp:BoundField DataField="OM " HeaderText="OM " SortExpression="OM " />
        <asp:BoundField DataField="Violado?" HeaderText="Violado?" SortExpression="Violado?" />
        <asp:BoundField DataField="Portfolio" HeaderText="Portfolio" SortExpression="Portfolio" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dashToolConnectionString %>" SelectCommand="SELECT * FROM [DashGeral]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
