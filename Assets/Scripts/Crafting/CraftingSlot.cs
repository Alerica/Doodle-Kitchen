using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingSlot : MonoBehaviour
{
    public Image icon;
    public GameObject scrollPanel;         
    public Transform scrollContent;        
    public GameObject itemSlotButtonPrefab;
    public ItemData selectedItem;

    public Sprite defaultIcon;


    public void OnClickSlot()
    {
        scrollPanel.SetActive(!scrollPanel.activeSelf);
        RefreshScrollList();
    }

    void RefreshScrollList()
    {
        foreach (Transform child in scrollContent)
            Destroy(child.gameObject);

        foreach (var entry in InventoryManager.Instance.GetInventory())
        {
            if (entry.Key.itemType != ItemType.Ingredient) continue;

            GameObject btnObj = Instantiate(itemSlotButtonPrefab, scrollContent);
            btnObj.GetComponentInChildren<Image>().sprite = entry.Key.icon;
            btnObj.GetComponentInChildren<TextMeshProUGUI>().text = $"{entry.Key.itemName} ({entry.Value})";

            var item = entry.Key;
            btnObj.GetComponent<Button>().onClick.AddListener(() => {
                SelectItem(item);
                scrollPanel.SetActive(false);
            });
        }
    }

    void SelectItem(ItemData item)
    {
        selectedItem = item;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public ItemData GetSelectedItem()
    {
        return selectedItem;
    }

    public void ClearSlot()
    {
        selectedItem = null;
        icon.sprite = defaultIcon;
    }

}
