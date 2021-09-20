using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjectY.Backend.Data.Migrations
{
    public partial class Added_table_attachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.CreateTable(
                name: "attachments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Идентификатор записи")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: true, comment: "Ключ объекта"),
                    FileName = table.Column<string>(type: "text", nullable: true, comment: "Наименование файла"),
                    ContentType = table.Column<string>(type: "text", nullable: true, comment: "Тип контента файла"),
                    FileSize = table.Column<long>(type: "bigint", nullable: false, comment: "Размер файла"),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Дата создания"),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Дата последнего обновления")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attachments");

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                });
        }
    }
}
