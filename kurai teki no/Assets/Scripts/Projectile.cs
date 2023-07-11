using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed;
    public GameObject effectO;
    
    private Rigidbody2D rb2d_Projectile;
    private GameObject target;


    void Start()
    {
        
        rb2d_Projectile = this.gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        ProjectileMove();

    }

    void ProjectileMove()
    {
        SoundManagerScript.PlaySound("shot");
        Vector2 movedir = (target.transform.position - transform.position).normalized * ProjectileSpeed;
        rb2d_Projectile.velocity = new Vector2(movedir.x, movedir.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManagerScript.PlaySound("hit");
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth ph = target.GetComponent<PlayerHealth>();
            //PlayerHealth ph = collision.GetComponent<PlayerHealth>(); // 'Collision2D' does not contain a definition for 'GetComponent' and no accessible extension method 'GetComponent' accepting a first argument of type 'Collision2D' could be found.

            if (ph != null)
            {
                
                ph.TakeDamage(1);
            }
        }
        GameObject ef = Instantiate(effectO, transform.position, transform.rotation);
        Destroy(ef, 0.5f);
        Destroy(this.gameObject);
    }
    //Ontrigger
    #region
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        PlayerHealth ph = collision.GetComponent<PlayerHealth>();
    //        if(ph != null)
    //        {
    //            ph.TakeDamage(1);
    //        } 
    //    }
    //    GameObject ef = Instantiate(effectO, transform.position, transform.rotation);
    //    Destroy(ef, 0.5f);
    //    Destroy(this.gameObject);
    //}
    #endregion
}
