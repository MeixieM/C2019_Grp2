using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentaPix_Clinic.Migrations
{
    public partial class updatePaymentToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Payments_PaymentId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PaymentId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AppointmentId",
                table: "Payments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DoctorId",
                table: "Payments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PatientId",
                table: "Payments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TreatmentId",
                table: "Payments",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Appointments_AppointmentId",
                table: "Payments",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Doctors_DoctorId",
                table: "Payments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Patients_PatientId",
                table: "Payments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Treatments_TreatmentId",
                table: "Payments",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "TreatmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Appointments_AppointmentId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Doctors_DoctorId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Patients_PatientId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Treatments_TreatmentId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_AppointmentId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_DoctorId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PatientId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_TreatmentId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PaymentId",
                table: "Patients",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Payments_PaymentId",
                table: "Patients",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId");
        }
    }
}
