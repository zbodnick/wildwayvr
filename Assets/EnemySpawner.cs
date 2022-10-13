using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour {

    private Transform Player;
    public int NumberOfEnemiesToSpawn = 5;
    public float SpawnDelay = 1f;
    public List<NewEnemyObject> EnemyPrefabs = new List<NewEnemyObject>();
    public SpawnMethod EnemySpawnMethod = SpawnMethod.RoundRobin;

    private NavMeshTriangulation Triangulation;
    private Dictionary<int, ObjectPool> EnemyObjectPools = new Dictionary<int, ObjectPool>();

    private void Awake()
    {

        Player = GameObject.Find("XR Rig").transform;

        for (int i = 0; i < EnemyPrefabs.Count; i++)
        {
            EnemyObjectPools.Add(i, ObjectPool.CreateInstance(EnemyPrefabs[i], NumberOfEnemiesToSpawn));
        }
    }

    private void Start()
    {
        Triangulation = NavMesh.CalculateTriangulation();

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds Wait = new WaitForSeconds(SpawnDelay);

        int SpawnedEnemies = 0;

        while (SpawnedEnemies < NumberOfEnemiesToSpawn)
        {
            if (EnemySpawnMethod == SpawnMethod.RoundRobin)
            {
                SpawnRoundRobinEnemy(SpawnedEnemies);
            }
            else if (EnemySpawnMethod == SpawnMethod.Random)
            {
                SpawnRandomEnemy();
            }

            SpawnedEnemies++;

            yield return Wait;
        }
    }

    private void SpawnRoundRobinEnemy(int SpawnedEnemies) {
        int SpawnIndex = SpawnedEnemies % EnemyPrefabs.Count;

        SpawnEnemy(SpawnIndex);
    }

    private void SpawnRandomEnemy() {
        SpawnEnemy(Random.Range(0, EnemyPrefabs.Count));
    }

    // Spawns random enemy
    private void SpawnEnemy(int SpawnIndex) {
        PoolableObject poolableObject = EnemyObjectPools[SpawnIndex].GetObject();

        if (poolableObject != null) {
            EnemyObject enemy = poolableObject.GetComponent<EnemyObject>();

            int VertexIndex = Random.Range(0, Triangulation.vertices.Length);

            NavMeshHit Hit;
            if (NavMesh.SamplePosition(Triangulation.vertices[VertexIndex], out Hit, 2f, -1)) {
                enemy.Agent.Warp(Hit.position);
                // enemy needs to get enabled and start chasing now.
                enemy.Agent.enabled = true;
                enemy.Controller.ChasePlayer();
            } else {
                Debug.LogError($"Unable to place Agent on NavMesh. Tried to use {Triangulation.vertices[VertexIndex]}");
            }
        } else {
            Debug.LogError($"Unable to get enemy of type {SpawnIndex} from object pool.");
        }
    }


    public enum SpawnMethod {
        RoundRobin,
        Random
        // Add more spawn methods
    }
}