using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to handle shuting down the game.
/// </summary>
public class EndGame : MonoBehaviour
{
    // If the game is running in the Unity editor, stop it. Otherwise quit the application.
    public void Quit() {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
		Application.Quit();
    #endif
    }
    /*
    The function Quit() is copied from a function of the same name from the source below.

    Title : Tutorials: User Interface (UI): Creating A Main Menu
    Author : Unity
    Date Accessed : 08/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/topics/user-interface-ui/creating-main-menu
     */
}
