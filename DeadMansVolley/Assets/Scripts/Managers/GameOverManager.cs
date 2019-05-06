using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to control the gameover state.
/// </summary>
public class GameOverManager : MonoBehaviour
{
    // Public variables
    public GameObject gameOverMenu;
    public GameObject gameOverText;
    public float gameOverSlowDownRate = 3f;
    public Animator gameOverMenuAnimator;

    // Private variables
    GameObject player;
    PlayerHealth playerHealth;
    Animator animator;
    float gameOverSlowDownTimer;
    float gameOverSlowDownTimerEnd;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
        gameOverSlowDownTimerEnd = gameOverSlowDownRate;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        GameOver();
    }

    /// <summary>
    /// Animate the gameover message and make the game over menu active
    /// </summary>
    void GameOver()
    {
        if (playerHealth.currentHealth <= 0)
        {
            gameOverText.SetActive(true);
            animator.SetTrigger("GameOver");
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);

            if (gameOverSlowDownTimerEnd == gameOverSlowDownRate) {
                gameOverSlowDownTimerEnd += Time.unscaledTime;
            }
            gameOverSlowDownTimer = Time.unscaledTime;
            if (gameOverSlowDownTimerEnd <= gameOverSlowDownTimer)
            {
                gameOverMenuAnimator.SetTrigger("GameOver");
            }
        }
    }

    /*
    The functions Awake() and Update() are modified from functions of the same name from the source below.

    Title : Tutorials: Survival Shooter tutorial: Game Over
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/survival-shooter/game-over?playlist=17144
     */
}



