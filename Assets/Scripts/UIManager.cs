using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text moneyText;

    void Update()
    {
        healthText.text = "Health: " + GameManager.instance.playerHealth;
        moneyText.text = "Money: $" + GameManager.instance.money;
    }
}