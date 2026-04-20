using UnityEngine;

public class TowerShop : MonoBehaviour
{
    public static TowerShop instance;

    public GameObject selectedTowerPrefab;
    public int towerCost = 50;

    void Awake()
    {
        instance = this;
    }

    public GameObject basicTowerPrefab;

    public void SelectBasicTower()
    {
        selectedTowerPrefab = basicTowerPrefab;
        towerCost = 50;
    }
}