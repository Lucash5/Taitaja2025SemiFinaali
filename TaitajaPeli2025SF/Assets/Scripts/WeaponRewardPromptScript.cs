using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponRewardPromptScript : MonoBehaviour
{
    public GameObject wall;
    public TMP_Text notification;

    public TMP_Text killCount;
    public GameObject rewardPrompt;
    public int killedZombies = 0;

    public Sprite[] weapons;

    bool chosen = false;

    SpriteRenderer playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (killedZombies >= 100 && rewardPrompt.activeSelf == false && chosen == false)
        {
            rewardPrompt.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.Alpha1) && chosen == false)
        {
            chosen = true;  
            rewardPrompt.SetActive(false);
            playerSprite.sprite = weapons[0];
            gameObject.GetComponent<PlayerWeaponScript>().SwitchWeapons("m249");
            wall.SetActive(false);
            StartCoroutine(ShowNotification());
        }
        else if(Input.GetKey(KeyCode.Alpha2) && chosen == false)
        {
            chosen = true;
            rewardPrompt.SetActive(false);
            playerSprite.sprite = weapons[1];
            gameObject.GetComponent<PlayerWeaponScript>().SwitchWeapons("shotgun");
            wall.SetActive(false);
            StartCoroutine(ShowNotification());
        }
    }

    public void ZombieKilled()
    {
        killedZombies += 1;
        killCount.text = killedZombies.ToString() + "/100";
    }

    public void ResetCount()
    {

    }

    IEnumerator ShowNotification()
    {
        notification.enabled = true;
        yield return new WaitForSeconds(8);
        notification.enabled = false;
    }
}
