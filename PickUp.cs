using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public bool points;
    public bool life;
    public bool maxLife;

    public PlayerHealthManager playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (life) playerHealth.lives++;
            if (maxLife) playerHealth.currentHealth = playerHealth.maxHealth;
            if (points) playerHealth.points += 3000;

            this.gameObject.SetActive(false);
        }
    }
}
