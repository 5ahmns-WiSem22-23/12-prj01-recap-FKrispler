using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Speed of the car
    public float speed = 10.0f;
    public float boostDuration = 2.0f; // duration of the boost effect
    public float boostAmount = 10.0f; // amount to increase speed by when boosting

    // Update is called once per frame
    void Update()
    {
        // Get input axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Set velocity based on input
        Vector2 velocity = new Vector2(horizontalInput, verticalInput) * speed;

        // Rotate the car based on velocity
        if (velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        // Move the car
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "BoostPad")
        {
            StartCoroutine(Boost());
        }
    }

    IEnumerator Boost()
    {
        // Increase speed
        speed += boostAmount;

        // Wait for boost duration
        float elapsedTime = 0.0f;
        while (elapsedTime < boostDuration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Decrease speed gradually to normal over 2 seconds
        elapsedTime = 0.0f;
        while (elapsedTime < boostDuration)
        {
            speed = Mathf.Lerp(speed, 10.0f, elapsedTime / boostDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set speed back to normal
        speed = 10.0f;
    }
}