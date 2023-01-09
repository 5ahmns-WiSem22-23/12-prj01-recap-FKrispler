using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHolder : MonoBehaviour
{
    private bool isholding;

    private void Start()
    {
        isholding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PickUp")
        {
            isholding = true;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "PointObject")
        {
            isholding = false;
        }
    }
}
