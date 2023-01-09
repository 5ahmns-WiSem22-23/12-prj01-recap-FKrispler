using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject pickUp;

    private void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Instantiate(pickUp, spawnPoints[Random.Range(0, spawnPoints.Length)]);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Spawn();
        }
    }
}
