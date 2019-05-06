using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This class handled the enemys movment and rotation based on the position and proximity to the player.
/// </summary>
public class EnemyMovement : MonoBehaviour
{
    //Public variables
    public float timerIntervals = 2.0f;
    public float normalSpeed = 6.0f;
    public float sidewaysSpeed = 6.0f;
    public float backwardsSpeed = 6.0f;

    //Private variables    
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    
    bool isPlayerWithinRange;
    bool isPlayerTooClose;
    EnemyPlayerDetector playerMovementRangeCode;
    EnemyPlayerDetector playerTooCloseCode;

    NavMeshAgent nav;
    Vector3 destination;
    float timeLeft;
    int leftOrRight = 50;
    bool direction;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        //Get the player range detectors from the children. They are this big cos they use the same behavior so GetComponentInChildren can't guarantee getting the right instance of the code for 
        //the behavior desiered.
        GameObject playerMovementRange = transform.Find("PlayerMovementRange").gameObject;
        if (playerMovementRange != null)
        {
            //Debug.Log("playerMovementRange was found");
            playerMovementRangeCode = playerMovementRange.GetComponent<EnemyPlayerDetector>();
            if (playerMovementRangeCode != null)
            {
                //Debug.Log("playerMovementRangeCode obtained");
            }
        }
        GameObject playerTooClose = transform.Find("PlayerTooCloseRange").gameObject;
        if (playerTooClose != null)
        {
            //Debug.Log("playerTooClose was found");
            playerTooCloseCode = playerTooClose.GetComponent<EnemyPlayerDetector>();
            if (playerTooCloseCode != null)
            {
                //Debug.Log("playerTooCloseCode obtained");
            }
        }

        //Get key components from the player and enemy.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();

        //Setup the timer and direction.
        timeLeft = timerIntervals;
        direction = randomBoolean();
    }

    /// <summary>
    /// Update is called every frame.
    /// </summary>
    void Update()
    {
        Timer();
        GetPlayerRange();
        SetSpeed();
        Rotation();
        Move();
    }

    /// <summary>
    /// Uses two different colliders to get the current range from the player.
    /// </summary>
    void GetPlayerRange()
    {
        isPlayerWithinRange = playerMovementRangeCode.getPlayerRange();
        isPlayerTooClose = playerTooCloseCode.getPlayerRange();
    }

    void SetSpeed()
    {
        if ((isPlayerTooClose == true) && (nav.speed != backwardsSpeed))
        {
            nav.speed = backwardsSpeed;
            Debug.Log("Set speed for backwards");
        }
        else if ((isPlayerTooClose != true) && (isPlayerWithinRange == true) && (nav.speed != sidewaysSpeed))
        {
            nav.speed = sidewaysSpeed;
            Debug.Log("Set speed for sideways");
        }
        else if ((isPlayerTooClose != true) && (isPlayerWithinRange != true) && (nav.speed != normalSpeed))
        {
            nav.speed = normalSpeed;
            Debug.Log("Set speed for forwards");
        }
    }

    /// <summary>
    /// Point the enemy to face where the player is.
    /// </summary>
    void Rotation()
    {
        Vector3 enemyToPlayer = player.position - transform.position;
        enemyToPlayer.y = 0f;
        enemyToPlayer.Normalize();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(enemyToPlayer), 12 * Time.deltaTime);
    }

    /// <summary>
    /// Move based on the distance from the player.
    /// </summary>
    void Move()
    {
        if (playerHealth.currentHealth > 0 && enemyHealth.currentHealth > 0)
        {
            if (isPlayerTooClose == true)
            {
                //Move away from the player.
                destination = transform.position - transform.forward * 6;
            }
            else if (isPlayerWithinRange == true)
            {
                //Move to the side.
                if (direction == false)
                {
                    //Move right.
                    destination = gameObject.transform.position + gameObject.transform.right * 6;
                }
                else if (direction == true)
                {
                    //Move left.
                    destination = gameObject.transform.position - gameObject.transform.right * 6;
                }
            }
            else
            {
                //Move towards the player.
                destination = player.position;
            }
            nav.SetDestination(destination);
        }
        else
        {
            //Stop enemy from moving.
            nav.enabled = false;
        }
    }

    /// <summary>
    /// Randomly choose a Boolean based on if a number is above or below a half way point + increases the chance of picking the other option next time.
    /// </summary>
    /// <returns> A Boolean used to decied between left of right.</returns>
    bool randomBoolean()
    {
        int directionNumber = Random.Range(1, 100);
        if (directionNumber > leftOrRight)
        { 
            //Left.
            leftOrRight += 1;
            //Debug.Log("This enemy will move left");
            return true;
        }
        else if (directionNumber < leftOrRight)
        {
            //Right.
            leftOrRight -= 1;
            //Debug.Log("This enemy will move right");
            return false;
        }
        else
        {
            //If the random number is the same as the leftOrRight number. Called wtf cos the chances are 1/100.
            bool wtf = (Random.Range(0, 2) == 0);
            //Debug.Log("This enemy couldn't decide");
            return wtf;
        }
    }

    /// <summary>
    /// A simple timer. This is used to impliment movement behavior that operate at different time intervals than update.
    /// </summary>
    void Timer()
    {
        if(timeLeft <= 0)
        {
            timeLeft = timerIntervals;
            //Stick stuff you want on a timer here

            direction = randomBoolean();
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }

    /*
    The function Awake() is modified from a function of the same name from the source below.
    The function Move() is loosly based on the function Update() from the source below.

    Title : Tutorials: Survival Shooter tutorial: Creating Enemy #1
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/survival-shooter/enemy-one?playlist=17144

    ~~~

    The function Rotation() is modified from the function Turning() from the source below.

    Title : Tutorials: Survival Shooter tutorial: Player Character
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/survival-shooter/player-character?playlist=17144
     */
}
