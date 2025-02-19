using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEvent : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("IsTouch", true);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("IsTouch", false);
    }
}
