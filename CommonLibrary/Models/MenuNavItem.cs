using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class MenuNavItem
    {
        public int MenuId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string TargetUrl { get; set; }
        public int? ParentId { get; set; }

        // 支援無限層級的子節點清單
        public List<MenuNavItem> Children { get; set; } = new();
    }
}
