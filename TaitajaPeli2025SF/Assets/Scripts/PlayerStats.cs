using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float Health;
    public float bulletDamageVulnerability;
    public TMP_Text health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        health.text = Health.ToString();  
        if (Health <= 0)
        {

            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Boolet")
        {
            TakeDamage(bulletDamageVulnerability);
            Destroy(collision.gameObject);
        }
    }
}
