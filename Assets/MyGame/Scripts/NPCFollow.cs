using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    // Speed of the NPC
    public float speed = 5.0f;

    // Tag for the player game object
    public string playerTag = "Player";

    // Reference to the player game object
    private GameObject player;

    

    // Use this for initialization
    void Start()
    {
        // Find the player game object
        player = GameObject.FindWithTag(playerTag);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction to the player
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Set velocity based on direction
        Vector2 velocity = direction * speed;

        // Rotate the NPC based on velocity
        if (velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        // Move the NPC
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
