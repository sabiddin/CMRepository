using CM.Web.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CM.Application.Interfaces;
using StructureMap.Attributes;
using CM.Domain.Entities;

namespace CM.Web.ClientMaintenance
{
    public partial class SearchClient : BasePageWithIoC
    {
        public string SSN { get {
                return txtClientSSN.Text;
            } }
        [SetterProperty]
        public IClientService ClientService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<Client> clients= ClientService.GetClients();
                rptClients.DataSource = clients;
                rptClients.DataBind();
                btnAddClient.Visible = clients.Count == 0;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<Client> clients = ClientService.GetClientsBySSN(txtClientSSN.Text);
            rptClients.DataSource = clients;
            rptClients.DataBind();
            btnAddClient.Visible = clients.Count == 0;
            btnAddClient.HRef = $"~/ClientMaintenance/AddUpdateClient.aspx?Action=ADD&ClientSSN={txtClientSSN.Text}";
        }
       
    }
}