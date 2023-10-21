using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeApi.Migrations
{
    /// <inheritdoc />
    public partial class changecollums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cinemas_enderecos_EnderecoId",
                table: "cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_sessoes_cinemas_CinemaId",
                table: "sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_sessoes_filmes_FilmeId",
                table: "sessoes");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "sessoes",
                newName: "cinemaId");

            migrationBuilder.RenameColumn(
                name: "FilmeId",
                table: "sessoes",
                newName: "filmeId");

            migrationBuilder.RenameIndex(
                name: "IX_sessoes_CinemaId",
                table: "sessoes",
                newName: "IX_sessoes_cinemaId");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "filmes",
                newName: "titulo");

            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "filmes",
                newName: "genero");

            migrationBuilder.RenameColumn(
                name: "Duracao",
                table: "filmes",
                newName: "duracao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "filmes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "enderecos",
                newName: "numero");

            migrationBuilder.RenameColumn(
                name: "Lougradouro",
                table: "enderecos",
                newName: "lougradouro");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "enderecos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "cinemas",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "cinemas",
                newName: "enderecoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cinemas",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_cinemas_EnderecoId",
                table: "cinemas",
                newName: "IX_cinemas_enderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_cinemas_enderecos_enderecoId",
                table: "cinemas",
                column: "enderecoId",
                principalTable: "enderecos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sessoes_cinemas_cinemaId",
                table: "sessoes",
                column: "cinemaId",
                principalTable: "cinemas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sessoes_filmes_filmeId",
                table: "sessoes",
                column: "filmeId",
                principalTable: "filmes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cinemas_enderecos_enderecoId",
                table: "cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_sessoes_cinemas_cinemaId",
                table: "sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_sessoes_filmes_filmeId",
                table: "sessoes");

            migrationBuilder.RenameColumn(
                name: "cinemaId",
                table: "sessoes",
                newName: "CinemaId");

            migrationBuilder.RenameColumn(
                name: "filmeId",
                table: "sessoes",
                newName: "FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_sessoes_cinemaId",
                table: "sessoes",
                newName: "IX_sessoes_CinemaId");

            migrationBuilder.RenameColumn(
                name: "titulo",
                table: "filmes",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "genero",
                table: "filmes",
                newName: "Genero");

            migrationBuilder.RenameColumn(
                name: "duracao",
                table: "filmes",
                newName: "Duracao");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "filmes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "numero",
                table: "enderecos",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "lougradouro",
                table: "enderecos",
                newName: "Lougradouro");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "enderecos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "cinemas",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "enderecoId",
                table: "cinemas",
                newName: "EnderecoId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "cinemas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_cinemas_enderecoId",
                table: "cinemas",
                newName: "IX_cinemas_EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_cinemas_enderecos_EnderecoId",
                table: "cinemas",
                column: "EnderecoId",
                principalTable: "enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sessoes_cinemas_CinemaId",
                table: "sessoes",
                column: "CinemaId",
                principalTable: "cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sessoes_filmes_FilmeId",
                table: "sessoes",
                column: "FilmeId",
                principalTable: "filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
