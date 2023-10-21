using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeApi.Migrations
{
    /// <inheritdoc />
    public partial class changecollumenderecoid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cinemas_enderecos_enderecoId",
                table: "cinemas");

            migrationBuilder.RenameColumn(
                name: "enderecoId",
                table: "cinemas",
                newName: "enderecoid");

            migrationBuilder.RenameIndex(
                name: "IX_cinemas_enderecoId",
                table: "cinemas",
                newName: "IX_cinemas_enderecoid");

            migrationBuilder.AddForeignKey(
                name: "FK_cinemas_enderecos_enderecoid",
                table: "cinemas",
                column: "enderecoid",
                principalTable: "enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cinemas_enderecos_enderecoid",
                table: "cinemas");

            migrationBuilder.RenameColumn(
                name: "enderecoid",
                table: "cinemas",
                newName: "enderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_cinemas_enderecoid",
                table: "cinemas",
                newName: "IX_cinemas_enderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_cinemas_enderecos_enderecoId",
                table: "cinemas",
                column: "enderecoId",
                principalTable: "enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
