using UnityEngine;
using UnityEngine.UI;

public class PlantUI : MonoBehaviour
{
    public PlantData plantData;
    public Image plantImage;
    public GameObject harvestButton;

    private float growthTimer;
    private int currentStage;

    void Start()
    {
        growthTimer = 0f;
        currentStage = 0;
        plantImage.sprite = plantData.growthStages[currentStage];
    }

    void Update()
    {
        if (IsReadyToHarvest()) harvestButton.SetActive(true);
        if(GameManager.Instance.isAutoHarvest) OnClickHarvest();

        growthTimer += Time.deltaTime;
        float stageDuration = plantData.growthTimeSeconds / plantData.growthStages.Length;

        int stage = Mathf.FloorToInt(growthTimer / stageDuration);
        if (stage > currentStage && stage < plantData.growthStages.Length)
        {
            currentStage = stage;
            plantImage.sprite = plantData.growthStages[currentStage];
        }
    }

    public bool IsReadyToHarvest()
    {
        return currentStage == plantData.growthStages.Length - 1;
    }

    public void OnClickHarvest()
    {
        if (!IsReadyToHarvest()) return;

        Debug.Log("Harvested: " + plantData.fruitName + " x" + plantData.harvestYield);

        InventoryManager.Instance.AddItem(plantData.itemData, plantData.harvestYield + GameManager.Instance.plantYield);

        ResetPlant();
    }

    void ResetPlant()
    {
        growthTimer = 0f;
        currentStage = 0;
        plantImage.sprite = plantData.growthStages[0];
        harvestButton.SetActive(false);
    }
}
