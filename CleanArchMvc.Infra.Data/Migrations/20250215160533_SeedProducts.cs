using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                   "VALUES('Mouse RedDragon', 'Mouse RedDragon 8000 DPI RGB', 60, 10, 'image.png', 1)");

            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                  "VALUES('Monitor Acer 25.5', 'Monitor Acer 165hz', 899.99, 50, 'monitor_acer.png', 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
