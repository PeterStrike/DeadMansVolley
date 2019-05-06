using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is to change the balls colour and propertys after hitting or being hit by something.
/// </summary>
public class BallStates : MonoBehaviour
{
    // Public variables
    public Material neutralState;
    public Material enemyState;
    public Material playerState;

    // Private variables
    int state = 0; 
    Renderer render;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        render = GetComponentInChildren<Renderer>();
        render.enabled = true;
    }

    /// <summary>
    /// OnTriggerEnter is called when the GameObject collides with another GameObject.
    /// </summary>
    /// <param name="other"> A Collider involved in this collision. </param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            ChangeBallState(0);
        }
    }

    /// <summary>
    /// Gets the current state of the ball.
    /// </summary>
    /// <returns> The current state of the ball as an integer. </returns>
    public int GetState()
    {
        return state;
    }

    /// <summary>
    /// Sets the state of the ball.
    /// </summary>
    /// <param name="newState"> The new state of the ball as an integer. </param>
    public void ChangeBallState(int newState)
    {
        state = newState;
        if (newState == 1)
        {
            render.sharedMaterial = playerState;
        }
        else if (newState == 2)
        {
            render.sharedMaterial = enemyState;
        }
        else if (newState == 0)
        {
            render.sharedMaterial = neutralState;
        }
    }
}
