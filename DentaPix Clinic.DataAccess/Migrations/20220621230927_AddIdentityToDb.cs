using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentaPix_Clinic.Migrations
{
    public partial class AddIdentityToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Treatments",
                newName: "TreatmentPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TreatmentPrice",
                table: "Treatments",
                newName: "Price");
        }
    }
}
