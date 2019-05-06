using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the rate at which enemys 
/// spawn and which spawner is used
/// </summary>
public class EnemySpawnerManager : MonoBehaviour
{
    // Public variables
    public float spawnTimer = 3f;

    // Private variables
    GameObject player;
    PlayerHealth playerHealth;
    GameObject[] enemySpawnPoints;
    EnemySpawner spawner;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemySpawnPoints = GameObject.FindGameObjectsWithTag("Spawner");
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
    }

    // Select a EnemySpawner then spawn an enemy
    void SpawnEnemy() {
        if (playerHealth.currentHealth <= 0)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0,enemySpawnPoints.Length);
        spawner = enemySpawnPoints[spawnPointIndex].GetComponent<EnemySpawner>();
        spawner.CreateEnemy();
    }
    /*
    The functions SpawnEnemy() is modified from the function Spawn() from the source below.

    Title : Survival Shooter tutorial: Spawning Enemies
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/survival-shooter/more-enemies?playlist=17144
     */
}
