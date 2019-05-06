using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handled the amount of health the enemy has and the visual display of that health.
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    //Public variables
    public int startingHealth = 2;
    public int currentHealth;
    public int scoreValue = 10;

    public SkinnedMeshRenderer enemyHealthUnit1;
    public SkinnedMeshRenderer enemyHealthUnit2;
    public SkinnedMeshRenderer enemyHealthUnit3;
    public SkinnedMeshRenderer enemyHealthUnit4;
    public SkinnedMeshRenderer enemyHealthUnit5;
    public SkinnedMeshRenderer enemyBody;
    public SkinnedMeshRenderer enemyBat;

    //Private variables
    GameObject levelManager;
    EnemyManager enemyManager;
    Rigidbody enemyRigidbody;
    bool isDead;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        enemyManager = levelManager.GetComponent<EnemyManager>();
        enemyRigidbody = GetComponent<Rigidbody>();
        currentHealth = startingHealth;
    }

    /// <summary>
    /// Called when colliding with something that should do damage to the enemy.
    /// </summary>
    /// <param name="amount"> The amount of damage the enemy should take. </param>
    public void TakeDamage(int amount)
    {
        if (isDead == true)
        {
            return;
        }
        currentHealth -= amount;
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
        else if (currentHealth <= 1)
        {
            enemyHealthUnit5.enabled = false;
        }
        else if (currentHealth <= 2)
        {
            enemyHealthUnit4.enabled = false;
        }
        else if (currentHealth <= 3)
        {
            enemyHealthUnit3.enabled = false;
        }
        else if (currentHealth <= 4)
        {
            enemyHealthUnit2.enabled = false;
        }
        else if (currentHealth <= 5)
        {
            enemyHealthUnit1.enabled = false;
        }
    }

    // Removes the enemy as they are deaded
    /// <summary>
    /// Removes the enemy from the manager, then selfdestructs. Should only be called if the enemys health reaches 0.
    /// </summary>
    void Death()
    {
        isDead = true;
        ScoreManager.score += scoreValue;
        enemyManager.RemoveEnemy(enemyRigidbody);
        Destroy(this.gameObject);
    }

    /*
    The functions Awake(), TakeDamage(int amount) and Death() are modified from functions of the same name from the source below.
 
    Title : Tutorials: Survival Shooter tutorial: Harming Enemies
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/survival-shooter/harming-enemies?playlist=17144
     */
}
