namespace ReadingIsGood.Data.Migrations.MigrationSteps;

[Migration(1)]
public class Customers : Migration
{
    public override void Up()
    {
        Create.Table(TableNames.Customers)
            .WithColumn(ColumnNames.Id).AsGuid().PrimaryKey().NotNullable()
            .WithColumn("FirstName").AsString(EntityConfigs.NameLength).NotNullable()
            .WithColumn("LastName").AsString(EntityConfigs.NameLength).NotNullable()
            .WithColumn("Email").AsString(EntityConfigs.NameLength).NotNullable()
            .WithColumn(ColumnNames.CreatedOnUtc).AsDateTime().NotNullable()
            .WithColumn(ColumnNames.UpdatedOnUtc).AsDateTime().Nullable();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}