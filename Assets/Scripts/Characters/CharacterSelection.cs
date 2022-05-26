using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject Student;
    [SerializeField] private GameObject Nurse;

    private int Player;

    private void Start()
    {
        Player = CharacterChanging.actor;

        if(Player < 0)
        {
            Student.SetActive(true);
            Nurse.SetActive(false);
        }
        if(Player > 0)
        {
            Student.SetActive(false);
            Nurse.SetActive(true);
        }
    }
}
