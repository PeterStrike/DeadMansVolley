using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to apply a velocity to all objects identified as 'ball' in the 'bat swing area'. This is done when the player clicks the left mouse button.
/// </summary>
public class BatSwing : MonoBehaviour
{
    // Public variables
    public float newballSpeed;
    public Transform BatArea;

    // Private variables
    Animator animator;
    List<Rigidbody> ballColliders = new List<Rigidbody>();

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    /// <summary>
    /// Update is called every frame.
    /// </summary>
    void Update()
    {
        ApplyNewVelocity();
    }

    /// <summary>
    /// OnTriggerEnter is called when the GameObject collides with another GameObject.
    /// </summary>
    /// <param name="other"> A Collider involved in this collision. </param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Rigidbody ballInstance = other.gameObject.GetComponent<Rigidbody>();
            if (!ballColliders.Contains(ballInstance))
            {
                ballColliders.Add(other.gameObject.GetComponent<Rigidbody>());
                //Debug.Log("This Ball is added to the list");
            }
            else
            {
                //Debug.Log("This Ball is already in the list");
            }
        }
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider 'other' has stopped touching the trigger.
    /// </summary>
    /// <param name="other"> A Collider involved in this collision. </param>
    void OnTriggerExit(Collider other)
    {
        RemoveBall(other.gameObject.GetComponent<Rigidbody>());
    }

    /// <summary>
    /// Remove a single ball from the list.
    /// </summary>
    /// <param name="ball"> The Rigidbody of the GamObject to be removed from the list. </param>
    public void RemoveBall(Rigidbody ball)
    {
        if (ballColliders.Contains(ball))
        {
            //Debug.Log("This Ball is in the list");
            ballColliders.Remove(ball);
            if (!ballColliders.Contains(ball))
            {
                //Debug.Log("Ball was removed"); 
            }
            else
            {
               //Debug.Log("Ball was not removed");
            }
        }
        else
        {
            //Debug.Log("This Ball is not in the list");
        }
    }

    /// <summary>
    /// Clears the list of GameObjects.
    /// </summary>
    public void ClearBalls()
    {
        ballColliders.Clear();
    }
    
    /// <summary>
    /// Calculate and apply a new velocity to all balls in the bat swing area + change the state to not hurt the player.
    /// </summary>
    private void ApplyNewVelocity()
    {
        if (Input.GetButtonDown("Fire1") && !animator.GetBool("IsGuard"))
        {
            foreach (Rigidbody ballInstance in ballColliders)
            {
                    ballInstance.velocity = newballSpeed * BatArea.forward;
                    BallStates ballStateInstance = ballInstance.gameObject.GetComponent<BallStates>();
                    ballStateInstance.ChangeBallState(1);
            }
        }
    }

    /*
    The function ApplyNewVelocity() is loosly based on the function Fire() from the source below.
 
    Title : Tutorials: Tanks tutorial: Firing Shells
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/tanks-tutorial/firing-shells?playlist=20081
     */
}
