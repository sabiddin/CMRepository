<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUpdateClient.aspx.cs" Inherits="CM.Web.ClientMaintenance.AddUpdateClient" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="panel panel-default">
        <div class="panel-heading"><h4>
            <asp:Label Text="" ID="lblCurrentTitle" runat="server" /></h4></div>
        <div class="panel-body">
    <div class="form-horizontal">       
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="SSN" CssClass="col-md-2 control-label">SSN</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="SSN" Enabled="false" MaxLength="9" CssClass="form-control" TextMode="SingleLine" />                
            </div>
        </div>               
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ClientFirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ClientFirstName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ClientFirstName"
                    CssClass="text-danger" ErrorMessage="The First Name field is required." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ClientMiddleName" CssClass="col-md-2 control-label">Middle Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ClientMiddleName" CssClass="form-control" TextMode="SingleLine" />                
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ClientLastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ClientLastName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ClientLastName"
                    CssClass="text-danger" ErrorMessage="The ClientLastName field is required." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlRepresentative" CssClass="col-md-2 control-label">Representative</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlRepresentative" CssClass="form-control" style="width:auto !important" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRepresentative"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The Representative field is required." />               
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Active" CssClass="col-md-2 control-label">Active</asp:Label>
            <div class="col-md-10">
                <div class="form-check">
                <asp:CheckBox Text="" ID="Active" CssClass="form-check-input" runat="server" />                
                    </div>
            </div>             
        </div>


        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" id="btnSave" OnClick="btnSave_Click" Text="Add Client" CssClass="btn btn-default" />
                <asp:Button runat="server" id="btnCancel" OnClick="btnCancel_Click" Text="Cancel" CssClass="btn btn-warning" />
            </div>
        </div>
    </div>
            </div>
    </div>
</asp:Content>
