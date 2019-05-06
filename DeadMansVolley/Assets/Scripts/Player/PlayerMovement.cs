using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handled the players movment and rotation 
/// based on input from both teh mouse and keyboard.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    // Public variables
    public float normalSpeed = 6f;
    public float guardSpeed = 3f;

    // Private variables
    float currentSpeed;
	Vector3 movement;
	Rigidbody playerRigidbody;
    Animator animator;
    int floorMask;
	float cameraRayLength = 100f;

    // Awake is called when the script instance is being loaded
	void Awake() {
		floorMask = LayerMask.GetMask("Floor");
		playerRigidbody = GetComponent <Rigidbody> ();
        animator = GetComponent<Animator>();
        currentSpeed = normalSpeed;
    }

    // Update is called once per fixed frame-rate frame
    void FixedUpdate() {
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");
        SetCurrentSpeed();
        Move(horizontal, vertical);
		Turn();
	}

    // Move based on inupt from the keyboard
	void Move(float h, float v) {
		movement.Set (h, 0f, v);
		movement = movement.normalized * currentSpeed * Time.deltaTime;
		playerRigidbody.MovePosition(transform.position + movement);
	}

    // Point the player to face where the mouse is
	void Turn() {
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if(Physics.Raycast (camRay, out floorHit, cameraRayLength, floorMask))
        {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidbody.MoveRotation (newRotation);
		}
	}

    // Change the players movement speed based on if they are guarding or not.
    void SetCurrentSpeed() {
        if (animator.GetBool("IsGuard") == true)
        {
            currentSpeed = guardSpeed;
        }
        else
        {
            currentSpeed = normalSpeed;
        }
    }
    /*
    The functions Awake() and FixedUpdate() are modified from functions of the same name from the source below.
    The functions Move(float h, float v) and Turn() are copied from functions of the same name from the source below.

    Title : Tutorials: Survival Shooter tutorial: Player Character
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/survival-shooter/player-character?playlist=17144
     */
}
