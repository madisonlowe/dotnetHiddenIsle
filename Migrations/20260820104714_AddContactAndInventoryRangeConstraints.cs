using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetHiddenIsle.Migrations
{
    /// <inheritdoc />
    public partial class AddContactAndInventoryRangeConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Contact_Affection_Range",
                table: "Contact",
                sql: "\"Affection\" >= 0 AND \"Affection\" <= 6");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Contact_Distance_Range",
                table: "Contact",
                sql: "\"Distance\" >= 0 AND \"Distance\" <= 3");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Agents_InventoryLoad_Range",
                table: "Agents",
                sql: "\"InventoryLoad\" >= 0 AND \"InventoryLoad\" <= 5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Contact_Affection_Range",
                table: "Contact");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Contact_Distance_Range",
                table: "Contact");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Agents_InventoryLoad_Range",
                table: "Agents");
        }
    }
}
