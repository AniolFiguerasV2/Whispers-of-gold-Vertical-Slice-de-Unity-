using UnityEngine;
using System.Collections.Generic;
public class MonsterSpawn : MonoBehaviour
{
    public List<GameObject> monsters;
    public Transform[] spawnPoints;

    public float maxSpawnTime = 5f;

    private bool[] spawnPointOccupied;
    private bool isSpawned = false;

    public DayCicle dayCicle;

    private void Start()
    {
        spawnPointOccupied = new bool[spawnPoints.Length];
        for (int i = 0; i < spawnPointOccupied.Length; i++)
        {
            spawnPointOccupied[i] = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MonsterSpawners") && !isSpawned)
        {
            SpawnMonsters();
            isSpawned = true;
        }
    }

    private void SpawnMonsters()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (!spawnPointOccupied[i] && monsters.Count > 0)
            {
                if (dayCicle.cycleTime >= 3) {
                    int rand = Random.Range(0, monsters.Count);
                    GameObject monster = Instantiate(monsters[rand], spawnPoints[i].position, spawnPoints[i].rotation);

                    spawnPointOccupied[i] = true;
                    Destroy(monster, maxSpawnTime);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MonsterSpawners"))
        {
            isSpawned = false;
        }
    }
}