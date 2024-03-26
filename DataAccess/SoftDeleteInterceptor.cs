using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataAccess;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData, 
        InterceptionResult<int> result)
    {
        if (eventData.Context is null) return result;
        
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is not { State: EntityState.Deleted, Entity: ISoftDelete delete }) continue;
            entry.State = EntityState.Modified;
            delete.DeletedAt = DateTimeOffset.UtcNow;
        }
        return result;
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        var valueTask = await new ValueTask<InterceptionResult<int>>(result);
        if (eventData.Context is null) return valueTask;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is not { State: EntityState.Deleted, Entity: ISoftDelete delete }) continue;
            entry.State = EntityState.Modified;
            delete.DeletedAt = DateTimeOffset.UtcNow;
        }

        return valueTask;
    }
}