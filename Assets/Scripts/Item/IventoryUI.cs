using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject itemSlotPrefab;
    public InventoryFilter currentFilter = InventoryFilter.All;

    void Start()
    {
        InventoryManager.Instance.onInventoryChangedCallback += UpdateUI;
        UpdateUI();
    }

    public void UpdateUI()
    {
        // Clear existing UI
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        foreach (var entry in InventoryManager.Instance.GetInventory())
        {
            if (ShouldShowItem(entry.Key))
            {
                GameObject slot = Instantiate(itemSlotPrefab, contentParent);
                slot.GetComponent<ItemSlot>().Setup(entry.Key, entry.Value);
            }
        }
    }

    bool ShouldShowItem(ItemData item)
    {
        return currentFilter == InventoryFilter.All ||
              (currentFilter == InventoryFilter.Ingredient && item.itemType == ItemType.Ingredient) ||
              (currentFilter == InventoryFilter.Food && item.itemType == ItemType.Food);
    }

    public void SetFilter(int filterIndex)
    {
        currentFilter = (InventoryFilter)filterIndex;
        UpdateUI();
    }
}

public enum InventoryFilter { All, Ingredient, Food }
