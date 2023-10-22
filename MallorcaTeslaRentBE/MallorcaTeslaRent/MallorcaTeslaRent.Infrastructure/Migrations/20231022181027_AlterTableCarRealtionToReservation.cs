using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MallorcaTeslaRent.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableCarRealtionToReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "HashedPassword");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ReservationId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "Users",
                newName: "Password");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");
        }
    }
}
