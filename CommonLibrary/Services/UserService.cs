using CommonLibrary.Data;
using CommonLibrary.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CommonLibrary.Services
{
    public class UserService
    {
        //private readonly IDbConnection _db;
        //public UserService(IDbConnection db) => _db = db;
        private readonly CommonSqlAccess sqlDataAccess;
        public UserService(IConfiguration config) => this.sqlDataAccess = new CommonSqlAccess(config);


        // 登入驗證並一次性查出該帳號綁定的多個角色
        public async Task<(UserDto User, List<string> Roles)> AuthenticateAsync(string username, string password)
        {
            //// 注意：實務上密碼請使用雜湊驗證（如 BCrypt），此處以明文示意
            //string userSql = "SELECT * FROM Users WHERE Username = @Username AND PasswordHash = @Password";
            //var user = await _db.QueryFirstOrDefaultAsync<UserDto>(userSql, new { Username = username, Password = password });

            //if (user == null) return (null, null);

            //// 透過中介表撈取多個角色
            //string roleSql = @"
            //SELECT r.RoleName 
            //FROM Roles r
            //INNER JOIN UserRoles ur ON r.RoleId = ur.RoleId
            //WHERE ur.UserId = @UserId";

            //var roles = (await _db.QueryAsync<string>(roleSql, new { UserId = user.UserId })).ToList();
            //return (user, roles);

            return await sqlDataAccess.AuthenticateAsync(username, password);
        }
    }
}
