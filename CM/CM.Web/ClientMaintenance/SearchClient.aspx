<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchClient.aspx.cs" Inherits="CM.Web.ClientMaintenance.SearchClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    &nbsp;
                </div>
                <div class="row">
                    <div class="input-group has-feedback has-search">
                        <asp:Label CssClass="control-label" Text="Search by SSN" runat="server" />
                        <asp:TextBox CssClass="form-control" MaxLength="9" runat="server" ID="txtClientSSN" />
                        <asp:Button CssClass="btn btn-default" Text="Search" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />
                    </div>
                </div>
                <div class="row">
                    &nbsp;
                </div>
                <div class="row">
                    <asp:Repeater runat="server" ID="rptClients">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <asp:Label runat="server"> <%#Eval("ClientFirstName")%> &nbsp; <%#Eval("ClientLastName")%></asp:Label>
                                        </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="col-sm-8">
                                                    <table class="table table-stripped table-hover">
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" CssClass="control-label">ID</asp:Label></td>
                                                            <td>
                                                                <asp:Label runat="server" CssClass="col-sm-1 control-label"><%#Eval("ClientID") %></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" CssClass="control-label">SSN</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" CssClass="control-label"><%#Eval("ClientSSN") %> </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" CssClass="control-label">First Name</asp:Label></td>
                                                            <td>
                                                                <asp:Label runat="server" CssClass="control-label"><%#Eval("ClientFirstName") %> </asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" CssClass="control-label">Middle Name</asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label runat="server" CssClass="control-label"><%#Eval("ClientMiddleName") %> </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" CssClass="control-label">Last Name</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" CssClass="control-label"><%#Eval("ClientLastName") %> </asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="col-sm-2">                                                    
                                                     <div class="row">
                                                         <img src="../Images/cinqueterre.jpg" class="img-responsive" alt="Cinque Terre">
                                                    </div>                                                    
                                                    <div>
                                                        &nbsp;
                                                    </div>
                                                    <div class="row">
                                                        <asp:Button Text="Add Blotter" CssClass="btn btn-primary" CommandArgument="ClientID" CommandName="AddBlotter" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="row">                    
                    <a class="btn btn-default" href="#" id="btnAddClient" runat="server">Add New Client</a>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
