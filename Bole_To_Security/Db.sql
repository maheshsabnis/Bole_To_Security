Create Database UkgAuthDb
Create Table Roles(
  RoleId int identity(1,1) Primary Key,
  RoleName varchar(100) Not Null
)

CReate Table Users(
   UserId int Identity (1001,1) Primary Key,
   UserName varchar(100) Not null,
   Password varchar(20) Not null
)

Create Table UserRoles(
   UserRoleId int Identity(10001,1) Primary Key,
   UserId int References Users(UserId) Not Null,
   RoleId int References Roles(RoleId) Not Null
)
