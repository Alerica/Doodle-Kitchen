using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "RecipeBook", menuName = "Scriptable Objects/RecipeBook")]
public class RecipeBook : ScriptableObject
{
    public List<Recipe> recipes;

    public ItemData GetResult(List<ItemData> inputIngredients)
    {
        foreach (var recipe in recipes)
        {
            if (MatchIngredients(recipe.ingredients, inputIngredients))
                return recipe.result;
        }
        return null;
    }

    bool MatchIngredients(List<ItemData> a, List<ItemData> b)
    {
        var tempA = new List<ItemData>(a);
        var tempB = new List<ItemData>(b);
        tempA.Sort((x, y) => x.name.CompareTo(y.name));
        tempB.Sort((x, y) => x.name.CompareTo(y.name));
        for (int i = 0; i < 3; i++)
        {
            if (tempA[i] != tempB[i]) return false;
        }
        return true;
    }
}