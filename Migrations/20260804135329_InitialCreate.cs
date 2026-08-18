using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetHiddenIsle.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoreSelf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChildSelf = table.Column<string>(type: "text", nullable: false),
                    AdultSelf = table.Column<string>(type: "text", nullable: false),
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
                    Load = table.Column<int>(type: "integer", nullable: false),
                    Items = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Class = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<string>(type: "text", nullable: false),
                    Culture = table.Column<string>(type: "text", nullable: false),
                    Look = table.Column<string>(type: "text", nullable: false),
                    InventoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    AbilityTrackXP = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    Burdens = table.Column<List<string>>(type: "text[]", nullable: false),
                    Vices = table.Column<List<string>>(type: "text[]", nullable: false),
                    Virtues = table.Column<List<string>>(type: "text[]", nullable: false),
                    Ideals = table.Column<List<string>>(type: "text[]", nullable: false),
                    CoreSelfId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_CoreSelf_CoreSelfId",
                        column: x => x.CoreSelfId,
                        principalTable: "CoreSelf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agents_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AgentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ability_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AbilitySuits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AgentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilitySuits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbilitySuits_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Affection = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Card = table.Column<string>(type: "text", nullable: false),
                    Land = table.Column<string>(type: "text", nullable: false),
                    Distance = table.Column<int>(type: "integer", nullable: false),
                    AgentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MagicalProficiency",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SchoolName = table.Column<string>(type: "text", nullable: false),
                    CurrentRank = table.Column<int>(type: "integer", nullable: false),
                    ClockSegmentsFilled = table.Column<int>(type: "integer", nullable: false),
                    MaxClockSegments = table.Column<int>(type: "integer", nullable: false),
                    AgentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicalProficiency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicalProficiency_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MagicalSource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceType = table.Column<int>(type: "integer", nullable: false),
                    SourceName = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    AgentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicalSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicalSource_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SuitSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    XP = table.Column<int>(type: "integer", nullable: false),
                    Harm = table.Column<string>(type: "text", nullable: false),
                    AbilitySuitsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuitSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuitSkill_AbilitySuits_AbilitySuitsId",
                        column: x => x.AbilitySuitsId,
                        principalTable: "AbilitySuits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ability_AgentId",
                table: "Ability",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilitySuits_AgentId",
                table: "AbilitySuits",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_CoreSelfId",
                table: "Agents",
                column: "CoreSelfId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_InventoryId",
                table: "Agents",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_AgentId",
                table: "Contact",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicalProficiency_AgentId",
                table: "MagicalProficiency",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicalSource_AgentId",
                table: "MagicalSource",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_SuitSkill_AbilitySuitsId",
                table: "SuitSkill",
                column: "AbilitySuitsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "MagicalProficiency");

            migrationBuilder.DropTable(
                name: "MagicalSource");

            migrationBuilder.DropTable(
                name: "SuitSkill");

            migrationBuilder.DropTable(
                name: "AbilitySuits");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "CoreSelf");

            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
