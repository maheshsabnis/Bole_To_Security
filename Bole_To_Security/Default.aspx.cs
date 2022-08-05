using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bole_To_Security.DataAccess;
namespace Bole_To_Security
{
    public partial class _Default : Page
    {
        ResponseObject response;

        UsersLogic _userLogic;

        public _Default(  UsersLogic userLogic)
        {
            _userLogic = userLogic;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtename.Text = string.Empty;
            txtpwd.Text = string.Empty;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new Users()
                { 
                    UserName = txtename.Text,
                    Password = txtpwd.Text  
                };

                response = _userLogic.AuthenticateUser(user);

                if (!response.IsRequestSuccessful)
                    throw new Exception("Login is Failed");

                // Save the Logic Information in the session Object
                Session["IsAuthenticated"] = response.IsRequestSuccessful;
                Session["UserName"] = response.UserName;
                Session["RoleName"] = response.RoleName;

                // Create a FormAuthentication Ticket
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, response.UserName, DateTime.Now, DateTime.Now.AddMinutes(180), true, response.RoleName);
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(authenticationCookie);

                // Set the redirection
                if (response.RoleName == "Admin")
                    Server.Transfer("Admin/AdminUI.aspx");
                if (response.RoleName == "Manager")
                    Server.Transfer("Manager/ManagerUI.aspx");
                if (response.RoleName == "Clerk")
                    Server.Transfer("Clerk/ClerkUI.aspx");
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        protected void lnkbtnregister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegisterUser.aspx");
        }
    }
}