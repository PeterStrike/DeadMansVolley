using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to manipulate the collider infront 
/// of the player to prevent taking damage from collisions 
/// in the form of a 'Guard'.
/// </summary>
public class BatGuard : MonoBehaviour
{
    // Private variables
    Collider guardCollider;
    Animator animator;
    bool guardState;

    // Start is called before the first frame update
    void Start() {
        guardCollider = GetComponent<Collider>();
        animator = GetComponentInParent<Animator>();
        guardCollider.enabled = false;
        guardState = false;
    }

    // Update is called once per frame
    void Update() {
        if (animator.GetBool("IsGuard") != guardState)
        {
            guardCollider.enabled = !guardCollider.enabled;
            guardState = animator.GetBool("IsGuard");
        }
    }
}
