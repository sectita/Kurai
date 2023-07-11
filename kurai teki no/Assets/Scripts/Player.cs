using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float moveSpeed;

    private Vector2 moveVelocity;
    private Vector2 mousePos;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Movement();
        Rotation();
    }
    void Rotation()
    {
        Vector2 dir = mousePos - myBody.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        myBody.rotation = angle;
    }
    void Movement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;
        myBody.MovePosition(myBody.position + moveVelocity * Time.fixedDeltaTime);
    }
}
