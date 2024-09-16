using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ms_configuration.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMCD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RabbitMqExchanges");

            migrationBuilder.CreateTable(
                name: "RabbitMqRoutingKeys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Exchange = table.Column<string>(type: "TEXT", nullable: false),
                    Queue = table.Column<string>(type: "TEXT", nullable: false),
                    RoutingKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RabbitMqRoutingKeys", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RabbitMqRoutingKeys");

            migrationBuilder.CreateTable(
                name: "RabbitMqExchanges",
                columns: table => new
                {
                    Exchange = table.Column<string>(type: "TEXT", nullable: false),
                    Queue = table.Column<string>(type: "TEXT", nullable: false),
                    RabbitMqConfigModelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoutingKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RabbitMqExchanges", x => new { x.Exchange, x.Queue });
                    table.ForeignKey(
                        name: "FK_RabbitMqExchanges_RabbitMqConfigs_RabbitMqConfigModelId",
                        column: x => x.RabbitMqConfigModelId,
                        principalTable: "RabbitMqConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RabbitMqExchanges_RabbitMqConfigModelId",
                table: "RabbitMqExchanges",
                column: "RabbitMqConfigModelId");
        }
    }
}
