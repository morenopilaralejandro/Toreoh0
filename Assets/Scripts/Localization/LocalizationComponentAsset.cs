using UnityEngine;
using UnityEngine.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aremoreno.Enums.Localization;

public class LocalizationComponentAsset<T> where T : Object
{
    private Dictionary<LocalizationField, LocalizedAsset<T>> localizedAssets = new ();

    public LocalizationComponentAsset(LocalizationEntity entity, string id, LocalizationField[] fields)
    {
        Initialize(entity, id, fields);
    }

    public void Initialize(LocalizationEntity entity, string id, LocalizationField[] fields) 
    {
        localizedAssets.Clear();
        foreach(var field in fields)
        {
            var asset = new LocalizedAsset<T>();
            asset.TableReference = LocalizationManager.Instance.GetTableReference(entity, field);
            asset.TableEntryReference = id;
            localizedAssets[field] = asset;
        }
    }

    public async Task<T> GetAssetAsync(LocalizationField field) 
    {
        var handle = localizedAssets[field].LoadAssetAsync();
        await handle.Task;
        return handle.Result;
    }
}
