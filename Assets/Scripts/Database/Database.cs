using UnityEngine.AddressableAssets;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Database<T> : IAsyncDatabase
{
    private readonly Dictionary<string, T> data = new();
    private readonly string label;
    private readonly System.Func<T, string> idSelector;

    public IReadOnlyDictionary<string, T> Data => data;

    public Database(string label, System.Func<T, string> idSelector)
    {
        this.label = label;
        this.idSelector = idSelector;
    }

    public async Task LoadAsync()
    {
        var handle = Addressables.LoadAssetsAsync<T>(
            label, 
            item => data[idSelector(item)] = item
        );

        await handle.Task;
    }

    public T Get(string id) => data[id];
}
