using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MallorcaTeslaRent.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterCarRelationWithReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations");

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
    }
}
