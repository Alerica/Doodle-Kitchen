using UnityEngine;
using System.Collections.Generic;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private Dictionary<ItemData, int> inventory = new();
    public event Action onInventoryChangedCallback;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddItem(ItemData item, int amount = 1)
    {
        if (inventory.ContainsKey(item))
            inventory[item] += amount;
        else
            inventory[item] = amount;

        onInventoryChangedCallback?.Invoke();
    }

    public bool RemoveItem(ItemData item, int amount = 1)
    {
        if (inventory.ContainsKey(item))
        {
            inventory[item] -= amount;

            if (inventory[item] <= 0)
                inventory.Remove(item);

            onInventoryChangedCallback?.Invoke();
            return true;
        }
        return false;
    }

    public Dictionary<ItemData, int> GetInventory()
    {
        return inventory;
    }
}

