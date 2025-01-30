using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponScript : MonoBehaviour
{
    bool gunCooldown;
    public float fireRate;
    public float bulletVelocity;
    public Transform firingPoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && gunCooldown == false)
        {
            StartCoroutine(FireBullet());
        }
    }
   IEnumerator FireBullet()
    {
        gunCooldown = true;
        GameObject instantiatedBullet = Instantiate(bullet);
        instantiatedBullet.transform.position = firingPoint.position;
        instantiatedBullet.transform.rotation = firingPoint.rotation;   
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletVelocity);
        instantiatedBullet.name = "Bullet";

        yield return new WaitForSeconds(fireRate);
        gunCooldown = false;
    }

}
