using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission06_trev3law.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Movie", x => x.MovieID);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieID", "Category", "Director", "Edited", "Lent_To", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Action", "Christopher Nolan", false, "Josh", "Great Movie", "PG-13", "The Dark Knight", 2013 });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieID", "Category", "Director", "Edited", "Lent_To", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Rom/Com", "Some Guy", false, "Ashley", "Funny Movie", "PG-13", "Crazy Stupid Love", 2013 });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieID", "Category", "Director", "Edited", "Lent_To", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Action", "Tom Cruise", false, "Me", "The Best Movie", "PG-13", "Top Gun Maverick", 2022 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
