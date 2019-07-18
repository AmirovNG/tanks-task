using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : Tank
{
    float h, v;
    Rigidbody2D rb2d;
    gunController gun;
    void Start()
    {
        gun = GetComponentInChildren<gunController>();
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
}