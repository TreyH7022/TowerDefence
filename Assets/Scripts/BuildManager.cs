using UnityEngine;

public class BuildManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceTower();
        }
    }

    void PlaceTower()
    {
        if (TowerShop.instance.selectedTowerPrefab == null)
            return;

        if (!GameManager.instance.SpendMoney(TowerShop.instance.towerCost))
        {
            Debug.Log("Not enough money!");
            return;
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Instantiate(TowerShop.instance.selectedTowerPrefab, mousePos, Quaternion.identity);
    }
}