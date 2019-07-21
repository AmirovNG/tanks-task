using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Tank
{
    private float h, v;
    Rigidbody2D rb2d;
    GunController gun;
    void Start()
    {
        gun = GetComponentInChildren<GunController>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (h != 0 && !isMoving) StartCoroutine(MoveHorizontal(h, rb2d));
        else if (v != 0 && !isMoving) StartCoroutine(MoveVertical(v, rb2d));
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gun.Fire();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
}