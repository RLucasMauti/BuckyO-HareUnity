using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{


    public float currentHealth;
    public float maxHealth;
    public int lives;
    public int points;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 10.0f;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
