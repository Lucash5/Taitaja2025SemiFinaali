using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDifficultyScript : MonoBehaviour
{
    public GameObject wallToCollapse;
    public EnemySpawnScript enemySpawnScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            wallToCollapse.SetActive(true);
            enemySpawnScript.switchDifficulty();
        }
    }
}
