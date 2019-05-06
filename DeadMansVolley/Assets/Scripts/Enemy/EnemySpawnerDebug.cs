using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerDebug : MonoBehaviour
{
    //Public variables
    public Transform fireTransform;
    public float spawnTimer = 3f;

    //Private variables
    GameObject levelManager;
    EnemyManager enemyManager;
    int maxNumberOfEnemys = 0;
    int currentNumberOfEnemys = 0;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        enemyManager = levelManager.GetComponent<EnemyManager>();
        maxNumberOfEnemys = enemyManager.maxNumberOfEnemys;
        //InvokeRepeating("CreateEnemy", spawnTimer, spawnTimer);   Disabled so that the manager can handle the spawning of enemys
    }


    /// <summary>
    /// Update is called every frame.
    /// </summary>
    void Update()
    {
        currentNumberOfEnemys = enemyManager.GetCurrentNumberOfEnemys();
        if (Input.GetButtonUp("Fire4"))   //This should be disabled if for the primary game levels.
        {
            CreateEnemy();
        }
    }

    /// <summary>
    /// Creates an instance of a enemy object.
    /// </summary>
    public void CreateEnemy()
    {
        if (currentNumberOfEnemys < maxNumberOfEnemys)
        {
            Rigidbody newBallInstance = enemyManager.CreateNewEnemyType1(fireTransform.position, fireTransform.rotation);
        }
    }

    /*
    The functions Start() is modified from the function of the same name from the source below.

    Title : Survival Shooter tutorial: Spawning Enemies
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/survival-shooter/more-enemies?playlist=17144

    ~~~

    The function CreateBall() is modified from the function Fire() from the source below.
 
    Title : Tutorials: Tanks tutorial: Firing Shells
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/tanks-tutorial/firing-shells?playlist=20081
     */
}
