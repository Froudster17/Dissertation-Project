using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject objectNeeded;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private BoxCollider2D boxCollider2D2;
    [SerializeField] private Animator animator;
    [SerializeField] private TextDisplay textDisplay;
    [SerializeField] private GameObject interactionDisplay;
    private bool playerHere;


    private void Update()
    {
        if (playerHere == true && Input.GetKeyDown(KeyCode.E) && objectNeeded.active)
        {
            Debug.Log("Door open");
            //textDisplay.enabled = !textDisplay.enabled;
            boxCollider2D.enabled = !boxCollider2D.enabled;
            boxCollider2D2.enabled = !boxCollider2D2.enabled;
            interactionDisplay.active = !interactionDisplay.active;
            animator.SetTrigger("OpenDoor");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerHere = false;
    }
}
