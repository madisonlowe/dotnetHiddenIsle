using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetHiddenIsle.Migrations
{
    /// <inheritdoc />
    public partial class AddAgentLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentLevel",
                table: "Agents",
                type: "integer",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentLevel",
                table: "Agents");
        }
    }
}
