using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles all possiable outcomes if this object collides with almost any other object.
/// </summary>
public class BallCollisions : MonoBehaviour
{
    // Public variables
    public int attackDamage = 1;

    // Private variables
    PlayerHealth playerHealth;
    BatSwing playerBatSwing;
    EnemyHealth enemyHealth;
    bool isPlayerInRange;
    bool isEnemyInRange;

    GameObject levelManager;
    BallManager ballManager;
    Rigidbody ballRigidbody;
    Collider ballCollider;
    BallStates ballState;
    int state;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        ballManager = levelManager.GetComponent<BallManager>();
        ballState = GetComponent<BallStates>();
        ballRigidbody = GetComponent<Rigidbody>();
        ballCollider = GetComponent<Collider>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the GameObject collides with another GameObject.
    /// </summary>
    /// <param name="other"> A Collider involved in this collision. </param>
    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (state != 1))
        {
            isPlayerInRange = true;
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        }
        else if (other.tag == "Bat")
        {
            playerBatSwing = other.gameObject.GetComponentInChildren<BatSwing>();
        }
        else if ((other.tag == "Enemy") && (state != 2))
        {
            isEnemyInRange = true;
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        }
        else if (other.tag == "Despawner")
        {
            DestroyBall();
        }
        else if (other.tag == "Breakable")
        {
            Destroy(other.gameObject);
            DestroyBall();
        }
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider 'other' has stopped touching the trigger.
    /// </summary>
    /// <param name="other"> A Collider involved in this collision. </param>
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = false;
        }
        else if (other.tag == "Enemy")
        {
            isEnemyInRange = false;
        }
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        state = ballState.GetState();
        if (isPlayerInRange)
        {
            DamagePlayer();
        }
        if (isEnemyInRange)
        {
            DamageEnemy();
        }
    }

    /// <summary>
    /// Damage the player.
    /// </summary>
    void DamagePlayer()
    {
        if (playerHealth.currentHealth > 0)
        { 
            if (playerBatSwing != null)
            {
                playerBatSwing.RemoveBall(ballRigidbody);
            }
            playerHealth.TakeDamage(attackDamage);
            DestroyBall();
        }
    }

    /// <summary>
    /// Damage the enemy.
    /// </summary>
    void DamageEnemy()
    {
        if (enemyHealth.currentHealth > 0)
        {
            enemyHealth.TakeDamage(attackDamage);
            DestroyBall();
        }
    }

    /// <summary>
    /// Removes this ball from the manager, then selfdestructs.
    /// </summary>
    void DestroyBall()
    {
        ballManager.RemoveBall(ballRigidbody);
        Destroy(this.gameObject);
    }

    /*
    The functions Awake(), OnTriggerEnter(Collider other), OnTriggerExit(Collider other) and Update() are modified from the function of the same name from the source below.
    The functions DamagePlayer() and DamageEnemy() are modified from the function Attack() from the source below.
 
    Title : Tutorials: Survival Shooter tutorial: Player Health
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/survival-shooter/player-health?playlist=17144
     */
}
