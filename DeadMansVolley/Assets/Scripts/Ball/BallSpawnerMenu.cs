using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class spawns a ball. It is used to control the ball spawners in the main menu.
/// </summary>
public class BallSpawnerMenu : MonoBehaviour
{
    // Public variables
    public Transform fireTransform;
    public float ballSpeed;

    // Private variables
    GameObject levelManager;
    BallManager ballManager;
    int maxNumberOfBalls = 0;
    int currentNumberOfBalls;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        ballManager = levelManager.GetComponent<BallManager>();
        maxNumberOfBalls = ballManager.maxNumberOfBalls;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        currentNumberOfBalls = ballManager.GetCurrentNumberOfBalls();
    }

    /// <summary>
    /// Creates an instance of a ball object and gives it an initial velocity
    /// </summary>
    public void CreateBall()
    {
        if (currentNumberOfBalls < maxNumberOfBalls)
        {
            Rigidbody newBallInstance = ballManager.CreateNewBall(fireTransform.position, fireTransform.rotation);
            newBallInstance.velocity = ballSpeed * fireTransform.forward;
        }
    }

    /*
    The function ApplyNewVelocity() is modified from the function Fire() from the source below.
 
    Title : Tutorials: Tanks tutorial: Firing Shells
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/tanks-tutorial/firing-shells?playlist=20081
     */
}
