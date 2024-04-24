using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leituraria.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(300)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Imagem = table.Column<string>(type: "VARCHAR(600)", nullable: true),
                    CadastradoEm = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CadastradoEm = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "VARCHAR(300)", nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Isbn10 = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Isbn13 = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Idioma = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(600)", nullable: false),
                    QuantidadePaginas = table.Column<int>(type: "INT", nullable: false),
                    Valor = table.Column<decimal>(type: "MONEY", nullable: false),
                    AutorId = table.Column<int>(type: "INT", nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livro_Autor_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aluguel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlugadoEm = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DevolverEm = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ClienteId = table.Column<int>(type: "INT", nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluguel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluguel_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Cep = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Pais = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    ClienteId = table.Column<int>(type: "INT", nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AluguelLivro",
                columns: table => new
                {
                    AlugueisId = table.Column<int>(type: "INT", nullable: false),
                    LivrosId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AluguelLivro", x => new { x.AlugueisId, x.LivrosId });
                    table.ForeignKey(
                        name: "FK_AluguelLivro_Aluguel_AlugueisId",
                        column: x => x.AlugueisId,
                        principalTable: "Aluguel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AluguelLivro_Livro_LivrosId",
                        column: x => x.LivrosId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluguel_ClienteId",
                table: "Aluguel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AluguelLivro_LivrosId",
                table: "AluguelLivro",
                column: "LivrosId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteId",
                table: "Endereco",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_AutorId",
                table: "Livro",
                column: "AutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AluguelLivro");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Aluguel");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Autor");
        }
    }
}
