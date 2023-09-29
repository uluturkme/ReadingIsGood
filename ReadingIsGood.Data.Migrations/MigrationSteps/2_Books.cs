namespace ReadingIsGood.Data.Migrations.MigrationSteps;

[Migration(2)]
public class Books : Migration
{
    public override void Up()
    {
        Create.Table(TableNames.Books)
            .WithColumn(ColumnNames.Id).AsGuid().PrimaryKey().NotNullable()
            .WithColumn("Title").AsString(EntityConfigs.NameLength).NotNullable()
            .WithColumn("Description").AsString(EntityConfigs.DescriptionLength).NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable()
            .WithColumn("Quantity").AsInt32().NotNullable()
            .WithColumn(ColumnNames.CreatedOnUtc).AsDateTime().NotNullable()
            .WithColumn(ColumnNames.UpdatedOnUtc).AsDateTime().Nullable();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}