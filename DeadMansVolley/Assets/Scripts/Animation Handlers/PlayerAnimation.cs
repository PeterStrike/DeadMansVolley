using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles all of the animations the players 
/// has by changing the booleans in the animator 
/// and calling the triggers based on player input.
/// </summary>
public class PlayerAnimation : MonoBehaviour
{
    // Private variables
    Animator animator;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        animator.SetBool("IsBatLeft", true);
        animator.SetBool("IsGuard", false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            if (animator.GetBool("IsBatLeft") == true && animator.GetBool("IsGuard") == false)
            {
                animator.SetTrigger("BatToRight");
                animator.SetBool("IsBatLeft", false);
            }
            else if (animator.GetBool("IsBatLeft") == false && animator.GetBool("IsGuard") == false)
            {
                animator.SetTrigger("BatToLeft");
                animator.SetBool("IsBatLeft", true);
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("BatToGuard");
            animator.SetBool("IsGuard", true);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            if (animator.GetBool("IsBatLeft") == true)
            {
                animator.SetTrigger("BatToLeft");
                animator.SetBool("IsGuard", false);
            }
            else if (animator.GetBool("IsBatLeft") == false)
            {
                animator.SetTrigger("BatToRight");
                animator.SetBool("IsGuard", false);
            }
        }
    }
}
