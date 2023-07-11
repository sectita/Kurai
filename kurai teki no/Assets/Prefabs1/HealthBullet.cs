using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBullet : MonoBehaviour
{
    PlayerHealth playerHealth;
    public int _healthUp = 1;

    public float HealthBulletSpeed;
    //public GameObject effectO;

    private Rigidbody2D rb2d_HealthBullet;
    private GameObject target;
    

    void Start()
    {
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        rb2d_HealthBullet = this.gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        ProjectileMove();

    }

    void ProjectileMove()
    {
        SoundManagerScript.PlaySound("shot");
        Vector2 movedir = (target.transform.position - transform.position).normalized * HealthBulletSpeed;
        rb2d_HealthBullet.velocity = new Vector2(movedir.x, movedir.y);
        
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (playerHealth)
    //    {
    //        SoundManagerScript.PlaySound("pick");
    //        if (playerHealth.currentHealth < playerHealth.health)
    //        {
    //            //playerHealth.HealUp(2);
    //            playerHealth.currentHealth = playerHealth.currentHealth + _healthUp;
    //            Destroy(this.gameObject);
    //        }
    //    }
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            SoundManagerScript.PlaySound("pick");
            if (playerHealth.currentHealth < playerHealth.health)
            {
                //playerHealth.HealUp(2);
                playerHealth.currentHealth = playerHealth.currentHealth + _healthUp;
                Destroy(this.gameObject, 0.3f);
            }
        }

    }
}
