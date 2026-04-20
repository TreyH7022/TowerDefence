using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text moneyText;
    public TMP_Text waveText;
    public EnemySpawner spawner;

    void Update()
    {
        healthText.text = "Health: " + GameManager.instance.playerHealth;
        moneyText.text = "Money: $" + GameManager.instance.money;
        waveText.text = "Wave: " + spawner.waveNumber;
    }
}