using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace Bole_To_Security.DataAccess
{
    public class RoleLogic
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public RoleLogic()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=UkgAuthDB;Integrated Security=SSPI");
        }

        public IEnumerable<Roles> GetRoles()
        {
            List<Roles> roles = new List<Roles>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = "Select * from Roles";
                var reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(new Roles() 
                    {
                       RoleId = Convert.ToInt32(reader["RoleId"]),
                       RoleName = reader["RoleName"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Conn.Close();
            }
            return roles;
        }

        public ResponseObject CreateRole(Roles role)
        {
            ResponseObject response = new ResponseObject(); 
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Insert into Roles Values('{role.RoleName}')";
                int Res = Cmd.ExecuteNonQuery();
                if (Res > 0)
                {
                    response.IsRequestSuccessful = true;
                    response.Message = $"Role {role.RoleName} is created successfully.";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return response;
        }
    }
}