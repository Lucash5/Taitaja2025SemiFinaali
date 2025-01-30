using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public Transform player;
    public GameObject[] enemies;

    public Transform corner1;
    public Transform corner2;

    public float spawnRate;

    public float enemy1Odds;
    public float round2enemy1Odds;

    float easierEnemyOdds;

    public float round1Intensity;
    public float round2Intensity;

    public float round1ZombieAmount;
    public float round2ZombieAmount;

    float spawnedZombies;
    float maxZombiesAmount;

    bool spawnCooldown;

    bool intensityCooldown;
    // Start is called before the first frame update
    void Start()
    {
        easierEnemyOdds = enemy1Odds;
        spawnRate = round1Intensity;
        maxZombiesAmount = round1ZombieAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnCooldown && spawnedZombies > maxZombiesAmount)
        {
            StartCoroutine(spawningEnemy());
        }

        if (!intensityCooldown)
        {
            StartCoroutine(IntensifySpawnRate());
        }
    }

    IEnumerator spawningEnemy()
    {
        spawnedZombies += 1;
        spawnCooldown = true;
        GameObject instantiatedEnemy;
        int randomNum = Random.Range(0, 100);
        if (randomNum > easierEnemyOdds)
        {
            instantiatedEnemy = Instantiate(enemies[0]);
        }
        else
        {
            instantiatedEnemy = Instantiate(enemies[1]);
        }

        instantiatedEnemy.transform.position = new Vector2(Random.Range(corner1.position.x, corner2.position.x), Random.Range(corner1.position.y, corner2.position.y));
        instantiatedEnemy.GetComponent<EnemyScript>().player = player;

        yield return new WaitForSeconds(spawnRate);
        spawnCooldown = false;
    }

    public void switchDifficulty()
    {
        easierEnemyOdds = round2enemy1Odds;
        spawnRate = round2Intensity;
        maxZombiesAmount = round2ZombieAmount;
    }

    IEnumerator IntensifySpawnRate()
    {
        intensityCooldown  = true;

        spawnRate += 0.05f;
        yield return new WaitForSeconds(1);
        intensityCooldown = false;
    }
}
