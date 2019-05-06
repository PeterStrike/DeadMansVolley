using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is used to display the players 
/// current score in the survival levels.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    // Public variables
    public static int score;

    // Private variables
    Text text;

    // Start is called before the first frame update
    void Awake() {
        text = GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update() {
        text.text = "Score: " + score;
    }
    /*
    The functions Awake() and Update() are copied from functions of the same name from the source below.

    Title : Tutorials: Survival Shooter tutorial: Scoring points
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/survival-shooter-tutorial/scoring-points?playlist=17144
     */
}
