using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; 
    public int currentHealth; 
    public Slider healthBar; 
    public GameObject gameOverScreen; 
    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth; 
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 

        if (healthBar != null)
        {
            healthBar.value = currentHealth; 
        }

        if (currentHealth <= 0)
        {
            GameOver(); 
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f; 
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); 
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount; 
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
        if (healthBar != null)
        {
            healthBar.value = currentHealth; 
        }
    }
}
