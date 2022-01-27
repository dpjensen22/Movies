using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieSet",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    Lent_To = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSet", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "MovieSet",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "Lent_To", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Sci-fi", "Christopher Nolan", false, null, null, "PG-13", "Interstellar", 2014 });

            migrationBuilder.InsertData(
                table: "MovieSet",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "Lent_To", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Drama", "Damien Chazell", false, null, null, "R", "Whiplash", 2014 });

            migrationBuilder.InsertData(
                table: "MovieSet",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "Lent_To", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "War", "Sam Mendes", false, null, null, "R", "1917", 2020 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieSet");
        }
    }
}
