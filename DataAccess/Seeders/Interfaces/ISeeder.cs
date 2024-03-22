namespace DataAccess.Seeders.Abstract;

public interface ISeeder<T>
{
    List<T> Seed();
}