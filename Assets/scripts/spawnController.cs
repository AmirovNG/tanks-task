using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour
{
    GameObject[] tanks;
    GameObject tank;
    [SerializeField]
    bool isPlayer;
    [SerializeField]
    GameObject PlayerTank, EnemyTank;
    void Start()
    {
        if (isPlayer)
        {
            tanks = new GameObject[1] { PlayerTank };
        }
        else
        {
            tanks = new GameObject[1] { EnemyTank };
        }
    }
    public void StartSpawning()
    {
        tank = Instantiate(tanks[Random.Range(0, tanks.Length)], transform.position, transform.rotation);
    }

    public void SpawnNewTank()
    {
        if (tank != null) tank.SetActive(true);
    }
}