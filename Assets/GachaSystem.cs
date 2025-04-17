using TMPro;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    public TextMeshProUGUI gachaResult;
    
    public ItemData[] ingredients;
    public int gachaCost = 5;
    public int gachaRecipeCost = 500;

    public void GachaIngredient() {
        if(GameManager.Instance.gold >= gachaCost)
        {
            GameManager.Instance.removeGold(gachaCost);
            ItemData ingredient = ingredients[Random.Range(0, ingredients.Length)];
            InventoryManager.Instance.AddItem(ingredient);
            gachaResult.text = "You got " + ingredient.name + "!";
            Debug.Log("You got " + ingredient.name + "!");
        }
        else
        {
            gachaResult.text = "Not enough Gold!";
            Debug.Log("Not enough gold");
        }
    }

    public void GachaRecipe()
    {
        if(GameManager.Instance.gold >= gachaRecipeCost)
        {
            GameManager.Instance.removeGold(gachaRecipeCost);
            gachaResult.text = $"Try Mixing : {GameManager.Instance.ShowOneFoodRecipe()}";
        }
        else
        {
            gachaResult.text = "Not enough Gold!";
            Debug.Log("Not enough gold");
        }
    }

}
