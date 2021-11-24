using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelTransylvania.Migrations
{
    public partial class ChangeThePrecison : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerNight",
                table: "Rooms",
                type: "decimal(4,2)",
                precision: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "RoomSize",
                table: "RoomProperties",
                type: "decimal(4,2)",
                precision: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldPrecision: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerNight",
                table: "Rooms",
                type: "decimal(2,2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)",
                oldPrecision: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "RoomSize",
                table: "RoomProperties",
                type: "decimal(2,2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)",
                oldPrecision: 4);
        }
    }
}
