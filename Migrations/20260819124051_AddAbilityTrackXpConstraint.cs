using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetHiddenIsle.Migrations
{
    /// <inheritdoc />
    public partial class AddAbilityTrackXpConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Agents_AbilityTrackXP_Range",
                table: "Agents",
                sql: "\"AbilityTrackXP\" >= 0 AND \"AbilityTrackXP\" <= 9");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Agents_AbilityTrackXP_Range",
                table: "Agents");
        }
    }
}
