using System.Collections.Generic;

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
        int total = item.GetPriceBuy(currencyType) * count;
        currencyComponent.Remove(currencyType, total);
        storageComponent.Add(item, count);
    }

    public void Sell(Item item, int count, CurrencyType currencyType) 
    {
        int total = item.GetPriceSell(currencyType) * count;
        currencyComponent.Add(currencyType, total);
        storageComponent.Remove(item, count);
    }

    // consume materials
    public bool HasEnoughMaterial(List<MaterialRequirement> materialRequirements)
    {
        foreach(var materialRequirement in materialRequirements)
            if (!HasEnoughOfItem(materialRequirement.ItemId, materialRequirement.Amount))
                return false;
        return true;
    }

    public void ConsumeMaterialRequirement(List<MaterialRequirement> materialRequirements)
    {
       foreach(var materialRequirement in materialRequirements)
            Remove(materialRequirement.ItemId, materialRequirement.Amount);
    }

    // drop
    public List<ItemReward> GenerateDrops(List<ItemDrop> drops)
    {
        List<ItemReward> rewards = new ();
        foreach (var drop in drops)
        {
            if(Random.value > drop.DropChance) continue;
            int count = Random.Range(drop.QuantityMin, drop.QuantityMax + 1);
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
            Add(reward.ItemId, reward.Count);
    }
}
