using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class moves the camera so that it follows 
/// the player.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    // Public variables
    public Transform target;
    public float smoothing = 5f;

    // Private variables
    Vector3 offset;

    // Start is called before the first frame update
    void Start() {
        offset = transform.position - target.position;
    }

    // Update is called once per fixed frame-rate frame
    void FixedUpdate() {
        Vector3 targetCameraPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCameraPosition, smoothing*Time.deltaTime);
    }
    /*
    The functions Start() and FixedUpdate() are copied from functions of the same name from the source below.
 
    Title : Tutorials: Survival Shooter tutorial: Camera setup
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/survival-shooter/camera-setup?playlist=17144
     */
}
