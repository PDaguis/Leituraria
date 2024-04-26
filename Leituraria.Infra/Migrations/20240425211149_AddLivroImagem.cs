using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leituraria.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddLivroImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Livro",
                type: "VARCHAR(600)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Livro");
        }
    }
}
