using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Item;

public class ItemManagerComponentProcess
{
    private ItemManagerComponentStorage storageComponent;
    private ItemManagerComponentCurrency currencyComponent;

    public ItemManagerComponentProcess(
        ItemManagerComponentStorage storageComponent,
        ItemManagerComponentCurrency currencyComponent)
    {
        this.storageComponent = storageComponent;
        this.currencyComponent = currencyComponent;
    }

    // buy
    public void Buy(Item item, int count, CurrencyType currencyType) 
    {
        int total = item.ShopComponent.GetPriceBuy(currencyType) * count;
        currencyComponent.Remove(currencyType, total);
        storageComponent.Add(item, count);
    }

    public void Sell(Item item, int count, CurrencyType currencyType) 
    {
        int total = item.ShopComponent.GetPriceSell(currencyType) * count;
        currencyComponent.Add(currencyType, total);
        storageComponent.Remove(item, count);
    }

    // consume materials
    public bool HasEnoughMaterial(List<MaterialRequirement> materialRequirements)
    {
        foreach(var materialRequirement in materialRequirements)
            if (!storageComponent.HasEnoughOfItem(materialRequirement.ItemId, materialRequirement.Count))
                return false;
        return true;
    }

    public void ConsumeMaterialRequirement(List<MaterialRequirement> materialRequirements)
    {
       foreach(var materialRequirement in materialRequirements)
            storageComponent.Remove(materialRequirement.ItemId, materialRequirement.Count);
    }

    // drop
    public List<ItemReward> GenerateDrops(List<ItemDrop> drops)
    {
        List<ItemReward> rewards = new ();
        foreach (var drop in drops)
        {
            if(Random.value > drop.DropChance) continue;
            int count = Random.Range(drop.CountMin, drop.CountMax + 1);
            rewards.Add(new ItemReward 
            {
                ItemId = drop.ItemId,
                Count = count
            });
        }
        return rewards;
    }

    // reward
    public void MultiplyRewards(List<ItemReward> rewards, int multiplier)
    {
        foreach (var reward in rewards)
            reward.Count *= multiplier;
    }

    public void AddRewards(List<ItemReward> rewards)
    {
        foreach (var reward in rewards)
            storageComponent.Add(reward.ItemId, reward.Count);
    }
}
