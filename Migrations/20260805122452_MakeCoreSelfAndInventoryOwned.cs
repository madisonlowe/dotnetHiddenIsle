using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetHiddenIsle.Migrations
{
    /// <inheritdoc />
    public partial class MakeCoreSelfAndInventoryOwned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_CoreSelf_CoreSelfId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Inventory_InventoryId",
                table: "Agents");

            migrationBuilder.DropTable(
                name: "CoreSelf");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Agents_CoreSelfId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_InventoryId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "CoreSelfId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Agents");

            migrationBuilder.AddColumn<string>(
                name: "CoreSelfAdultSelf",
                table: "Agents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoreSelfChildSelf",
                table: "Agents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<string>>(
                name: "CoreSelfFulfilledVirtues",
                table: "Agents",
                type: "text[]",
                nullable: false,
                defaultValue: new List<string>());

            migrationBuilder.AddColumn<List<string>>(
                name: "InventoryItems",
                table: "Agents",
                type: "text[]",
                nullable: false,
                defaultValue: new List<string>());

            migrationBuilder.AddColumn<int>(
                name: "InventoryLoad",
                table: "Agents",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoreSelfAdultSelf",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "CoreSelfChildSelf",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "CoreSelfFulfilledVirtues",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "InventoryItems",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "InventoryLoad",
                table: "Agents");

            migrationBuilder.AddColumn<Guid>(
                name: "CoreSelfId",
                table: "Agents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InventoryId",
                table: "Agents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CoreSelf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdultSelf = table.Column<string>(type: "text", nullable: false),
                    ChildSelf = table.Column<string>(type: "text", nullable: false),
                    FulfilledVirtues = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreSelf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Items = table.Column<List<string>>(type: "text[]", nullable: false),
                    Load = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_CoreSelfId",
                table: "Agents",
                column: "CoreSelfId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_InventoryId",
                table: "Agents",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_CoreSelf_CoreSelfId",
                table: "Agents",
                column: "CoreSelfId",
                principalTable: "CoreSelf",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Inventory_InventoryId",
                table: "Agents",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
