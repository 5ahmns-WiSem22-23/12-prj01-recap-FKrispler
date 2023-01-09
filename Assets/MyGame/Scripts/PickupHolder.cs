using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupHolder : MonoBehaviour
{
    private bool isholding;
    public int score;
    public Text scoreText;
    public GameObject signalPickUp;
    public Spawner spawner;

    private void Start()
    {
        isholding = false;
        score = 0;
    }

    private void Update()
    {
        scoreText.text = "Capital: " + score.ToString() + " €";
        if (isholding)
        {
            signalPickUp.SetActive(true);
        }
        else
        {
            signalPickUp.SetActive(false);
        }
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hgh");
        if (collision.tag == "PickUp")
        {
            isholding = true;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "PointObject")
        {           
            if (isholding)
            {
                isholding = false;
                score++;
            }
        }

            if (collision.tag == "Npc")
            {
                if (isholding)
                {
                    isholding = false;
                spawner.Spawn();
                }
                
                score--;               
            }
    }
}
