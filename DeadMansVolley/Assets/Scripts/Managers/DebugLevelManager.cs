using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// This class is for debuging only. 
/// It is used to reset the scene by pressing r.
/// </summary>
public class DebugLevelManager : MonoBehaviour
{
    // Private variables
    GameObject levelText;
    bool textVisable;

    // Start is called before the first frame update
    void Start() {
        levelText = GameObject.FindGameObjectWithTag("Text");
        textVisable = true;
    }
    
    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Reset"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetButton("Fire1") && textVisable == true)
        {
            Destroy(levelText);
            textVisable = false;
        }
    }
}
