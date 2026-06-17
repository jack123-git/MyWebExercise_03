using CommonLibrary.Data;
using CommonLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

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
