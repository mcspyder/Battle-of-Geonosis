using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    public float currentHealth;
    public Slider healthSlider;
    
    
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update(){
        float normalizedHealth = currentHealth / maxHealth;
        healthSlider.value = normalizedHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
