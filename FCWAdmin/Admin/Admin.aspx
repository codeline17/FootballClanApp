<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="FCW.Admin.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentTitle" runat="server">
    Ndeshjet
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentContent" runat="server">
    <asp:GridView ID="gdView" runat="server" DataSourceID="dsMatches"></asp:GridView>
    <asp:SqlDataSource ID="dsMatches" runat="server"></asp:SqlDataSource>
</asp:Content>
