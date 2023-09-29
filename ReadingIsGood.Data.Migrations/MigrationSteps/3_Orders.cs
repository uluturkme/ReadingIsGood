namespace ReadingIsGood.Data.Migrations.MigrationSteps;

[Migration(3)]
public class Orders : Migration
{
    private readonly string CustomerForeignKey = $"FK_{TableNames.Orders}_{TableNames.Customers}_Id";
    private readonly string OrderForeignKey = $"FK_{TableNames.OrderItems}_{TableNames.Orders}_Id";
    private readonly string BookForeignKey = $"FK_{TableNames.OrderItems}_{TableNames.Books}_Id";

    public override void Up()
    {
        Create.Table(TableNames.Orders)
            .WithColumn(ColumnNames.Id).AsGuid().PrimaryKey().NotNullable()
            .WithColumn("CustomerId").AsGuid().NotNullable().ForeignKey(CustomerForeignKey, TableNames.Customers, ColumnNames.Id)
            .WithColumn("TotalPrice").AsDecimal().NotNullable()
            .WithColumn(ColumnNames.CreatedOnUtc).AsDateTime().NotNullable()
            .WithColumn(ColumnNames.UpdatedOnUtc).AsDateTime().Nullable();

        Create.Table(TableNames.OrderItems)
            .WithColumn(ColumnNames.Id).AsGuid().PrimaryKey().NotNullable()
            .WithColumn("OrderId").AsGuid().NotNullable().ForeignKey(OrderForeignKey, TableNames.Orders, ColumnNames.Id)
            .WithColumn("BookId").AsGuid().NotNullable().ForeignKey(BookForeignKey, TableNames.Books, ColumnNames.Id)
            .WithColumn("Quantity").AsInt32().NotNullable()
            .WithColumn(ColumnNames.CreatedOnUtc).AsDateTime().NotNullable()
            .WithColumn(ColumnNames.UpdatedOnUtc).AsDateTime().Nullable();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}
