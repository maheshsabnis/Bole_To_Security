using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bole_To_Security.Admin
{
    public partial class AdminUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RoleName"].ToString() == String.Empty)
            {
                Server.Transfer("./../Default.aspx");
            }
            //else
            //{
            //    lblusername.Text = Session["UserName"].ToString();
            //}
        }

        protected void lnkbtnassignroletouser_Click(object sender, EventArgs e)
        {
            Server.Transfer("AssignRoleToUser.aspx");
        }

        protected void lnkbtncreaterole_Click(object sender, EventArgs e)
        {
            Server.Transfer("CreateRole.aspx");
        }

        protected void lnkbtndeptcrud_Click(object sender, EventArgs e)
        {
            Server.Transfer("DepartmenrCRUD.aspx");
        }

        protected void lnkbtnempcrud_Click(object sender, EventArgs e)
        {
            Server.Transfer("EmployeeCRUD.aspx");
        }

        protected void lnkbtnlogout_Click(object sender, EventArgs e)
        {
            Session["RoleName"] = String.Empty;
            Session["UserName"] = String.Empty;
            Server.Transfer("./../Default.aspx");

        }
    }
}