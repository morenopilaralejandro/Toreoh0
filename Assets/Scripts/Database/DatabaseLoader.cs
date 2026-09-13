using System.Collections.Generic;
using System.Threading.Tasks;

public class DatabaseLoader
{
    private readonly DatabaseRegistry databaseRegistry;
    private readonly DatabaseDependencies databaseDependencies;
    private readonly Dictionary<IAsyncDatabase, Task> loadedTask = new();

    public DatabaseLoader(
        DatabaseRegistry databaseRegistry,
        DatabaseDependencies databaseDependencies)
    {
        this.databaseRegistry = databaseRegistry;
        this.databaseDependencies = databaseDependencies;
    }

    public async Task LoadAsync()
    {
        foreach(var database in databaseRegistry.GetAllDatabases())
            await LoadRecursive(database);
    }

    private Task LoadRecursive(IAsyncDatabase database) 
    {
        if(loadedTask.TryGetValue(database, out var existingTask)) return existingTask;      
        var task = LoadRecursiveInternal(database);
        loadedTask.Add(database, task);
        return task;
    }

    private async Task LoadRecursiveInternal(IAsyncDatabase database) 
    {
        foreach (var dependency in databaseDependencies.Get(database))
            await LoadRecursive(dependency);
        await database.LoadAsync();
    }
}
