using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHover : MonoBehaviour
{
    private Outline outline;
    private Animator animator;

    private void Start()
    {
        outline = GetComponent<Outline>();
        animator = GetComponent<Animator>();
    }
    private void OnMouseEnter()
    {
        outline.enabled = true;
        animator.SetBool("Focus", true);
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
        animator.SetBool("Focus", false);
    }
}
