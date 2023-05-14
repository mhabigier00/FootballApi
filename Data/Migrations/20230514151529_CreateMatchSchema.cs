using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;


namespace FootballApi.Data.Migrations
{
    public partial class CreateMatchSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavouriteMatches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
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
