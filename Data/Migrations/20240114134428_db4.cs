using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionIMM.Data.Migrations
{
    /// <inheritdoc />
    public partial class db4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Description",
                table: "maintenances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "proprietes",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "maintenances",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_contratLocations_proprietes_ProprieteId",
                table: "contratLocations",
                column: "ProprieteId",
                principalTable: "proprietes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactionVentes_proprietes_ProprieteId",
                table: "transactionVentes",
                column: "ProprieteId",
                principalTable: "proprietes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
