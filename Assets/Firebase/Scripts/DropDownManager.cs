using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropDownManager : MonoBehaviour
{

    [SerializeField] private TMPro.TMP_Dropdown dropdown;
    [SerializeField] private Login_Register_Home lrh;
    [SerializeField] private HandlesData hd;


    public void Update()
    {
     dropdown.options[0].text = FirebaseConnection.instance.getUsername();   
    }
    public void DropdownValue(int value)
    {
        if(value == 1)
        {
            SceneManager.LoadScene(1);
        }
        if(value == 2)
        {
            lrh.LogoutRedirection();
        }
    }
}
