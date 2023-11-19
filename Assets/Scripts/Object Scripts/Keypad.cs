using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public string currentPasword;
    [SerializeField] private string input;
    [SerializeField] private Text displayText;
    public GameObject objectToShowKeypad;

    private float btnClicked = 0;
    private float numOfGuesses;

    private void Start()
    {
        btnClicked = 0;
        numOfGuesses = currentPasword.Length;
    }

    private void Update()
    {
        if (btnClicked == numOfGuesses)
        {
            if (input == currentPasword)
            {
                btnClicked = 0;
                input = "";
                displayText.text = input.ToString();
                Debug.Log("Correct password");
                FindObjectOfType<AudioManager>().Play("Start");
                objectToShowKeypad.SetActive(true);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Declined");
                input = "";
                displayText.text = input.ToString();
                btnClicked = 0;
            }
        }
    }

    public void ValueEntered(string valueEntered)
    {
        FindObjectOfType<AudioManager>().Play("Click");
        btnClicked++;
        input += valueEntered;
        displayText.text = input.ToString();
    }
}
