using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bole_To_Security.DataAccess;
namespace Bole_To_Security
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        
        private UsersLogic _usersLogic;
        ResponseObject response;
        
        public RegisterUser(UsersLogic usersLogic)
        {
            _usersLogic = usersLogic;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtename.Text = "";
            txtpwd.Text = "";
            txtconfirmpwd.Text = "";
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtpwd.Text.Equals(txtconfirmpwd.Text))
                {
                    var user = new Users()
                    {
                        UserName = txtename.Text,
                        Password = txtconfirmpwd.Text
                    };
                   response =  _usersLogic.CreateNewUser(user);
                   lblstatus.Text = response.Message;
                }
                else
                {
                    throw new Exception("Password Does not match");
                }
                
            }
            catch (Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
        }

        
    }
}