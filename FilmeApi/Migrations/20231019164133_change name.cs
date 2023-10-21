using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeApi.Migrations
{
    /// <inheritdoc />
    public partial class changename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Enderecos_EnderecoId",
                table: "Cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaId",
                table: "Sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas");

            migrationBuilder.RenameTable(
                name: "Sessoes",
                newName: "sessoes");

            migrationBuilder.RenameTable(
                name: "Filmes",
                newName: "filmes");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "enderecos");

            migrationBuilder.RenameTable(
                name: "Cinemas",
                newName: "cinemas");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_CinemaId",
                table: "sessoes",
                newName: "IX_sessoes_CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_Cinemas_EnderecoId",
                table: "cinemas",
                newName: "IX_cinemas_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sessoes",
                table: "sessoes",
                columns: new[] { "FilmeId", "CinemaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_filmes",
                table: "filmes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_enderecos",
                table: "enderecos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cinemas",
                table: "cinemas",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_sessoes",
                table: "sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_filmes",
                table: "filmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_enderecos",
                table: "enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cinemas",
                table: "cinemas");

            migrationBuilder.RenameTable(
                name: "sessoes",
                newName: "Sessoes");

            migrationBuilder.RenameTable(
                name: "filmes",
                newName: "Filmes");

            migrationBuilder.RenameTable(
                name: "enderecos",
                newName: "Enderecos");

            migrationBuilder.RenameTable(
                name: "cinemas",
                newName: "Cinemas");

            migrationBuilder.RenameIndex(
                name: "IX_sessoes_CinemaId",
                table: "Sessoes",
                newName: "IX_Sessoes_CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_cinemas_EnderecoId",
                table: "Cinemas",
                newName: "IX_Cinemas_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes",
                columns: new[] { "FilmeId", "CinemaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Enderecos_EnderecoId",
                table: "Cinemas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaId",
                table: "Sessoes",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
