using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    GameObject[] SpawnPoints;
    void Start()
    {   
    }

    private IEnumerator Respawn(GameObject tank)
    {
            yield return new WaitForSeconds(1);
                GameObject randomSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
                tank.transform.position = randomSpawnPoint.transform.position;
                tank.SetActive(true);
    }
    public void AddTankToSpawnQueue(GameObject tank)
    {
        StartCoroutine(Respawn(tank));
    }
}