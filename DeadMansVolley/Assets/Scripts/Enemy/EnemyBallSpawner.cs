using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class spawns a ball in front of the enemy after X seconds and shoots it towards the player.
/// </summary>
public class EnemyBallSpawner : MonoBehaviour
{
    //Public variables
    public Transform fireTransform;
    public float ballSpeed;
    
    //Private variables
    GameObject levelManager;
    BallManager ballManager;
    int maxNumberOfBalls = 0;
    int currentNumberOfBalls;

    Transform player;
    PlayerHealth playerHealth;

    EnemyPlayerDetector PlayerFiringRangeCode;
    bool isPlayerWithinRange;
    float spawnTimer;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        //Get the managers requiered to spawn balls.
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        ballManager = levelManager.GetComponent<BallManager>();
        maxNumberOfBalls = ballManager.maxNumberOfBalls;

        //Get the players health.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();

        //Get the player range detector from the child. It is this big cos is uses the same behavior as EnemyMovement so GetComponentInChildren can't guarantee getting the right instance of the code for 
        //the behavior desiered.
        GameObject PlayerFiringRange = transform.Find("PlayerFiringRange").gameObject;
        if (PlayerFiringRange != null)
        {
            Debug.Log("PlayerFiringRange was found");
            PlayerFiringRangeCode = PlayerFiringRange.GetComponent<EnemyPlayerDetector>();
            if (PlayerFiringRangeCode != null)
            {
                Debug.Log("PlayerFiringRangeCode obtained");
            }
        }

        //Set the timer and start invokeing the method to spawn balls.
        spawnTimer = Random.Range(20,40)/10;
        InvokeRepeating("CreateBall", spawnTimer, spawnTimer);
    }

    /// <summary>
    /// Update is called every frame.
    /// </summary>
    void Update()
    {
        currentNumberOfBalls = ballManager.GetCurrentNumberOfBalls();
        GetPlayerRange();
    }

    /// <summary>
    /// Uses a collider to get the current range from the player.
    /// </summary>
    void GetPlayerRange()
    {
        isPlayerWithinRange = PlayerFiringRangeCode.getPlayerRange();
    }

    /// <summary>
    /// Creates an instance of a ball object and gives it an initial velocity
    /// </summary>
    void CreateBall()
    {
        if ((currentNumberOfBalls < maxNumberOfBalls) && (isPlayerWithinRange == true) && (playerHealth.currentHealth > 0))
        {
            Rigidbody newBallInstance = ballManager.CreateNewBall(fireTransform.position, fireTransform.rotation);
            newBallInstance.velocity = ballSpeed * fireTransform.forward;
            BallStates ballStateInstance = newBallInstance.gameObject.GetComponent<BallStates>();
            ballStateInstance.ChangeBallState(2);
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
