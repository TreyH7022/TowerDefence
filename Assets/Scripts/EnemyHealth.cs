using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    private float currentHealth;
    public AudioClip deathSound;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {

        if (deathSound != null)
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        
        GameManager.instance.AddMoney(10);
        Destroy(gameObject);
    }

}