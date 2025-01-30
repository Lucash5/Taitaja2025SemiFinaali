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

    AudioSource AS;
    public AudioClip AC;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponentInChildren<AudioSource>();
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
        AS.PlayOneShot(AC);
        gunCooldown = true;
        GameObject instantiatedBullet = Instantiate(bullet);
        instantiatedBullet.transform.position = firingPoint.position;
        instantiatedBullet.transform.rotation = firingPoint.rotation;   
        instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletVelocity);
        instantiatedBullet.name = "Bullet";

        StartCoroutine(DestroyBullet(instantiatedBullet) );

        yield return new WaitForSeconds(fireRate);
        gunCooldown = false;
    }

    public void SwitchWeapons(string weapon)
    {
        if(weapon == "m249")
        {
            fireRate /= 3;
            bulletVelocity /= 1.5f;
        }

        if (weapon == "shotgun")
        {
            fireRate /= 4;
            bulletVelocity *= 1.2f;
        }
    }

    IEnumerator DestroyBullet(GameObject boolet)
    {
        yield return new WaitForSeconds(8);
        Destroy(boolet);
    }

}
