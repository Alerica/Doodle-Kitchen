using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class CraftingSystem : MonoBehaviour
{
    public CraftingSlot[] craftingSlots;
    public RecipeBook recipeBook;
    public TextMeshProUGUI cookingResultText;

    public void OnCookButtonPressed()
    {
        List<ItemData> selectedItems = new();

        foreach (var slot in craftingSlots)
        {
            var item = slot.GetSelectedItem();
            if (item == null)
            {
                cookingResultText.text = "Missing ingredient!";
                Debug.Log("Missing ingredient!");
                return;
            }
            selectedItems.Add(item);
        }

        var result = recipeBook.GetResult(selectedItems);
        if (result != null)
        {

            foreach (var item in selectedItems)
                if(!InventoryManager.Instance.RemoveItem(item))
                    {
                        cookingResultText.text = "You don`t have the ingredients, it burns down";
                        foreach (var slot in craftingSlots)
                            slot.ClearSlot();
                        return;
                    }
            
            InventoryManager.Instance.AddItem(result);
            cookingResultText.text = $"Cooked: {result.itemName}";
            Debug.Log("Cooked: " + result.itemName);
        }
        else
        {
            cookingResultText.text = "Unknown recipe!";
            Debug.Log("Unknown recipe!");
        }

        foreach (var slot in craftingSlots)
            slot.ClearSlot();
    }
}
