using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentaPix_Clinic.Migrations
{
    public partial class addPatientToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "ProfilePictureURL",
                table: "Patients",
                newName: "ImageURL");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Payments",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Patients",
                newName: "ProfilePictureURL");

            migrationBuilder.AlterColumn<string>(
                name: "Amount",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
