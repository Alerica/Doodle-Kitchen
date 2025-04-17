using UnityEngine;

public class TestAddItem : MonoBehaviour
{
    public ItemData[] itemToAdds;

    void Start()
    {
        foreach(ItemData itemToAdd in itemToAdds)
            InventoryManager.Instance.AddItem(itemToAdd, 5);
    }
}

