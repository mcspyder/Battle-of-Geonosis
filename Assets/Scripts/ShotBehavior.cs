using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour
{
    public Vector3 m_target;
    public GameObject collisionExplosion;
    public float speed;
    public int damageAmount = 60;

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (m_target != null)
        {
            if (transform.position == m_target)
            {
                explode();
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
        }
    }

    public void setTarget(Vector3 target)
    {
        m_target = target;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Access enemy health and apply damage
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                bool isDead = enemyHealth.currentHealth <= damageAmount;
                enemyHealth.TakeDamage(damageAmount);

                // Check if the enemy is dead
                if (isDead)
                {
                    var scoringController = FindObjectsOfType<ScoringController>();
                    foreach (var entry in scoringController)
                        if (entry != null)
                        {
                            entry.AddScore();
                        }
                }
            }
            explode();
        }
    }

    void explode()
    {
        if (collisionExplosion != null)
        {
            GameObject explosion = Instantiate(collisionExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }
    }
}
