using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Bomb instance;
    public float explosionRange;
    public float timeToDetonate;
    public float timeToDestroy;

    public GameObject bombEffect;
    public LayerMask WhatToDestroy;//Tile
    float actualTimeToDestroy;

    // Start is called before the first frame update
    void Start()
    {

        instance = this;
        actualTimeToDestroy = timeToDetonate + timeToDestroy;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToDetonate <= 0)
        {
            Detonat();
        }
        if(timeToDetonate > 0)
        {
            timeToDetonate -= Time.deltaTime;
        }
        if(actualTimeToDestroy <= 0)
        {
            SoundManagerScript.PlaySound("explosion");
            Instantiate(bombEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(actualTimeToDestroy > 0)
        {
            actualTimeToDestroy -= Time.deltaTime;
        }
    }
    void Detonat()
    {
        Collider2D[] objectsToDestroy = Physics2D.OverlapCircleAll(transform.position, explosionRange, WhatToDestroy);//position,toRange,whatTo
        for(int i = 0; i < objectsToDestroy.Length; i++)
        {
            objectsToDestroy[i].GetComponent<TileDetection>().Destroy();
            
            //objectsToDestroy[i].GetComponent<PlayerHealth>().TakeDamage(0);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
