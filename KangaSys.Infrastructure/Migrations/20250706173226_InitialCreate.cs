// <copyright file="20250706173226_InitialCreate.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

#nullable disable

namespace KangaSys.Infrastructure.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientReportData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    BusinessUnit = table.Column<string>(type: "text", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Revenue = table.Column<decimal>(type: "numeric", nullable: false),
                    Expense = table.Column<decimal>(type: "numeric", nullable: false),
                    Segment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientReportData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientReportData_ClientId",
                table: "ClientReportData",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientReportData_Region",
                table: "ClientReportData",
                column: "Region");

            migrationBuilder.CreateIndex(
                name: "IX_ClientReportData_ReportDate",
                table: "ClientReportData",
                column: "ReportDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientReportData");
        }
    }
}
