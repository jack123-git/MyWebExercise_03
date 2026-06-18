using CommonLibrary.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;

namespace CommonLibrary.Data
{
    public class CommonSqlAccess(IConfiguration config)
    {
        private readonly IConfiguration _config = config;

        #region UserService
        public async Task<(UserDto User, List<string> Roles)> AuthenticateAsync(string username, string password)
        {
            //using var connection = new SqlConnection(_config.GetConnectionString("CommonDbConnection"));
            //string userSql = "SELECT * FROM Common.Users WHERE Username = @Username AND PasswordHash = @Password";
            //var user = await connection.QueryFirstOrDefaultAsync<UserDto>(userSql, new { Username = username, Password = password });

            //if (user == null) return (null, null);

            //// 透過中介表撈取多個角色
            //string roleSql = @"
            //SELECT r.RoleName 
            //FROM Roles r
            //INNER JOIN UserRoles ur ON r.RoleId = ur.RoleId
            //WHERE ur.UserId = @UserId";

            //var roles = (await connection.QueryAsync<string>(roleSql, new { UserId = user.UserId })).ToList();

            //connection.Close();
            //return (user, roles);

            // for Test
            var user = new UserDto
            {
                UserId = 1,
                Username = "testuser",
                PasswordHash = "hashedpassword"
            };

            var roles = new List<string> { "Admin", "User" };
            return (user, roles);
        }
        #endregion

        #region MenusService
        public async Task<List<MenuNavItem>> GetDynamicMenuAsync(List<string> roles)
        {
            //using var connection = new SqlConnection(_config.GetConnectionString("CommonDbConnection"));
            //if (roles == null || !roles.Any()) return new List<MenuNavItem>();

            //string sql = @"
            //SELECT DISTINCT m.* 
            //FROM Common.Menus m
            //INNER JOIN Common.RoleMenus rm ON m.MenuId = rm.MenuId
            //INNER JOIN Common.Roles r ON rm.RoleId = r.RoleId
            //WHERE r.RoleName IN @RoleNames
            //ORDER BY m.SortOrder, m.MenuId";

            //var allMenus = (await connection.QueryAsync<MenuNavItem>(sql, new { RoleNames = roles })).ToList();
            ////var allMenus = (await _db.QueryAsync<MenuNavItem>(sql, new { RoleNames = roles })).ToList();

            //// 在記憶體中將扁平資料轉換為樹狀結構 (兩層結構示意)
            //var rootMenus = allMenus.Where(m => m.ParentId == null).ToList();
            //foreach (var root in rootMenus)
            //{
            //    root.Children = allMenus.Where(m => m.ParentId == root.MenuId).ToList();
            //}

            //return rootMenus;

            // for Test
            var child1 = new List<MenuNavItem>
            {
                new MenuNavItem { MenuId = 3, Title = "使用者管理", Icon = "People", TargetUrl = "/admin/users", ParentId = 1 },
                new MenuNavItem { MenuId = 4, Title = "權限設定", Icon = "Security", TargetUrl = "/admin/roles", ParentId = 1 }
            };

            var child3 = new List<MenuNavItem>
            {
                new MenuNavItem { MenuId = 7, Title = "業務報表_2", Icon = "BarChart", TargetUrl = "/reports/sales3", ParentId = 6 },
                new MenuNavItem { MenuId = 8, Title = "銷售績效_2", Icon = "Assignment", TargetUrl = "/reports/sales2", ParentId = 6 }
            };

            var child2 = new List<MenuNavItem>
            {
                new MenuNavItem { MenuId = 5, Title = "業務報表", Icon = "BarChart", TargetUrl = "/reports/sales", ParentId = 2 },
                new MenuNavItem { MenuId = 6, Title = "銷售績效", Icon = "Assignment", TargetUrl = "/reports/sales", ParentId = 2, Children = child3 }
            };



            var rootMenus = new List<MenuNavItem>
            {
                new MenuNavItem { MenuId = 0, Title = "首頁", Icon = "home", TargetUrl = "/", ParentId = null }
                ,new MenuNavItem { MenuId = 1, Title = "系統管理", Icon = "Settings", TargetUrl = null, ParentId = null, Children = child1 }
                ,new MenuNavItem { MenuId = 2, Title = "業務報表", Icon = "BarChart", TargetUrl = null, ParentId = null, Children = child2 }
            };

            return rootMenus;
        }
        #endregion

    }
}
