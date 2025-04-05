using UnityEngine;

public class TestAddItem : MonoBehaviour
{
    public ItemData tomato;

    void Start()
    {
        InventoryManager.Instance.AddItem(tomato, 5);
    }
}

