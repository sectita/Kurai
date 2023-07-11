using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int health = 3; //max
    public GameObject deathEffect;
    private int currentHealth;

    public GameObject FloatingTextPrefab;
    public GameObject[] _loot;

    void Awake()
    {
        currentHealth = health;
         
    }

    public void TakeDamage(int damage)
    {
        if (FloatingTextPrefab && currentHealth > 0)
        {
            ShowFloatingText();
        }
 
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void ShowFloatingText()
    {
        GameObject ft = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        ft.GetComponent<TextMesh>().text = currentHealth.ToString();

    }

    public void Die()
    {
        SoundManagerScript.PlaySound("put");
        
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //LootDrop
        SpawnLoot();
        
    }
    public void SpawnLoot()
    {

        GameObject lt = Instantiate(_loot[Random.Range(0, _loot.Length)], transform.position, Quaternion.identity);
    }

    public void MultipleEnemys()
    {
        for(int i = 0; i <= 2; i++)
        {
            GameObject mse = Instantiate(_loot[Random.Range(0, _loot.Length)], transform.position, Quaternion.identity);
            
        }return;
    }

}
