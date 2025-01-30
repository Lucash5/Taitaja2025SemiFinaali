using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedZombieWeaponScript : MonoBehaviour
{
    public float keepDistance;

    public float bulletDamageVulnerability;
    public float movementSpeed;
    public float health;

    public Transform firingPoint;
    public Transform player;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pointToward = transform.position - player.position;
        transform.right = pointToward * -1;

        if (Vector2.Distance(transform.position, player.position) > keepDistance)
        {

        Vector2 direction = player.position - transform.position;

        float XYSum = Mathf.Abs(direction.x) + Mathf.Abs(direction.y);
        float XInfluence = direction.x / XYSum;
        float YInfluence = direction.y / XYSum;

        rb.velocity = new Vector2(XInfluence * movementSpeed, YInfluence * movementSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet")
        {
      
            takeDamage(bulletDamageVulnerability);
            Destroy(collision.gameObject);
        }

    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
