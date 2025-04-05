using UnityEngine;

[CreateAssetMenu(fileName = "PlantData", menuName = "Scriptable Objects/PlantData")]
public class PlantData : ScriptableObject
{
    [Header("Visuals")]
    public Sprite[] growthStages; 

    [Header("Growth Settings")]
    public float growthTimeSeconds; 

    [Header("Harvest Info")]
    public string fruitName;
    public int harvestYield; 
    public ItemData itemData;
}
