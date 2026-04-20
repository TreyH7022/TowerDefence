using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public bool isOccupied = false;
    public Transform buildPoint;

    public void PlaceTower()
    {
        if (isOccupied)
        {
            Debug.Log("Spot already occupied!");
            return;
        }

        if (TowerShop.instance.selectedTowerPrefab == null)
            return;

        if (!GameManager.instance.SpendMoney(TowerShop.instance.towerCost))
        {
            Debug.Log("Not enough money!");
            return;
        }

        Instantiate(TowerShop.instance.selectedTowerPrefab, buildPoint.position, Quaternion.identity);

        isOccupied = true;
    }
}