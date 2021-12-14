using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageEntity
{
    public class ManegeDbContext : DbContext
    {
        public ManegeDbContext(DbContextOptions<ManegeDbContext> options) : base(options)
        { }

        public DbSet<ApplyInfo> ApplyInfo { get; set; }

        public DbSet<DepartmentInfo> DepartmentInfo { get; set; }

        public DbSet<IncomeInfo> IncomeInfo { get; set; }

        public DbSet<InventoryInfo> InventoryInfo { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<StaffInfo> StaffInfo { get; set; }

        public DbSet<RoleInfo> RoleInfo { get; set; }

        public DbSet<MenuInfo> MenuInfo { get; set; }

        public DbSet<MealInfo> MealInfo { get; set; }

        public DbSet<Menu_RoleInfo> Menu_RoleInfo { get; set; }

        public DbSet<MenuClassifyInfo> MenuClassifyInfo { get; set; }

        public DbSet<MenuSheetInfo> MenuSheetInfo { get; set; }

        public DbSet<OrderInfo> OrderInfo { get; set; }

        public DbSet<OutlayInfo> OutlayInfo { get; set; }

        public DbSet<PurchaseInfo> PurchaseInfo { get; set; }

        public DbSet<Stasff_RoleInfo> Stasff_RoleInfo { get; set; }

        public DbSet<User_RoleInfo> User_RoleInfo { get; set; }


    }
}
