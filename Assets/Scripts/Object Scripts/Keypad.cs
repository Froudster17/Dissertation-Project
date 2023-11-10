using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private string currentPasword;
    [SerializeField] private string input;
    [SerializeField] private Text displayText;

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
                Debug.Log("Correct password");
            }
            else
            {
                input = "";
                displayText.text = input.ToString();
                btnClicked = 0;
            }
        }
    }

    public void ValueEntered(string valueEntered)
    {
        btnClicked++;
        input += valueEntered;
        displayText.text = input.ToString();
    }
}
