using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class CraftingSystem : MonoBehaviour
{
    public CraftingSlot[] craftingSlots;
    public RecipeBook recipeBook;
    public TextMeshProUGUI cookingResultText;
    public ItemData disgustedMesh;

    public Image[] plateAndBowlImage;

    public void OnCookButtonPressed()
    {
        List<ItemData> selectedItems = new();

        foreach (var slot in craftingSlots)
        {
            var item = slot.GetSelectedItem();
            if (item == null)
            {
                cookingResultText.text = "Missing ingredient! You need 3 to cook";
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
            cookingResultText.text = $"You just make {result.itemName}!";
            plateAndBowlImage[Random.Range(0,2)].sprite = result.icon;
            Debug.Log("Cooked: " + result.itemName);
        }
        else
        {
            foreach (var item in selectedItems) InventoryManager.Instance.RemoveItem(item);
            InventoryManager.Instance.AddItem(disgustedMesh);
            cookingResultText.text = "Unknown recipe! You got a Disgusted Mesh!";
            Debug.Log("Unknown recipe!");
        }

        foreach (var slot in craftingSlots)
            slot.ClearSlot();
    }
}
