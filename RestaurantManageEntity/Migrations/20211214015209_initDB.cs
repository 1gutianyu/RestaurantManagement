using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantManageEntity.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplyInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    ApplyMoney = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    JobPerson = table.Column<string>(type: "varchar(36)", nullable: true),
                    Reason = table.Column<string>(type: "varchar(100)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    LeaderID = table.Column<string>(type: "varchar(36)", nullable: true),
                    ParentID = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IncomeInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    OrderId = table.Column<string>(type: "varchar(36)", nullable: true),
                    PutMoney = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    JobId = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InventoryInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    MaterialName = table.Column<string>(type: "varchar(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(36)", nullable: true),
                    Number = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "varchar(36)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Warming = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MealInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    TableName = table.Column<string>(type: "varchar(36)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menu_RoleInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    MenuId = table.Column<string>(type: "varchar(36)", nullable: true),
                    RoleId = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_RoleInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MenuClassifyInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    ClassName = table.Column<string>(type: "varchar(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuClassifyInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MenuInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    Title = table.Column<string>(type: "varchar(16)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Href = table.Column<string>(type: "varchar(128)", nullable: true),
                    ParentId = table.Column<string>(type: "varchar(36)", nullable: true),
                    Icon = table.Column<string>(type: "varchar(32)", nullable: true),
                    Target = table.Column<string>(type: "varchar(16)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MenuSheetInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    DisheName = table.Column<string>(type: "varchar(36)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    CategoryID = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSheetInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    DishesId = table.Column<string>(type: "varchar(36)", nullable: true),
                    TotalMoney = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    PayMethod = table.Column<string>(type: "varchar(36)", nullable: false),
                    JobId = table.Column<string>(type: "varchar(36)", nullable: true),
                    TableNumber = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OutlayInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    CheckPerson = table.Column<string>(type: "varchar(36)", nullable: true),
                    Reason = table.Column<string>(type: "varchar(100)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutlayInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    MaterialId = table.Column<string>(type: "varchar(36)", nullable: true),
                    Number = table.Column<double>(type: "float", nullable: false),
                    Buyer = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoleInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StaffInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    StaffName = table.Column<string>(type: "varchar(36)", nullable: false),
                    JobID = table.Column<string>(type: "varchar(36)", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    PassWord = table.Column<string>(type: "varchar(32)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(36)", nullable: true),
                    DepartmentID = table.Column<string>(type: "varchar(36)", nullable: true),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stasff_RoleInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stasff_RoleInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User_RoleInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(36)", nullable: true),
                    RoleId = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_RoleInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(36)", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Account = table.Column<string>(type: "varchar(16)", nullable: true),
                    PassWord = table.Column<string>(type: "varchar(32)", nullable: true),
                    PhoneNum = table.Column<string>(type: "varchar(16)", nullable: false),
                    Email = table.Column<string>(type: "varchar(32)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyInfo");

            migrationBuilder.DropTable(
                name: "DepartmentInfo");

            migrationBuilder.DropTable(
                name: "IncomeInfo");

            migrationBuilder.DropTable(
                name: "InventoryInfo");

            migrationBuilder.DropTable(
                name: "MealInfo");

            migrationBuilder.DropTable(
                name: "Menu_RoleInfo");

            migrationBuilder.DropTable(
                name: "MenuClassifyInfo");

            migrationBuilder.DropTable(
                name: "MenuInfo");

            migrationBuilder.DropTable(
                name: "MenuSheetInfo");

            migrationBuilder.DropTable(
                name: "OrderInfo");

            migrationBuilder.DropTable(
                name: "OutlayInfo");

            migrationBuilder.DropTable(
                name: "PurchaseInfo");

            migrationBuilder.DropTable(
                name: "RoleInfo");

            migrationBuilder.DropTable(
                name: "StaffInfo");

            migrationBuilder.DropTable(
                name: "Stasff_RoleInfo");

            migrationBuilder.DropTable(
                name: "User_RoleInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
