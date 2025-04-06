using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public void SellAllFoodItems()
    {
        var inventory = InventoryManager.Instance.GetInventory();
        var itemsToRemove = new List<ItemData>();

        foreach (var item in inventory)
        {
            if (item.Key.itemType == ItemType.Food)
            {
                int pricePerItem = item.Key.itemName == "Disgusted Mesh" ? 1 : 20;
                GameManager.Instance.AddGold(item.Value * pricePerItem);
                itemsToRemove.Add(item.Key);
            }
        }

        foreach (var item in itemsToRemove)
        {
            InventoryManager.Instance.RemoveItem(item, inventory[item]);
        }

        Debug.Log("[Shop] Sold all food.");
    }
}
