using TMPro;
using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [Header("Reference")]
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI farmGuideText;
    public TextMeshProUGUI kitchenGuideText;

    public TextMeshProUGUI recipeText;

    [Header("Currency")]
    [SerializeField] public int gold;
    

    [Header("Upgrades")]
    public bool isAutoHarvest;
    public int plantYield;

    [Header("Trophy")]
    public GameObject plantTropy;
    public GameObject completionTrophy;
    public GameObject coinTrophy;

    [Header("Food to be made")]
    public RecipeBook recipeBook;
    List<string> foodsToMake = new List<string>
    {
        "Bread",
        "Baked Potato",
        "Grilled Corn",
        "Spicy Grilled Corn",
        "Cheesy Grilled Corn",
        "Sauced Grilled Corn",
        "Fried Carrot",
        "Tomato Soup",
        "Carrot Soup",
        "Corn Soup",
        "Salad",
        "Pizza",
        "Cheesy Bread",
        "Veggie Wrap",
        "Corn Pepper Donburi",
        "Corn Wrap",
        "Corn Bread",
        "Tomato Flat Bread",
        "Egg Flat Bread",
        "Cheese Flat Bread",
        "Fried Egg",
        "Omelette",
        "Cheesy Omelette",
        "Simple Breakfast",
        "Veggie Fried Rice",
        "Egg Fried Rice",
        "Spicy Fried Rice",
        "Dumplings",
        "Tomato and Cheese",
        "Pancake"
    };


    void Awake()
    {
        Instance = this;
        gold = 100;
        plantYield = 0;
    }

    public void AddPlantYield()
    {
        plantYield += 1;
    }

    public void ActivateAutoHarvest()
    {
        isAutoHarvest = true;
    }

    public void AddGold(int amount)
    {
        gold += amount;
        coinText.text = gold + "";
        if(gold >= 10000) coinTrophy.SetActive(true);
    }

    public void removeGold(int amount)
    {
        gold -= amount;
        coinText.text = gold + "";
    }

    public void DisableFarmGuide()
    {
        farmGuideText.text = "";
    }

    public void DisableKitchenGuide()
    {
        kitchenGuideText.text = "";
    }

    public void UnlockPlantTropy()
    {
        plantTropy.SetActive(true);
    }

    public void UnlockCompletionTropy()
    {
        completionTrophy.SetActive(true);
    }
    
    public void OnFoodMade(string foodName)
    {
        if (foodsToMake.Contains(foodName))
        {
            foodsToMake.Remove(foodName);
            Debug.Log($"{foodName} made! {foodsToMake.Count} left.");
            recipeText.text = $"{foodsToMake.Count} Recipe Left";
            
            if (foodsToMake.Count == 0)
            {
                UnlockCompletionTropy();
            }
        }
    }

    public string ShowOneFoodRecipe()
    {
        string needed = "";
        if (foodsToMake == null || foodsToMake.Count == 0)
        {
            Debug.LogWarning("foodsToMake is empty!");
            return "";
        }

        string selectedFood = foodsToMake[Random.Range(0, foodsToMake.Count)];
        var recipe = recipeBook.recipes.Find(r => r.result.name == selectedFood);

        if (recipe != null)
        {
            Debug.Log($"Selected Food: {selectedFood}");
            Debug.Log("Ingredients:");
            foreach (var ingredient in recipe.ingredients)
            {
                needed = needed + " "  + ingredient.name;
                Debug.Log($"- {ingredient.name}");
            }
        }
        else
        {
            Debug.LogWarning($"No recipe found for {selectedFood}!");
        }
        return needed;
    }


}
