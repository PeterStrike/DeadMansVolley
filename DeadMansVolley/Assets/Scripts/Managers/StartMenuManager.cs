using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to setup the start menu.
/// </summary>
public class StartMenuManager : MonoBehaviour
{
    // Public variables
    public GameObject start;
    public GameObject mainMenu;

    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update() {
        if ((Input.anyKey) && (mainMenu.activeSelf == false) && (start.activeSelf == true))
        {
            start.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
