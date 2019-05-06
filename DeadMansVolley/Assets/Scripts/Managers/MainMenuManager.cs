using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to manage the ball spawners 
/// in the main menu. They are used to make the menu 
/// look more animated.
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    // Private variables
    GameObject player;
    PlayerMovement playerMovement;
    GameObject[] ballSpawnPoints;
    BallSpawnerMenu currentBallSpawner;
    float Timer;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.enabled = false;
        ballSpawnPoints = GameObject.FindGameObjectsWithTag("Spawner");
        SetRandomTimer();
    }

    // Update is called once per frame
    void Update() {
        if (Timer < Time.time) {
            int spawnPointIndex = Random.Range(0, ballSpawnPoints.Length);
            currentBallSpawner = ballSpawnPoints[spawnPointIndex].GetComponent<BallSpawnerMenu>();
            currentBallSpawner.CreateBall();
            SetRandomTimer();
        }
    }

    // Sets a random time for the timer
    void SetRandomTimer() {
        Timer = Time.time + Random.Range(1,3);
    }
    /*
    The functions Update() is loosly based on the functions Spawn() from source #1 and Fire() from source #2.

    #1
    Title : Survival Shooter tutorial: Spawning Enemies
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/survival-shooter/more-enemies?playlist=17144
 
    #2
    Title : Tutorials: Tanks tutorial: Firing Shells
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/tanks-tutorial/firing-shells?playlist=20081
     */
}
