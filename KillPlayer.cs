using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    public Transform spawnpoint;
    public Transform player;
    public PlayerHealthManager playerHealth;
    public PlayerController playerController;
    
    public float deathTime;
    public float waitAfterDeath;
    private bool timerStart;
    public float damageToGive;
    private bool death;

    private void Start()
    {
        playerHealth = player.gameObject.GetComponent<PlayerHealthManager>();
        playerController = player.gameObject.GetComponent<PlayerController>();
        waitAfterDeath = 0;
        timerStart = false;
        death = false;
    }

    private void Update()
    {
        if (playerHealth.currentHealth < 0)
        {
            if (!death)
            { 
                PlayerDeath(deathTime);
            }
        }

        if (waitAfterDeath < 0.0f && timerStart)
        {
            RespawnPlayer();
            timerStart = false;
            waitAfterDeath = 0;
            playerHealth.currentHealth = playerHealth.maxHealth;
        }

        if (timerStart)
        {
            waitAfterDeath -= Time.deltaTime;
        }

    }

    public void PlayerDeath(float time)
    {
        player.GetComponent<Animator>().SetBool("IsDead", true);
        waitAfterDeath = time;
        timerStart = true;
        playerController.canWalk = false;
        death = true;
    }

    private void RespawnPlayer()
    {
        player.position = spawnpoint.position;
        player.GetComponent<Animator>().SetBool("IsDead", false);
        playerController.canWalk = true;
        playerHealth.currentHealth = playerHealth.maxHealth;
        death = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.name == "Player")
        {
            playerHealth.currentHealth -= damageToGive;
            Debug.Log(damageToGive + " Damage Dealt");
        }
    }
}
