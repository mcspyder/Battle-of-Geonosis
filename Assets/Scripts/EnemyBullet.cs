using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount = 20;
        public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            Debug.Log("Enemy bullet hit the player.");
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            Destroy(gameObject);
        }
    }

}
