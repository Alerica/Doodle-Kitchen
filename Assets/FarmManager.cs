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
    public int maximumFertilizerUpgrade = 10;
    public int autoHarvestCost = 1000;


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
            GameManager.Instance.removeGold(plantCost);
            plantSlots[unlockedPlantCount].SetActive(true); 
            unlockedPlantCount++;
            if(unlockedPlantCount >= plantSlots.Length) GameManager.Instance.UnlockPlantTropy(); 
            farmShopText.text = $"{plantSlots[unlockedPlantCount - 1].name} Purchased!";
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
                GameManager.Instance.removeGold(plantCost);
                GameManager.Instance.AddPlantYield();
                currentFertilizerUpgrade++;
                farmShopText.text = $"Plant got extra {GameManager.Instance.plantYield} yield!";
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
            GameManager.Instance.removeGold(plantCost);
            GameManager.Instance.ActivateAutoHarvest();
            farmShopText.text = "Auto Harvest Unlocked!";
        } 
        else
        {
            Debug.Log("Not enough gold");
            farmShopText.text = $"Not enough gold! You need {autoHarvestCost} gold";;
        }
    }

    public void ToggleShopPanel()
    {
        GameManager.Instance.DisableFarmGuide();
        if(shopPanelOpen)   
            shopPanel.SetActive(false);
        else
            shopPanel.SetActive(true);
        shopPanelOpen = !shopPanelOpen;
        
    }
}
