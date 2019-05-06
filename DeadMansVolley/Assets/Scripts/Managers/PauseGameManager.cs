using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used control the pause menu.
/// </summary>
public class PauseGameManager : MonoBehaviour
{
    // Public variables
    public static bool isGamePaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Pause"))
        {
            if (isGamePaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Halt all action in the game and enable the pause menu
    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    // Disable the pause menu and resume the action
    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }
    /*
    The functions Update() ,Pause() and Resume() are copied from functions of the same name from the source below.

    Title : PAUSE MENU in Unity
    Author : Brackeys
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://www.youtube.com/watch?v=JivuXdrIHK0
     */
}
