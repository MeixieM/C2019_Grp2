using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentaPix_Clinic.Migrations
{
    public partial class addAppointmentToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentDay",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Appointments",
                newName: "NatureOfAppointment");

            migrationBuilder.RenameColumn(
                name: "AppointmentStatus",
                table: "Appointments",
                newName: "MobileNo");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "NatureOfAppointment",
                table: "Appointments",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "MobileNo",
                table: "Appointments",
                newName: "AppointmentStatus");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentDay",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
