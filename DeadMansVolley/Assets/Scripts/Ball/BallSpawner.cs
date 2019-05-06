using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class spawns a ball after X seconds or when the player pressed the space bar.
/// </summary>
public class BallSpawner : MonoBehaviour
{
    // Public variables
    public Transform fireTransform;
    public float ballSpeed;
    public float spawnTimer = 3f;

    // Private variables
    GameObject levelManager;
    BallManager ballManager;
    int maxNumberOfBalls = 0;
    int currentNumberOfBalls;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start() {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        ballManager = levelManager.GetComponent<BallManager>();
        maxNumberOfBalls = ballManager.maxNumberOfBalls;
        InvokeRepeating("CreateBall", spawnTimer, spawnTimer);
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update() {
        currentNumberOfBalls = ballManager.GetCurrentNumberOfBalls();
        if (Input.GetButtonUp("Jump"))
        {
            CreateBall();
        }
    }

    /// <summary>
    /// Creates an instance of a ball object and gives it an initial velocity.
    /// </summary>
    public void CreateBall() {
        if (currentNumberOfBalls < maxNumberOfBalls)
        {
            Rigidbody newBallInstance = ballManager.CreateNewBall(fireTransform.position, fireTransform.rotation);
            newBallInstance.velocity = ballSpeed * fireTransform.forward;
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

    The function ApplyNewVelocity() is modified from the function Fire() from the source below.
 
    Title : Tutorials: Tanks tutorial: Firing Shells
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/tanks-tutorial/firing-shells?playlist=20081
     */
}
