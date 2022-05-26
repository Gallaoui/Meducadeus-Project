using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuAction : MonoBehaviour
{
    [SerializeField] private GameObject Parent;  
    public void OpenMenu()
    {
        UISystem._background.style.display = DisplayStyle.Flex;
        Parent.SetActive(false);
    }
}
