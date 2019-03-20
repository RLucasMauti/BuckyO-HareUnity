using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTurret : UnityEngine.MonoBehaviour
{
    public GameObject bullet;
    public Transform firepoint;
    public float range = 10.0f;
    private bool readyToFire = true;
    private float timer = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hitinfo = Physics2D.Raycast(firepoint.transform.position, firepoint.transform.right, range);
        if (hitinfo)
        {
            PlayerHealthManager player = hitinfo.transform.GetComponent<PlayerHealthManager>();
            if (player != null)
            {
                Shoot();
            }
        }

        if (!readyToFire)
        {
            timer -= Time.deltaTime;
        }
       
        if (timer <= 0.0f)
        {
            readyToFire = true;
            timer = 1.0f;
        }
    }

    private void Shoot()
    {
        if (readyToFire)
        {
            Debug.Log("Tried to fire");
            Instantiate(bullet, firepoint.transform.position, transform.rotation);
            readyToFire = false;
        }
    }
}
