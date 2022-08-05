using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bole_To_Security.DataAccess;
namespace Bole_To_Security.Admin
{
    public partial class CreateRole : System.Web.UI.Page
    {
        RoleLogic roleLogic;
        ResponseObject response;

        public CreateRole(RoleLogic roleLogic)
        {
            this.roleLogic = roleLogic;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtrolename.Text = String.Empty;
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                var role = new Roles()
                { 
                   RoleName = txtrolename.Text
                };

                response = roleLogic.CreateRole(role);
                lblstatus.Text = response.Message;
            }
            catch (Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
        }
    }
}