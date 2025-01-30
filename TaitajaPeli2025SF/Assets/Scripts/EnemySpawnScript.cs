using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;

    public Transform corner1;
    public Transform corner2;

    public float spawnRate;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawningEnemy()
    {

        yield return new WaitForSeconds(spawnRate);
    }
}
