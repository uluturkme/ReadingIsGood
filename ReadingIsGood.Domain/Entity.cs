namespace ReadingIsGood.Domain;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? UpdatedOnUtc { get; private set; }


    public Entity()
    {
        CreatedOnUtc = DateTime.UtcNow;
    }

    public void Update()
    {
        UpdatedOnUtc = DateTime.UtcNow;
    }
}
