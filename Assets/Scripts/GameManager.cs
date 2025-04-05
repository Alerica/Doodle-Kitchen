using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [Header("Currency")]
    [SerializeField] private int gold;


    [Header("Upgrades")]
    public bool isAutoHarvest;
    
    void Awake()
    {
        Instance = this;
    }
}
