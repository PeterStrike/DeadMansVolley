using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handled the amount of health the player has and the visual display of that health.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    // Public variables
    public int startingHealth = 4;
    public int currentHealth;

    public SkinnedMeshRenderer playerHealthUnit1;
    public SkinnedMeshRenderer playerHealthUnit2;
    public SkinnedMeshRenderer playerHealthUnit3;
    public SkinnedMeshRenderer playerBody;
    public SkinnedMeshRenderer playerBat;

    // Private variables
    PlayerMovement playerMovement;
    Collider[] playerCollider;
    BatSwing batSwing;
    BatGuard batGuard;
    bool isDead;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement> ();
        playerCollider = GetComponents<Collider> ();
        batSwing = GetComponentInChildren<BatSwing>();
        batGuard = GetComponentInChildren<BatGuard>();
        currentHealth = startingHealth;
    }

    /// <summary>
    /// Called when colliding with something that should do damage to the player.
    /// </summary>
    /// <param name="amount"> The amount of damage the player should take. </param>
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        //batSwing.ClearBalls();    This was used as a short term solution to an issue with ball instances not being removed from the bat swing.
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
        else if (currentHealth <= 1)
        {
            playerHealthUnit3.enabled = false;
        }
        else if (currentHealth <= 2)
        {
            playerHealthUnit2.enabled = false;
        }
        else if (currentHealth <= 3)
        {
            playerHealthUnit1.enabled = false;
        }
    }

    /// <summary>
    /// Called when colliding with something that should heal the player.
    /// </summary>
    /// <param name="amount"> The amount of health that should be healed. </param>
    public void RestoreHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth >= 3)
        {
            playerHealthUnit1.enabled = true;
        }
        else if (currentHealth >= 2)
        {
            playerHealthUnit2.enabled = true;
        }
        else if (currentHealth >= 1)
        {
            playerHealthUnit3.enabled = true;

        }
    }

    /// <summary>
    /// Disables all player functions and visability. Should only be called if the players health reaches 0.
    /// </summary>
    void Death()
    {
        isDead = true;
        playerBody.enabled = false;
        playerBat.enabled = false;
        foreach (Collider collider in playerCollider)
        {
            collider.enabled = false;
        }
        gameObject.tag = "Untagged";
        playerMovement.enabled = false;
        batSwing.enabled = false;
        batGuard.enabled = false;
        //Time.timeScale = 0;   Disabled so that the manager can handle the game over effects insted
    }

    /*
    The functions Awake(), TakeDamage(int amount) and Death() are modified from functions of the same name from the source below.
 
    Title : Tutorials: Survival Shooter tutorial: Player Health
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/survival-shooter/player-health?playlist=17144
     */
}
