using CM.Application.Interfaces;
using CM.Domain.Entities;
using CM.Utils;
using CM.Web.DI;
using StructureMap.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CM.Web.ClientMaintenance
{
    public partial class AddUpdateClient : BasePageWithIoC
    {        
        public IRepresentativeService RepresentativeService { get; set; }     
        public IClientService ClientService { get; set; }

        public string ClientAction {
            get {
                return Request.QueryString["Action"];
            }
        }
        public string ClientSSN
        {
            get
            {
                return Request.QueryString["ClientSSN"];
            }
        }
        public int CurrentClientID
        {
            get
            {
                return Request.QueryString["Action"].HasValue()? Request.QueryString["Action"].ToInt():0;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblCurrentTitle.Text = $"{ClientAction} Client";
                SSN.Text = ClientSSN;
                var representatives = RepresentativeService.GetAll();                
                ddlRepresentative.DataSource = representatives;
                ddlRepresentative.DataValueField = "RepresentativeID";                
                ddlRepresentative.DataTextField = "FullName";
                ddlRepresentative.DataBind();
                ddlRepresentative.Items.Insert(0, "");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Client client = new Client() {
                ClientSSN =SSN.Text,
                ClientFirstName=ClientFirstName.Text,
                ClientMiddleName=ClientMiddleName.Text,
                ClientLastName =ClientLastName.Text,
                Active=Active.Checked?true:false,
                DateAdded=DateTime.Now,
                RepresentativeID=ddlRepresentative.SelectedValue.ToInt()
            };
            ClientService.AddClient(client);
            Response.Redirect("SearchClient.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("~ClientMaintenance/SearchClient");
        }
    }
}