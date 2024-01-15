using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionIMM.Data.Migrations
{
    /// <inheritdoc />
    public partial class db55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "proprietes",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Emplacement",
                table: "proprietes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.CreateIndex(
                name: "IX_transactionVentes_AcheteurId",
                table: "transactionVentes",
                column: "AcheteurId");

            migrationBuilder.CreateIndex(
                name: "IX_transactionVentes_ProprieteId",
                table: "transactionVentes",
                column: "ProprieteId");

            migrationBuilder.CreateIndex(
                name: "IX_maintenances_ProprieteId",
                table: "maintenances",
                column: "ProprieteId");

            migrationBuilder.CreateIndex(
                name: "IX_contratLocations_LocataireId",
                table: "contratLocations",
                column: "LocataireId");

            migrationBuilder.CreateIndex(
                name: "IX_contratLocations_ProprieteId",
                table: "contratLocations",
                column: "ProprieteId");

            migrationBuilder.AddForeignKey(
                name: "FK_contratLocations_clients_LocataireId",
                table: "contratLocations",
                column: "LocataireId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_contratLocations_proprietes_ProprieteId",
                table: "contratLocations",
                column: "ProprieteId",
                principalTable: "proprietes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_maintenances_proprietes_ProprieteId",
                table: "maintenances",
                column: "ProprieteId",
                principalTable: "proprietes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactionVentes_clients_AcheteurId",
                table: "transactionVentes",
                column: "AcheteurId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transactionVentes_proprietes_ProprieteId",
                table: "transactionVentes",
                column: "ProprieteId",
                principalTable: "proprietes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contratLocations_clients_LocataireId",
                table: "contratLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_contratLocations_proprietes_ProprieteId",
                table: "contratLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_maintenances_proprietes_ProprieteId",
                table: "maintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_transactionVentes_clients_AcheteurId",
                table: "transactionVentes");

            migrationBuilder.DropForeignKey(
                name: "FK_transactionVentes_proprietes_ProprieteId",
                table: "transactionVentes");

            migrationBuilder.DropIndex(
                name: "IX_transactionVentes_AcheteurId",
                table: "transactionVentes");

            migrationBuilder.DropIndex(
                name: "IX_transactionVentes_ProprieteId",
                table: "transactionVentes");

            migrationBuilder.DropIndex(
                name: "IX_maintenances_ProprieteId",
                table: "maintenances");

            migrationBuilder.DropIndex(
                name: "IX_contratLocations_LocataireId",
                table: "contratLocations");

            migrationBuilder.DropIndex(
                name: "IX_contratLocations_ProprieteId",
                table: "contratLocations");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "proprietes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Emplacement",
                table: "proprietes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Adresse",
                table: "clients",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
