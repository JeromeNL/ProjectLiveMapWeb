namespace DataAccess.Interfaces;

public interface ISoftDelete
{
    public DateTimeOffset? DeletedAt { get; set; }
    
    public void Undo()
    {
        DeletedAt = null;
    }
}