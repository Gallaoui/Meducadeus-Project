using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanging : MonoBehaviour
{
    private bool changed = true;
    public static int actor = 1;
    [SerializeField] private GameObject Student;
    [SerializeField] private GameObject Nurse;

    public void Change()
    {
            Student.SetActive(changed);
            Nurse.SetActive(!changed);

            actor *= -1;
            changed = !changed;
            print(actor);
    }
}
