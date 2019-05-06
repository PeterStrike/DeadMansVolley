using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used by the enemy to gauge its distance from the player.
/// </summary>
public class EnemyPlayerDetector : MonoBehaviour
{
    //Private variables
    bool isPlayerInRange;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        isPlayerInRange = false;
    }

    /// <summary>
    /// OnTriggerEnter is called when the GameObject collides with another GameObject.
    /// </summary>
    /// <param name="other"> A Collider involved in this collision. </param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerMovement")
        {
            isPlayerInRange = true;
        }
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider 'other' has stopped touching the trigger.
    /// </summary>
    /// <param name="other"> A Collider involved in this collision. </param>
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerMovement")
        {
            isPlayerInRange = false;
        }
    }

    /// <summary>
    /// Gets if the player is in contact with this collider.
    /// </summary>
    /// <returns> A Boolean that says if the player is in range. </returns>
    public bool getPlayerRange()
    {
        return isPlayerInRange;
    }
}
