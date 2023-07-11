using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    //LookDirection
    private Rigidbody2D rb2d;
    public Vector2 movement;
    public float speed;

    //MoveDirection
    public float stopDistance;
    public float retreatDistance;

    private Transform Player;
    public Transform fp;
    public GameObject projectile;


    private float timeBtwShots;
    public float startTimeBtwShots;




    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2d = this.GetComponent<Rigidbody2D>();
        timeBtwShots = startTimeBtwShots;

    }


    void Update()
    {
        lookDirection();
        MoveDirection();
        EnemyShoot();
    }

    void lookDirection()
    {
        Vector3 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90f;
        rb2d.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    void MoveDirection()
    {
        //moveAI
        if (Vector2.Distance(transform.position, Player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);


        }
        else if (Vector2.Distance(transform.position, Player.position) > stopDistance && Vector2.Distance(transform.position, Player.position) > retreatDistance)
        {
            transform.position = this.transform.position;

        }
        else if (Vector2.Distance(transform.position, Player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, -speed * Time.deltaTime);
        }
    }

    void EnemyShoot()
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
