using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltY : MonoBehaviour
{
    public GameObject effectY;

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    GameObject effect = Instantiate(effectY, transform.position, Quaternion.identity);
    //    Destroy(effect, 1f);
    //    Destroy(gameObject);
    //}
    void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManagerScript.PlaySound("shot");
        enemyHealth enemy = collision.GetComponent<enemyHealth>();
        if(enemy != null)
        {
            enemy.TakeDamage(1);
        }
        Instantiate(effectY, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}