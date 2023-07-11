using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject boltY;
    public GameObject bomb;
    public float bulletSpeed;

    private float TimeShot;
    public float StartTime;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && AmmoText.ammoAmount > 0)
        {
            SoundManagerScript.PlaySound("shot");
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SoundManagerScript.PlaySound("plant");
            Debug.Log("G Pressed: ");
            Bomb();
        }
    }
    void Shoot()
    {


        if (TimeShot <= 0)
        {
            
            GameObject bullet = Instantiate(boltY, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
            TimeShot = StartTime = 0;
            AmmoText.ammoAmount -= 1;
            return;
        }
        else
        TimeShot -= Time.deltaTime;
    }

    void Bomb()
    {
        Instantiate(bomb, transform.position, transform.rotation);
    }
}
