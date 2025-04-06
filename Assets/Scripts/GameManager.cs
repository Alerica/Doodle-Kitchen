using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [Header("Currency")]
    [SerializeField] public int gold;
    

    [Header("Upgrades")]
    public bool isAutoHarvest;
    public int plantYield;

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
    
}
