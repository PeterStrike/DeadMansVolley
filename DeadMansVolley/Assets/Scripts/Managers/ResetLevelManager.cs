using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is used to restart the current 
/// level. The time scale is reset to make 
/// sure that the level resets properly.
/// </summary>
public class ResetLevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 1;
    }

    // Reloads the current level
    public void Reset() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
