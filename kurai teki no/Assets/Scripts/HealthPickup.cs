using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerHealth;
    public int _healthUp = 2;

    //void Awake()
    //{
    //    playerHealth = GetComponent<PlayerHealth>();
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if(playerHealth)
        {
            SoundManagerScript.PlaySound("pick");
            if (playerHealth.currentHealth < playerHealth.health)
            {
                //playerHealth.HealUp(2);
                playerHealth.currentHealth = playerHealth.currentHealth + _healthUp;
                Destroy(this.gameObject);
            }
        }

    }
}
