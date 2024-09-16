using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ms_configuration.Migrations
{
    /// <inheritdoc />
    public partial class AddColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActionName",
                table: "RabbitMqRoutingKeys",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "RabbitMqRoutingKeys",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "RabbitMqRoutingKeys",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "RabbitMqConfigs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "RabbitMqConfigs",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionName",
                table: "RabbitMqRoutingKeys");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "RabbitMqRoutingKeys");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "RabbitMqRoutingKeys");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "RabbitMqConfigs");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "RabbitMqConfigs");
        }
    }
}
