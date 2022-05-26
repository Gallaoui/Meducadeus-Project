using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsLeave : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject EnteringCube;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Leave", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Leave", false);
        }
        StartCoroutine(SwitchOff());
    }

    IEnumerator SwitchOff()
    {
        EnteringCube.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
