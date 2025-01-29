using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public float zigzagAmplitude = 1f; 
    public float zigzagFrequency = 2f;

    private Vector3 initialPosition;

    // Define the bounds of movement
    public float leftBoundary = -10f; 
    public float rightBoundary = 10f;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Move horizontally
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // Add zigzag movement
        float zigzagOffset = Mathf.Sin(Time.time * zigzagFrequency) * zigzagAmplitude;
        transform.position = new Vector3(transform.position.x, initialPosition.y + zigzagOffset, transform.position.z);

        // Clamp position within boundaries
        if (transform.position.x < leftBoundary || transform.position.x > rightBoundary)
        {
            moveSpeed *= -1; // Reverse direction
            float clampedX = Mathf.Clamp(transform.position.x, leftBoundary, rightBoundary);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            moveSpeed *= -1;
        }
    }
}
