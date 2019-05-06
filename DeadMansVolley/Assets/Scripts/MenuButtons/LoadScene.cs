using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The class is used to load new scenes.
/// </summary>
public class LoadScene : MonoBehaviour
{
    // Private variables
    int sceneIndex;

    /// <summary>
    /// Load a scene based on its index
    /// </summary>
    public void LoadByIndex()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// Set the index for the scene to be loaded
    /// </summary>
    /// <param name="index"> The index of the next scene. </param>
    public void SetSceneIndex(int index)
    {
        sceneIndex = index;
    }

    /*
    The function LoadByIndex() is copied from a function of the same name from the source below.

    Title : Tutorials: User Interface (UI): Creating A Main Menu
    Author : Unity
    Date Accessed : 08/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/topics/user-interface-ui/creating-main-menu
     */
}
