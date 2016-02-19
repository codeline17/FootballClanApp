<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Leagues.aspx.cs" Inherits="FCWAdmin.Admin.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentTitle" runat="server">
    Leagues
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentContent" runat="server">
    <style>
        .hidden {
            display: none;
        }
    </style>
    <script type="text/javascript">
        function DateChanged() {
            $get('<%=btnDummy.ClientID %>').click();
        }
    </script>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Create League</h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="lblLeagueName" runat="server" Text="League Name : "></asp:Label>
                    <asp:TextBox ID="txtLeagueName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <h4>League Type</h4>
                    <asp:RadioButtonList ID="rbLeagueType" runat="server" BorderWidth="5px" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">Player League</asp:ListItem>
                        <asp:ListItem Value="2">Clan League</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <h4>Validity Dates</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date : "></asp:Label>
                    <asp:TextBox ID="txtStartDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="calStartDate" runat="server" Format="dd/MM/yyyy"
                        BehaviorID="calStartDate" TargetControlID="txtStartDate" ClientIDMode="Static" OnClientDateSelectionChanged="DateChanged"></ajaxToolkit:CalendarExtender>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lblEndDate" runat="server" Text="End Date : "></asp:Label>
                    <asp:TextBox ID="txtEndDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="calEndDate" runat="server" Format="dd/MM/yyyy"
                        BehaviorID="calEndDate" OnClientDateSelectionChanged="DateChanged" TargetControlID="txtEndDate" ClientIDMode="Static"></ajaxToolkit:CalendarExtender>
                </div>
                <div class="col-lg-4">
                    <asp:Button ID="btnDummy" runat="server" OnClick="btnDummy_Click" CssClass="hidden" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <p style="padding-top: 50px;">
                        <asp:Button ID="btnCreateClan" runat="server" Text="Create League" class="btn btn-success"
                            OnClick="btnCreateClan_Click" />
                    </p>
                </div>
                <div class="col-lg-4">
                </div>
                <div class="col-lg-4">
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Existing Leagues</h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="lblAllLeagues" runat="server" Text="Select League : "></asp:Label>
                    <asp:DropDownList ID="ddlLeagues" runat="server" DataSourceID="dsLeaguesAll" AutoPostBack="True" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlLeagues_SelectedIndexChanged"></asp:DropDownList>
                    <asp:SqlDataSource ID="dsLeaguesAll" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>"
                        SelectCommand="LeaguesGetAll" SelectCommandType="StoredProcedure" InsertCommand="LeagueCreate"
                        InsertCommandType="StoredProcedure">
                        <InsertParameters>
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="type" Type="Int32" />
                            <asp:Parameter Name="StartDate" Type="DateTime" />
                            <asp:Parameter Name="EndDate" Type="DateTime" />
                        </InsertParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="gdLeagueDetails" runat="server" Width="30%" AutoGenerateColumns="False" CellPadding="4" DataSourceID="dsLeagueDetails" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="PartName" HeaderText="Member" ReadOnly="True" SortExpression="PartName" />
                            <asp:BoundField DataField="Points" HeaderText="Points" ReadOnly="True" SortExpression="Points" />
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
                    <asp:SqlDataSource ID="dsLeagueDetails" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="LeagueGetById" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlLeagues" Name="LeagueId" PropertyName="SelectedValue" Type="Int64" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
