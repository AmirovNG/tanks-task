﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    GameObject canonBall, fire;
    projectileController canon;
    [SerializeField]
    int speed;
    void Start()
    {
        canonBall = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        canon = canonBall.GetComponent<projectileController>();
        canon.speed = speed;
        //fire = transform.GetChild(0).gameObject;
    }
    public void Fire()
    {
        if (canonBall.activeSelf == false)
        {
            canonBall.transform.position = transform.position;
            canonBall.transform.rotation = transform.rotation;
            canonBall.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        if (canonBall != null) canon.DestroyProjectile();
    }
}