<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Log.aspx.cs"  Inherits="WebApplication1.log" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Histórico
        
    </h2>
    <p>
         Exibir log's de Importação de dados. 
     </p>  
    <p> Selecione o Grupo: <asp:DropDownList ID="Ddl1Grupoarea" runat="server">
        </asp:DropDownList> 
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Gerar" />
    </p>
    <p>
        <asp:Chart ID="Chart1" runat="server" >
             <series>
                 <asp:Series Name="Series1">
                 </asp:Series>
             </series>
             <chartareas>
                 <asp:ChartArea Name="ChartArea1">
                 </asp:ChartArea>
             </chartareas>
         </asp:Chart>
         <asp:GridView ID="GridView2" runat="server">
         </asp:GridView>
    </p>
   </asp:Content>
