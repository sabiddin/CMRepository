using System;
using System.Linq;
using System.Web;
using System.Web.UI;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
using Owin;
using CM.Domain.Entities;
using CM.Web.Models;
using CM.Application.Interfaces;
using StructureMap.Attributes;
using CM.Web.DI;
using CM.Utils;

namespace CM.Web.Account
{
    public partial class Register : BasePageWithIoC
    {
        [SetterProperty]
        public IUserService UserService { get; set; }
        [SetterProperty]
        public IRepresentativeService RepresentativeService { get; set; }
        [SetterProperty]
        public IRoleService RoleService { get; set; }
        protected void CreateUser_Click(object sender, EventArgs e)
        {           
            Domain.Entities.User user = new User() {
                Username=Username.Text,
                Password =Password.Text,
                DateAdded=DateTime.Now,
                Locked =false,
                RoleID= Role.SelectedValue.ToInt()
            };
            UserService.AddUser(user);
            Domain.Entities.Representative representative = new Representative()
            {
                UserID=user.UserID,
                FirstName=FirstName.Text,
                MiddleName=MiddleName.Text,
                LastName =LastName.Text,
                Active =  Active.Checked ?true:false,
                DateAdded=DateTime.Now
            };
            RepresentativeService.AddRepresentative(representative);
        }
        protected void Page_Load(Object sender, EventArgs eventArgs)
        {
            if (!Page.IsPostBack)
            {
                InitializeRoles(); 
            }
        }
        public void InitializeRoles() {
            var roles = RoleService.GetRoles();
            Role.DataSource = roles;            
            Role.DataValueField = "RoleID";
            Role.DataTextField = "RoleDesc";
            Role.DataBind();
            Role.Items.Insert(0, "");
        }
    }
}