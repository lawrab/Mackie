using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnailRacing.Mackie.Migrations
{
    public partial class AddingGuildConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuildId = table.Column<string>(type: "TEXT", nullable: false),
                    TeamsTextParentChannelId = table.Column<string>(type: "TEXT", nullable: false),
                    TeamsTextParentChannelName = table.Column<string>(type: "TEXT", nullable: false),
                    TeamsVoiceParentChannelId = table.Column<string>(type: "TEXT", nullable: false),
                    TeamsVoiceParentChannelName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuration");
        }
    }
}
