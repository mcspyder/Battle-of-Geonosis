using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float minTimebetweenShots = 1f;
    public float maxTimebetweenShots = 3f;
    public float bulletSpread = 5f; // Spread angle in degrees

    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    void Shoot()
    {
        // randomize the bullet's firing angle
        Quaternion spreadRotation = Quaternion.Euler(0, Random.Range(-bulletSpread, bulletSpread), 0);
        Instantiate(bullet, firePos.position, firePos.rotation * spreadRotation);
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimebetweenShots, maxTimebetweenShots));
            Shoot();
        }
    }
}
