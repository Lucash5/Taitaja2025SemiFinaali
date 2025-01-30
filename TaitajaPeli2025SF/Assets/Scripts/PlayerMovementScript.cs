using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    float originalSpeed;
    public float playerMovementSpeed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = playerMovementSpeed;
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerMovementSpeed, Input.GetAxis("Vertical") * playerMovementSpeed);

        Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.right = direction * -1;
    }

    public IEnumerator TemporarySpeedUp(float time, float multiplier)
    {
        playerMovementSpeed *= playerMovementSpeed * multiplier;
        yield return new WaitForSeconds(time);
        playerMovementSpeed = originalSpeed;
    }
}
