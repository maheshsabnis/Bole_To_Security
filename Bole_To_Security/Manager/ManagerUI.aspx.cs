using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bole_To_Security.Manager
{
    public partial class ManagerUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RoleName"].ToString() == String.Empty)
            {
                Response.Redirect("./../Default.aspx");
            }
        }

        protected void lnkbtndeptcrud_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmenrCRUD.aspx");
        }

        protected void lnkbtnempcrud_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeCRUD.aspx");
        }

        protected void lnkbtnlogout_Click(object sender, EventArgs e)
        {
            Session["RoleName"] = String.Empty;
            Session["UserName"] = String.Empty;
            Response.Redirect("./../Default.aspx");
        }
    }
}