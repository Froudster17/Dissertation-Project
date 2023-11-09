using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackstoryDisplay : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator.SetTrigger("Show");
    }

    public void HideDisplay()
    {
        animator.SetTrigger("Hide");
    }
}
