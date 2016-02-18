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
                        BehaviorID="calEndDate" TargetControlID="txtEndDate" ClientIDMode="Static"></ajaxToolkit:CalendarExtender>
                </div>
                <div class="col-lg-4">
                    <asp:Button ID="btnDummy" runat="server" OnClick="btnDummy_Click" CssClass="hidden" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <p style="padding-top: 50px;">
                        <asp:Button ID="btnCreateClan" runat="server" Text="Create League" class="btn btn-success" />
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
                    <asp:DropDownList ID="ddlLeagues" runat="server" DataSourceID="dsLeaguesAll" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                    <asp:SqlDataSource ID="dsLeaguesAll" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="LeaguesGetAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
