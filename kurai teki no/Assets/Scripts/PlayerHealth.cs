using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerHealth : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;
    float lerpSpeed;

    public int health = 3; //max health
    public float currentHealth;
    public GameObject PlayerdeathEffect;
    public Button _retry;
    public Button _quit;
    //private bool ui;

    void Start()
    {
        _retry.gameObject.SetActive(false);
        _quit.gameObject.SetActive(false);
        //ui = false;
    }

    void Awake()
    {
        currentHealth = health;
    }

    void Update()
    {
        healthText.text = "Health:" + currentHealth + "%";
        healthText.text = currentHealth.ToString();

        if (currentHealth > health) //equalize notMoreThan max health 
            currentHealth = health;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFill();
        ColorBarFill();
        //HealUp();
    }

    void HealthBarFill()
    {
        //healthBar.fillAmount = currentHealth / health; // without lerpspeed float
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / health, lerpSpeed);
    }

    void ColorBarFill()
    {
        Color healthColor = Color.Lerp(Color.green, Color.red, (currentHealth / health));
    }

    public void TakeDamage(int damage) //Damage
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        { 

            Die();
            
        }
    }

    public void HealUp(int healAmount)
    {
        if (currentHealth < health)
            health += healAmount;
    }

    void Die()
    {
        Instantiate(PlayerdeathEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        uiFun();
    }

    void uiFun()
    {

        _retry.gameObject.SetActive(true);
        _quit.gameObject.SetActive(true);

    }
}
