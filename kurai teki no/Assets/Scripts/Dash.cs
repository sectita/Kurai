using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    #region
    //    //private Animator myAnim;
    //    private bool dash = false;
    //    private float dashTimer = 0;
    //    private float dashCd = 0.3f;
    //    public Collider2D[] Coll;
    //    void Start()
    //    {
    //       // myAnim = gameObject.GetComponent<Animator>();
    //    }
    //    void Update()
    //    {
    //        if (Input.GetKey(KeyCode.Space) && !dash)
    //        {
    //            dash = true;
    //            dashTimer = dashCd;
    //           // myAnim.SetBool("Dash", dash);
    //            foreach (Collider2D coll in Coll)
    //            {
    //                if (coll.gameObject.tag == ("Enemy"))
    //                {
    //                    coll.enabled = false;
    //                }
    //            }
    //        }
    //        if (dash)
    //        {
    //            if (dashTimer > 0)
    //            {
    //                dashTimer -= Time.deltaTime;
    //            }
    //            else
    //            {
    //                dash = false;
    //               // myAnim.SetBool("Dash", false);
    //            }
    //        }
    //    }
    #endregion
    #region
    public Rigidbody2D rb;
    float dashSpeed = 200000;
    bool dash = true;
    float dashCooldown = 100f;

    public GameObject dashEffect;
    //public Collider2D[] Coll;
    private void FixedUpdate()
    {
        if (dashCooldown == 0)
        {
            dash = true;
        }
        else
        {
            dashCooldown--;
        }
        rb.velocity = Vector2.zero;
        if (Input.GetKey(KeyCode.Space) && dash)
        {
            SoundManagerScript.PlaySound("power");
            //foreach (Collider2D coll in Coll)
            //{
            //    if (coll.gameObject.tag == ("Enemy"))
            //    {
            //        enemyHealth enemy = GetComponent<enemyHealth>();
            //        enemy.TakeDamage(1);
            //        coll.enabled = true;
            //    }
            //}
            GameObject DS = Instantiate(dashEffect, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            Destroy(DS, 1f);
            Vector2 mouseDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2)).normalized;
            rb.AddForce(mouseDirection * dashSpeed * Time.fixedDeltaTime);
            dash = false;
            dashCooldown = 100f;

        }
    }
    #endregion
}