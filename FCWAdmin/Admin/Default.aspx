<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FCWAdmin.Admin.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentTitle" runat="server">
    Ndeshjet
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentContent" runat="server">
    <script type="text/javascript">
        function DateChanged() {
            $get('<%=txtCalendar.ClientID %>').value = $find('dtNdeshjet').get_selectedDate();
            $get('<%=btnFilter.ClientID %>').click();
       }
    </script>
    <asp:TextBox ID="txtCalendar" runat="server" OnTextChanged="txtCalendar_TextChanged" ClientIDMode="Static"></asp:TextBox>
    <asp:Button ID="btnFilter" runat="server" Text="Button" OnClick="btnFilter_Click" ClientIDMode="Static" />
    <ajaxToolkit:CalendarExtender ClientIDMode="Static" ID="dtNdeshjet" runat="server" Format="dd/MM/yyyy" TargetControlID="txtCalendar" OnClientDateSelectionChanged="DateChanged" />
    <asp:GridView ID="gdView" Width="50%" AutoGenerateEditButton="true" runat="server" PageSize="50" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" ForeColor="#333333" GridLines="None" OnRowDataBound="gdView_RowDataBound" OnRowEditing="gdView_RowEditing" OnRowCancelingEdit="gdView_RowCancelingEdit" OnRowUpdating="gdView_RowUpdating">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="false" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hdId" runat="server" Value='<%# Eval("Id") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:HiddenField ID="hdId" runat="server" Value='<%# Eval("Id") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="HomeId" HeaderText="HomeId" SortExpression="HomeId" Visible="false" />
            <asp:BoundField DataField="AwayId" HeaderText="AwayId" SortExpression="AwayId" Visible="false" />
            <asp:BoundField DataField="LeagueId" HeaderText="LeagueId" SortExpression="LeagueId" Visible="false" />
            <asp:BoundField DataField="StartDate" ReadOnly="true" HeaderText="StartDate" SortExpression="StartDate" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
            <asp:BoundField DataField="Name" ReadOnly="true" HeaderText="Home Team" SortExpression="Name" />
            <asp:BoundField DataField="Name1" ReadOnly="true" HeaderText="Away Team" SortExpression="Name1" />
            <asp:BoundField DataField="Name2" ReadOnly="true" HeaderText="League" SortExpression="Name2" />
            <asp:BoundField DataField="PackId" HeaderText="Pack" SortExpression="PackId" Visible="false" />
            <asp:TemplateField HeaderText="Pack" SortExpression="Pack">
                <ItemTemplate>
                    <asp:Label ID="lblPack" runat="server" Text='<%# Eval("PackName")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblPack" runat="server" Text='<%# Eval("PackName")%>' Visible="false"></asp:Label>
                    <asp:DropDownList ID="ddlPacks" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
</asp:Content>
