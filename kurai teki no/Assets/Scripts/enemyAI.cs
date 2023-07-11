using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public float speed;
    public float stopDistance;
    public float retreatDistance;

    public Transform Player;
    public Transform fp;
    public GameObject projectile;


    private float timeBtwShots;
    public float startTimeBtwShots;
    

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {




        shoot();
        //moveAI
        if (Vector2.Distance(transform.position, Player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            

        }
        else if(Vector2.Distance(transform.position, Player.position) > stopDistance && Vector2.Distance(transform.position, Player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            
        }else if(Vector2.Distance(transform.position, Player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, -speed * Time.deltaTime);
        }
    }
    void shoot()
    {
        if (timeBtwShots <= 0)
        {
            GameObject pj = Instantiate(projectile, fp.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
