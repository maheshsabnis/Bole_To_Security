using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bole_To_Security.DataAccess
{
    public class UsersLogic
    {
        SqlConnection Conn;
        SqlCommand Cmd;

        public UsersLogic()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=UkgAuthDB;Integrated Security=SSPI");
        }

        public IEnumerable<Users> GetUsers()
        {
            List<Users> users = new List<Users>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = "Select * from Users";
                var reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new Users()
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        UserName = reader["UserName"].ToString(),
                        Password = reader["Password"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return users;
        }

        public ResponseObject CreateNewUser(Users user)
        {
            ResponseObject response = new ResponseObject(); 
            try
            {
                if (!CheckIfUserExists(user.UserName, out int userid))
                {
                    Conn.Open();
                    Cmd = Conn.CreateCommand();
                    Cmd.CommandText = $"Insert into  Users Values ('{user.UserName}',{user.Password})";
                    int Result = Cmd.ExecuteNonQuery();
                    if (Result > 0)
                    {
                        response.IsRequestSuccessful = true;
                        response.Message = $"The User {user.UserName} is created Successful";
                    }    
                }
                else
                {
                    response.IsRequestSuccessful = false;
                    response.Message = $"The User {user.UserName} is creation is failed";
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

        private bool CheckIfUserExists(string userName, out int userid)
        {
            var user = (from usr in GetUsers()
                       where usr.UserName == userName
                       select usr).FirstOrDefault();
            if (user == null)
            {
                userid = 0;
                return false;
            }
            else
            {
                userid = user.UserId;
                return true;
            }
            
        }

        public ResponseObject AssignRoleToUser(string roleName, string userName)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                // Check if the role exist
                if (CheckIfRoleExists(roleName) && CheckIfUserExists(userName, out int userid))
                {
                    Conn.Open();
                    Cmd = Conn.CreateCommand();
                    int roleId = 0, userId = 0;
                    GetRoleIdUserIdByRoleNameUserName(roleName, userName,out roleId, out userId);
                    Cmd.CommandText = $"Insert into UserInRoles Values({userId}, {roleId})";
                    int Result = Cmd.ExecuteNonQuery();
                    if (Result > 0)
                    {
                        response.IsRequestSuccessful = true;
                        response.Message = $"The Role {roleName} is assigned to User {userName}";
                    }
                }
                else 
                {
                    response.IsRequestSuccessful = false;
                    response.Message = $"Role {roleName} is not assigned to User {userName}";
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

        private void GetRoleForTheUser(int userid, out string rolename)
        {
            int roleId = 0;
            string rName = String.Empty;
            try
            {

                // get the roleId from the UserRoles based on the UserId
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select RoleId from UserRoles where UserId={userid}";
                SqlDataReader Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    roleId = Convert.ToInt32(Reader["RoleId"]);
                }
                Reader.Close();

                // noe retrive the role name based on the RoelId
                Cmd.CommandText = $"Select RoleName from Roles where RoleId={roleId}";
                SqlDataReader Reader1 = Cmd.ExecuteReader();
                while (Reader1.Read())
                {
                    rName = Reader1["RoleName"].ToString();
                }
                Reader1.Close();
                rolename = rName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
        }

        private bool CheckIfRoleExists(string roleName)
        {
            var roleLogic = new RoleLogic();    
            var role = (from r in roleLogic.GetRoles()
                        where r.RoleName == roleName
                        select r).First();
            if (role == null)
                return false;
            return true;
        }

        private bool IsRoleExistForUser(int userId)
        {
            bool IsRoleExistToUser = false;
            var userWithRole = (from ur in GetUserRoles()
                               where ur.UserId == userId
                               select ur).FirstOrDefault();
            if(userWithRole == null)
                IsRoleExistToUser = false; // No Role for the user
            else
                IsRoleExistToUser =  true;
            return IsRoleExistToUser;
        }


        // Get UserId and RoleId from Based on RoleName and UserName
        private void GetRoleIdUserIdByRoleNameUserName(string roleName, string userName, out int roleId, out int userId)
        {
            var roleLogic = new RoleLogic();

            roleId = roleLogic.GetRoles().Where(r => r.RoleName.Trim() == roleName.Trim()).First().RoleId;
            userId = GetUsers().Where(u=>u.UserName.Trim() == userName.Trim()).First().UserId;
        }

        public IEnumerable<UserInRoles> GetUserRoles()
        {
            List<UserInRoles> userInRoles = new List<UserInRoles>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = "Select * from UserRoles";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    userInRoles.Add(new UserInRoles() 
                    {
                      UserRoleId = Convert.ToInt32(reader["UserRoleId"]),
                      UserId = Convert.ToInt32(reader["UserId"]),
                      RoleId = Convert.ToInt32(reader["RoleId"])
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return userInRoles;
        }


        public ResponseObject AuthenticateUser(Users user)
        {
            var response = new ResponseObject();
            int userid = 0;
            try
            {
                // check if the user exist
                if (!CheckIfUserExists(user.UserName, out userid))
                {
                    response.IsRequestSuccessful = false;
                    response.Message = "Sorry! This user is not exist";
                    return response;
                }
                // set the userid after searching the user
                user.UserId = userid;
                // Check the USerName and Password Match
                var u = (from usr in GetUsers()
                            where usr.UserName.Trim() == user.UserName.Trim()
                            select usr).FirstOrDefault();
                if (u.Password.Trim() != user.Password.Trim())
                {
                    response.IsRequestSuccessful = false;
                    response.Message = "Sorry! The Password does not match";
                    return response;
                }

                // Check if the Role is assigned to the user
                if (!IsRoleExistForUser(user.UserId))
                {
                    response.IsRequestSuccessful = false;
                    response.Message = "Sorry! The Role is not assigned to the user, please wait the Admin assign the role";
                    return response;
                }

                // AUthenticate the USer and read the rolename for the user
                response.IsRequestSuccessful = true;
                response.Message = "The User is Logged-In Successfully";
                string roleName = string.Empty;
                GetRoleForTheUser(user.UserId, out roleName);
                response.RoleName = roleName;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
    }
}