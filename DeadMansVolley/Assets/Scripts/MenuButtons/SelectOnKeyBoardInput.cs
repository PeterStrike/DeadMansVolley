using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnKeyBoardInput : MonoBehaviour
{
    // Public variables
    public EventSystem eventSystem;
    public GameObject selectedGameObject;

    // Private variables
    bool isButtonSelected;

    // Update is called once per frame
    void Update() {
        if ((Input.GetAxisRaw("Vertical") != 0) && (isButtonSelected == false))
        {
            eventSystem.SetSelectedGameObject(selectedGameObject);
            isButtonSelected = true;
        }
    }

    // When an object that this behavior is attached to is disabled, the button isn't selected
    void OnDisable() {
        isButtonSelected = false;
    }
    /*
    The functions Update() and OnDisable() are copied from functiona of the same name from the source below.

    Title : Tutorials: User Interface (UI): Creating A Main Menu
    Author : Unity
    Date Accessed : 08/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/topics/user-interface-ui/creating-main-menu
     */
}
