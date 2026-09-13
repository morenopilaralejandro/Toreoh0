using System.Collections.Generic;

public class DatabaseDependencies
{
    private readonly Dictionary<IAsyncDatabase, IAsyncDatabase[]> dependencies = new();

    public void Register(IAsyncDatabase database, params IAsyncDatabase[] dependsOn)
    {
        dependencies[database] = dependsOn;
    }

    public IAsyncDatabase[] Get(IAsyncDatabase database) 
    {
        return this.dependencies.TryGetValue(database, out var dependencies) 
            ? dependencies : System.Array.Empty<IAsyncDatabase>();
    }
}
