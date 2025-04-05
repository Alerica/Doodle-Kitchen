using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI amountText;

    public void Setup(ItemData data, int amount)
    {
        icon.sprite = data.icon;
        amountText.text = amount.ToString();
    }
}

