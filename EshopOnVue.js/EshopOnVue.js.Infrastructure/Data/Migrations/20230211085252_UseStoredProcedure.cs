using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopOnVue.js.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UseStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.Sql(SqlScripts.Files.CreateProcedureGetAllCatalogItems);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlScripts.Files.DropProcedureGetAllCatalogItems);
        }
    }
}
