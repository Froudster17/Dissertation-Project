using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private Animator[] animator;
    [SerializeField] private Text text;
    [SerializeField] private string displayText;
    private bool textShown;
    private bool playerHere;

    private void Update()
    {
        if (playerHere == true && Input.GetKeyDown(KeyCode.E) && textShown == false)
        {
            foreach (Animator animator in animator)
            {
                animator.SetTrigger("Show");
            }
            text.text = displayText;
            textShown = true;
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
        foreach (Animator animator in animator)
        {
            animator.SetTrigger("Hide");
        }
        playerHere = false;
        textShown = false;
    }
}
