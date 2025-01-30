using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject[] enemies;

    public Transform corner1;
    public Transform corner2;

    public float spawnRate;

    public float[] round1Odds;
    public float[] round2Odds;
    public float[] round3Odds;

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

        int randomNum = Random.Range(0, 100);
        if (true)
        {

        }


        yield return new WaitForSeconds(spawnRate);
    }
}
