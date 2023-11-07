using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Animator animator;

    private Vector2 movement;
    private Vector2 lastMovement; // Store the last non-zero movement

    public void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Movement", movement.sqrMagnitude);

        if (movement != Vector2.zero)
        {
            lastMovement = movement; // Update the last non-zero movement
            OnAnimatorMove();
        }


    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnAnimatorMove()
    {
        // Update the idle blend tree parameters with the last non-zero movement
        animator.SetFloat("LastHorizontal", lastMovement.x);
        animator.SetFloat("LastVertical", lastMovement.y);
        animator.SetFloat("Movement", movement.sqrMagnitude);
    }
}
