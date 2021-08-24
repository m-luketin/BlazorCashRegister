using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorCashRegister.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsTaxRateReduced = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                });

            migrationBuilder.CreateTable(
                name: "CashRegisters",
                columns: table => new
                {
                    CashRegisterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRegisters", x => x.CashRegisterId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ReceiptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    RegisterCashRegisterId = table.Column<int>(type: "int", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK_Receipts_CashRegisters_RegisterCashRegisterId",
                        column: x => x.RegisterCashRegisterId,
                        principalTable: "CashRegisters",
                        principalColumn: "CashRegisterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleReceipts",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleReceipts", x => new { x.ArticleId, x.ReceiptId });
                    table.ForeignKey(
                        name: "FK_ArticleReceipts_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleReceipts_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleReceipts_ReceiptId",
                table: "ArticleReceipts",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_EmployeeId",
                table: "Receipts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_RegisterCashRegisterId",
                table: "Receipts",
                column: "RegisterCashRegisterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleReceipts");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "CashRegisters");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
