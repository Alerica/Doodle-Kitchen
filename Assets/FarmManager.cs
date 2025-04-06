using TMPro;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject[] plantSlots; 
    public TextMeshProUGUI farmShopText;
    public bool shopPanelOpen = false;
    private int unlockedPlantCount = 1; 

    public int plantCost = 100;
    public int fertilizerCost = 250;

    public int currentFertilizerUpgrade = 1;
    public int maximumFertilizerUpgrade = 5;
    public int autoHarvestCost = 5000;


    public void BuyNewPlant()
    {
        if (unlockedPlantCount >= plantSlots.Length)
        {
            Debug.Log("All plants unlocked!");
            farmShopText.text = "All plants unlocked!";
            return;
        }

        if (GameManager.Instance.gold >= plantCost)
        {
            GameManager.Instance.gold -= plantCost;
            plantSlots[unlockedPlantCount].SetActive(true); 
            unlockedPlantCount++;
        }
        else
        {
            Debug.Log("Not enough gold!");
            farmShopText.text = $"Not enough gold! You need {plantCost} gold";;
        }
    }

    public void BuyFertilizer()
    {
        if(currentFertilizerUpgrade <= maximumFertilizerUpgrade)
        {
            if (GameManager.Instance.gold >= fertilizerCost)
            {
                GameManager.Instance.gold -= fertilizerCost;
                GameManager.Instance.AddPlantYield();
                currentFertilizerUpgrade++;
            }
            else
            {
                Debug.Log("Not enough gold");
                farmShopText.text = $"Not enough gold! You need {fertilizerCost} gold";
            }
        }
        else 
        {
            Debug.Log("Maximum Upgrade already");
            farmShopText.text = "Maximum Upgrade already";
        }
        
    }

    public void BuyAutoHarvest()
    {
        if (GameManager.Instance.gold >= autoHarvestCost)
        {
            GameManager.Instance.gold -= autoHarvestCost;
            GameManager.Instance.ActivateAutoHarvest();
        } 
        else
        {
            Debug.Log("Not enough gold");
            farmShopText.text = $"Not enough gold! You need {autoHarvestCost} gold";;
        }
    }

    public void ToggleShopPanel()
    {
        if(shopPanelOpen)   
            shopPanel.SetActive(false);
        else
            shopPanel.SetActive(true);
        shopPanelOpen = !shopPanelOpen;
        
    }
}
