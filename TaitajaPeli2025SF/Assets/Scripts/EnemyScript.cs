using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float bulletDamageVulnerability;

    public bool soldierZombie;
    public float keepDistance;
    bool attackCooldown = false;


    public float attackCooldownDuration;
    public float health;

    public float attackDamage;
    public float movementSpeed;
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
        Vector2 direction = player.position - transform.position;

        float XYSum = Mathf.Abs( direction.x) + Mathf.Abs(direction.y);
        float XInfluence = direction.x / XYSum; 
        float YInfluence = direction.y / XYSum; 

        rb.velocity = new Vector2(XInfluence * movementSpeed, YInfluence * movementSpeed);

        if (soldierZombie)
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && !attackCooldown)
        {
            attackCooldown = true;
            StartCoroutine(inflictDamage());
        }
    }

    IEnumerator inflictDamage()
    {

        player.gameObject.GetComponent<PlayerStats>().TakeDamage(attackDamage);
        yield return new WaitForSeconds(attackCooldownDuration);
        attackCooldown = false;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet")
        {
        Debug.Log("TST");
            takeDamage(bulletDamageVulnerability);
            Destroy(collision.gameObject);
        }

    }
}
