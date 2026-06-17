using CommonLibrary.Data;
using CommonLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace CommonLibrary.Services
{
    public class MenuService
    {
        private readonly CommonSqlAccess sqlDataAccess;
        public MenuService(IConfiguration config) => this.sqlDataAccess = new CommonSqlAccess(config);

        public async Task<List<MenuNavItem>> GetDynamicMenuAsync(List<string> roles) 
        {
            return await sqlDataAccess.GetDynamicMenuAsync(roles);
        }
    }
}
