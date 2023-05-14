using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FootballApi.Data.Migrations
{
    public partial class SchemaChangeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteMatches");
            migrationBuilder.CreateTable(
                name: "FavouriteMatches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    MatchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteMatches", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteMatches_UserId",
                table: "FavouriteMatches",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteMatches_MatchId",
                table: "FavouriteMatches",
                column: "MatchId");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteMatches");
        }

    }
}
