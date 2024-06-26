using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private Animator[] animator;
    [SerializeField] private Text text;
    [SerializeField] private string displayText;
    [SerializeField] private string currentPassword;
    [SerializeField] private GameObject objectToShow;
    private bool textShown;
    public bool playerHere;

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
            FindObjectOfType<Keypad>().currentPasword = currentPassword;

            if (objectToShow == null)
            {
                return;
            } 
            else
            {
                FindObjectOfType<Keypad>().objectToShowKeypad = this.objectToShow;
            }
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
        if (collision.gameObject.tag == "Player")
        {
            foreach (Animator animator in animator)
            {
                animator.SetTrigger("Hide");
            }
            playerHere = false;
            textShown = false;
        }
    }
}
