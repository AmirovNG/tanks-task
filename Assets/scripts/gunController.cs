using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private int i = 0;
    [SerializeField]
    GameObject[] projectiles;
    GameObject[] canonBall;
    ProjectileController canon;
    [SerializeField]
    private int speed;

    void Start()
    {
        foreach (GameObject projectile in projectiles)
        {
            canon = projectile.GetComponent<ProjectileController>();
            canon.speed = speed;
        }
    }
    public void Fire()
    {   if (i >= projectiles.Length)
        {
            i = 0;
        }

        if (projectiles[i].activeSelf == false)
        {
            projectiles[i].transform.position = transform.position;
            projectiles[i].transform.rotation = transform.rotation;
            projectiles[i].SetActive(true);
        }
        i++;
        }


    private void OnDestroy()
    {
        if (projectiles[i] != null) canon.DestroyProjectile();
    }
}