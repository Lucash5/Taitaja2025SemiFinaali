using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpScript : MonoBehaviour
{
    public float speedUpTime;
    public float speedUpMultiplier;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(collision.gameObject.GetComponent<PlayerMovementScript>().TemporarySpeedUp(speedUpTime, speedUpMultiplier));
            Destroy(gameObject);
        }
    }
}
