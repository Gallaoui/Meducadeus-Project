using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsEnter : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject LeavingCube;


    private void OnTriggerEnter(Collider other)
    {  
         if (other.CompareTag("Player"))
         {
             animator.SetBool("Enter", true);
         }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Enter", false);
        }
        StartCoroutine( SwitchOff());
    }

    IEnumerator SwitchOff()
    {
        LeavingCube.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
