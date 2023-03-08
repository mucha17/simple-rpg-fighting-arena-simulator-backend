using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace simple_rpg_fighting_simulator.Migrations
{
    /// <inheritdoc />
    public partial class SpellSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Spells",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[,]
                {
                    { 1, 30, "Fireball" },
                    { 2, 20, "Frenzy" },
                    { 3, 50, "Blizzard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Spells",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Spells",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Spells",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
