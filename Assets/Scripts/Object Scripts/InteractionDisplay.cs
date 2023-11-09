using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDisplay : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Show");
        FindObjectOfType<AudioManager>().Play("Interaction");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetTrigger("Hide");
    }
}
