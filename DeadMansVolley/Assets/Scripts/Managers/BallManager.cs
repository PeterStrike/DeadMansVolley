using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls how many balls are in the scene at any one time.
/// </summary>
public class BallManager : MonoBehaviour
{
    //Public variables
    public Rigidbody ballObject;
    public int maxNumberOfBalls = 25;

    //Private variables
    List<Rigidbody> ballInstances;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        ballInstances = new List<Rigidbody>();
    }

    /// <summary>
    ///  Get the current number of balls in the scene.
    /// </summary>
    /// <returns> The number of balls as a integer. </returns>
    public int GetCurrentNumberOfBalls()
    {
        return ballInstances.Count;
    }

    /// <summary>
    /// Create a new ball with the given position and rotation
    /// </summary>
    /// <param name="position"> The location the new ball should spawned in. </param>
    /// <param name="rotation"> The starting rotation of the new ball. </param>
    /// <returns> An instant of the new ball. </returns>
    public Rigidbody CreateNewBall(Vector3 position, Quaternion rotation)
    {
        Rigidbody newBallInstance = Instantiate(ballObject, position, rotation) as Rigidbody;
        ballInstances.Add(newBallInstance);
        return newBallInstance;
    }

    /// <summary>
    /// Remove the given ball from the list.
    /// </summary>
    /// <param name="ball"> The ball that is to be removed. </param>
    public void RemoveBall(Rigidbody ball)
    {
        if (ballInstances.Contains(ball))
        {
            ballInstances.Remove(ball);
        }
    }
}
